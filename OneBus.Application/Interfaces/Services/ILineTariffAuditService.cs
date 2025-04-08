using OneBus.Application.DTOs.LineTariffAudit;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface ILineTariffAuditService : 
        IBaseService<LineTariffAudit, CreateLineTariffAuditDTO, ReadLineTariffAuditDTO, UpdateLineTariffAuditDTO, BaseFilter>
    {
    }
}
