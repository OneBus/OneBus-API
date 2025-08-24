namespace OneBus.Domain.Entities
{
    public class Line : BaseEntity
    {
        public Line()
        {
            Number = string.Empty;
            Name = string.Empty;
        }

        public string Number { get; set; }

        public string Name { get; set; }

        public byte Type { get; set; }       

        public TimeOnly TravelTime { get; set; }

        public decimal Mileage { get; set; }

        public byte MinNumberBuses { get; set; }
            
        public byte MaxNumberBuses { get; set; }      

        public ICollection<LineTime>? LineTimes { get; set; }
    }
}
