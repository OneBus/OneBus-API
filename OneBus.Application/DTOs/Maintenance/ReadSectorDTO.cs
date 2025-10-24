namespace OneBus.Application.DTOs.Maintenance
{
    public class ReadSectorDTO
    {
        public ReadSectorDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
