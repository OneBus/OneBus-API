using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class UserTypeFeatureRepository : BaseRepository<UserTypeFeature, BaseFilter>, IUserTypeFeatureRepository
    {
        public UserTypeFeatureRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
