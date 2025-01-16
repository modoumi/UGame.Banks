using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.DbCaching;
using UGame.Banks.Client;

namespace UGame.Banks.Client.Caching
{
    internal static class DbCacheUtil
    {

        #region s_app
        public static S_appPO GetApp(string appId, bool exceptionOnNull = true, string errorCode = null)
        {
            var ret = DbCachingUtil.GetSingle<S_appPO>(appId);
            if (ret == null)
            {
                if (exceptionOnNull)
                {
                    if (string.IsNullOrEmpty(errorCode))
                        throw new Exception($"AppId不存在: {appId}");
                    else
                        throw new CustomException(errorCode, $"AppId不存在: {appId}");
                }
                else
                    return null;
            }
            return ret;
        }
        #endregion

        #region s_provider
        public static S_providerPO GetProvider(string providerId, bool excOnNull = true, string errorCode = null)
        {
            var ret = DbCachingUtil.GetSingle<S_providerPO>(providerId);
            if (ret == null)
            {
                if (excOnNull)
                {
                    if (string.IsNullOrEmpty(errorCode))
                        throw new Exception($"providerId不存在: {providerId}");
                    else
                        throw new CustomException(errorCode, $"providerId不存在: {providerId}");
                }
                else
                    return null;
            }
            return ret;
        }
        #endregion

    }
}
