namespace OneBus.Domain.Filters
{
    public class EmployeeFilter : BaseFilter
    {
        public byte? Status { get; set; }
        
        public byte? Role { get; set; }

        public byte? BloodType { get; set; }
    }
}
