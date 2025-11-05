namespace OneBus.Application.DTOs.Vehicle
{
    public class ReadBrandDTO
    {
        public ReadBrandDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
