namespace OneBus.Domain.Entities
{
    public class VehicleGarage : BaseEntity
    {
        public ulong VehicleId { get; set; }

        public ulong GarageId { get; set; }

        public Vehicle? Vehicle { get; set; }

        public Garage? Garage { get; set; }
    }
}
