using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Caching;

namespace UGame.Banks.Letspay.Service
{
    public class MexCallbackService : MexCallbackServiceBase
    {
        //public const decimal PERFEE = 3.0m;
        public override decimal GetPayFee(decimal money, string bankId)
        {
            var bankEo = DbBankCacheUtil.GetBank(bankId);
            if (string.IsNullOrWhiteSpace(bankEo.BankConfig))
                throw new ArgumentNullException(nameof(bankEo.BankConfig),$"bankId:{bankId}对应的配置bankconfig不能为空！");
            var perFee = JObject.Parse(bankEo.BankConfig).SelectToken("perFee");
            if (null == perFee)
                throw new Exception($"bankConfig配置错误！perFee手续费配置不能为空！");
            return (money * bankEo.PayFee)+perFee.Value<decimal>();
        }
    }
}
