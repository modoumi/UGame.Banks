using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data;
using UGame.Banks.Mlpay.Common;
using UGame.Banks.Mlpay.IpoDto;
using UGame.Banks.Service;
using UGame.Banks.Service.Services;
using UGame.Banks.Service.Services.Cash;
using UGame.Banks.Service.Services.Pay;
using Xxyy.Banks.DAL;
using Xxyy.Common;

namespace UGame.Banks.Mlpay.Service
{
    public class PayService:BankServiceBase, ICashFeeService
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
        public async Task<MlpayPayDto> CommpnPay(MlpayPayIpo ipo)
        {
            var ret = BankUtil.CreateDto<MlpayPayDto>(ipo);

            try
            {
                var targetBankId = "mlpay_" + ipo.CountryId.ToLower();
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
                await Execute(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Mlpay, null, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
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
                return 0;
            }
            return ipo.UserFeeAmount.AToM(ipo.CurrencyId);
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<MlpayCashDto> ProxyPay(MlpayCashIpo ipo)
        {
            var ret = BankUtil.CreateDto<MlpayCashDto>(ipo);
            try
            {
                var targetBankId = "mlpay_" + ipo.CountryId.ToLower();
                if (ipo.BankId != targetBankId)
                    ipo.BankId = targetBankId;
                if (ipo.Amount <= 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于等于0");
                if ((ipo.Amount - ipo.UserFeeAmount) <= 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于UserFeeAmount扣除的手续费");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                if (string.IsNullOrWhiteSpace(ipo.AccountName))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行账号accountName不能为空");

                if (string.IsNullOrWhiteSpace(ipo.AccountNo))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行代码accountNo不能为空");

                if (string.IsNullOrWhiteSpace(ipo.BankCode))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现bankCode不能为空");

                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    var bankProxy = BankProxyUtil.CreateBankProxy(ipo.CountryId, ipo.BankId);
                    await bankProxy.ProxyPay(ipo, ret);
                };
                await Execute(ipo, ret, OrderTypeEnum.Draw, PayTypeEnum.Mlpay, null, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
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
            var mlpayIpo = (MlpayCashIpo)ipo;
            order.AccName = mlpayIpo.AccountName;
            order.AccNumber = mlpayIpo.AccountNo;
            order.BankCode = mlpayIpo.BankCode;
        }
    }
}
