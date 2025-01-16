using TinyFx.Extensions.StackExchangeRedis;

namespace Lobby.Flow.Caching
{
    public class BankErrorDCache : RedisHashClient<long>
    {
        public BankErrorDCache()
        {
            RedisKey = GetGlobalRedisKey();
        }
    }
}
