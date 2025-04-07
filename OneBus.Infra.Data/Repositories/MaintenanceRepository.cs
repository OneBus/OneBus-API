using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class MaintenanceRepository : BaseRepository<Maintenance, BaseFilter>, IMaintenanceRepository
    {
        public MaintenanceRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
