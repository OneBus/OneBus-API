namespace OneBus.Application.DTOs.EmployeeWorkday
{
    public class ReadEmployeeWorkdayDTO : BaseReadDTO
    {
        public long EmployeeId { get; set; }

        public string? EmployeeName { get; set; }
        
        public byte[]? EmployeeImage { get; set; }

        public string? EmployeeCpf { get; set; }

        public string? EmployeeCode { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public byte DayType { get; set; }

        public string? DayTypeName { get; set; }
    }
}
