using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class LineTimeMapping : BaseEntityMapping<LineTime>
    {
        public override void Configure(EntityTypeBuilder<LineTime> builder)
        {
            builder.ToTable("LinhaHorario");
            base.Configure(builder);

            builder.Property(c => c.LineId).HasColumnName("LinhaId");
            builder.Property(c => c.EndTime).HasColumnName("HoraFim");
            builder.Property(c => c.StartTime).HasColumnName("HoraInicio");
            builder.Property(c => c.DayType).HasColumnName("Dia").HasConversion<byte>();

            builder
                .HasOne(c => c.Line)
                .WithMany(c => c.LineTimes)
                .HasForeignKey(c => c.LineId);
        }
    }
}
