using FluentValidation;
using OneBus.Application.DTOs.VehicleOperation;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Enums;
using OneBus.Domain.Enums.Line;
using OneBus.Domain.Enums.Vehicle;
using OneBus.Domain.Extensions;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class VehicleOperationService : BaseService<VehicleOperation, CreateVehicleOperationDTO, ReadVehicleOperationDTO, UpdateVehicleOperationDTO, VehicleOperationFilter>,
        IVehicleOperationService
    {
        public VehicleOperationService(
            IBaseRepository<VehicleOperation, VehicleOperationFilter> baseRepository, 
            IValidator<CreateVehicleOperationDTO> createValidator, 
            IValidator<UpdateVehicleOperationDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        public override async Task<Result<Pagination<ReadVehicleOperationDTO>>> GetPaginedAsync(
            VehicleOperationFilter filter, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetPaginedAsync(filter, dbQueryOptions, cancellationToken);

            if (!result.Sucess)
                return result;

            foreach (var vehicleOperation in result.Value!.Items)
            {
                vehicleOperation.VehicleTypeName = ((VehicleType?)vehicleOperation.VehicleType)?.ToString()?.Localize();
                vehicleOperation.LineTimeDayTypeName = ((DayType?)vehicleOperation.LineTimeDayType)?.ToString()?.Localize();                
                vehicleOperation.VehicleStatusName = ((VehicleStatus?)vehicleOperation.VehicleStatus)?.ToString()?.Localize();
                vehicleOperation.LineTimeLineTypeName = ((LineType?)vehicleOperation.LineTimeLineType)?.ToString()?.Localize();
                vehicleOperation.LineTimeDirectionTypeName = ((DirectionType?)vehicleOperation.LineTimeDirectionType)?.ToString()?.Localize();
                vehicleOperation.EmployeeWorkdayDayTypeName = ((DayType?)vehicleOperation.EmployeeWorkdayDayType)?.ToString()?.Localize();
                vehicleOperation.LineTimeLineDirectionTypeName = ((DirectionType?)vehicleOperation.LineTimeLineDirectionType)?.ToString()?.Localize();
            }

            return result;
        }

        public override async Task<Result<ReadVehicleOperationDTO>> GetByIdAsync(
            long id, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetByIdAsync(id, dbQueryOptions, cancellationToken);

            if (!result.Sucess)
                return result;

            var vehicleOperation = result.Value!;
            vehicleOperation.VehicleTypeName = ((VehicleType?)vehicleOperation.VehicleType)?.ToString()?.Localize();
            vehicleOperation.LineTimeDayTypeName = ((DayType?)vehicleOperation.LineTimeDayType)?.ToString()?.Localize();
            vehicleOperation.VehicleStatusName = ((VehicleStatus?)vehicleOperation.VehicleStatus)?.ToString()?.Localize();
            vehicleOperation.LineTimeLineTypeName = ((LineType?)vehicleOperation.LineTimeLineType)?.ToString()?.Localize();
            vehicleOperation.LineTimeDirectionTypeName = ((DirectionType?)vehicleOperation.LineTimeDirectionType)?.ToString()?.Localize();
            vehicleOperation.EmployeeWorkdayDayTypeName = ((DayType?)vehicleOperation.EmployeeWorkdayDayType)?.ToString()?.Localize();
            vehicleOperation.LineTimeLineDirectionTypeName = ((DirectionType?)vehicleOperation.LineTimeLineDirectionType)?.ToString()?.Localize();

            return result;
        }

        protected override void UpdateFields(VehicleOperation entity, UpdateVehicleOperationDTO updateDTO)
        {
            entity.VehicleId = updateDTO.VehicleId;
            entity.LineTimeId = updateDTO.LineTimeId;
            entity.EmployeeWorkdayId = updateDTO.EmployeeWorkdayId;
        }
    }
}
