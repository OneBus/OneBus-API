﻿namespace OneBus.Domain.Entities
{
    public class LineTime : BaseEntity
    {
        public long LineId { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public byte DayType { get; set; }

        public Line? Line { get; set; }

        public ICollection<BusOperation>? BusOperations { get; set; }
    }
}
