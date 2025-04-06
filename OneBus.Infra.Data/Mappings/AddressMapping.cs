using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class AddressMapping : BaseEntityMapping<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Endereco");
            base.Configure(builder);

            builder.Property(c => c.State).HasColumnName("Estado").HasMaxLength(4);
            builder.Property(c => c.PostCode).HasColumnName("Cep").HasMaxLength(15);
            builder.Property(c => c.City).HasColumnName("Municipio").HasMaxLength(50);
            builder.Property(c => c.Area).HasColumnName("Logradouro").HasMaxLength(100);
            builder.Property(c => c.Number).HasColumnName("Numero").HasMaxLength(30);
            builder.Property(c => c.Complement).HasColumnName("Complemento").HasMaxLength(50);

            builder.HasIndex(c => c.PostCode);
        }
    }
}
