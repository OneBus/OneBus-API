using System.Globalization;
using System.Reflection;
using System.Resources;

namespace OneBus.Domain.Commons
{
    public static class ResourceMgr
    {
        public static string GetString(
            string? name,
            bool returnEmptyWhenNotFound = false,
            bool returnKeyWhenNotFound = false)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            ResourceManager resourceManager = new("OneBus.Domain.Resources.Messages", Assembly.GetExecutingAssembly());
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");
            string? result = resourceManager.GetString(name);

            if (!string.IsNullOrWhiteSpace(result))
                return result;

            return returnEmptyWhenNotFound ? string.Empty :
                   returnKeyWhenNotFound ? name : $"[[{name}]]";
        }
    }
}
