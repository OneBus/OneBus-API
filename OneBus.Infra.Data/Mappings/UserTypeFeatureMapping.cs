using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class UserTypeFeatureMapping : BaseEntityMapping<UserTypeFeature>
    {
        public override void Configure(EntityTypeBuilder<UserTypeFeature> builder)
        {
            builder.ToTable("TipoUsuarioFuncionalidade");
            base.Configure(builder);

            builder.Property(c => c.UserTypeId).HasColumnName("TipoUsuarioId");
            builder.Property(c => c.FeatureId).HasColumnName("FuncionalidadeId");
            builder.Property(c => c.HasPermission).HasColumnName("TemPermissao");
        
            builder
                .HasOne(c => c.UserType)
                .WithMany(c => c.UserTypeFeatures)
                .HasForeignKey(c => c.UserTypeId);

            builder
                .HasOne(c => c.Feature)
                .WithMany(c => c.UserTypeFeatures)
                .HasForeignKey(c => c.FeatureId);
        }
    }
}
