using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class StopRepository : BaseRepository<Stop, BaseFilter>, IStopRepository
    {
        public StopRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
