using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class BusOperationMapping : BaseEntityMapping<BusOperation>
    {
        public override void Configure(EntityTypeBuilder<BusOperation> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(c => c.LineTime)
                .WithMany(c => c.BusOperations)
                .HasForeignKey(c => c.LineTimeId);

            builder
                .HasOne(c => c.Bus)
                .WithMany(c => c.BusOperations)
                .HasForeignKey(c => c.BusId);

            builder
                .HasOne(c => c.EmployeeWorkday)
                .WithMany(c => c.BusOperations)
                .HasForeignKey(c => c.EmployeeWorkDayId);
        }
    }
}
