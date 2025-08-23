using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class EmployeeGarage : BaseEntity
    {
        public ulong EmployeeId { get; set; }

        public ulong GarageId { get; set; }

        public Employee? Employee { get; set; }

        public Garage? Garage { get; set; }
    }
}
