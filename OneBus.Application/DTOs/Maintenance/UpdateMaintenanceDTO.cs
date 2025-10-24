namespace OneBus.Application.DTOs.Maintenance
{
    public class UpdateMaintenanceDTO : BaseUpdateDTO
    {
        public UpdateMaintenanceDTO()
        {
            Description = string.Empty;
        }

        public byte Sector { get; set; }

        public string Description { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public DateOnly SurveyExpiration { get; set; }

        public decimal Cost { get; set; }
    }
}
