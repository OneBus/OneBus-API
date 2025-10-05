namespace OneBus.Domain.Filters
{
    public class VehicleFilter : BaseFilter
    {
        public byte? Status { get; set; }

        public byte? Type { get; set; }

        public byte? Brand { get; set; }

        public byte? BusChassisBrand { get; set; }

        public byte? BusServiceType { get; set; }

        public byte? Color { get; set; }

        public byte? FuelType { get; set; }

        public byte? TransmissionType { get; set; }
    }
}
