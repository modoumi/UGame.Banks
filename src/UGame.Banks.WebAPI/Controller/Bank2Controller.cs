using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using TinyFx;
using TinyFx.AspNet;
using UGame.Banks.Service;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services;
using UGame.Banks.Service.Services.Cash;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Service.Services.Query;
using UGame.Banks.Service.Services.SyncOrders;
using Xxyy.Banks.DAL;
using UGame.Banks.Letspay.Ipo;
using UGame.Banks.Tejeepay.Service;
using Xxyy.Common;

namespace UGame.Banks.WebAPI.Controller
{
    /// <summary>
    /// 查询订单状态
    /// </summary>
    //[ApiController]
    //[IgnoreActionFilter]
    [Route("api/bank")]
    [AllowAnonymous]
    public class Bank2Controller : TinyFxControllerBase
    {
        private BankService _bankSvc = new();

        /// <summary>
        /// 获取支付状态
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("order2")]
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
        [Route("cashfee2")]
        public async Task<CalcCashFeeDto> CashFee(CalcCashFeeIpo ipo)
        {
            CalcCashFeeDto dto = new CalcCashFeeDto() { Status = "success" };
            ICashFeeService feeSvc = null;
            string bankId = ipo.BankId.ToLower();
            switch (bankId)
            {
                case "tejeepay":
                    feeSvc = new Tejeepay.Service.PayService();
                    dto.Fee = feeSvc.Fee(ipo);
                    //if (ipo.CountryId == "BRA")
                    //    dto.Fee = 0;
                    //else if(ipo.CountryId=="MEX")
                    //    dto.Fee = await new Tejeepay.Service.MexCallbackService("tejeepay_mex").GetFee(ipo);
                    break;
                case "letspay":
                    if (ipo.CountryId == "BRA")
                    {
                        feeSvc = new Letspay.Service.PayService();
                        dto.Fee = feeSvc.Fee(ipo);
                    }
                    else if (ipo.CountryId == "MEX")
                    {
                        feeSvc = new Letspay.Service.PayServiceCommon();
                        dto.Fee=feeSvc.Fee(ipo);
                        //dto.Fee = new Letspay.Service.MexCallbackService().GetPayFee((ipo.Amount - ipo.UserFeeAmount).AToM(ipo.CurrencyId), "letspay_mex"); 
                    }
                    break;
                case "mlpay":
                    feeSvc = new Mlpay.Service.PayService();
                    dto.Fee = feeSvc.Fee(ipo);
                    break;
                case "bfpay":
                    feeSvc = new BFpay.Service.PayService();
                    dto.Fee = feeSvc.Fee(ipo);
                    break;
                case "hubtel":
                    feeSvc = new Hubtel.PaySvc.PayService();
                    dto.Fee = feeSvc.Fee(ipo);
                    break;
            }
            return dto;
        }

        /// <summary>
        /// 获取letspay支持的指定国家的银行列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("banklist")]
        public Task<List<Sb_bankcodePO>> BankList(GetBankListIpo ipo)
        {
            return Task.FromResult(_bankSvc.GetBankList(ipo));
        }

        ///// <summary>
        ///// 验证三方订单
        ///// </summary>
        ///// <param name="ipo"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("verifyorders")]
        //public async Task<IActionResult> VerifyOrders(VerifyOrderIpo ipo)
        //{
        //    //this.HttpContext.Request.Headers.TryGetValue("PROVIDERID", out var providerIdHeader);

        //    //if (providerIdHeader == StringValues.Empty)
        //    //    throw new ArgumentException("请求头中PROVIDERID不能为空！");

        //    //var providerId = providerIdHeader.FirstOrDefault();
        //    //var providerEo = Common.Caching.DbCacheUtil.GetProvider(providerId);
        //    //if (null == providerEo)
        //    //    throw new Exception($"没有找到对应的provider!ProviderId:{providerId}");

        //    //await BankUtil.CheckSign(providerEo.OwnPublicKey, $"s_provider没有定义TrdPublicKey。providerId:{providerId}");
        //    //return Ok("ok test");
        //    await _bankSvc.VerifyOrders(ipo);
        //    return Ok("ok");
        //}

        ///// <summary>
        ///// 验证三方订单2
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("verifyExceptionorders"), AllowAnonymous]
        //public async Task<IActionResult> verifyExceptionorders()
        //{
        //    var tejeeQuerySvc = new QueryService();
        //    await tejeeQuerySvc.VerifyExceptionOrders();
        //    return Ok("ok");
        //}
    }
}
