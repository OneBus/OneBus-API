using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class VehicleOperationMapping : BaseEntityMapping<VehicleOperation>
    {
        public override void Configure(EntityTypeBuilder<VehicleOperation> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(c => c.LineTime)
                .WithMany(c => c.VehicleOperations)
                .HasForeignKey(c => c.LineTimeId);

            builder
                .HasOne(c => c.Vehicle)
                .WithMany(c => c.VehicleOperations)
                .HasForeignKey(c => c.VehicleId);

            builder
                .HasOne(c => c.EmployeeWorkday)
                .WithMany(c => c.VehicleOperations)
                .HasForeignKey(c => c.EmployeeWorkdayId);
        }
    }
}
