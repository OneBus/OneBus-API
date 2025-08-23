using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class BusOperation : BaseEntity
    {
        public ulong LineTimeId { get; set; }

        public ulong EmployeeWorkDayId { get; set; }

        public ulong BusId { get; set; }

        public DateOnly Date { get; set; }

        public LineTime? LineTime { get; set; }

        public EmployeeWorkday? EmployeeWorkday { get; set; }

        public Bus? Bus { get; set; }
    }
}
