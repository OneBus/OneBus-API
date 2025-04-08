using OneBus.Application.DTOs.StopTime;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IStopTimeService :
        IBaseService<StopTime, CreateStopTimeDTO, ReadStopTimeDTO, UpdateStopTimeDTO, BaseFilter>
    {
    }
}
