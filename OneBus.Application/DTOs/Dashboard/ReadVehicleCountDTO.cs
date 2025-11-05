using OneBus.Application.DTOs.Vehicle;

namespace OneBus.Application.DTOs.Dashboard
{
    public class ReadVehicleCountDTO
    {
        public ReadVehicleCountDTO()
        {
            StatusName = string.Empty;
            Vehicles = [];
        }

        public long Count { get { return Vehicles.LongCount(); } }

        public byte Status { get; set; }

        public string StatusName { get; set; }

        public IEnumerable<ReadVehicleDTO> Vehicles { get; set; }
    }
}
