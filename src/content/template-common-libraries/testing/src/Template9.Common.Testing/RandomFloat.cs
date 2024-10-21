namespace Template9.Common.Testing;

/// <summary>
/// Generates random floating point numbers for testing purposes.
/// </summary>
public static class RandomFloat
{
    public const int MaxValue = 99999;

    public const int MaxPrecision = 5;

    /// <summary>
    /// Returns a random floating point number.
    /// </summary>
    /// <returns></returns>
    public static float Next()
    {
        return Next(1, MaxValue, MaxPrecision);
    }

    /// <summary>
    ///     <para>Returns a random floating point number with the specified decimal precision.</para>
    ///     <para>The precision specified cannot exceed 5.</para>
    /// </summary>
    /// <param name="precision"></param>
    /// <returns></returns>
    public static float Next(int precision)
    {
        return Next(1, MaxValue, precision);
    }

    /// <summary>
    ///     <para>Returns a random floating point number where the whole number is between 0 and the max specified and the fractional portion has the specified decimal precision.</para>
    ///     <para>The max value specified cannot exceed 99999 and the precision specified cannot exceed 5.</para>
    /// </summary>
    /// <param name="max"></param>
    /// <param name="precision"></param>
    /// <returns>The actual value returned may be fractionally larger than the maximum value specified.</returns>
    public static float Next(int max, int precision)
    {
        return Next(1, max, precision);
    }

    /// <summary>
    ///     <para>Returns a random floating point number where the whole number is in the range specified and the fractional portion has the specified decimal precision.</para>
    ///     <para>The min value specified must be greater than 0, the max value specified cannot exceed 99999, and the precision specified cannot exceed 5.</para>
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="precision"></param>
    /// <returns>The actual value returned may be fractionally larger than the maximum value specified.</returns>
    public static float Next(int min, int max, int precision)
    {
        var exceptions = new List<ArgumentException>();

        if (min < 0)
            exceptions.Add(new ArgumentException($"{nameof(min)} must be greater than or equal to 0", nameof(min)));

        if (max > MaxValue)
            exceptions.Add(new ArgumentException($"{nameof(max)} must be less than or equal to {MaxValue}", nameof(max)));

        if (min > max)
            exceptions.Add(new ArgumentException($"{nameof(min)} cannot be larger than {nameof(max)}", nameof(min)));

        if (precision > MaxPrecision || precision < 1)
            exceptions.Add(new ArgumentException($"{nameof(precision)} must be between 1 and {MaxPrecision}", nameof(precision)));

        if (exceptions.Any()) throw new AggregateException(exceptions);
        return Generate(min, max, precision);
    }

    private static float Generate(int min, int max, int precision)
    {
        var whole = Random.Shared.Next(min, max);
        var fraction = (decimal)Random.Shared.NextDouble();
        return (float)(whole + decimal.Round(fraction, precision));
    }
}
