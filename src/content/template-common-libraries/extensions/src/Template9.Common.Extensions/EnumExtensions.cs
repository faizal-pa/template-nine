namespace Template9.Common.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Converts the string to the appropriate value from the enum.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static TEnum ToEnum<TEnum>(this string value) where TEnum : struct
    {
        if (!Enum.TryParse<TEnum>(value, true, out var result))
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Unable to parse '{value}' as enum '{typeof(TEnum).Name}'");
        }

        return result;
    }

    /// <summary>
    /// Converts the string to the appropriate value from the enum.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="value"></param>
    /// <param name="useDefault"></param>
    /// <returns>If an appropriate match is not found, the default value provided is returned.</returns>
    public static TEnum ToEnum<TEnum>(this string value, TEnum useDefault) where TEnum : struct
    {
        if (!Enum.TryParse<TEnum>(value, true, out var result))
        {
            result = useDefault;
        }

        return result;
    }
}
