using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class UserMapping : BaseEntityMapping<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Email).HasMaxLength(80);
            builder.Property(c => c.Salt).HasMaxLength(25);
            builder.Property(c => c.Name).HasMaxLength(80);
            builder.Property(c => c.Password).HasMaxLength(50);
        }
    }
}
