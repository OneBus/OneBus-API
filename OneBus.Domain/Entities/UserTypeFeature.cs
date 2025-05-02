namespace OneBus.Domain.Entities
{
    public class UserTypeFeature : BaseEntity
    {
        public ulong UserTypeId { get; set; }

        public ulong FeatureId { get; set; }

        public bool HasPermission { get; set; }

        public UserType? UserType { get; set; }

        public Feature? Feature { get; set; }
    }
}
