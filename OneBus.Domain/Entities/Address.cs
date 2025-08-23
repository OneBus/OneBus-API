using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class Address : BaseEntity
    {
        public Address()
        {
            Area = string.Empty;
            PostCode = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Number = string.Empty;
        }

        public string Area { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string? Number { get; set; }

        public string? Complement { get; set; }

        public ICollection<Company>? Companies { get; set; }

        public ICollection<Employee>? Employees { get; set; }

        public ICollection<Garage>? Garages { get; set; }

        public ICollection<LineAddress>? LineAddresses { get; set; }
    }
}
