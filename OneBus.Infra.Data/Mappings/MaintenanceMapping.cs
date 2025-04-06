using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class MaintenanceMapping : BaseEntityMapping<Maintenance>
    {
        public override void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.ToTable("Manutencao");
            base.Configure(builder);

            builder.Property(c => c.Cost).HasColumnName("Custo");
            builder.Property(c => c.EndDate).HasColumnName("DataFim");
            builder.Property(c => c.VehicleId).HasColumnName("VeiculoId");
            builder.Property(c => c.StartDate).HasColumnName("DataInicio");
            builder.Property(c => c.Sector).HasColumnName("Setor").HasConversion<byte>();
            builder.Property(c => c.SurveyExpiration).HasColumnName("VistoriaVencimento");
            builder.Property(c => c.Description).HasColumnName("Descricao").HasMaxLength(150);

            builder
                .HasOne(c => c.Vehicle)
                .WithMany(c => c.Maintenances)
                .HasForeignKey(c => c.VehicleId);
        }
    }
}
