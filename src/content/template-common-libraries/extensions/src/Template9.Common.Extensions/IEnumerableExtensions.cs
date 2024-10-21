namespace Template9.Common.Extensions;

public static class IEnumerableExtensions
{
    /// <summary>
    /// Returns true if the sequence is NOT null and has items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public static bool IsNotNullAndHasItems<T>(this IEnumerable<T> sequence)
    {
        if (sequence == null) return false;
        return sequence.Any();
    }

    /// <summary>
    /// Returns true if the sequence is null or is empty.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> sequence)
    {
        if (sequence == null) return true;
        return !sequence.Any();
    }

    /// <summary>
    /// Returns true if the value is found in the set of specified parameters.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="set"></param>
    /// <returns></returns>
    public static bool In<T>(this T value, params T[] set) where T : IEquatable<T> => set.Any(x => x.Equals(value));

    /// <summary>
    /// Performs a shuffle on the collection using <see cref="Random.Shared"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <remarks>This is an O(n) operation.</remarks>
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
    {
        return collection.OrderBy(x => Random.Shared.Next());
    }
}
