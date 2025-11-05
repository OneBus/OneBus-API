namespace OneBus.Application.DTOs.Vehicle
{
    public class ReadFuelTypeDTO
    {
        public ReadFuelTypeDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
