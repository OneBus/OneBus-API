using OneBus.Application.DTOs.BusAudit;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;

namespace OneBus.Application.Interfaces.Services
{
    public interface IBusAuditService : 
        IBaseService<BusAudit, CreateBusAuditDTO, ReadBusAuditDTO, UpdateBusAuditDTO, BaseFilter>
    {
    }
}
