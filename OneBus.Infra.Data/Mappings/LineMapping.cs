using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class LineMapping : BaseEntityMapping<Line>
    {
        public override void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.ToTable("Linha");
            base.Configure(builder);

            builder.Property(c => c.CompanyId).HasColumnName("EmpresaId");
            builder.Property(c => c.Mileage).HasColumnName("Quilometragem");
            builder.Property(c => c.TravelTime).HasColumnName("TempoViagem");
            builder.Property(c => c.Name).HasColumnName("Nome").HasMaxLength(80);
            builder.Property(c => c.Number).HasColumnName("Numero").HasMaxLength(20);
            builder.Property(c => c.Type).HasColumnName("Tipo").HasConversion<byte>();
            builder.Property(c => c.MinNumberBuses).HasColumnName("NumeroMinimoOnibus");
            builder.Property(c => c.MaxNumberBuses).HasColumnName("NumeroMaximoOnibus");           
        }
    }
}
