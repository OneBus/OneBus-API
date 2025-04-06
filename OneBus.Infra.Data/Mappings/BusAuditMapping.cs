using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class BusAuditMapping : BaseEntityMapping<BusAudit>
    {
        public override void Configure(EntityTypeBuilder<BusAudit> builder)
        {
            builder.ToTable("OnibusAuditoria");
            base.Configure(builder);

            builder.Property(c => c.Date).HasColumnName("Data");
            builder.Property(c => c.BusId).HasColumnName("OnibusId");
            builder.Property(c => c.EmployeeId).HasColumnName("FuncionarioId");
            builder.Property(c => c.TotalMileage).HasColumnName("TotalQuilometragem");
            builder.Property(c => c.TotalPassengers).HasColumnName("TotalPassageiros");
            builder.Property(c => c.TotalMileageToday).HasColumnName("TotalQuilometragemDia");
            builder.Property(c => c.TotalPassengersToday).HasColumnName("TotalPassageirosDia");

            builder
                .HasOne(c => c.Employee)
                .WithMany(c => c.BusAudits)
                .HasForeignKey(c => c.EmployeeId);

            builder
                .HasOne(c => c.Bus)
                .WithMany(c => c.BusAudits)
                .HasForeignKey(c => c.BusId);
        }
    }
}
