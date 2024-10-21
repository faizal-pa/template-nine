using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Template9.Common.Exceptions;

namespace Template9.Common.Redis;

/// <summary>
/// Encapsulates method for adding the Redis client to the dependency injection container.
/// </summary>
public static class CompositionExtensions
{
    /// <summary>
    /// Adds a scoped <see cref="IRedisCache"/> instance ot the service collection.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="ConfigurationException"></exception>
    public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
    {
        if (services.Any(descriptor => descriptor.ServiceType == typeof(RedisMarker)))
            return services;

        var options = configuration.GetSection(RedisOptions.SectionName).Get<RedisOptions>();
        if (options == null || string.IsNullOrEmpty(options.ConnectionString))
            throw new ConfigurationException("Configuration value Redis:ConnectionString not found!");

        services.AddSingleton(ConnectionMultiplexer.Connect(options.ConnectionString));
        services.AddSingleton<IRedisCacheFactory, RedisCacheFactory>();
        services.AddScoped<IRedisCache, RedisCache>();

        services.AddSingleton<RedisMarker>();
        return services;
    }
}
