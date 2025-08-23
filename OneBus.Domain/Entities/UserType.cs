using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class UserType : BaseEntity
    {
        public UserType()
        {
            Name = string.Empty;            
        }

        public ulong CompanyId { get; set; }

        public string Name { get; set; }

        public Company? Company { get; set; }

        public ICollection<UserTypeFeature>? UserTypeFeatures { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
