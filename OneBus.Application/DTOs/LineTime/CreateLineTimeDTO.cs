namespace OneBus.Application.DTOs.LineTime
{
    public class CreateLineTimeDTO : BaseCreateDTO
    {
        public long LineId { get; set; }

        public TimeOnly Time { get; set; }

        public byte DayType { get; set; }
    }
}
