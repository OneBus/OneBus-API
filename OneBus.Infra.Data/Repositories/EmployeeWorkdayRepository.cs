using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class EmployeeWorkdayRepository : BaseRepository<EmployeeWorkday, BaseFilter>, IEmployeeWorkdayRepository
    {
        public EmployeeWorkdayRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
