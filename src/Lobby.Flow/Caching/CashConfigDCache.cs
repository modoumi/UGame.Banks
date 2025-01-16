//using StackExchange.Redis;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TinyFx.Caching;
//using TinyFx.Extensions.StackExchangeRedis;

//namespace Lobby.Flow.Caching
//{
//    /// <summary>
//    /// 提现配置缓存
//    /// </summary>
//    public class CashConfigDCache : RedisHashExpireClient<Lobby.Flow.DAL.Sc_cash_configEO>
//    {
//        private const int EXPIRE_DAY = 1;

//        public CashConfigDCache()
//        {
//            RedisKey = GetProjectGroupRedisKey("CashConfig");
//        }

//        public static string GetField(string operatorId, string currencyId) => $"{operatorId}|{currencyId}";


//        protected override async Task<CacheValue<CacheItem<Lobby.Flow.DAL.Sc_cash_configEO>>> LoadValueWhenRedisNotExistsAsync(string field)
//        {
//            var ret = new CacheValue<CacheItem<Lobby.Flow.DAL.Sc_cash_configEO>>();
//            ret.Value = new CacheItem<Lobby.Flow.DAL.Sc_cash_configEO>();

//            var keys = field.Split('|');
//            var operatorId = keys[0];
//            var currencyId = keys[1];

//            var mo = new Lobby.Flow.DAL.Sc_cash_configMO();

//            ret.Value.Value = await mo.GetSingleAsync($"OperatorID = @OperatorID and CurrencyId = @CurrencyId", operatorId, currencyId);
//            if (ret.Value.Value == null)
//                throw new Exception($"RouletteConfig.The operatorId({operatorId}) and CurrencyId({currencyId}) data do not exist.");

//            ret.HasValue = ret.Value.Value != null;
//            ret.Value = new CacheItem<Lobby.Flow.DAL.Sc_cash_configEO>(ret.Value.Value, TimeSpan.FromDays(EXPIRE_DAY));

//            return ret;
//        }

//    }
//}
