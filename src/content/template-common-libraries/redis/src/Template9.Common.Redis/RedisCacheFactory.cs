using StackExchange.Redis;

namespace Template9.Common.Redis;

public class RedisCacheFactory : IRedisCacheFactory
{
    private readonly ConnectionMultiplexer _multiplexer;

    public RedisCacheFactory(ConnectionMultiplexer multiplexer)
    {
        _multiplexer = multiplexer;
    }

    public IRedisCache CreateClient()
    {
        return new RedisCache(_multiplexer);
    }
}
