namespace OneBus.Application.DTOs.EmployeeWorkday
{
    public class ReadDayTypeDTO
    {
        public ReadDayTypeDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
