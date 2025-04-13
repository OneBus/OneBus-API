using OneBus.Application.DTOs.VehicleOperation;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class VehicleOperationController : BaseController<VehicleOperation, CreateVehicleOperationDTO, ReadVehicleOperationDTO, UpdateVehicleOperationDTO, BaseFilter>
    {
        public VehicleOperationController(
            IBaseService<VehicleOperation, CreateVehicleOperationDTO, ReadVehicleOperationDTO, UpdateVehicleOperationDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
