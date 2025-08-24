using OneBus.Domain.Enums.Employee;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
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

        public ICollection<EmployeeWorkday>? EmployeeWorkdays { get; set; }
    }
}
