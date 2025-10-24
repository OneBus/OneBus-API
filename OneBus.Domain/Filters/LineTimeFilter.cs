namespace OneBus.Domain.Filters
{
    public class LineTimeFilter : BaseFilter
    {
        public byte? DirectionType { get; set; }
    
        public byte? DayType { get; set; }
    }
}
