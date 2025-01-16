using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.BFpay.Common
{
    public static class BankProxyUtil
    {
        private static ConcurrentDictionary<string, BfpayBankProxyBase> _countryProxyDict = new();
        public static BfpayBankProxyBase CreateBankProxy(string countryId, string bankId)
        {
            if (!_countryProxyDict.TryGetValue(countryId, out var ret))
            {
                var type = Type.GetType($"UGame.Banks.BFpay.BankProxy{countryId}");
                ret = Activator.CreateInstance(type, bankId) as BfpayBankProxyBase;
                _countryProxyDict.TryAdd(countryId, ret);
            }
            return ret;
        }
    }
}
