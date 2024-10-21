using System.Text.Json;
using StackExchange.Redis;
using Template9.Common.Mapper;
using Template9.Common.Mapper.Extensions;

namespace Template9.Common.Redis;

public class RedisCache : IRedisCache
{
    private readonly ConnectionMultiplexer _multiplexer;

    private IServer _server = null!;
    private IDatabase _database = null!;

    public RedisCache(ConnectionMultiplexer multiplexer)
    {
        _multiplexer = multiplexer;
    }

    public IServer Server
    {
        get
        {
            _server ??= _multiplexer.GetServers().First();
            return _server;
        }
    }

    public IDatabase Database
    {
        get
        {
            _database ??= _multiplexer.GetDatabase();
            return _database;
        }
    }

    public async Task<bool> DeleteKeyAsync(string key)
    {
        return await Database.KeyDeleteAsync(key);
    }

    public async Task<long> DeleteKeysAsync(string[] keys)
    {
        var redisKeys = Array.ConvertAll(keys, key => (RedisKey)key);
        return await Database.KeyDeleteAsync(redisKeys);
    }

    public async Task<IEnumerable<T>> GetAllHashAsync<T>(string pattern, IAutoMapperConfiguration mapperConfiguration)
    {
        var tasks = Server.Keys(pattern: pattern)
            .Select(k => Database.HashGetAllAsync(k));

        var hashEntries = await Task.WhenAll(tasks);

        var results = hashEntries
            .Select(h => h.MapTo<T>(mapperConfiguration));

        return results;
    }

    public async Task<IEnumerable<T>> GetAllJsonAsync<T>(string pattern)
    {
        var tasks = Server.Keys(pattern: pattern)
            .Select(k => Database.StringGetAsync(k));

        var results = await Task.WhenAll(tasks);
        List<T> values = [];

        foreach (var result in results)
        {
            if (result.IsNull) continue;
            var value = JsonSerializer.Deserialize<T>(result.ToString());
            if (value != null) values.Add(value);
        }

        return values;
    }

    public async Task<IEnumerable<T>> GetAllJsonAsync<T>(string pattern, JsonSerializerOptions options)
    {
        var tasks = Server.Keys(pattern: pattern)
            .Select(k => Database.StringGetAsync(k));

        var results = await Task.WhenAll(tasks);
        List<T> values = [];

        foreach (var result in results)
        {
            if (result.IsNull) continue;
            var value = JsonSerializer.Deserialize<T>(result.ToString(), options);
            if (value != null) values.Add(value);
        }

        return values;
    }

    public IEnumerable<string> GetAllKeys(string pattern)
    {
        return Server.Keys(pattern: pattern)
            .Select(r => r.ToString());
    }

    public async Task<T?> GetHashAsync<T>(string key, IAutoMapperConfiguration mapperConfiguration)
    {
        var result = await Database.HashGetAllAsync(key);
        if (result.Length == 0) return default;
        return result.MapTo<T>(mapperConfiguration);
    }

    public async Task<T?> GetJsonAsync<T>(string key)
    {
        var result = await Database.StringGetAsync(key);
        if (result.IsNull) return default;
        return JsonSerializer.Deserialize<T>(result.ToString());
    }

    public async Task<T?> GetJsonAsync<T>(string key, JsonSerializerOptions options)
    {
        var result = await Database.StringGetAsync(key);
        if (result.IsNull) return default;
        return JsonSerializer.Deserialize<T>(result.ToString(), options);
    }

    public async Task SetHashAsync<T>(string key, T value, IAutoMapperConfiguration mapperConfiguration)
    {
        if (value == null) throw new ArgumentNullException(nameof(value), "Value cannot be null");
        var hash = value.MapTo<HashEntry[]>(mapperConfiguration);
        await Database.HashSetAsync(key, hash);
    }

    public async Task SetHashAsync<T>(string key, T value, TimeSpan expiry, IAutoMapperConfiguration mapperConfiguration)
    {
        if (value == null) throw new ArgumentNullException(nameof(value), "Value cannot be null");
        var hash = value.MapTo<HashEntry[]>(mapperConfiguration);
        await Database.HashSetAsync(key, hash);
        await Database.KeyExpireAsync(key, expiry);
    }

    public async Task SetJsonAsync<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize<T>(value);
        await Database.StringSetAsync(key, json);
    }

    public async Task SetJsonAsync<T>(string key, T value, TimeSpan expiry)
    {
        var json = JsonSerializer.Serialize<T>(value);
        await Database.StringSetAsync(key, json, expiry);
    }

    public async Task SetJsonAsync<T>(string key, T value, JsonSerializerOptions options)
    {
        var json = JsonSerializer.Serialize<T>(value, options);
        await Database.StringSetAsync(key, json);
    }

    public async Task SetJsonAsync<T>(string key, T value, TimeSpan expiry, JsonSerializerOptions options)
    {
        var json = JsonSerializer.Serialize<T>(value, options);
        await Database.StringSetAsync(key, json, expiry);
    }
}
