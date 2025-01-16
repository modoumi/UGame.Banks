using Google.Protobuf.WellKnownTypes;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Caching;
using TinyFx.Extensions.AutoMapper;
using TinyFx.Extensions.StackExchangeRedis;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Repository;

namespace UGame.Banks.Service.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderPayDCache : RedisStringClient<GetOrderViewDto>
    {
        private const int EXPIRE_MINUTES = 30; // 缓存有效期
        private Sb_bank_orderMO _bankOrderMo = new();
        /// <summary>
        /// 
        /// </summary>
        public string OrderId { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        public OrderPayDCache(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentNullException("OrderPayDCache：orderId不能为空");
            }
            this.OrderId = orderId;
            RedisKey = GetProjectRedisKey(orderId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// 
        public async Task SetOrderAndExpire(GetOrderViewDto order)
        {
            await SetAndExpireMinutesAsync(order, EXPIRE_MINUTES);
        }

        protected override async Task<CacheValue<GetOrderViewDto>> LoadValueWhenRedisNotExistsAsync()
        {
            var ret = new CacheValue<GetOrderViewDto>();
            var bankOrderEo = await _bankOrderMo.GetByPKAsync(this.OrderId);
            if (null == bankOrderEo)
            {
                ret.HasValue = false;
            }
            else
            {
                ret.HasValue = true;
                ret.Value = bankOrderEo.Map<GetOrderViewDto>();
            }
            return ret;
        }
    }
}
