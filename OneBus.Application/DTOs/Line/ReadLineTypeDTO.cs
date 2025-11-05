namespace OneBus.Application.DTOs.Line
{
    public class ReadLineTypeDTO
    {
        public ReadLineTypeDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
