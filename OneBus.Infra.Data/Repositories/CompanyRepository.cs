using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class CompanyRepository : BaseRepository<Company, BaseFilter>, ICompanyRepository
    {
        public CompanyRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
