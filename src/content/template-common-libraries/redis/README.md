# Template9.Common.Redis

Extension methods for using StackExchange.Redis in projects. Using the extension method will read the Redis connection string from the configuration provider, instantiate a [ConnectionMultiplexer](https://github.com/StackExchange/StackExchange.Redis/blob/main/src/StackExchange.Redis/ConnectionMultiplexer.cs), and inject a factory to provide scoped instances of an [IRedisCache](./Template9.Common.Redis/IRedisCache.cs).

> Note: The usage information below applies to a single instance implementation of Redis. For cluster implementations, inject the ConnectionMultiplexer instead.

## Usage

Add the connection string to the appropriate configuration provider.

```json
{
    "Redis": {
        "ConnectionString": "<connection string goes here>"
    }
}
```

Add Redis to the dependency injection container.

```csharp
builder.Services.AddRedisCache(builder.Configuration);
```

Inject `IRedisCache` into a service.

```csharp
public class CacheClient
{
    private readonly IRedisCache _redisCache;

    public CacheClient(IRedisCache redisCache)
    {
        _redisCache = redisCache;
    }
}
```
# IRedisCacheFactory

IRedisCache is injected as a scoped dependency. If you need to get an instance of IRedisCache in a singleton, inject the IRedisCacheFactory and use it to create instances as needed.

# IRedisCache

This interface wraps access to the default server and default database, and contains a number of convenience methods for storing and retrieving objects from the Redis cache. [StackExchange.Redis](https://stackexchange.github.io/StackExchange.Redis/) contains the full documentation for using these interfaces.

## Properties

| Name     | Description                                              |
|----------|----------------------------------------------------------|
| Database | An instance of [StackExchange.Redis.IServer][server]     |
| Server   | An instance of [StackExchange.Redis.IDatabase][database] |

[server]: https://github.com/StackExchange/StackExchange.Redis/blob/main/src/StackExchange.Redis/Interfaces/IServer.cs
[database]: https://github.com/StackExchange/StackExchange.Redis/blob/main/src/StackExchange.Redis/Interfaces/IDatabase.cs

## Methods

Many operations can be completed directly by access the available methods of `IRedisCache.Database` or `IRedisCache.Server`. The methods provided below are for convenience in completing common serialization/deserialization tasks with objects. If they do not meet your specific needs, do not use them.

| Method          | Description                                                                                                 |
|-----------------|-------------------------------------------------------------------------------------------------------------|
| GetAllHashAsync | Returns all instances of a type by mapping the hash from from all keys matching the specified pattern       |
| GetAllJsonAsync | Returns all instances of a type by deserializing the JSON stored at all keys matching the specified pattern |
| GetAllKeys      | Returns a enumerable of keys that match the specified pattern                                               |
| GetHashAsync    | Returns an instance of a type by mapping the hash stored at the specified key                               |
| GetJsonAsync    | Returns an instance of a type by deserializing the JSON stored at the specified key                         |
| SetHashAsync    | Serializes the instance of a type to a hash and stores in Redis at the specified key                        |
| SetJsonAsync    | Serializes the instance of a type to JSON and stores in Redis at the specified key                          |

## When To Use a Hash

Use a string (or an object serialized to a JSON string) when:
- storing simple key-value pairs where the value is a single, indivisible piece of data
- your operations require manipulating the entire value
- performing atomic operations

Use a hash when:
-  logically grouping related data under a single key
- storing objects or records where you need to access and modify individual fields

## Json Serialization

This package uses [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/api/system.text.json?view=net-8.0) to perform serialization and deserialization of objects. Each method that performs any JSON related operation has an overload that takes an instance of [JsonSerializationOptions](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions?view=net-8.0) that will allow you to control how those operations occur.

## AutoMapper Configuration

To use the Hash methods, you will need to have [AutoMapper](https://www.nuget.org/packages/AutoMapper) profiles in the [IAutoMapperConfiguration](https://github.com/Template9fsi/lib-dotnet-common-mapper) that maps between `HashEntry[]` and your desired classes. Use the following example to create those profiles.

### Model

```csharp
public class Movie
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = null!;

    public int Year { get; set; }

    public int UpVotes { get; set; }
}
```

### AutoMapper Profile

```csharp
public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, HashEntry[]>()
            .ConvertUsing<MovieToHashEntryConverter>();

        CreateMap<HashEntry[], Movie>()
            .ConvertUsing<HashEntryToMovieConverter>();
    }
}

public class MovieToHashEntryConverter : ITypeConverter<Movie, HashEntry[]>
{
    public HashEntry[] Convert(Movie source, HashEntry[] destination, ResolutionContext context)
    {
        var entries = new List<HashEntry>
        {
            new(new RedisValue(nameof(Movie.Id)), new RedisValue(source.Id.ToString())),
            new(new RedisValue(nameof(Movie.Title)), new RedisValue(source.Title)),
            new(new RedisValue(nameof(Movie.Year)), new RedisValue(source.Year.ToString())),
            new(new RedisValue(nameof(Movie.UpVotes)), new RedisValue(source.UpVotes.ToString()))
        };

        destination = [.. entries];

        return destination;
    }
}

public class HashEntryToMovieConverter : ITypeConverter<HashEntry[], Movie>
{
    public Movie Convert(HashEntry[] source, Movie destination, ResolutionContext context)
    {
        destination = new Movie();

        foreach (var entry in source)
        {
            if (entry.Value.IsNull) continue;

            switch (entry.Name)
            {
                case nameof(Movie.Id):
                    destination.Id = Guid.Parse(entry.Value.ToString());
                    break;
                case nameof(Movie.Title):
                    destination.Title = entry.Value.ToString();
                    break;
                case nameof(Movie.Year):
                    if (int.TryParse(entry.Value.ToString(), out var year))
                        destination.Year = year;
                    break;
                case nameof(Movie.UpVotes):
                    if (int.TryParse(entry.Value.ToString(), out var upVotes))
                        destination.UpVotes = upVotes;
                    break;
                default:
                    break;
            }
        }

        return destination;
    }
}
```