namespace OneBus.Application.DTOs.EmployeeWorkday
{
    public class CreateEmployeeWorkdayDTO : BaseCreateDTO
    {
        public long EmployeeId { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public byte DayType { get; set; }
    }
}
