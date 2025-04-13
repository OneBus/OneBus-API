using OneBus.Application.DTOs.Stop;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class StopController : BaseController<Stop, CreateStopDTO, ReadStopDTO, UpdateStopDTO, BaseFilter>
    {
        public StopController(
            IBaseService<Stop, CreateStopDTO, ReadStopDTO, UpdateStopDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
