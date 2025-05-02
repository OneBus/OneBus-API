using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class FeatureMapping : BaseEntityMapping<Feature>
    {
        public override void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable("Funcionalidade");
            base.Configure(builder);
            
            builder.Property(c => c.Code).HasColumnName("Codigo");
            builder.Property(c => c.Description).HasColumnName("Descricao").HasMaxLength(80);

            builder.HasIndex(c => c.Code);
            builder.HasIndex(c => c.Description);
        }
    }
}
