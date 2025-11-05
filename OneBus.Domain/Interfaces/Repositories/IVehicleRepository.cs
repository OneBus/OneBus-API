using OneBus.Domain.Entities;
using OneBus.Domain.Enums.Vehicle;
using OneBus.Domain.Filters;

namespace OneBus.Domain.Interfaces.Repositories
{
    public interface IVehicleRepository : IBaseRepository<Vehicle, VehicleFilter>
    {
        Task<bool> SetStatusAsync(IEnumerable<long> ids, VehicleStatus status, CancellationToken cancellationToken = default);
    }
}
