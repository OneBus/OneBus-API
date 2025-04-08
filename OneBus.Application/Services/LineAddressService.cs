using FluentValidation;
using OneBus.Application.DTOs.LineAddress;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class LineAddressService : BaseService<LineAddress, CreateLineAddressDTO, ReadLineAddressDTO, UpdateLineAddressDTO, BaseFilter>,
        ILineAddressService
    {
        public LineAddressService(
            IBaseRepository<LineAddress, BaseFilter> baseRepository, 
            IValidator<CreateLineAddressDTO> createValidator, 
            IValidator<UpdateLineAddressDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
