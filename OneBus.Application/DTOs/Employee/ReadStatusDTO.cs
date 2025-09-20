namespace OneBus.Application.DTOs.Employee
{
    public class ReadStatusDTO
    {
        public ReadStatusDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
