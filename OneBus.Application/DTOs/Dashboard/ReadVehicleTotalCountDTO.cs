namespace OneBus.Application.DTOs.Dashboard
{
    public class ReadVehicleTotalCountDTO
    {
        public ReadVehicleTotalCountDTO(IEnumerable<ReadVehicleCountDTO> vehicleCounts)
        {
            VehicleCounts = vehicleCounts;
        }

        public long TotalCount { get { return VehicleCounts.SelectMany(c => c.Vehicles).LongCount(); } }

        public IEnumerable<ReadVehicleCountDTO> VehicleCounts { get; set; }
    }
}
