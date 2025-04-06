using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class LineTariffAuditMapping : BaseEntityMapping<LineTariffAudit>
    {
        public override void Configure(EntityTypeBuilder<LineTariffAudit> builder)
        {
            builder.ToTable("LinhaTarifaAuditoria");
            base.Configure(builder);

            builder.Property(c => c.Date).HasColumnName("Data");
            builder.Property(c => c.EmployeeId).HasColumnName("FuncionarioId");
            builder.Property(c => c.LineTariffId).HasColumnName("LinhaTarifaId");
            builder.Property(c => c.RemainingTicketsNumber).HasColumnName("NumeroRestanteBilhetes");

            builder
                .HasOne(c => c.Employee)
                .WithMany(c => c.LineTariffAudits)
                .HasForeignKey(c => c.EmployeeId);
        }
    }
}
