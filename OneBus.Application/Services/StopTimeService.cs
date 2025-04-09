using FluentValidation;
using OneBus.Application.DTOs.StopTime;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class StopTimeService : BaseService<StopTime, CreateStopTimeDTO, ReadStopTimeDTO, UpdateStopTimeDTO, BaseFilter>,
        IStopTimeService
    {
        public StopTimeService(
            IBaseRepository<StopTime, BaseFilter> baseRepository, 
            IValidator<CreateStopTimeDTO> createValidator, 
            IValidator<UpdateStopTimeDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(StopTime entity, UpdateStopTimeDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
