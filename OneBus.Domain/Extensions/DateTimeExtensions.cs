namespace OneBus.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToBrazilianDateTime(this DateTime dateTime)
        {
            TimeZoneInfo brazilTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), brazilTimeZone);
        }
    }
}
