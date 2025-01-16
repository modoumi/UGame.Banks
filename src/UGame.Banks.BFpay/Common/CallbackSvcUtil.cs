using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.BFpay.Service;
using UGame.Banks.BFpay.IpoDto;

namespace UGame.Banks.BFpay.Common
{
    /// <summary>
    /// 回调服务util类
    /// </summary>
    public static class CallbackSvcUtil
    {
        private static ConcurrentDictionary<string, CallbackService> _bankIdCallbackSvcDict = new();
        public static CallbackService Create(string bankId,string countryId)
        {
            if(!_bankIdCallbackSvcDict.TryGetValue(bankId,out CallbackService ret))
            {
                var callbackSvcType = Type.GetType($"UGame.Banks.BFpay.Service.{countryId}CallbackService");
                ret = Activator.CreateInstance(callbackSvcType) as CallbackService;
                if (null == ret)
                    throw new Exception($"创建BFpay回调服务实例{countryId}CallbackService异常！");
                _bankIdCallbackSvcDict.TryAdd(bankId,ret);
            }
            return ret;
        }
    }
}
