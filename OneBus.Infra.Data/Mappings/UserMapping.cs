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
            builder.Property(c => c.Salt).HasMaxLength(32);
            builder.Property(c => c.Name).HasMaxLength(80);
            builder.Property(c => c.Password).HasMaxLength(50);

            // Admin default data:
            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "Administrador",
                    Email = "onebus@admin",
                    Password = "YRT66Z4XEJ2SSNaJVDIXQW7uvC8LSvOxDU1sH/Sr/ic=", //onebus@2025
                    Salt = "c37b6028194d489192aac9391801594a",
                    CreatedAt = new DateTime(2025, 08, 25, 00, 00, 00, DateTimeKind.Utc),
                }
            );
        }
    }
}
