using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class LineTariffMapping : BaseEntityMapping<LineTariff>
    {
        public override void Configure(EntityTypeBuilder<LineTariff> builder)
        {
            builder.ToTable("LinhaTarifa");
            base.Configure(builder);

            builder.Property(c => c.LineId).HasColumnName("LinhaId");
            builder.Property(c => c.Price).HasColumnName("Preco");
            builder.Property(c => c.NumberTickets).HasColumnName("NumeroBilhetes");

            builder
                .HasOne(c => c.Line)
                .WithMany(c => c.LineTariffs)
                .HasForeignKey(c => c.LineId);
        }
    }
}
