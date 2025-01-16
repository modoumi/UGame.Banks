using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Extensions.StackExchangeRedis;

namespace UGame.Banks.Service.Caching
{
    /// <summary>
    /// orderid订单被处理的次数
    /// </summary>
    public class OrderProcessCountDCache:RedisStringClient<int>
    {
        public string OrderId { get; set; }
        private const int EXPIRE_DAYS = 1; // 缓存有效期
        public OrderProcessCountDCache(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                throw new ArgumentNullException("OrderProcessCountDCache：orderId不能为空");
            OrderId = orderId;
            RedisKey = GetProjectRedisKey(orderId);
        }

        public async Task<double> Increment(double value,CommandFlags flags = CommandFlags.None)
        {
            double ret = await base.Database.StringIncrementAsync(base.RedisKey, value, flags);
            await SetSlidingExpirationAsync(TimeSpan.FromDays(EXPIRE_DAYS));
            return ret;
        }

    }
}
