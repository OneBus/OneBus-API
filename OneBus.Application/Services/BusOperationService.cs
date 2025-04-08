using FluentValidation;
using OneBus.Application.DTOs.BusOperation;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class BusOperationService : BaseService<BusOperation, CreateBusOperationDTO, ReadBusOperationDTO, UpdateBusOperationDTO, BaseFilter>,
        IBusOperationService
    {
        public BusOperationService(
            IBaseRepository<BusOperation, BaseFilter> baseRepository, 
            IValidator<CreateBusOperationDTO> createValidator, 
            IValidator<UpdateBusOperationDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
