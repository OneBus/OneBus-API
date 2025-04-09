using FluentValidation;
using OneBus.Application.DTOs.LineTariffAudit;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class LineTariffAuditService : BaseService<LineTariffAudit, CreateLineTariffAuditDTO, ReadLineTariffAuditDTO, UpdateLineTariffAuditDTO, BaseFilter>,
        ILineTariffAuditService
    {
        public LineTariffAuditService(
            IBaseRepository<LineTariffAudit, BaseFilter> baseRepository, 
            IValidator<CreateLineTariffAuditDTO> createValidator, 
            IValidator<UpdateLineTariffAuditDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(LineTariffAudit entity, UpdateLineTariffAuditDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
