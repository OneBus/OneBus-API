using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OneBus.Application.DTOs.VehicleOperation;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums.Employee;
using OneBus.Domain.Enums.Vehicle;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Workers
{
    public class VehicleOperationWorker : BackgroundService
    {
        private readonly SemaphoreSlim _semaphoreSlim;
        private readonly IServiceProvider _serviceProvider;

        const int Interval = 5;

        public VehicleOperationWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _semaphoreSlim = new(initialCount: 1, maxCount: 1);
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timeSpan = TimeSpan.FromMinutes(Interval);
            using var timer = new PeriodicTimer(timeSpan);

            do
            {
                if (!await _semaphoreSlim.WaitAsync(millisecondsTimeout: 0, stoppingToken))
                {
                    continue;
                }

                try
                {
                    await DoWorkAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    _semaphoreSlim.Release();
                }

            } while (await timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested);
        }

        private async Task DoWorkAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var vehicleOperationService = scope.ServiceProvider.GetRequiredService<IVehicleOperationService>();

            var vehicleOperationsPagination = await vehicleOperationService.GetPaginedAsync(
                new Domain.Filters.VehicleOperationFilter { PageSize = int.MaxValue },
                DbQueryOptions.Create(["Vehicle", "LineTime.Line", "EmployeeWorkday.Employee"]),
                cancellationToken);

            if (!vehicleOperationsPagination.Sucess || !vehicleOperationsPagination.Value!.Items.Any())
                return;

            var vehiclesOperations = vehicleOperationsPagination.Value.Items;

            await UpdateVehicleStatusAsync(vehiclesOperations, cancellationToken);
        }

        private async Task UpdateVehicleStatusAsync(IEnumerable<ReadVehicleOperationDTO> vehicleOperations, CancellationToken cancellationToken)
        {
            if (vehicleOperations is null || !vehicleOperations.Any())
                return;

            var currentTime = TimeOnly.FromDateTime(DateTime.UtcNow.ToLocalTime());

            await SyncRangeOperationsAsync(vehicleOperations, currentTime, cancellationToken);
            await SyncOutOfRangeOperationsAsync(vehicleOperations, currentTime, cancellationToken);
        }

        private async Task SyncOutOfRangeOperationsAsync(
            IEnumerable<ReadVehicleOperationDTO> vehicleOperations,
            TimeOnly currentTime,
            CancellationToken cancellationToken)
        {
            if (vehicleOperations is null || !vehicleOperations.Any())
                return;

            var rangeOperations = vehicleOperations.Where(c => IsNotOperational(c, currentTime));

            if (!rangeOperations.Any())
                return;

            using var scope = _serviceProvider.CreateScope();
            var vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();

            var vehicleIds = rangeOperations.Select(c => c.VehicleId);
            await vehicleRepository.SetStatusAsync(vehicleIds, VehicleStatus.Disponível, cancellationToken);
        }

        private static bool IsNotOperational(ReadVehicleOperationDTO operation, TimeOnly currentTime)
        {
            var baseCondition = ((currentTime < operation.EmployeeWorkdayStartTime || currentTime > TimeOnly.MaxValue) &&
                                  operation.LineTimeTime < currentTime && currentTime < operation.LineTimeTime) ||
                                currentTime > operation.EmployeeWorkdayEndTime || currentTime < TimeOnly.MinValue;

            return (baseCondition || currentTime < operation.LineTimeTime || operation.EmployeeWorkdayEmployeeStatus is not (byte)EmployeeStatus.Ativo) &&
                   operation.VehicleStatus is (byte)VehicleStatus.Em_Operação;
        }

        private async Task SyncRangeOperationsAsync(
            IEnumerable<ReadVehicleOperationDTO> vehicleOperations,
            TimeOnly currentTime,
            CancellationToken cancellationToken)
        {
            if (vehicleOperations is null || !vehicleOperations.Any())
                return;

            var rangeOperations = vehicleOperations.Where(c => IsOperational(c, currentTime));

            if (!rangeOperations.Any())
                return;

            using var scope = _serviceProvider.CreateScope();
            var vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();

            var vehicleIds = rangeOperations.Select(c => c.VehicleId);
            await vehicleRepository.SetStatusAsync(vehicleIds, VehicleStatus.Em_Operação, cancellationToken);
        }

        private static bool IsOperational(ReadVehicleOperationDTO operation, TimeOnly currentTime)
        {
            var baseCondition = (currentTime >= operation.EmployeeWorkdayStartTime && currentTime <= TimeOnly.MaxValue &&
                                 operation.LineTimeTime >= currentTime) ||
                                (currentTime <= operation.EmployeeWorkdayEndTime && currentTime >= TimeOnly.MinValue);

            return baseCondition &&
                   currentTime >= operation.LineTimeTime &&
                   operation.VehicleStatus is (byte)VehicleStatus.Disponível &&
                   operation.EmployeeWorkdayEmployeeStatus is (byte)EmployeeStatus.Ativo;
        }
    }
}
