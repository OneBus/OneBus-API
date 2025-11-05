namespace OneBus.Application.DTOs.Dashboard
{
    public class ReadEmployeeTotalCountDTO
    {
        public ReadEmployeeTotalCountDTO(IEnumerable<ReadEmployeeCountDTO> employeeCounts)
        {
            EmployeeCounts = employeeCounts;
        }

        public long TotalCount { get { return EmployeeCounts.SelectMany(c => c.Employees).LongCount(); } }

        public IEnumerable<ReadEmployeeCountDTO> EmployeeCounts { get; set; }
    }
}
