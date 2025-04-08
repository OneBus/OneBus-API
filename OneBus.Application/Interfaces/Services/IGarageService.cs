using OneBus.Application.DTOs.Garage;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IGarageService : 
        IBaseService<Garage, CreateGarageDTO, ReadGarageDTO, UpdateGarageDTO, BaseFilter>
    {
    }
}
