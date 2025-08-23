using OneBus.Domain.Enums.LineAddress;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
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
