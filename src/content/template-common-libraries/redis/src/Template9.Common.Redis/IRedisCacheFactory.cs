namespace Template9.Common.Redis;

public interface IRedisCacheFactory
{
    IRedisCache CreateClient();
}
