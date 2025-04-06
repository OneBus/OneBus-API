using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class VehicleGarageMapping : BaseEntityMapping<VehicleGarage>
    {
        public override void Configure(EntityTypeBuilder<VehicleGarage> builder)
        {
            builder.ToTable("VeiculoGaragem");
            base.Configure(builder);

            builder.Property(c => c.GarageId).HasColumnName("GaragemId");
            builder.Property(c => c.VehicleId).HasColumnName("VeiculoId");

            builder
                .HasOne(c => c.Garage)
                .WithMany(c => c.VehicleGarages)
                .HasForeignKey(c => c.GarageId);
            
            builder
                .HasOne(c => c.Vehicle)
                .WithMany(c => c.VehicleGarages)
                .HasForeignKey(c => c.VehicleId);
        }
    }
}
