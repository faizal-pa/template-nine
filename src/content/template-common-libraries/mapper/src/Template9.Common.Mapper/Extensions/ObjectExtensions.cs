namespace Template9.Common.Mapper.Extensions;

public static class ObjectExtensions
{
    /// <summary>
    /// Maps the object to an object of type <typeparamref name="TDestination"/> using the specified mapper configuration.
    /// </summary>
    /// <typeparam name="TDestination">Destination instance type</typeparam>
    /// <param name="value">The source object to map</param>
    /// <param name="mapperConfiguration">The mapper configuration to use</param>
    /// <returns></returns>
    public static TDestination MapTo<TDestination>(this object value, IAutoMapperConfiguration mapperConfiguration)
    {
        if (mapperConfiguration == null)
            throw new ArgumentException($"Missing required parameters {nameof(mapperConfiguration)}");

        return mapperConfiguration.Mapper.Map<TDestination>(value);
    }

    /// <summary>
    /// Maps an enumeration of instances of type <typeparamref name="T"/> to instances of type <typeparamref name="TDestination"/>.
    /// </summary>
    /// <typeparam name="T">Source instance type</typeparam>
    /// <typeparam name="TDestination">Destination instance type</typeparam>
    /// <param name="sequence">The enumeration of instances to map</param>
    /// <param name="mapperConfiguration">The mapper configuration to use</param>
    /// <returns>An enumeration of mapped <typeparamref name="TDestination"/> instances</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<TDestination> MapTo<T, TDestination>(this IEnumerable<T> sequence, IAutoMapperConfiguration mapperConfiguration)
    {
        if (sequence == null) throw new ArgumentNullException(nameof(sequence), "Unable to map a null enumeration.");

        return (
            from item in sequence
            select item.MapTo<TDestination>(mapperConfiguration)
        ).ToArray();
    }

    /// <summary>
    /// Maps an enumeration of instances into an enumeration of instances of type <typeparamref name="TDestination"/>.
    /// </summary>
    /// <typeparam name="TDestination">The type of instances to return</typeparam>
    /// <param name="sequence">The enumeration of items to map</param>
    /// <param name="mapperConfiguration">The mapper configuration to use</param>
    /// <returns>A sequence of mapped <typeparamref name="TDestination"/> instances</returns>
    public static IEnumerable<TDestination> MapTo<TDestination>(this IEnumerable<object> sequence, IAutoMapperConfiguration mapperConfiguration)
    {
        return sequence.MapTo<object, TDestination>(mapperConfiguration);
    }
}
