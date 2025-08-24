using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class BusMapping : BaseEntityMapping<Bus>
    {
        public override void Configure(EntityTypeBuilder<Bus> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.ChassisBrand).HasMaxLength(50);
            builder.Property(c => c.ChassisModel).HasMaxLength(50);

            builder
                .HasOne(c => c.Vehicle)
                .WithMany(c => c.Buses)
                .HasForeignKey(c => c.VehicleId);
        }
    }
}
