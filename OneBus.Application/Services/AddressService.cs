using FluentValidation;
using OneBus.Application.DTOs.Address;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class AddressService : BaseService<Address, CreateAddressDTO, ReadAddressDTO, UpdateAddressDTO, AddressFilter>, 
        IAddressService
    {
        public AddressService(
            IBaseRepository<Address, AddressFilter> baseRepository, 
            IValidator<CreateAddressDTO> createValidator, 
            IValidator<UpdateAddressDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
