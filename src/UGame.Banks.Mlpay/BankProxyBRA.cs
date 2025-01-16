using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using UGame.Banks.Mlpay.IpoDto;
using UGame.Banks.Service;

namespace UGame.Banks.Mlpay
{
    public class BankProxyBRA : MlpayBankProxyBase
    {
        public BankProxyBRA(string bankId) : base(bankId)
        {
        }

        protected override int MULTIPLE { get; set; } = 100;

        protected override decimal CalcCashFee(decimal payMoney)
        {
            return 0;
        }

        protected override (string bankCode, string identityNo) GetPayInRequestParam(MlpayPayIpo ipo)
        {
            return (null, ipo.TaxId);
        }

        protected override int GetReceiptMode(MlpayCashIpo ipo)
        {
            return ipo.BankCode switch
            {
                "CPF" => 0,
                "CNPJ" => 1,
                "PHONE" => 2,
                "EMAIL" => 3,
                "EVP" => 4,
                _ => throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"{nameof(ipo.BankCode)}:{ipo.BankCode}参数错误！")
            };
        }
    }
}
