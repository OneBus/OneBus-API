using System.Reflection;
using System.Text.Json.Serialization;

namespace OneBus.Application.Utils
{
    public static class EnumUtils
    {
        public static string? GetName<TEnum>(object? value)
            where TEnum : Enum
        {
            if (value is null)
                return null;            

            return Enum.GetName(typeof(TEnum), value);
        }

        public static string GetDisplayName(this Enum value)
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attribute = memberInfo[0]
                .GetCustomAttribute<JsonStringEnumMemberNameAttribute>();

            return attribute?.Name ?? value.ToString();
        }
    }
}
