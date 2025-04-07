using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, BaseFilter>, IEmployeeRepository
    {
        public EmployeeRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
