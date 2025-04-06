using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class GarageMapping : BaseEntityMapping<Garage>
    {
        public override void Configure(EntityTypeBuilder<Garage> builder)
        {
            builder.ToTable("Garagem");
            base.Configure(builder);

            builder.Property(c => c.CompanyId).HasColumnName("EmpresaId");
            builder.Property(c => c.AddressId).HasColumnName("EnderecoId");
            builder.Property(c => c.Name).HasColumnName("Nome").HasMaxLength(80);
            builder.Property(c => c.Image).HasColumnName("Foto").HasMaxLength(20);
            builder.Property(c => c.Phone).HasColumnName("Telefone").HasMaxLength(20);

            builder
                .HasOne(c => c.Company)
                .WithMany(c => c.Garages)
                .HasForeignKey(c => c.CompanyId);
            
            builder
                .HasOne(c => c.Address)
                .WithMany(c => c.Garages)
                .HasForeignKey(c => c.AddressId);
        }
    }
}
