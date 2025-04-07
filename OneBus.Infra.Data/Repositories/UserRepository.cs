using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User, BaseFilter>, IUserRepository
    {
        public UserRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
