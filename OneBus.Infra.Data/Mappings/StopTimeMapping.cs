using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class StopTimeMapping : BaseEntityMapping<StopTime>
    {
        public override void Configure(EntityTypeBuilder<StopTime> builder)
        {
            builder.ToTable("ParadaHorario");
            base.Configure(builder);

            builder.Property(c => c.StopId).HasColumnName("ParadaId");
            builder.Property(c => c.Time).HasColumnName("Horario").HasMaxLength(100);
            builder.Property(c => c.DayType).HasColumnName("Dia").HasConversion<byte>();

            builder
                .HasOne(c => c.Stop)
                .WithMany(c => c.StopTimes)
                .HasForeignKey(c => c.StopId);
        }
    }
}
