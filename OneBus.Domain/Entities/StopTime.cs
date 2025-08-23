using OneBus.Domain.Enums.StopTime;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class StopTime : BaseEntity
    {
        public StopTime()
        {
            Time = string.Empty;
        }

        public ulong StopId { get; set; }

        public string Time { get; set; }

        public DayType DayType { get; set; }

        public Stop? Stop { get; set; }
    }
}
