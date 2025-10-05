namespace OneBus.Application.DTOs.Employee
{
    public class ReadEmployeeStatusDTO
    {
        public ReadEmployeeStatusDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
