using OneBus.Application.DTOs.StopTime;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class StopTimeController : BaseController<StopTime, CreateStopTimeDTO, ReadStopTimeDTO, UpdateStopTimeDTO, BaseFilter>
    {
        public StopTimeController(
            IBaseService<StopTime, CreateStopTimeDTO, ReadStopTimeDTO, UpdateStopTimeDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
