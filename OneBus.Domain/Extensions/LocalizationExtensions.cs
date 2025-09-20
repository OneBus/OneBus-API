using OneBus.Domain.Commons;

namespace OneBus.Domain.Extensions
{
    public static class LocalizationExtensions
    {
        public static string Localize(this string? value)
        {
            return ResourceMgr.GetString(value, returnKeyWhenNotFound: true);
        }
    }
}
