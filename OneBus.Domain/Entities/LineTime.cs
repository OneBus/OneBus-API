using OneBus.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class LineTime : BaseEntity
    {
        public long LineId { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public DayType DayType { get; set; }

        public Line? Line { get; set; }

        public ICollection<BusOperation>? BusOperations { get; set; }
    }
}
