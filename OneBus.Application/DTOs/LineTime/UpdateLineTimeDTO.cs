namespace OneBus.Application.DTOs.LineTime
{
    public class UpdateLineTimeDTO : BaseUpdateDTO
    {        
        public TimeOnly Time { get; set; }

        public byte DayType { get; set; }

        public byte DirectionType { get; set; }
    }
}
