using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class LineTariffAuditRepository : BaseRepository<LineTariffAudit, BaseFilter>, ILineTariffAuditRepository
    {
        public LineTariffAuditRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
