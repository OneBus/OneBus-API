using OneBus.Domain.Enums.LineAddress;

namespace OneBus.Domain.Entities
{   
    public class LineAddress : BaseEntity
    {
        public ulong LineId { get; set; }

        public ulong AddressId { get; set; }

        public DirectionLine DirectionLine { get; set; }

        public Line? Line { get; set; }

        public Address? Address { get; set; }

        public ICollection<Stop>? Stops { get; set; }
    }
}
