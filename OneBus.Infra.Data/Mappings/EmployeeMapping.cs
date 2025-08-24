using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class EmployeeMapping : BaseEntityMapping<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Funcionario");
            base.Configure(builder);

            builder.Property(c => c.Rg).HasMaxLength(20);
            builder.Property(c => c.Cpf).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(80);
            builder.Property(c => c.CnhNumber).HasColumnName("NumeroCnh");
            builder.Property(c => c.CnhExpiration).HasColumnName("ValidadeCnh");
            builder.Property(c => c.HiringDate).HasColumnName("DataContratacao");
            builder.Property(c => c.Name).HasColumnName("Nome").HasMaxLength(80);
            builder.Property(c => c.Image).HasColumnName("Foto").HasMaxLength(20);
            builder.Property(c => c.Code).HasColumnName("Codigo").HasMaxLength(30);
            builder.Property(c => c.Phone).HasColumnName("Telefone").HasMaxLength(20);
            builder.Property(c => c.Role).HasColumnName("Cargo").HasConversion<byte>();
            builder.Property(c => c.Status).HasColumnName("Status").HasConversion<byte>();
            builder.Property(c => c.BloodType).HasColumnName("TipoSanguineo").HasConversion<byte>();
            builder.Property(c => c.CnhCategory).HasColumnName("CategoriaCnh").HasConversion<byte>();

            builder.HasIndex(c => c.Cpf);
            builder.HasIndex(c => c.CnhNumber);
            builder.HasIndex(c => c.Code);          
        }
    }
}
