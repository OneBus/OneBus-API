using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class GarageRepository : BaseRepository<Garage, BaseFilter>, IGarageRepository
    {
        public GarageRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
