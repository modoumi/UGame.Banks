using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using UGame.Banks.Letspay.Ipo;
using UGame.Banks.Service;

namespace UGame.Banks.Letspay
{
    public class BankProxyMEX : LetspayBankProxyBase
    {
        public BankProxyMEX(string bankId) : base(bankId)
        {
        }

        public override decimal CalcCashFee(decimal payMoney)
        {
            var perFee = JObject.Parse(_bank.BankConfig).SelectToken("perFee");
            if (perFee == null)
                throw new Exception("bankconfig种手续费配置错误！缺少perFee");
            return _bank.CashFee * payMoney + perFee.Value<decimal>();
        }

        protected override (string bankCode, string product) GetPayInRequestParam(LetsCommonPayIpo ipo)
        {
            return (ipo.bankCode, "mexbank");
        }

        protected override string GetRemarkInfo(LetsProxyPayIpo ipo)
        {
            //if (ipo.drawMode != "bank" && ipo.drawMode != "clabe")
            //{
            //    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX,$"drawMode：{ipo.drawMode}参数错误");
            //}
            return $"email:{ipo.email}/phone:{ipo.phone}/mode:bank";
        }
    }
}
