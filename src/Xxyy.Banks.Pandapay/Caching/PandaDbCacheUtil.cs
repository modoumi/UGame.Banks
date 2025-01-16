using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xxyy.Banks.DAL;
using Xxyy.Banks.Pandapay.PaySvc;

namespace Xxyy.Banks.Pandapay.Caching
{
    public static class PandaDbCacheUtil
    {
        private static PandaPayRspBase<IEnumerable<QueryBankListRsp>> _banks;
        public static PandaPayRspBase<IEnumerable<QueryBankListRsp>> Banks
        {
            get
            {
                if (_banks == null)
                {
                    var proxy = new BankProxy();
                    var bankList = proxy.QueryBankList().GetAwaiter().GetResult();
                    _banks = bankList;
                }
                return _banks;
            }
        }
    }
}
