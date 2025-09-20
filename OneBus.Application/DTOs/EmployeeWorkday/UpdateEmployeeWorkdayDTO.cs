namespace OneBus.Application.DTOs.EmployeeWorkday
{
    public class UpdateEmployeeWorkdayDTO : BaseUpdateDTO
    {
        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}
