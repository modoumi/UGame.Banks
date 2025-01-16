//using StackExchange.Redis;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TinyFx.Caching;
//using TinyFx.Data.SqlSugar;
//using TinyFx.Extensions.StackExchangeRedis;

//namespace Lobby.Flow.Caching
//{
//    /// <summary>
//    /// 当前OperatorId下的所有数据
//    /// </summary>
//    public class PayConfigDCache : RedisHashExpireClient<List<Lobby.Flow.DAL.L_pay_configPO>>
//    {
//        private const int EXPIRE_DAY = 1;

//        public PayConfigDCache()
//        {
//            RedisKey = GetProjectGroupRedisKey("PayConfig");
//        }

//        public static string GetField(string operatorId, string currencyId) => $"{operatorId}|{currencyId}";


//        protected override async Task<CacheValue<CacheItem<List<Lobby.Flow.DAL.L_pay_configPO>>>> LoadValueWhenRedisNotExistsAsync(string field)
//        {
//            var keys = field.Split('|');
//            var operatorId = keys[0];
//            var currencyId = keys[1];

//            var value = await DbUtil.GetRepository<Lobby.Flow.DAL.L_pay_configPO>().AsQueryable()
//                .Where(d => d.OperatorID.Equals(operatorId) && d.CurrencyID.Equals(currencyId))
//                .ToListAsync();

//            if (value == null)
//                throw new Exception($"PayConfig.The operatorId({operatorId}) and CurrencyId({currencyId}) data do not exist.");

//            var ret = new CacheValue<CacheItem<List<Lobby.Flow.DAL.L_pay_configPO>>>();
//            ret.HasValue = value != null && value.Any();
//            ret.Value = new CacheItem<List<Lobby.Flow.DAL.L_pay_configPO>>(value, TimeSpan.FromDays(EXPIRE_DAY));

//            return ret;
//        }

//        /// <summary>
//        /// GetAsync
//        /// </summary>
//        /// <param name="operatorId"></param>
//        /// <param name="currencyId"></param>
//        /// <returns></returns>
//        public async Task<List<Lobby.Flow.DAL.L_pay_configPO>> GetAsync(string operatorId, string currencyId)
//        {
//            var ret = new List<Lobby.Flow.DAL.L_pay_configPO>();

//            var field = GetField(operatorId, currencyId);
//            var payConfigDCache = await GetOrLoadAsync(field);

//            if (payConfigDCache.HasValue)
//                ret = payConfigDCache.Value;

//            return ret;
//        }

//    }
//}
