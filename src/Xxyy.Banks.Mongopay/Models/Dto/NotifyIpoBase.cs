using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Mongopay.Models.Dto
{

    /// <summary>
    ///  spei充值、提现通知基类
    /// </summary>
    public class NotifyIpoBase : CallbackIpoCommonBase
    {
        /// <summary>
        /// 商户订单号
        /// 商户下单时请求的商户订单号
        /// type 为1 时指创建虚拟账号时上送的商户流水号
        /// </summary>
        public string OrderNum { get; set; }

        /// <summary>
        /// 平台订单号
        /// </summary>
        public string PlatOrderNum { get; set; }

        /// <summary>
        /// 应答描述
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 签名，详见 1.4签名规则
        /// </summary>
        public string PlatSign { get; set; }
    }
}
