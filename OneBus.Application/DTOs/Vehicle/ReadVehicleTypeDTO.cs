namespace OneBus.Application.DTOs.Vehicle
{
    public class ReadVehicleTypeDTO
    {
        public ReadVehicleTypeDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
