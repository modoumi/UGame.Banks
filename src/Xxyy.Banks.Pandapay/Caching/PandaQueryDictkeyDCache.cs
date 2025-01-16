using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Ocsp;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Caching;
using TinyFx.Extensions.StackExchangeRedis;
using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Pandapay.Caching
{
    public class PandaQueryDictkeyDCache: RedisStringClient<PandaPayRspBase<QueryDictKeyRsp>>
    {
        private const int EXPIRE_DAYS = 3; // 缓存有效期
        private string _queryDictKey;
        public PandaQueryDictkeyDCache(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("PandaQueryDictkeyDCache：key不能为空");
            }
            this._queryDictKey = key;
            RedisKey = GetProjectGroupRedisKey("pandapay",key);
        }

        protected override async Task<CacheValue<PandaPayRspBase<QueryDictKeyRsp>>> LoadValueWhenRedisNotExistsAsync()
        {
            var ret = new CacheValue<PandaPayRspBase<QueryDictKeyRsp>>();
            var result = await new BankProxy().QueryDictKey(new PaySvc.QueryDictKeyIpo
            {
                QueryKey = this._queryDictKey
            });

            if (null == result || result.data == null || result.message != "Success")
            {
                ret.HasValue = false;
            }
            else
            {
                ret.HasValue = true;
                ret.Value = result;
            }
            return ret;
        }
    }
}
