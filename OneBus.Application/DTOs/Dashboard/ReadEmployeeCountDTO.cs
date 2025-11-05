using OneBus.Application.DTOs.Employee;

namespace OneBus.Application.DTOs.Dashboard
{
    public class ReadEmployeeCountDTO
    {
        public ReadEmployeeCountDTO()
        {
            StatusName = string.Empty;
            Employees = [];
        }

        public long Count { get { return Employees.LongCount(); } }

        public byte Status { get; set; }

        public string StatusName { get; set; }

        public IEnumerable<ReadEmployeeDTO> Employees { get; set; }
    }
}
