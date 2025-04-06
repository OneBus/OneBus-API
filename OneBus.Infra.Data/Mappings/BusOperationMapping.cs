using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class BusOperationMapping : BaseEntityMapping<BusOperation>
    {
        public override void Configure(EntityTypeBuilder<BusOperation> builder)
        {
            builder.ToTable("OnibusOperacao");
            base.Configure(builder);

            builder.Property(c => c.Date).HasColumnName("Data");
            builder.Property(c => c.BusId).HasColumnName("OnibusId");
            builder.Property(c => c.LineTimeId).HasColumnName("LinhaHorarioId");
            builder.Property(c => c.EmployeeWorkDayId).HasColumnName("FuncionarioHorarioId");

            builder
                .HasOne(c => c.LineTime)
                .WithMany(c => c.BusOperations)
                .HasForeignKey(c => c.LineTimeId);

            builder
                .HasOne(c => c.Bus)
                .WithMany(c => c.BusOperations)
                .HasForeignKey(c => c.BusId);

            builder
                .HasOne(c => c.EmployeeWorkday)
                .WithMany(c => c.BusOperations)
                .HasForeignKey(c => c.EmployeeWorkDayId);
        }
    }
}
