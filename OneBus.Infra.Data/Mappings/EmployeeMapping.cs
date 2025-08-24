using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class EmployeeMapping : BaseEntityMapping<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Rg).HasMaxLength(20);
            builder.Property(c => c.Cpf).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(80);
            builder.Property(c => c.CnhNumber).HasMaxLength(20);
            builder.Property(c => c.Name).HasMaxLength(80);
            builder.Property(c => c.Code).HasMaxLength(30);
            builder.Property(c => c.Phone).HasMaxLength(20);

            builder.HasIndex(c => c.Cpf);
            builder.HasIndex(c => c.CnhNumber);
            builder.HasIndex(c => c.Code);
        }
    }
}
