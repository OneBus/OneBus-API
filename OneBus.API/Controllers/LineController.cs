using OneBus.Application.DTOs.Line;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class LineController : BaseController<Line, CreateLineDTO, ReadLineDTO, UpdateLineDTO, BaseFilter>
    {
        public LineController(
            IBaseService<Line, CreateLineDTO, ReadLineDTO, UpdateLineDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
