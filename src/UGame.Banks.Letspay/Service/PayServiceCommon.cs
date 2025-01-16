using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data;
using UGame.Banks.Letspay.Common;
using UGame.Banks.Letspay.Ipo;
using UGame.Banks.Service;
using UGame.Banks.Service.Services;
using UGame.Banks.Service.Services.Cash;
using UGame.Banks.Service.Services.Pay;
using Xxyy.Banks.DAL;
using Xxyy.Common;
using Xxyy.Common.Caching;

using Xxyy.DAL;

namespace UGame.Banks.Letspay.Service
{
    public class PayServiceCommon:BankServiceBase,ICashFeeService
    {
        private readonly Sc_cash_auditMO _cashAuditMo = new();
        //private HttpContext _httpContext;

        ///// <summary>
        ///// 构造函数
        ///// </summary>
        //public PayServiceCommon()
        //{
        //    _httpContext = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext;
        //}

        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        public async Task<LetsCommonPayDto> CommpnPay(LetsCommonPayIpo ipo)
        {
            var ret = BankUtil.CreateDto<LetsCommonPayDto>(ipo);
            
            try
            {
                var targetBankId = "letspay_" + ipo.CountryId.ToLower();
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
                    // await new BankProxyMex(ipo.BankId).CommonPay(ipo, ret);
                    var bankProxy = BankProxyUtil.CreateBankProxy(ipo.CountryId,ipo.BankId);
                    await bankProxy.CommonPay(ipo,ret);
                };
                await Execute(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Letspay, null, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
            }
            catch (Exception ex)
            {
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
                var targetBankId = "letspay_" + ipo.CountryId.ToLower();
                if (ipo.CountryId == "MEX" && ipo.BankId != targetBankId)
                {
                    ipo.BankId = targetBankId;
                }
                return ipo.CountryId switch
                {
                    "BRA" => 0,
                    "MEX" => BankProxyUtil.CreateBankProxy(ipo.CountryId, ipo.BankId).CalcCashFee(ipo.Amount.AToM(ipo.CurrencyId)),
                    _ => throw new ArgumentException("不支持的参数CountryId", nameof(ipo.CountryId))
                };
            }
            return ipo.UserFeeAmount.AToM(ipo.CurrencyId);
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<LetsProxyPayDto> ProxyPay(LetsProxyPayIpo ipo)
        {
            var ret = BankUtil.CreateDto<LetsProxyPayDto>(ipo);
            try
            {
                var targetBankId = "letspay_" + ipo.CountryId.ToLower();
                if (ipo.BankId != targetBankId)
                    ipo.BankId = targetBankId;
                if (ipo.Amount <= 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于等于0");
                if((ipo.Amount - ipo.UserFeeAmount)<=0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于UserFeeAmount扣除的手续费");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                if (string.IsNullOrWhiteSpace(ipo.accountName))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行账号accountName不能为空");

                if (string.IsNullOrWhiteSpace(ipo.accountNo))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行代码accountNo不能为空");

                if (string.IsNullOrWhiteSpace(ipo.bankCode))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现bankCode不能为空");

                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    //await new BankProxyMex(ipo.BankId).ProxyPay(ipo, ret);
                    var bankProxy = BankProxyUtil.CreateBankProxy(ipo.CountryId,ipo.BankId);
                    await bankProxy.ProxyPay(ipo,ret);
                };
                await Execute(ipo, ret, OrderTypeEnum.Draw, PayTypeEnum.Letspay, null, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : ex.Message;
            }
            return ret;
        }

        protected override void SetSbBankOrderEo(Sb_bank_orderEO order, PayIpoBase ipo)
        {
            var letsProxyPayIpo = (LetsProxyPayIpo)ipo;
            order.AccName = letsProxyPayIpo.accountName;
            order.AccNumber = letsProxyPayIpo.accountNo;
            order.BankCode = letsProxyPayIpo.bankCode;
        }
    }
}
