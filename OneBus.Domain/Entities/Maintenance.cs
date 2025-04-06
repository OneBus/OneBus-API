using OneBus.Domain.Enums.Maintenance;

namespace OneBus.Domain.Entities
{
    public class Maintenance : BaseEntity
    {
        public Maintenance()
        {
            Description = string.Empty;
        }

        public ulong VehicleId { get; set; }

        public Sector Sector { get; set; }

        public string Description { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public DateOnly SurveyExpiration { get; set; }

        public decimal Cost { get; set; }

        public Vehicle? Vehicle { get; set; }
    }
}
