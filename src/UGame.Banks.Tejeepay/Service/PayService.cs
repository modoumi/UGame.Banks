using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Serilog.Enrichers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data;
using TinyFx.Logging;
using UGame.Banks.Service;
using UGame.Banks.Service.Services;
using UGame.Banks.Service.Services.Cash;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Tejeepay.Common;
using UGame.Banks.Tejeepay.Dto;
using UGame.Banks.Tejeepay.Model;
using Xxyy.Banks.DAL;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.DAL;

namespace UGame.Banks.Tejeepay.Service
{
    public class PayService : BankServiceBase,ICashFeeService
    {

        //private readonly Sc_cash_auditMO _cashAuditMo = new();
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
        public async Task<TejeeCommonPayDto> CommpnPay(TejeeCommonPayIpo ipo)
        {
            var ret = BankUtil.CreateDto<TejeeCommonPayDto>(ipo);

            try
            {
                if (ipo.Amount < 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"充值金额Amount必须大于等于0");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                //var userDCache = await GlobalUserDCache.Create(ipo.UserId);
                //var countryId = await userDCache.GetCountryIdAsync();
                //if (countryId == "MEX")
                //{
                //    ipo.BankId = "tejeepay_mex";
                //}

                    //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    ipo.ClientIp = NetUtils.getIp(HttpContextEx.Current);
                    if (string.IsNullOrWhiteSpace(ipo.CountryId))
                    {
                        var userDCache = await GlobalUserDCache.Create(ipo.UserId);
                        var countryId = await userDCache.GetCountryIdAsync();
                        ipo.CountryId = countryId;
                    }
                    if (ipo.CountryId == "MEX")
                    {
                        await new BankProxyMex("tejeepay_mex").CommonPay(ipo, ret);
                    }
                    else
                    {
                        await new BankProxy(ipo.BankId).CommonPay(ipo, ret);
                    }
                };
                await Execute(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Tejeepay, null, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : ex.Message;
                LogUtil.GetContextLogger()
                    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddMessage("通过tejeepay代收异常！")
                    .AddException(ex)
                    .AddField("bank.ipo",SerializerUtil.SerializeJsonNet(ipo))
                    .AddField("bank.dto",SerializerUtil.SerializeJsonNet(ret));
            }
            return ret;
        }

        public decimal Fee(CalcCashFeeIpo ipo)
        {
            if (ipo.UserFeeAmount == 0)
            {
                return ipo.CountryId switch
                {
                    "BRA" => 0,
                    "MEX" => new BankProxyMex("tejeepay_mex").CalcCashFee(ipo.Amount.AToM(ipo.CurrencyId)),
                    _ => throw new ArgumentException("不支持的参数CountryId", nameof(ipo.CountryId))
                };
            }
            return ipo.UserFeeAmount.AToM(ipo.CurrencyId);
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<TejeeProxyPayDto> ProxyPay(TejeeProxyPayIpo ipo)
        {
            var ret = BankUtil.CreateDto<TejeeProxyPayDto>(ipo);
            try
            {
                if (ipo.Amount < 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于等于0");
                if ((ipo.Amount - ipo.UserFeeAmount) <= 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于UserFeeAmount扣除的手续费");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                if (ipo.BizEnum == BizOutEnum.df104 && string.IsNullOrWhiteSpace(ipo.certId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行账号certId不能为空");

                if ((ipo.BizEnum == BizOutEnum.df101|| ipo.BizEnum == BizOutEnum.df103) && string.IsNullOrWhiteSpace(ipo.mobile))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款人手机号mobile不能为空");

                if ((ipo.BizEnum == BizOutEnum.df101|| ipo.BizEnum == BizOutEnum.df103) && string.IsNullOrWhiteSpace(ipo.email))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款人邮箱email不能为空");

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
                    //var userDCache = await GlobalUserDCache.Create(ipo.UserId);
                    //var countryId = await userDCache.GetCountryIdAsync();
                    if (string.IsNullOrWhiteSpace(ipo.CountryId))
                    {
                        ipo.CountryId = await (await GlobalUserDCache.Create(ipo.UserId)).GetCountryIdAsync();
                    }
                    if (ipo.CountryId == "MEX")
                    {
                        await new BankProxyMex("tejeepay_mex").ProxyPay(ipo, ret);
                    }
                    else
                    {
                        await new BankProxy(ipo.BankId).ProxyPay(ipo, ret);
                    }
                };
                await Execute(ipo, ret, OrderTypeEnum.Draw, PayTypeEnum.Tejeepay, null, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : ex.Message;
                LogUtil.GetContextLogger()
                    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddMessage("通过tejeepay代付异常！")
                    .AddException(ex)
                    .AddField("bank.ipo", SerializerUtil.SerializeJsonNet(ipo))
                    .AddField("bank.dto", SerializerUtil.SerializeJsonNet(ret));
            }
            return ret;
        }

        protected override void SetSbBankOrderEo(Sb_bank_orderEO order, PayIpoBase ipo)
        {
            var tejeeProxyPayIpo = (TejeeProxyPayIpo)ipo;
            order.AccName = tejeeProxyPayIpo.bankCardName;
            order.AccNumber = tejeeProxyPayIpo.certId;
            order.BankCode = tejeeProxyPayIpo.bankCode;
        }
    }
}
