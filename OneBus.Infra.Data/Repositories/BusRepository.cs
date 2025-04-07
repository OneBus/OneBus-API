using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class BusRepository : BaseRepository<Bus, BaseFilter>, IBusRepository
    {
        public BusRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
