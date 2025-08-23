using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class BusAudit : BaseEntity
    {
        public ulong EmployeeId { get; set; }

        public ulong BusId { get; set; }

        public DateOnly Date { get; set; }

        public ulong TotalPassengers { get; set; }

        public ulong TotalPassengersToday { get; set; }

        public decimal TotalMileage { get; set; }
    
        public decimal TotalMileageToday { get; set; }

        public Employee? Employee { get; set; }

        public Bus? Bus { get; set; }
    }
}
