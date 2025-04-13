using OneBus.Application.DTOs.VehicleGarage;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class VehicleGarageController : BaseController<VehicleGarage, CreateVehicleGarageDTO, ReadVehicleGarageDTO, UpdateVehicleGarageDTO, BaseFilter>
    {
        public VehicleGarageController(
            IBaseService<VehicleGarage, CreateVehicleGarageDTO, ReadVehicleGarageDTO, UpdateVehicleGarageDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
