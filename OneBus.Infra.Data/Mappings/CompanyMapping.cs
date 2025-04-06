using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class CompanyMapping : BaseEntityMapping<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Empresa");
            base.Configure(builder);

            builder.Property(c => c.Cnpj).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(80);
            builder.Property(c => c.AddressId).HasColumnName("EnderecoId");
            builder.Property(c => c.Name).HasColumnName("Nome").HasMaxLength(80);
            builder.Property(c => c.Image).HasColumnName("Foto").HasMaxLength(20);
            builder.Property(c => c.Phone).HasColumnName("Telefone").HasMaxLength(20);

            builder.HasIndex(c => c.Cnpj);
            builder.HasIndex(c => c.Email);

            builder
                .HasOne(c => c.Address)
                .WithMany(c => c.Companies)
                .HasForeignKey(c => c.AddressId);
        }
    }
}
