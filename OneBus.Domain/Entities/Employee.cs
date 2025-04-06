using OneBus.Domain.Enums.Employee;

namespace OneBus.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
            Name = string.Empty;
            Rg = string.Empty;
            Cpf = string.Empty;
            Code = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
        }

        public ulong AddressId { get; set; }

        public string Name { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public BloodType? BloodType { get; set; }

        public string Code { get; set; }

        public Role Role { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateOnly HiringDate { get; set; }

        public string? CnhNumber { get; set; }

        public CnhCategory? CnhCategory { get; set; }

        public DateOnly? CnhExpiration { get; set; }

        public EmployeeStatus Status { get; set; }

        public string? Image { get; set; }

        public Address? Address { get; set; }

        public ICollection<EmployeeGarage>? EmployeeGarages { get; set; }

        public ICollection<EmployeeWorkday>? EmployeeWorkdays { get; set; }

        public ICollection<BusAudit>? BusAudits { get; set; }

        public ICollection<LineTariffAudit>? LineTariffAudits { get; set; }
    }
}
