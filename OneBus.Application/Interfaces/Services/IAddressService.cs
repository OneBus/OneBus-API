using OneBus.Application.DTOs.Address;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IAddressService : 
        IBaseService<Address, CreateAddressDTO, ReadAddressDTO, UpdateAddressDTO, AddressFilter>
    {
    }
}
