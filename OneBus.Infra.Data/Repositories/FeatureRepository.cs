using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class FeatureRepository : BaseReadOnlyRepository<Feature, BaseFilter>, IFeatureRepository
    {
        public FeatureRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
