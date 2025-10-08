namespace OneBus.Application.DTOs.Line
{
    public class ReadDirectionTypeDTO
    {
        public ReadDirectionTypeDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
