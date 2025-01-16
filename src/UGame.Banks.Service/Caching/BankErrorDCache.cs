using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Extensions.StackExchangeRedis;

namespace UGame.Banks.Service.Caching
{
    /// <summary>
    /// Bank合作渠道调用异常计数缓存(field---tejeepay,value--1)
    /// </summary>
    public class BankErrorDCache:RedisHashClient<long>
    {
        /// <summary>
        /// 
        /// </summary>
        public BankErrorDCache()
        {
            RedisKey = GetGlobalRedisKey();
        }

        /// <summary>
        /// 原子递增field字段值
        /// </summary>
        /// <param name="bankId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task IncrError(string bankId,long value=1)
        {
             var result= await this.IncerementAsync(bankId,value);
            if (result < 0)
                await this.SetAsync(bankId,0);
        }
    }
}
