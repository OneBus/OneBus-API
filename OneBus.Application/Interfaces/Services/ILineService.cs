using OneBus.Application.DTOs.Line;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface ILineService :
        IBaseService<Line, CreateLineDTO, ReadLineDTO, UpdateLineDTO, LineFilter>
    {
        Result<IEnumerable<ReadDirectionTypeDTO>> GetDirectionTypes();
        Result<IEnumerable<ReadLineTypeDTO>> GetLineTypes();
    }
}
