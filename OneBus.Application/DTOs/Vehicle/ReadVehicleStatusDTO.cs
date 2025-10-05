namespace OneBus.Application.DTOs.Vehicle
{
    public class ReadVehicleStatusDTO
    {
        public ReadVehicleStatusDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
