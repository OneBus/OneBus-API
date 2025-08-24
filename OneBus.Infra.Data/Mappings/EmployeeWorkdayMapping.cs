using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneBus.Domain.Entities;

namespace OneBus.Infra.Data.Mappings
{
    public class EmployeeWorkdayMapping : BaseEntityMapping<EmployeeWorkday>
    {
        public override void Configure(EntityTypeBuilder<EmployeeWorkday> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(c => c.Employee)
                .WithMany(c => c.EmployeeWorkdays)
                .HasForeignKey(c => c.EmployeeId);
        }
    }
}
