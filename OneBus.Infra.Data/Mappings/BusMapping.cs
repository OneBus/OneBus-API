using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class BusMapping : BaseEntityMapping<Bus>
    {
        public override void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.ToTable("Onibus");
            base.Configure(builder);

            builder.Property(c => c.VehicleId).HasColumnName("VeiculoId");
            builder.Property(c => c.ChassisYear).HasColumnName("AnoChassi");
            builder.Property(c => c.HasLowFloor).HasColumnName("TemPisoBaixo");
            builder.Property(c => c.HasLeftDoors).HasColumnName("TemPortasEsquerda");
            builder.Property(c => c.InsuranceExpiration).HasColumnName("SeguroVencimento");
            builder.Property(c => c.FumigateExpiration).HasColumnName("DetetizacaoVencimento");
            builder.Property(c => c.ChassisBrand).HasColumnName("MarcaChassi").HasMaxLength(50);
            builder.Property(c => c.ServiceType).HasColumnName("Servico").HasConversion<byte>();
            builder.Property(c => c.ChassisModel).HasColumnName("ModeloChassi").HasMaxLength(50);

            builder
                .HasOne(c => c.Vehicle)
                .WithMany(c => c.Buses)
                .HasForeignKey(c => c.VehicleId);
        }
    }
}
