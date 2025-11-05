using OneBus.Application.DTOs.Dashboard;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Enums.Employee;
using OneBus.Domain.Enums.Vehicle;
using OneBus.Domain.Extensions;

namespace OneBus.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IVehicleService _vehicleService;
        private readonly IEmployeeService _employeeService;

        public DashboardService(
            IVehicleService vehicleService,
            IEmployeeService employeeService)
        {
            _vehicleService = vehicleService;
            _employeeService = employeeService;
        }

        public async Task<Result<ReadEmployeeTotalCountDTO>> GetEmployeeStatusAsync(
            CancellationToken cancellationToken = default)
        {
            var employeesPagination = await _employeeService.GetPaginedAsync(
                new Domain.Filters.EmployeeFilter { PageSize = int.MaxValue },
                cancellationToken: cancellationToken);

            if (!employeesPagination.Sucess || !employeesPagination.Value!.Items.Any())
                return SuccessResult<ReadEmployeeTotalCountDTO>.Create(new ReadEmployeeTotalCountDTO([]));

            var employees = employeesPagination.Value.Items;

            var groupByStatus = employees.GroupBy(c => c.Status).ToList();

            List<ReadEmployeeCountDTO> employeeCounts = [];
            foreach (var group in groupByStatus)
            {
                employeeCounts.Add(new ReadEmployeeCountDTO
                {
                    Status = group.Key,
                    StatusName = ((EmployeeStatus)group.Key).ToString().Localize(),
                    Employees = group.Select(c => c)
                });
            }

            var result = new ReadEmployeeTotalCountDTO(employeeCounts);
            return SuccessResult<ReadEmployeeTotalCountDTO>.Create(result);
        }

        public async Task<Result<ReadVehicleTotalCountDTO>> GetVehicleStatusAsync(CancellationToken cancellationToken = default)
        {
            var vehiclesPagination = await _vehicleService.GetPaginedAsync(
                new Domain.Filters.VehicleFilter { PageSize = int.MaxValue },
                cancellationToken: cancellationToken);

            if (!vehiclesPagination.Sucess || !vehiclesPagination.Value!.Items.Any())
                return SuccessResult<ReadVehicleTotalCountDTO>.Create(new ReadVehicleTotalCountDTO([]));

            var vehicles = vehiclesPagination.Value.Items;

            var groupByStatus = vehicles.GroupBy(c => c.Status).ToList();

            List<ReadVehicleCountDTO> vehicleCounts = [];
            foreach (var group in groupByStatus)
            {
                vehicleCounts.Add(new ReadVehicleCountDTO
                {
                    Status = group.Key,
                    StatusName = ((VehicleStatus)group.Key).ToString().Localize(),
                    Vehicles = group.Select(c => c)
                });
            }

            var result = new ReadVehicleTotalCountDTO(vehicleCounts);
            return SuccessResult<ReadVehicleTotalCountDTO>.Create(result);
        }
    }
}
