using EasyNetQ.Producer;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TinyFx;

namespace UGame.Banks.BFpay.Proxy
{ 
    public class BfPayReq
    {
       public class Head
        {
            /// <summary>
            ///  商户编号,不参与签名
            /// </summary>
            public string MchtId { get; set; }

            /// <summary>
            /// 固定值“20”,不参与签名
            /// </summary>
            public string Version { get; set; } = "20";

            /// <summary>
            /// 固定值,支付方式,不参与签名
            /// </summary>
            public string Biz { get; set; } = "ca001";


        }

        public class Body
        {
            /// <summary>
            ///  订单号
            /// </summary>
            public string OrderId { get; set; }

            /// <summary>
            /// 订单时间yyyyMMddHHmmss
            /// </summary>
            public string OrderTime { get; set; }

            /// <summary>
            /// 总金额,以分为单位
            /// </summary>
            public string Amount { get; set; }

            /// <summary>
            /// 货币种类,三位字母代码(详情见下边币种)
            /// </summary>
            public string CurrencyType { get; set; }

            /// <summary>
            /// 商品名称（不要带中文元素）
            /// </summary>
            public string Goods { get; set; } = string.Empty;

            /// <summary>
            /// 接收推送通知的URL
            /// </summary>
            public string NotifyUrl { get; set; }

            /// <summary>
            /// 网页回调地址
            /// </summary>
            public string CallBackUrl { get; set; }

            /// <summary>
            /// 商品描述,logo地址
            /// </summary>
            public string Desc { get; set; } = string.Empty;

            /// <summary>
            ///印度UPI支付,用户的VPA账号
            ///支持印尼单独指定银行编码（见代收-附录银行编码）印尼api下单必须传【说明biz传va101和wp101的情况】 巴西代收传商户真实CPF(纳税登记号) ，若没有可以不传 
            /// </summary>
            public string Operator { get; set; } = string.Empty;

            /// <summary>
            /// 订单超时时间
            /// </summary>
            public string ExpireTime { get; set; }

            /// <summary>
            /// 请求IP地址
            /// </summary>
            public string Ip { get; set; }

            /// <summary>
            /// 保留字段
            /// </summary>
            public string Param { get; set; } = string.Empty;


            /// <summary>
            /// 要求：小于32位
            /// </summary>
            public string UserId { get; set; } = string.Empty;


            public string Phone { get; set; } = string.Empty;

            public string Name { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;

            public string AppId { get; set; } = string.Empty;
            public string AppName { get; set; } = string.Empty;
        }

        public Body body { get; set; }
        public Head head { get; set; }

        public string sign { get; set; }
    }

    public class BfPayRsp
    {
        public class Body {

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
            /// 保留字段
            /// </summary>
            public string param { get; set;}
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
