using OneBus.Domain.Enums.StopTime;

namespace OneBus.Domain.Entities
{
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
