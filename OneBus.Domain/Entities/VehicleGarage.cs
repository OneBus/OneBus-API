using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class VehicleGarage : BaseEntity
    {
        public ulong VehicleId { get; set; }

        public ulong GarageId { get; set; }

        public Vehicle? Vehicle { get; set; }

        public Garage? Garage { get; set; }
    }
}
