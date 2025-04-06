namespace OneBus.Domain.Entities
{
    public class Stop : BaseEntity
    {
        public ulong LineAddressId { get; set; }

        public bool IsInitialStop { get; set; }

        public bool IsFinalStop { get; set; }

        public string? Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public LineAddress? LineAddress { get; set; }

        public ICollection<StopTime>? StopTimes { get; set; }
    }
}
