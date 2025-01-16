using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.BFpay.IpoDto;

namespace UGame.Banks.BFpay.Service
{
    internal class BRACallbackService : CallbackService
    {
        public override decimal GetPayFee(BankCallbackContext context)
        {
            var bankEo = DbBankCacheUtil.GetBank(context.OrderEo.BankID);
            if (string.IsNullOrWhiteSpace(bankEo.BankConfig))
                throw new ArgumentNullException(nameof(bankEo.BankConfig), $"bankId:{context.OrderEo.BankID}对应的配置bankconfig不能为空！");
            return context.OrderEo.OrderMoney * bankEo.PayFee;
        }

    }
}
