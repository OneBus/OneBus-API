namespace OneBus.Domain.Filters
{
    public class EmployeeFilter : BaseFilter
    {
        public byte? Status { get; set; }
        
        public byte? CnhCategory { get; set; }

        public byte? Role { get; set; }

        public byte? BloodType { get; set; }

        //public DateOnly? HiringDate { get; set; }

        //public DateOnly? CnhExpiration { get; set; }
    }
}
