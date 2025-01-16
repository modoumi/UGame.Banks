using Lobby.Flow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Caching;
using TinyFx.Data.SqlSugar;
using TinyFx.Extensions.StackExchangeRedis;

namespace Lobby.Flow.Caching
{
    public class BraUserBankDCache : RedisStringClient<List<L_bra_user_bankPO>>
    {
        private const int EXPIRE_DAY = 1;

        private string OperatorId { get; set; }

        private string UserId { get; set; }

        public BraUserBankDCache(string operatorId, string userId)
        {
            OperatorId = operatorId;
            UserId = userId;
            RedisKey = GetProjectGroupRedisKey("UserBank", $"{operatorId}:{userId}");
        }

        protected override async Task<CacheValue<List<L_bra_user_bankPO>>> LoadValueWhenRedisNotExistsAsync()
        {
            var ret = new CacheValue<List<L_bra_user_bankPO>>();

            ret.Value = await DbUtil.GetRepository<L_bra_user_bankPO>()
                .AsQueryable()
                .Where(d => d.UserID.Equals(UserId))
                .OrderByDescending(d => d.RecDate)
                .ToListAsync();

            ret.HasValue = ret.Value != null && ret.Value.Any();

            return ret;
        }

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <returns></returns>
        public async Task<CacheValue<List<L_bra_user_bankPO>>> GetAsync()
        {
            return await GetOrLoadAsync(false, TimeSpan.FromDays(EXPIRE_DAY));
        }

        /// <summary>
        /// SetAsync
        /// </summary>
        /// <returns></returns>
        public async Task SetAsync()
        {
            await GetOrLoadAsync(true, TimeSpan.FromDays(EXPIRE_DAY));
        }

    }
}
