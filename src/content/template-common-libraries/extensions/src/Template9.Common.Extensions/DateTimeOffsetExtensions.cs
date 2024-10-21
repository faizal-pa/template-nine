namespace Template9.Common.Extensions;

public static class DateTimeOffsetExtensions
{
    /// <summary>
    /// Returns a DateTimeOffset that represents the end of the day (23:59:59:999) for the current DateTimeOffset.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTimeOffset GetEndOfDay(this DateTimeOffset value)
    {
        return new DateTimeOffset(value.Year, value.Month, value.Day, 23, 59, 59, 999, value.Offset);
    }

    /// <summary>
    /// Returns a DateTimeOffset that represents the start of the day (0:0:0:0) for the current DateTimeOffset.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTimeOffset GetStartOfDay(this DateTimeOffset value)
    {
        return new DateTimeOffset(value.Year, value.Month, value.Day, 0, 0, 0, 0, value.Offset);
    }
}
