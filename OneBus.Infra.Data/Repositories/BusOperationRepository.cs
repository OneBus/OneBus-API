using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class BusOperationRepository : BaseRepository<BusOperation, BaseFilter>, IBusOperationRepository
    {
        public BusOperationRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
