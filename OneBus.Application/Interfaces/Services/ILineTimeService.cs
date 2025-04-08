using OneBus.Application.DTOs.LineTime;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface ILineTimeService : 
        IBaseService<LineTime, CreateLineTimeDTO, ReadLineTimeDTO, UpdateLineTimeDTO, BaseFilter>
    {
    }
}
