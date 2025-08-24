namespace OneBus.Domain.Entities
{
    public class VehicleOperation : BaseEntity
    {
        public long EmployeeWorkdayId { get; set; }

        public long VehicleId { get; set; }

        public DateOnly Date { get; set; }

        public EmployeeWorkday? EmployeeWorkday { get; set; }

        public Vehicle? Vehicle { get; set; }
    }
}
