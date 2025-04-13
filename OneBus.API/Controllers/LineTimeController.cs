using OneBus.Application.DTOs.LineTime;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class LineTimeController : BaseController<LineTime, CreateLineTimeDTO, ReadLineTimeDTO, UpdateLineTimeDTO, BaseFilter>
    {
        public LineTimeController(
            IBaseService<LineTime, CreateLineTimeDTO, ReadLineTimeDTO, UpdateLineTimeDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
