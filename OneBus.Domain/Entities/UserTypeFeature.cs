using System.ComponentModel.DataAnnotations.Schema;

namespace OneBus.Domain.Entities
{
    [NotMapped]
    public class UserTypeFeature : BaseEntity
    {
        public ulong UserTypeId { get; set; }

        public ulong FeatureId { get; set; }

        public bool HasPermission { get; set; }

        public UserType? UserType { get; set; }

        public Feature? Feature { get; set; }
    }
}
