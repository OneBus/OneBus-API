namespace OneBus.Application.DTOs.Vehicle
{
    public class ReadTransmissionTypeDTO
    {
        public ReadTransmissionTypeDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
