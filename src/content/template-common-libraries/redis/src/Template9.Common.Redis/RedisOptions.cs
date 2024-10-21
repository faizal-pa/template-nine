namespace Template9.Common.Redis;

/// <summary>
/// Options for configuring the Redis client via injected configuration.
/// </summary>
public class RedisOptions
{
    /// <summary>
    /// The configuration section name to deserialize the options from.
    /// </summary>

    public static readonly string SectionName = "Redis";

    /// <summary>
    /// Redis connection string.
    /// </summary>
    public string ConnectionString { get; set; } = null!;
}
