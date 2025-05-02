using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class UserTypeRepository : BaseRepository<UserType, BaseFilter>, IUserTypeRepository
    {
        public UserTypeRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
