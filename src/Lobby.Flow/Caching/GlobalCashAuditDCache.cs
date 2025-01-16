using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Extensions.StackExchangeRedis;

namespace Lobby.Flow.Caching
{
    internal class GlobalCashAuditDCache : RedisStringClient<bool>
    {
        public GlobalCashAuditDCache()
        {
            RedisKey = GetGlobalRedisKey();
        }
    }
}
