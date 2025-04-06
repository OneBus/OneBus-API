namespace OneBus.Domain.Entities
{
    public class EmployeeGarage : BaseEntity
    {
        public ulong EmployeeId { get; set; }

        public ulong GarageId { get; set; }

        public Employee? Employee { get; set; }

        public Garage? Garage { get; set; }
    }
}
