namespace OneBus.Application.DTOs.Maintenance
{
    public class ReadMaintenanceDTO : BaseReadDTO
    {
        public ReadMaintenanceDTO()
        {
            Description = string.Empty;
        }

        public long VehicleId { get; set; }

        public string? VehiclePrefix { get; set; }

        public byte Sector { get; set; }

        public string? SectorName { get; set; }

        public string Description { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public DateOnly SurveyExpiration { get; set; }

        public decimal Cost { get; set; }
    }
}
