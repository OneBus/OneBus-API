namespace OneBus.Domain.Entities
{
    public class Feature : BaseEntity
    {
        public Feature()
        {
            Description = string.Empty;
        }

        public byte Code { get; set; }

        public string Description { get; set; }

        public ICollection<UserTypeFeature>? UserTypeFeatures { get; set; }
    }
}
