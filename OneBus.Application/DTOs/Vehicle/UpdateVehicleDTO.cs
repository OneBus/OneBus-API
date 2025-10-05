namespace OneBus.Application.DTOs.Vehicle
{
    public class UpdateVehicleDTO : BaseUpdateDTO
    {
        public UpdateVehicleDTO()
        {
            Prefix = string.Empty;
            Model = string.Empty;
            Plate = string.Empty;
            Renavam = string.Empty;
        }

        public string Prefix { get; set; }

        public byte NumberDoors { get; set; }

        public byte NumberSeats { get; set; }

        public bool HasAccessibility { get; set; }

        public byte FuelType { get; set; }

        public byte Brand { get; set; }

        public string Model { get; set; }

        public ushort Year { get; set; }

        public string Plate { get; set; }

        public byte? Color { get; set; }

        public string? BodyworkNumber { get; set; }

        public string? NumberChassis { get; set; }

        public string? EngineNumber { get; set; }

        public byte AxesNumber { get; set; }

        public DateOnly IpvaExpiration { get; set; }

        public DateOnly LicensingExpiration { get; set; }

        public string Renavam { get; set; }

        public byte TransmissionType { get; set; }

        public DateOnly AcquisitionDate { get; set; }

        public byte Status { get; set; }

        public byte[]? Image { get; set; }

        public byte? BusServiceType { get; set; }

        public byte? BusChassisBrand { get; set; }

        public string? BusChassisModel { get; set; }

        public short? BusChassisYear { get; set; }

        public bool? BusHasLowFloor { get; set; }

        public bool? BusHasLeftDoors { get; set; }

        public DateOnly? BusInsuranceExpiration { get; set; }

        public DateOnly? BusFumigateExpiration { get; set; }
    }
}
