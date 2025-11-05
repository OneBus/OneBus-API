using Microsoft.EntityFrameworkCore;
using OneBus.Domain.Entities;
using OneBus.Domain.Enums.Vehicle;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.DbContexts;
using System.Linq.Expressions;

namespace OneBus.Infra.Data.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle, VehicleFilter>, IVehicleRepository
    {
        public VehicleRepository(OneBusDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<bool> SetStatusAsync(
            IEnumerable<long> ids,
            VehicleStatus status,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(ids, nameof(ids));

            return await _dbSet
                .Where(c => ids.Contains(c.Id))
                .ExecuteUpdateAsync(setters => setters
                        .SetProperty(c => c.Status, (byte)status),
                        cancellationToken) == ids.LongCount();
        }

        protected override Expression<Func<Vehicle, bool>> ApplyFilter(VehicleFilter filter)
        {
            var value = filter.Value?.ToLower();

            return c =>
                (filter.Type == null || c.Type == filter.Type) &&
                (filter.Color == null || c.Color == filter.Color) &&
                (filter.Brand == null || c.Brand == filter.Brand) &&
                (filter.Status == null || c.Status == filter.Status) &&
                (filter.FuelType == null || c.FuelType == filter.FuelType) &&
                (filter.BusServiceType == null || c.BusServiceType == filter.BusServiceType) &&
                (filter.BusChassisBrand == null || c.BusChassisBrand == filter.BusChassisBrand) &&
                (filter.TransmissionType == null || c.TransmissionType == filter.TransmissionType) &&
                (string.IsNullOrWhiteSpace(value) ||
                ((c.Prefix.ToLower().Contains(value) ||
                c.Model.ToLower().Contains(value) ||
                c.Plate.ToLower().Contains(value) ||
                c.Renavam.ToLower().Contains(value) ||
                c.Licensing!.ToLower().Contains(value) ||
                c.NumberChassis!.ToLower().Contains(value) ||
                c.BodyworkNumber!.ToLower().Contains(value) ||
                c.BusChassisModel!.ToLower().Contains(value) ||
                c.EngineNumber!.ToLower().Contains(value)) && value != string.Empty));
        }
    }
}
