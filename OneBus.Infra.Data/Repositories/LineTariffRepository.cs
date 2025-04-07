using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class LineTariffRepository : BaseRepository<LineTariff, BaseFilter>, ILineTariffRepository
    {
        public LineTariffRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
