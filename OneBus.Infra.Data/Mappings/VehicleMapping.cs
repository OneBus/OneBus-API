using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class VehicleMapping : BaseEntityMapping<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Renavam).HasMaxLength(20);
            builder.Property(c => c.Color).HasMaxLength(20);
            builder.Property(c => c.Brand).HasMaxLength(50);
            builder.Property(c => c.Plate).HasMaxLength(20);
            builder.Property(c => c.Model).HasMaxLength(50);
            builder.Property(c => c.Prefix).HasMaxLength(30);
            builder.Property(c => c.EngineNumber).HasMaxLength(20);
            builder.Property(c => c.NumberChassis).HasMaxLength(20);
            builder.Property(c => c.BodyworkNumber).HasMaxLength(20);

            builder.HasIndex(c => c.Plate);
            builder.HasIndex(c => c.Prefix);
            builder.HasIndex(c => c.Renavam);
        }
    }
}
