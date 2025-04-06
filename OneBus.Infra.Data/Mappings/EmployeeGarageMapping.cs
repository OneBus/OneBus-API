using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class EmployeeGarageMapping : BaseEntityMapping<EmployeeGarage>
    {
        public override void Configure(EntityTypeBuilder<EmployeeGarage> builder)
        {
            builder.ToTable("FuncionarioGaragem");
            base.Configure(builder);

            builder.Property(c => c.GarageId).HasColumnName("GaragemId");
            builder.Property(c => c.EmployeeId).HasColumnName("FuncionarioId");

            builder
                .HasOne(c => c.Garage)
                .WithMany(c => c.EmployeeGarages)
                .HasForeignKey(c => c.GarageId);

            builder
                .HasOne(c => c.Employee)
                .WithMany(c => c.EmployeeGarages)
                .HasForeignKey(c => c.EmployeeId);
        }
    }
}
