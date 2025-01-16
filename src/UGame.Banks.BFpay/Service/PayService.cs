using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data;
using UGame.Banks.Service;
using UGame.Banks.Service.Services.Pay;
using Xxyy.Banks.DAL;
using TinyFx.Logging;
using UGame.Banks.BFpay.Common;
using UGame.Banks.BFpay.IpoDto;
using UGame.Banks.Service.Services;
using UGame.Banks.Service.Services.Cash;
using Xxyy.Common;

namespace UGame.Banks.BFpay.Service
{
    public class PayService:BankServiceBase,ICashFeeService
    {
        //private HttpContext _httpContext;

        ///// <summary>
        ///// 构造函数
        ///// </summary>
        //public PayService()
        //{
        //    _httpContext = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext;
        //}

        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        public async Task<BfpayPayDto> CommpnPay(BfpayPayIpo ipo)
        {
            var ret = BankUtil.CreateDto<BfpayPayDto>(ipo);

            try
            {
                var targetBankId = "bfpay_" + ipo.CountryId.ToLower();
                if (ipo.BankId != targetBankId)
                    ipo.BankId = targetBankId;

                if (ipo.Amount < 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"充值金额Amount必须大于等于0");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    var bankProxy = BankProxyUtil.CreateBankProxy(ipo.CountryId, ipo.BankId);
                    await bankProxy.CommonPay(ipo, ret);
                };
                await Execute(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Bfpay, null, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
            }
            catch (Exception ex)
            {
                LogUtil.GetContextLogger()
    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
    .AddMessage("通过bfpay代收异常！")
    .AddException(ex)
    .AddField("bank.ipo", SerializerUtil.SerializeJsonNet(ipo))
    .AddField("bank.dto", SerializerUtil.SerializeJsonNet(ret));

                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : ex.Message;


            }
            return ret;
        }

        public decimal Fee(CalcCashFeeIpo ipo)
        {
            if (ipo.UserFeeAmount == 0)
            {
                return 0;
            }
            return ipo.UserFeeAmount.AToM(ipo.CurrencyId);
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<BfpayCashDto> ProxyPay(BfpayCashIpo ipo)
        {
            var ret = BankUtil.CreateDto<BfpayCashDto>(ipo);
            try
            {
                var targetBankId = "bfpay_" + ipo.CountryId.ToLower();
                if (ipo.BankId != targetBankId)
                    ipo.BankId = targetBankId;
                if (ipo.Amount <= 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于等于0");
                if ((ipo.Amount - ipo.UserFeeAmount) <= 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于UserFeeAmount扣除的手续费");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                if (string.IsNullOrWhiteSpace(ipo.certId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行账号certId不能为空");

                if (string.IsNullOrWhiteSpace(ipo.bankCardNo))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行代码bankCardNo不能为空");

                if (ipo.certType == 5 && string.IsNullOrWhiteSpace(ipo.bankCode))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款账号名称bankCode不能为空");

                if (string.IsNullOrWhiteSpace(ipo.bankCardName))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款账号名称bankCardName必须大于0");

                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    var bankProxy = BankProxyUtil.CreateBankProxy(ipo.CountryId, ipo.BankId);
                    await bankProxy.ProxyPay(ipo, ret);
                };
                await Execute(ipo, ret, OrderTypeEnum.Draw, PayTypeEnum.Bfpay, null, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
            }
            catch (Exception ex)
            {
                LogUtil.GetContextLogger()
.SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
.AddMessage("通过bfpay代付异常！")
.AddException(ex)
.AddField("bank.ipo", SerializerUtil.SerializeJsonNet(ipo))
.AddField("bank.dto", SerializerUtil.SerializeJsonNet(ret));


                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : ex.Message;
            }
            return ret;
        }

        protected override void SetSbBankOrderEo(Sb_bank_orderEO order, PayIpoBase ipo)
        {
            var payIpo = (BfpayCashIpo)ipo;
            order.AccName = payIpo.bankCardName;
            order.AccNumber = payIpo.certId;
            order.BankCode = payIpo.certId;
        }
    }
}
