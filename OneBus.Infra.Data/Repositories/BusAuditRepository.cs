using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class BusAuditRepository : BaseRepository<BusAudit, BaseFilter>, IBusAuditRepository
    {
        public BusAuditRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
