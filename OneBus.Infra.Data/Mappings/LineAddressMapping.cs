using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class LineAddressMapping : BaseEntityMapping<LineAddress>
    {
        public override void Configure(EntityTypeBuilder<LineAddress> builder)
        {
            builder.ToTable("LinhaEndereco");
            base.Configure(builder);

            builder.Property(c => c.LineId).HasColumnName("LinhaId");
            builder.Property(c => c.AddressId).HasColumnName("EnderecoId");
            builder.Property(c => c.DirectionLine).HasColumnName("SentidoLinha").HasConversion<byte>();

            builder
                .HasOne(c => c.Line)
                .WithMany(c => c.LineAddresses)
                .HasForeignKey(c => c.LineId);

            builder
                .HasOne(c => c.Address)
                .WithMany(c => c.LineAddresses)
                .HasForeignKey(c => c.AddressId);
        }
    }
}
