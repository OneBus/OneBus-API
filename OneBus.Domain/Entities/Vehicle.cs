using OneBus.Domain.Enums.Vehicle;

namespace OneBus.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public Vehicle()
        {
            Prefix = string.Empty;
            Brand = string.Empty;
            Model = string.Empty;
            Plate = string.Empty;
            Renavam = string.Empty;
        }

        public VehicleType Type { get; set; }

        public string Prefix { get; set; }

        public byte NumberDoors { get; set; }

        public byte NumberSeats { get; set; }

        public bool HasAccessibility { get; set; }

        public FuelType FuelType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public ushort Year { get; set; }

        public string Plate { get; set; }

        public string? Color { get; set; }

        public string? BodyworkNumber { get; set; }

        public string? NumberChassis { get; set; }

        public string? EngineNumber { get; set; }

        public byte AxesNumber { get; set; }

        public DateOnly IpvaExpiration { get; set; }

        public DateOnly LicensingExpiration { get; set; }

        public string Renavam { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public DateOnly AcquisitionDate { get; set; }

        public VehicleStatus Status { get; set; }

        public string? Image { get; set; }

        public ICollection<VehicleGarage>? VehicleGarages { get; set; }

        public ICollection<Bus>? Buses { get; set; }

        public ICollection<Maintenance>? Maintenances { get; set; }

        public ICollection<VehicleOperation>? VehicleOperations { get; set; }
    }
}
