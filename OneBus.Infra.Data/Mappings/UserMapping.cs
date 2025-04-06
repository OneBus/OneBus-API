using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class UserMapping : BaseEntityMapping<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            base.Configure(builder);

            builder.Property(c => c.Email).HasMaxLength(80);
            builder.Property(c => c.CompanyId).HasColumnName("EmpresaId");
            builder.Property(c => c.Salt).HasColumnName("Sal").HasMaxLength(25);
            builder.Property(c => c.Name).HasColumnName("Nome").HasMaxLength(80);
            builder.Property(c => c.Image).HasColumnName("Foto").HasMaxLength(20);
            builder.Property(c => c.Phone).HasColumnName("Telefone").HasMaxLength(20);
            builder.Property(c => c.Password).HasColumnName("Senha").HasMaxLength(50);

            builder
                .HasOne(c => c.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(c => c.CompanyId);
        }
    }
}
