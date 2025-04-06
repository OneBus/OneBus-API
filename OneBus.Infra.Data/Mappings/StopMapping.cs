using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class StopMapping : BaseEntityMapping<Stop>
    {
        public override void Configure(EntityTypeBuilder<Stop> builder)
        {
            builder.ToTable("Parada");
            base.Configure(builder);

            builder.Property(c => c.IsFinalStop).HasColumnName("PontoFinal");
            builder.Property(c => c.IsInitialStop).HasColumnName("PontoInicial");
            builder.Property(c => c.Name).HasColumnName("Nome").HasMaxLength(50);
            builder.Property(c => c.LineAddressId).HasColumnName("LinhaEnderecoId");

            builder
                .HasOne(c => c.LineAddress)
                .WithMany(c => c.Stops)
                .HasForeignKey(c => c.LineAddressId);
        }
    }
}
