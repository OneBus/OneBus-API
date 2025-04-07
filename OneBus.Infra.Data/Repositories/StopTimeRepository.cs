using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class StopTimeRepository : BaseRepository<StopTime, BaseFilter>, IStopTimeRepository
    {
        public StopTimeRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
