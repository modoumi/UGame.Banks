using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Mlpay.Common
{
    public static class BankProxyUtil
    {
        private static ConcurrentDictionary<string, MlpayBankProxyBase> _countryProxyDict = new();
        public static MlpayBankProxyBase CreateBankProxy(string countryId, string bankId)
        {
            if (!_countryProxyDict.TryGetValue(countryId, out var ret))
            {
                var type = Type.GetType($"UGame.Banks.Mlpay.BankProxy{countryId}");
                ret = Activator.CreateInstance(type, bankId) as MlpayBankProxyBase;
                _countryProxyDict.TryAdd(countryId, ret);
            }
            return ret;
        }
    }
}
