using FluentValidation;
using OneBus.Application.DTOs.Stop;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class StopService : BaseService<Stop, CreateStopDTO, ReadStopDTO, UpdateStopDTO, BaseFilter>,
        IStopService
    {
        public StopService(
            IBaseRepository<Stop, BaseFilter> baseRepository, 
            IValidator<CreateStopDTO> createValidator, 
            IValidator<UpdateStopDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
