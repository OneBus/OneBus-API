using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;

namespace OneBus.Infra.Data.Repositories
{
    public class VehicleOperationRepository : BaseRepository<VehicleOperation, BaseFilter>, IVehicleOperationRepository
    {
        public VehicleOperationRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
