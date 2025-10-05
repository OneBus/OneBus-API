namespace OneBus.Domain.Entities
{
    public class VehicleOperation : BaseEntity
    {
        public long? LineTimeId { get; set; }

        public long EmployeeWorkdayId { get; set; }

        public long VehicleId { get; set; }

        public DateOnly Date { get; set; }

        public EmployeeWorkday? EmployeeWorkday { get; set; }

        public Vehicle? Vehicle { get; set; }
    
        public LineTime? LineTime { get; set; }
    }
}
