using OneBus.Application.DTOs.Vehicle;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IVehicleService :
        IBaseService<Vehicle, CreateVehicleDTO, ReadVehicleDTO, UpdateVehicleDTO, BaseFilter>
    {
        Result<IEnumerable<ReadBrandDTO>> GetBrands();

        Result<IEnumerable<ReadBusChassisBrandDTO>> GetBusChassisBrands();
        
        Result<IEnumerable<ReadBusServiceTypeDTO>> GetBusServiceTypes();
        
        Result<IEnumerable<ReadColorDTO>> GetColors();
        
        Result<IEnumerable<ReadFuelTypeDTO>> GetFuelTypes();
        
        Result<IEnumerable<ReadVehicleStatusDTO>> GetStatus();
        
        Result<IEnumerable<ReadTransmissionTypeDTO>> GetTransmissionTypes();
        
        Result<IEnumerable<ReadTypeDTO>> GetVehicleTypes();
    }
}
