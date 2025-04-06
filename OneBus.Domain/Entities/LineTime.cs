using OneBus.Domain.Enums.StopTime;

namespace OneBus.Domain.Entities
{
    public class LineTime : BaseEntity
    {
        public ulong LineId { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public DayType DayType { get; set; }

        public Line? Line { get; set; }

        public ICollection<BusOperation>? BusOperations { get; set; }
    }
}
