namespace OneBus.Domain.Entities
{
    public class VehicleOperation : BaseEntity
    {
        public ulong EmployeeWorkdayId { get; set; }

        public ulong VehicleId { get; set; }

        public DateOnly Date { get; set; }

        public EmployeeWorkday? EmployeeWorkday { get; set; }

        public Vehicle? Vehicle { get; set; }
    }
}
