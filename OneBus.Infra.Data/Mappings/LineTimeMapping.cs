using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class LineTimeMapping : BaseEntityMapping<LineTime>
    {
        public override void Configure(EntityTypeBuilder<LineTime> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(c => c.Line)
                .WithMany(c => c.LineTimes)
                .HasForeignKey(c => c.LineId);
        }
    }
}
