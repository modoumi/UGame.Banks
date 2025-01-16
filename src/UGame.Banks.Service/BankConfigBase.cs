using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Caching;
using UGame.Banks.Repository;

namespace UGame.Banks.Service
{
    public abstract class BankConfigBase
    {
        private string _bankId;
        public string BankId
        {
            get
            {
                if (string.IsNullOrEmpty(_bankId))
                {
                    var ns = GetType().Assembly.GetName().Name;
                    var idx = ns.LastIndexOf('.');
                    _bankId = ns.Substring(idx + 1).ToLower();
                }
                return _bankId;
            }
        }
        public virtual string SignHeaderName => "X-Signature";

        public Sb_bankEO Bank => DbBankCacheUtil.GetBank(BankId);
    }
}
