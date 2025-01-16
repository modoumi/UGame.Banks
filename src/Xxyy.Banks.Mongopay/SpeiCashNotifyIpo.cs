using System.Text.Json.Serialization;
using Xxyy.Banks.DAL;

namespace Xxyy.Banks.Mongopay
{
    /// <summary>
    /// spei提现异步通知实体对象
    /// </summary>
    public class SpeiCashNotifyIpo : SpeiNotifyIpoBase
    {
        /// <summary>
        /// 代付订单状态(代付订单状态2：代付成功3和4：代付失败（注：存在返回2成功之后再返回4失败的情况，即退回。当状态更改时我们会再次发送通知，商户需实现处理该种情况的业务逻辑）)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 状态描述
        /// </summary>
        public string Msg { get; set; }

        ///// <summary>
        ///// 商户订单号
        ///// </summary>
        //public string OrderNum { get; set; }

        ///// <summary>
        ///// 平台订单号
        ///// </summary>
        //public string PlatOrderNum { get; set; }

        /// <summary>
        /// 手续费收取方式
        /// </summary>
        public string FeeType { get; set; }

        /// <summary>
        /// 收款银行代码
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 收款账号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 收款账号名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Fee { get; set; }

        /// <summary>
        /// 转账描述
        /// </summary>
        public string Description { get; set; }

      

        ///// <summary>
        ///// 签名
        ///// </summary>
        //public string PlatSign { get; set; }

        //[JsonIgnore]
        //public Sb_bank_orderEO Order { get; set; }

        //[JsonIgnore]
        //public long Balance { get; set; }
    }
}
