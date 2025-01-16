namespace UGame.Banks.BFpay.IpoDto
{
    /// <summary>
    /// 代收回调通知类
    /// </summary>
    public class PayNotifyIpo
    {
        public class Body
        {

            /// <summary>
            /// 商户ID
            /// </summary>
            public string MchtId { get; set; }

            /// <summary>
            /// 商户订单号
            /// </summary>
            public string OrderId { get; set; }

            /// <summary>
            /// 支付URL地址
            /// </summary>
            public string PayUrl { get; set; }
            /// <summary>
            /// 支付平台返回的交易流水号
            /// </summary>

            public string TradeId { get; set; }

 
            /// <summary>
            /// 总金额，通下单时金额一样
            /// </summary>

            public string Amount { get; set; }


            /// <summary>
            /// 支付结果 ，支付结果 ，SUCCESS:支付成功
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// 具体支付类型
            /// </summary>
            public string PayType { get; set; }

            /// <summary>
            /// 订单支付时间yyyyMMddHHmmss
            /// </summary>
            public string ChargeTime { get; set; }

            /// <summary>
            /// 平台随机序号
            /// </summary>
            public string Seq { get; set; }

            /// <summary>
            /// 支付类型,同下单时一样
            /// </summary>
            public string Biz { get; set; }

            /// <summary>
            /// 支付类型,同下单时一样
            /// </summary>
            public string Param { get; set; }

            /// <summary>
            /// 手机号
            /// </summary>
            public string Phone { get; set; }
        }

        public class Head
        {
            public string RespCode { get; set; }

            public string RespMsg { get; set; }

        }

        public Head head { get; set; }

        public Body body { get; set; }

        public string sign { get; set; }
    }
}
