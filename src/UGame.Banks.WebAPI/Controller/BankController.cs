using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using TinyFx;
using TinyFx.AspNet;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Cash;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Service.Services.Query;
using UGame.Banks.Service.Services.SyncOrders;
using Xxyy.Banks.DAL;
using UGame.Banks.Tejeepay.Service;
using Xxyy.Common;

namespace UGame.Banks.WebAPI.Controller
{
    /// <summary>
    /// 查询订单状态
    /// </summary>
    [ApiController]
    [IgnoreActionFilter]
    [Route("api/bank")]
    public class BankController : ControllerBase
    {
        private BankService _bankSvc = new();

        /// <summary>
        /// 获取支付状态
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("order")]
        [ProducesResponseType(200, Type = typeof(GetOrderDto))]
        public async Task<GetOrderDto> GetOrder(GetOrderIpo ipo)
        {
            //if (ipo.UserId != UserId)
            //    throw new Exception($"参数异常：{nameof(ipo.UserId)}");
            return await _bankSvc.GetOrder(ipo);
        }

        /// <summary>
        /// 计算提现手续费
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("cashfee")]
        public async Task<CalcCashFeeDto> CashFee(CalcCashFeeIpo ipo)
        {
            CalcCashFeeDto dto = new CalcCashFeeDto() { Status = "success" };
            string bankId = ipo.BankId.ToLower();
            switch (bankId)
            {
                case "tejeepay":
                    if (ipo.CountryId == "BRA")
                        dto.Fee = 0;
                    else if (ipo.CountryId == "MEX")
                        dto.Fee = await new MexCallbackService("tejeepay_mex").GetFee(ipo);
                    break;
                case "letspay":
                    if (ipo.CountryId == "BRA")
                        dto.Fee = 0;
                    else if (ipo.CountryId == "MEX")
                        dto.Fee = new Letspay.Service.MexCallbackService().GetPayFee((ipo.Amount - ipo.UserFeeAmount).AToM(ipo.CurrencyId), ipo.BankId);
                    break;
                case "mlpay":
                    dto.Fee = 0;
                    break;
            }
            return dto;
        }
    }
}
