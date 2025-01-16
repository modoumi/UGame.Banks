using TinyFx;
using TinyFx.Data.SqlSugar;
using TinyFx.Data;
using TinyFx.Logging;
using Xxyy.Banks.BLL;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.DAL;
using Xxyy.Banks.Mongopay.Models.Dto;
using Xxyy.Banks.Mongopay.Proxy;
using Microsoft.AspNetCore.Http;

namespace Xxyy.Banks.Mongopay.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class MongoPayService : BankServiceBase
    {
        private readonly HttpContext _httpContext;

        /// <summary>
        /// 一次性付款码
        /// </summary>
        public MongoPayService()
        {
            _httpContext = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext;
        }

        /// <summary>
        /// 一次性付款码
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<PayDto> Pay(PayIpo ipo)
        {
            var ret = BankUtil.CreateDto<PayDto>(ipo);

            try
            {
                if (ipo.Amount < 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"充值金额Amount必须大于等于0");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                LogUtil.Info($"mongopay.pay:2,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    var proxy = new BankProxy(ipo.BankId);
                    await proxy.Pay(ipo, ret);
                };
                //2.执行下单和支付流程
                await Execute(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Spei, _httpContext.Request.Path.Value, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
                LogUtil.Info($"mongopay.pay:4,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                LogUtil.Error(ex, $"mongopay.pay:5,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="ipo"></param>
        protected override void SetSbBankOrderEo(Sb_bank_orderEO order, PayIpoBase ipo)
        {
            var cashSpeiIpo = (CashSpeiIpo)ipo;
            order.AccName = cashSpeiIpo.AccName;
            order.AccNumber = cashSpeiIpo.AccNumber;
            order.BankCode = cashSpeiIpo.BankCode;
        }
    }
}
