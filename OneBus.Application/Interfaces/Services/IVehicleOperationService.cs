using OneBus.Application.DTOs.VehicleOperation;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IVehicleOperationService : 
        IBaseService<VehicleOperation, CreateVehicleOperationDTO, ReadVehicleOperationDTO, UpdateVehicleOperationDTO, VehicleOperationFilter>
    {
    }
}
