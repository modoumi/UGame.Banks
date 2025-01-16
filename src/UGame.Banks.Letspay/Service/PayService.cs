using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data;
using TinyFx.Logging;
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
    public class PayService:BankServiceBase,ICashFeeService
    {
        //private static readonly Sb_bank_orderMO _bankOrderMo = new();
        private readonly Sc_cash_auditMO _cashAuditMo = new();
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
        public async Task<LetsCommonPayDto> CommpnPay(LetsCommonPayIpo ipo)
        {
            var ret = BankUtil.CreateDto<LetsCommonPayDto>(ipo);

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
                    //ipo.ClientIp = NetUtils.getIp(_httpContext);
                    await new BankProxy(ipo.BankId).CommonPay(ipo, ret);
                };
                await Execute(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Letspay, null, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : ex.Message;
                LogUtil.GetContextLogger()
                    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddMessage("通过letspay代收异常！")
                    .AddException(ex)
                    .AddField("bank.ipo", SerializerUtil.SerializeJsonNet(ipo))
                    .AddField("bank.dto", SerializerUtil.SerializeJsonNet(ret));
            }
            return ret;
        }

        /// <summary>
        /// 代付
        /// cpf 的号码是 11 位数字，cnpj 是 14 位数字,去掉点横上传;
        /// phone 手机请带上 55 区号,手机号是 11 位本地号码加 55 区号总共 13 位;email 邮箱;evp 是 32 位字符串;
        /// 建议：使用 CPF 出款，某些大银行只支持 CPF，CPF 代付成功率高;
        /// </summary>
        /// <returns></returns>
        public async Task<LetsProxyPayDto> ProxyPay(LetsProxyPayIpo ipo)
        {
            var ret = BankUtil.CreateDto<LetsProxyPayDto>(ipo);
            try
            {
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

                //if (string.IsNullOrWhiteSpace(ipo.cashAuditId))
                //    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现审核编号不能为空");
                if (string.IsNullOrWhiteSpace(ipo.cpf))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现pix编号不能为空");



                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {

                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    await new BankProxy(ipo.BankId).ProxyPay(ipo, ret);

                };
                await Execute(ipo, ret, OrderTypeEnum.Draw, PayTypeEnum.Letspay, null, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : ex.Message;
                LogUtil.GetContextLogger()
                    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddMessage("通过letspay代收异常！")
                    .AddException(ex)
                    .AddField("bank.ipo", SerializerUtil.SerializeJsonNet(ipo))
                    .AddField("bank.dto", SerializerUtil.SerializeJsonNet(ret));
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

        

        protected override async Task CheckProxyPayIpo(PayIpoBase ipobase)
        {
            var ipo = ipobase as LetsProxyPayIpo;
            if (ipo == null)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, "参数异常！ipobase无法转换为LetsProxyPayIpo");
            if(string.IsNullOrWhiteSpace(ipo.CountryId))
            {
                ipo.CountryId=await (await GlobalUserDCache.Create(ipo.UserId)).GetCountryIdAsync();
            }
            var countryEo = DbCacheUtil.GetCountry(ipo.CountryId);
            ipo.bankCode = ipo.bankCode.ToLower();
            if (ipo.bankCode == "phone")
            {
                ipo.accountNo = ipo.accountNo.Trim();
                if (!ipo.accountNo.StartsWith(countryEo.CallingCode)||(ipo.accountNo.StartsWith(countryEo.CallingCode)&&ipo.accountNo.Length==11))
                {
                    ipo.accountNo = $"{countryEo.CallingCode}{ipo.accountNo}";
                }
                if (ipo.accountNo.Length != 13)
                {
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, "accountNo format error!");
                }
            }
        }

        public decimal Fee(CalcCashFeeIpo ipo)
        {
            if (ipo.UserFeeAmount == 0)
            {
                return 0;
            }
            return ipo.UserFeeAmount.AToM(ipo.CurrencyId);
        }
    }
}
