using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class LineMapping : BaseEntityMapping<Line>
    {
        public override void Configure(EntityTypeBuilder<Line> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).HasMaxLength(80);
            builder.Property(c => c.Number).HasMaxLength(20);
        }
    }
}
