namespace OneBus.Application.DTOs.Employee
{
    public class ReadBloodTypeDTO
    {
        public ReadBloodTypeDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
