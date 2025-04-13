using OneBus.Application.DTOs.LineTariffAudit;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.API.Controllers
{
    public class LineTariffAuditController : BaseController<LineTariffAudit, CreateLineTariffAuditDTO, ReadLineTariffAuditDTO, UpdateLineTariffAuditDTO, BaseFilter>
    {
        public LineTariffAuditController(
            IBaseService<LineTariffAudit, CreateLineTariffAuditDTO, ReadLineTariffAuditDTO, UpdateLineTariffAuditDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }
    }
}
