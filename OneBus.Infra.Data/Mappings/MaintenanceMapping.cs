using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class MaintenanceMapping : BaseEntityMapping<Maintenance>
    {
        public override void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Description).HasMaxLength(150);

            builder
                .HasOne(c => c.Vehicle)
                .WithMany(c => c.Maintenances)
                .HasForeignKey(c => c.VehicleId);
        }
    }
}
