using OneBus.Application.DTOs.Stop;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IStopService : 
        IBaseService<Stop, CreateStopDTO, ReadStopDTO, UpdateStopDTO, BaseFilter>
    {
    }
}
