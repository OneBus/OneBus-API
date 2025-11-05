namespace OneBus.Domain.Entities
{
    public class LineTime : BaseEntity
    {
        public long LineId { get; set; }

        public TimeOnly Time { get; set; }
        
        public byte DayType { get; set; }

        public Line? Line { get; set; }

        public ICollection<VehicleOperation>? VehicleOperations { get; set; }
    }
}
