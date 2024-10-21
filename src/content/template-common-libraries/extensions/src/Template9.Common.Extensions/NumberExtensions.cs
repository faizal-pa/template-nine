namespace Template9.Common.Extensions;

public static class NumberExtensions
{
    /// <summary>
    /// Returns true if the integer is in the 2xx range.
    /// </summary>
    /// <param name="statusCode"></param>
    /// <returns></returns>
    public static bool IsSuccessStatusCode(this int statusCode)
    {
        return statusCode.IsBetween(199, 300);
    }

    /// <summary>
    /// Returns true if the integer is greater than the lower bound and lower than the upper bound.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="lowerBound"></param>
    /// <param name="upperBound"></param>
    /// <returns></returns>
    public static bool IsBetween(this int value, int lowerBound, int upperBound)
    {
        return value > lowerBound && value < upperBound;
    }
}
