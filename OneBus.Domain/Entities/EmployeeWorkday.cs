using OneBus.Domain.Enums.StopTime;

namespace OneBus.Domain.Entities
{
    public class EmployeeWorkday : BaseEntity
    {
        public ulong EmployeeId { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public DayType DayType { get; set; }

        public Employee? Employee { get; set; }

        public ICollection<VehicleOperation>? VehicleOperations { get; set; }
    
        public ICollection<BusOperation>? BusOperations { get; set; }
    }
}
