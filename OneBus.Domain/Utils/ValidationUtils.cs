namespace OneBus.Domain.Utils
{
    public static class ValidationUtils
    {
        public static bool IsValidEnumValue<TEnum>(byte? value)
            where TEnum : Enum
        {
            if (!value.HasValue)
                return true;

            return Enum.IsDefined(typeof(TEnum), value);
        }

        public static bool IsValidEnumValue<TEnum>(byte value)
            where TEnum : Enum
        {
            return Enum.IsDefined(typeof(TEnum), value);
        }
    }
}
