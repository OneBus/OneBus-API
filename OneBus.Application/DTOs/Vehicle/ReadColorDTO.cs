namespace OneBus.Application.DTOs.Vehicle
{
    public class ReadColorDTO
    {
        public ReadColorDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
