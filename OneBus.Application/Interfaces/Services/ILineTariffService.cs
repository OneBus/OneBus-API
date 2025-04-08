using OneBus.Application.DTOs.LineTariff;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface ILineTariffService : 
        IBaseService<LineTariff, CreateLineTariffDTO, ReadLineTariffDTO, UpdateLineTariffDTO, BaseFilter>
    {
    }
}
