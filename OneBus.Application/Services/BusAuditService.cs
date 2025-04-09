using FluentValidation;
using OneBus.Application.DTOs.BusAudit;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class BusAuditService : BaseService<BusAudit, CreateBusAuditDTO, ReadBusAuditDTO, UpdateBusAuditDTO, BaseFilter>,
        IBusAuditService
    {
        public BusAuditService(
            IBaseRepository<BusAudit, BaseFilter> baseRepository, 
            IValidator<CreateBusAuditDTO> createValidator, 
            IValidator<UpdateBusAuditDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(BusAudit entity, UpdateBusAuditDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
