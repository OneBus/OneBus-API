using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class UserTypeMapping : BaseEntityMapping<UserType>
    {
        public override void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("TipoUsuario");
            base.Configure(builder);

            builder.Property(c => c.CompanyId).HasColumnName("EmpresaId");
            builder.Property(c => c.Name).HasColumnName("Nome").HasMaxLength(30);

            builder
                .HasOne(c => c.Company)
                .WithMany(c => c.UserTypes)
                .HasForeignKey(c => c.CompanyId);
        }
    }
}
