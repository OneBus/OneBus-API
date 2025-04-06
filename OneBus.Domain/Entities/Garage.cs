namespace OneBus.Domain.Entities
{
    public class Garage : BaseEntity
    {
        public Garage()
        {
            Name = string.Empty;
            Phone = string.Empty;
        }

        public ulong CompanyId { get; set; }

        public ulong AddressId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string? Image { get; set; }

        public Company? Company { get; set; }

        public Address? Address { get; set; }

        public ICollection<EmployeeGarage>? EmployeeGarages { get; set; }

        public ICollection<VehicleGarage>? VehicleGarages { get; set; }
    }
}
