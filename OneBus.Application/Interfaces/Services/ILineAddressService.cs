using OneBus.Application.DTOs.LineAddress;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface ILineAddressService : 
        IBaseService<LineAddress, CreateLineAddressDTO, ReadLineAddressDTO, UpdateLineAddressDTO, BaseFilter>
    {
    }
}
