using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data;
using Xxyy.Banks.BLL;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.DAL;
using Xxyy.Banks.Orionpay.Common;
using Xxyy.Banks.Orionpay.Dto;
using Xxyy.Banks.Orionpay.Ipo;
using Xxyy.Banks.Orionpay.Model;
using Xxyy.Common;

using Xxyy.DAL;

namespace Xxyy.Banks.Orionpay.Service
{
    public class PayService : BankServiceBase
    {
        private static readonly Sb_bank_orderMO _bankOrderMo = new();
        private readonly Sc_cash_auditMO _cashAuditMo = new();
        private HttpContext _httpContext;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PayService()
        {
            _httpContext = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext;
        }

        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        public async Task<OrionCommonPayDto> CommpnPay(OrionCommonPayIpo ipo)
        {
            var ret = BankUtil.CreateDto<OrionCommonPayDto>(ipo);

            try
            {
                if (ipo.Amount < 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"充值金额Amount必须大于等于0");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    ipo.ClientIp = NetUtils.getIp(_httpContext);
                    await new BankProxy(ipo.BankId).CommonPay(ipo, ret);
                };
                await Execute(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Orionpay, _httpContext.Request.Path.Value, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
            }
            return ret;
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<OrionProxyPayDto> ProxyPay(OrionProxyPayIpo ipo)
        {
            var ret = BankUtil.CreateDto<OrionProxyPayDto>(ipo);
            try
            {
                if (ipo.Amount < 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于等于0");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                if (string.IsNullOrWhiteSpace(ipo.certValue))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行账号certId不能为空");

                if (string.IsNullOrWhiteSpace(ipo.identifyValue))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行代码bankCardNo不能为空");

                if (string.IsNullOrWhiteSpace(ipo.cashAuditId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现审核编号不能为空");



                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    if (!string.IsNullOrWhiteSpace(ipo.cashAuditId))
                    {
                        var cashAuditEo = await _cashAuditMo.GetByPKAsync(ipo.cashAuditId);
                        if (null == cashAuditEo)
                            throw new CustomException($"参数异常!CashAuditId:{ipo.cashAuditId}");
                        if (cashAuditEo.Status != 0)
                            throw new CustomException($"参数异常!CashAuditId:{ipo.cashAuditId},已审核");
                        var userEo= await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId, tm);
                        if(null==userEo)
                            throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"userEo为null,参数userId:{ipo.UserId}错误");
                        ret.EndBalance = userEo.Cash;
                        ret.EndBonus =userEo.Bonus;
                    }
                    else
                    {
                        //账户余额是否满足
                        var userEo = await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId, tm, true);
                        if (ipo.Amount > userEo.Cash)
                            throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额");
                        //扣账户
                        var rows = await DbSink.BuildUserMo(ipo.UserId).PutAsync("Cash=Cash-@Amount,Bonus=Bonus-(case when Bonus>=@Amount then @Amount else Bonus end)", "UserID=@UserID and Cash>=@amount2 and (Bonus-(case when Bonus>=@Amount then @Amount else Bonus end))>=0", tm, ipo.Amount, ipo.UserId, ipo.Amount);
                        if (rows <= 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额");

                        //获取最新账户
                        ret.EndBalance = await DbSink.BuildUserMo(ipo.UserId).GetCashByPKAsync(ipo.UserId, tm);
                        if (ret.EndBalance < 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额");
                    }

                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    await new BankProxy(ipo.BankId).ProxyPay(ipo, ret);

                };
                await Execute(ipo, ret, OrderTypeEnum.Draw, PayTypeEnum.Orionpay, _httpContext.Request.Path.Value, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
            }
            return ret;
        }

        public async Task<QRCodeDto> GetQRCode(QRCodeIpo ipo)
        {
            string bankOrderId = ipo.BankOrderId;
            var order = await _bankOrderMo.GetSingleAsync("BankOrderID=@bankOrderId", bankOrderId);
            QRCodeDto result = new QRCodeDto();
            string meta = order.Meta;
            if(!string.IsNullOrEmpty(meta))
            {
                var jo = JObject.Parse(meta);
                result.qrCode = jo["brcode"]?.ToString();
                result.brCode = jo["brcode"]?.ToString();
            }
            return result;
        }
        protected override void SetSbBankOrderEo(Sb_bank_orderEO order, PayIpoBase ipo)
        {
            var orionProxyPayIpo = (OrionProxyPayIpo)ipo;
            order.AccName = orionProxyPayIpo.name;
            order.AccNumber = orionProxyPayIpo.identifyValue;
            order.BankCode = "";
        }
    }
}
