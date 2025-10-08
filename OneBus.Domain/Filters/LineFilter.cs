namespace OneBus.Domain.Filters
{
    public class LineFilter : BaseFilter
    {
        public byte? Type { get; set; }

        public byte? DirectionType { get; set; }
    }
}
