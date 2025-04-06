using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class EmployeeWorkdayMapping : BaseEntityMapping<EmployeeWorkday>
    {
        public override void Configure(EntityTypeBuilder<EmployeeWorkday> builder)
        {
            builder.ToTable("FuncionarioHorario");
            base.Configure(builder);

            builder.Property(c => c.EmployeeId).HasColumnName("FuncionarioId");
            builder.Property(c => c.StartTime).HasColumnName("HoraInicio");
            builder.Property(c => c.EndTime).HasColumnName("HoraFim");
            builder.Property(c => c.DayType).HasColumnName("Dia").HasConversion<byte>();

            builder
                .HasOne(c => c.Employee)
                .WithMany(c => c.EmployeeWorkdays)
                .HasForeignKey(c => c.EmployeeId);
        }
    }
}
