using OneBus.Domain.Enums.Address;

namespace OneBus.Domain.Filters
{
    public class AddressFilter : BaseFilter
    {
        public AreaType? AreaType { get; set; }
    }
}
