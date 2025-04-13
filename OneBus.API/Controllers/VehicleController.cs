using OneBus.Application.DTOs.Vehicle;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class VehicleController : BaseController<Vehicle, CreateVehicleDTO, ReadVehicleDTO, UpdateVehicleDTO, BaseFilter>
    {
        public VehicleController(
            IBaseService<Vehicle, CreateVehicleDTO, ReadVehicleDTO, UpdateVehicleDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
