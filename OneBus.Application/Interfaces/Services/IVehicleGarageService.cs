using OneBus.Application.DTOs.VehicleGarage;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IVehicleGarageService : 
        IBaseService<VehicleGarage, CreateVehicleGarageDTO, ReadVehicleGarageDTO, UpdateVehicleGarageDTO, BaseFilter>
    {
    }
}
