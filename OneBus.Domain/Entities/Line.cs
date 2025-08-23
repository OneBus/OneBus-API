using OneBus.Domain.Enums.Line;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class Line : BaseEntity
    {
        public Line()
        {
            Number = string.Empty;
            Name = string.Empty;
        }

        public ulong CompanyId { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public LineType Type { get; set; }       

        public TimeOnly TravelTime { get; set; }

        public decimal Mileage { get; set; }

        public byte MinNumberBuses { get; set; }
            
        public byte MaxNumberBuses { get; set; }

        public Company? Company { get; set; }

        public ICollection<LineAddress>? LineAddresses { get; set; }

        public ICollection<LineTariff>? LineTariffs { get; set; }

        public ICollection<LineTime>? LineTimes { get; set; }
    }
}
