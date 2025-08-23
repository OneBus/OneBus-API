using OneBus.Domain.Enums.Maintenance;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
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
