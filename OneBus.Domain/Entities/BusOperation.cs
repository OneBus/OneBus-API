using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class BusOperation : BaseEntity
    {
        public long LineTimeId { get; set; }

        public long EmployeeWorkDayId { get; set; }

        public long BusId { get; set; }

        public DateOnly Date { get; set; }

        public LineTime? LineTime { get; set; }

        public EmployeeWorkday? EmployeeWorkday { get; set; }

        public Bus? Bus { get; set; }
    }
}
