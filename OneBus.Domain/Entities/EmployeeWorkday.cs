using OneBus.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class EmployeeWorkday : BaseEntity
    {
        public long EmployeeId { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public DayType DayType { get; set; }

        public Employee? Employee { get; set; }

        public ICollection<VehicleOperation>? VehicleOperations { get; set; }
    
        public ICollection<BusOperation>? BusOperations { get; set; }
    }
}
