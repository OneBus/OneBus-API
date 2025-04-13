using OneBus.Application.DTOs.Maintenance;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class MaintenanceController : BaseController<Maintenance, CreateMaintenanceDTO, ReadMaintenanceDTO, UpdateMaintenanceDTO, BaseFilter>
    {
        public MaintenanceController(
            IBaseService<Maintenance, CreateMaintenanceDTO, ReadMaintenanceDTO, UpdateMaintenanceDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
