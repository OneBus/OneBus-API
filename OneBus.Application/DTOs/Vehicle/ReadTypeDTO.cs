namespace OneBus.Application.DTOs.Vehicle
{
    public class ReadTypeDTO
    {
        public ReadTypeDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
