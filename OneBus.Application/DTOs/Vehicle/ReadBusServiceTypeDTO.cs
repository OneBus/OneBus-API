namespace OneBus.Application.DTOs.Vehicle
{
    public class ReadBusServiceTypeDTO
    {
        public ReadBusServiceTypeDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
