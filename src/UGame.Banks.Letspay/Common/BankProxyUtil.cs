using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Common
{
    public static class BankProxyUtil
    {
        private static ConcurrentDictionary<string, LetspayBankProxyBase> _countryProxyDict = new();
        public static LetspayBankProxyBase CreateBankProxy(string countryId,string bankId)
        {
            if (!_countryProxyDict.TryGetValue(countryId,out var ret))
            {
                var type = Type.GetType($"UGame.Banks.Letspay.BankProxy{countryId}");
                ret = Activator.CreateInstance(type,bankId) as LetspayBankProxyBase;
                _countryProxyDict.TryAdd(countryId,ret);
            }
            return ret;
        }
    }
}
