using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class Company : BaseEntity
    {
        public Company()
        {
            Name = string.Empty;
            Cnpj = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
        }

        public ulong AddressId { get; set; }

        public string Name { get; set; }

        public string Cnpj { get; set; }
        
        public string Email { get; set; }

        public string Phone { get; set; }

        public string? Image { get; set; }

        public Address? Address { get; set; }

        public ICollection<UserType>? UserTypes { get; set; }

        public ICollection<Garage>? Garages { get; set; }

        public ICollection<Line>? Lines { get; set; }
    }
}
