using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public abstract class BaseEntityMapping<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();

            builder.Property(c => c.CreatedAt).HasColumnName("DataCriacao");
            builder.Property(c => c.DeletedAt).HasColumnName("DataExclusao");

            //Sempre obter por padrão registros ativos em consultas
            builder.HasQueryFilter(c => c.DeletedAt == null);
        }
    }
}
