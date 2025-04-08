using OneBus.Application.DTOs.Bus;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IBusService : IBaseService<Bus, CreateBusDTO, ReadBusDTO, UpdateBusDTO, BaseFilter>
    {
    }
}
