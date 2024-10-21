using System.Text.Json;
using StackExchange.Redis;
using Template9.Common.Mapper;

namespace Template9.Common.Redis;

public interface IRedisCache
{
    /// <summary>
    /// Gets an instance of <see cref="IServer"/> for using in interacting with the Redis cache instance.
    /// </summary>
    IServer Server { get; }

    /// <summary>
    /// Gets an instance of <see cref="IDatabase"/> for using in interacting with the Redis cache instance.
    /// </summary>
    IDatabase Database { get; }

    /// <summary>
    /// Removes the specified key. A key is ignored if it does not exist.
    /// </summary>
    /// <param name="key">The key to delete.</param>
    /// <returns><see langword="true"/> if the key was removed.</returns>
    Task<bool> DeleteKeyAsync(string key);

    /// <summary>
    /// Removes the specified keys. A key is ignored if it does not exist.
    /// </summary>
    /// <param name="keys">The keys to delete.</param>
    /// <returns>The number of keys that were removed.</returns>
    Task<long> DeleteKeysAsync(string[] keys);

    /// <summary>
    /// Returns all instance of type T by mapping the hash from from any key matching the specified pattern.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pattern"></param>
    /// <param name="mapperConfiguration"></param>
    /// <remarks>For wildcard searching, the pattern must end with an asterisk (*).</remarks>
    Task<IEnumerable<T>> GetAllHashAsync<T>(string pattern, IAutoMapperConfiguration mapperConfiguration);

    /// <summary>
    /// Returns all instances of type T by deserializing the JSON stored at any key matching the specified pattern.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pattern"></param>
    /// <remarks>For wildcard searching, the pattern must end with an asterisk (*).</remarks>
    Task<IEnumerable<T>> GetAllJsonAsync<T>(string pattern);

    /// <summary>
    /// Returns all instances of type T by deserializing the JSON stored at any key matching the specified pattern.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pattern"></param>
    /// <param name="options"></param>
    /// <remarks>For wildcard searching, the pattern must end with an asterisk (*).</remarks>
    Task<IEnumerable<T>> GetAllJsonAsync<T>(string pattern, JsonSerializerOptions options);

    /// <summary>
    /// Returns a enumerable of keys that match the specified pattern.
    /// </summary>
    /// <param name="pattern"></param>
    /// <remarks>For wildcard searching, the pattern must end with an asterisk (*).</remarks>
    IEnumerable<string> GetAllKeys(string pattern);

    /// <summary>
    /// Returns an instance of type T by mapping the hash stored at the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="mapperConfiguration"></param>
    /// <returns></returns>
    Task<T?> GetHashAsync<T>(string key, IAutoMapperConfiguration mapperConfiguration);

    /// <summary>
    /// Returns an instance of type T by deserializing the JSON stored at the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<T?> GetJsonAsync<T>(string key);

    /// <summary>
    /// Returns an instance of type T by deserializing the JSON stored at the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    Task<T?> GetJsonAsync<T>(string key, JsonSerializerOptions options);

    /// <summary>
    /// Serializes the instance of type T to a hash stored in Redis at the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="mapperConfiguration"></param>
    /// <returns></returns>
    Task SetHashAsync<T>(string key, T value, IAutoMapperConfiguration mapperConfiguration);

    /// <summary>
    /// Serializes the instance of type T to a hash stored in Redis at the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expiry"></param>
    /// <param name="mapperConfiguration"></param>
    /// <returns></returns>
    Task SetHashAsync<T>(string key, T value, TimeSpan expiry, IAutoMapperConfiguration mapperConfiguration);

    /// <summary>
    /// Serializes the instance of type T to JSON and stores in Redis at the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task SetJsonAsync<T>(string key, T value);

    /// <summary>
    /// Serializes the instance of type T to JSON and stores in Redis at the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expiry"></param>
    /// <returns></returns>
    Task SetJsonAsync<T>(string key, T value, TimeSpan expiry);

    /// <summary>
    /// Serializes the instance of type T to JSON and stores in Redis at the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    Task SetJsonAsync<T>(string key, T value, JsonSerializerOptions options);

    /// <summary>
    /// Serializes the instance of type T to JSON and stores in Redis at the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expiry"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    Task SetJsonAsync<T>(string key, T value, TimeSpan expiry, JsonSerializerOptions options);
}
