using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class EmployeeGarageRepository : BaseRepository<EmployeeGarage, BaseFilter>, IEmployeeGarageRepository
    {
        public EmployeeGarageRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
