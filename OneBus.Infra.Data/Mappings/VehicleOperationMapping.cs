using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class VehicleOperationMapping : BaseEntityMapping<VehicleOperation>
    {
        public override void Configure(EntityTypeBuilder<VehicleOperation> builder)
        {
            builder.ToTable("VeiculoOperacao");
            base.Configure(builder);

            builder.Property(c => c.Date).HasColumnName("Data");
            builder.Property(c => c.VehicleId).HasColumnName("VeiculoId");
            builder.Property(c => c.EmployeeWorkdayId).HasColumnName("FuncionarioHorarioId");

            builder
                .HasOne(c => c.Vehicle)
                .WithMany(c => c.VehicleOperations)
                .HasForeignKey(c => c.VehicleId);

            builder
                .HasOne(c => c.EmployeeWorkday)
                .WithMany(c => c.VehicleOperations)
                .HasForeignKey(c => c.EmployeeWorkdayId);
        }
    }
}
