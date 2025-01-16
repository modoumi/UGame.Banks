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

namespace UGame.Banks.Mlpay.Proxy
{
    public class PayReq
    {
        /// <summary>
        /// 支付中心分配的商户号
        /// </summary>
        public string partnerId { get; set; }

        /// <summary>
        /// 商户应用ID
        /// </summary>
        public long applicationId { get; set; }

        /// <summary>
        /// 支付方式ID 固定值 2
        /// </summary>
        public int payWay { get; set; }

        /// <summary>
        /// 商户生成的代收号
        /// </summary>
        public string partnerOrderNo { get; set; }

        /// <summary>
        /// 支付金额,单位分
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// 货币代码
        /// <para>印度-卢比:INR</para>
        /// <para>巴西-雷亚尔:BRL</para>
        /// <para> 孟加拉:BDT</para>
        /// <para>印尼:IDR</para>
        /// <para> 墨西哥：MXN</para>
        /// <para>俄罗斯：RUB</para>
        /// <para> 印度-卢比:INR</para>
        /// <para> 巴西-雷亚尔:BRL</para>
        /// <para>孟加拉:BDT</para>
        /// <para>印尼:IDR</para>
        /// <para> 墨西哥：MXN</para>
        /// <para> 俄罗斯：RUB</para>
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 用户游戏ID
        /// </summary>
        public string gameId { get; set; }

        /// <summary>
        /// 客户端IP地址 例：111.111.122.111 支持ip6
        /// </summary>
        public string clientIp { get; set; }

        /// <summary>
        /// 支付结果异步回调URL（URLENCODE编码,计算签名使用编码前数值
        /// </summary>
        public string notifyUrl { get; set; }

        /// <summary>
        /// 商品主题（URLENCODE编码,计算签名使用编码前数值）
        /// </summary>
        public string subject { get; set; }

        /// <summary>
        /// 商品描述信息（URLENCODE编码,计算签名使用编码前数值）
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// 非必填 付完成之后跳转到商户指定URL地址,个别通道 是无效的,如果有需要联系管理员确认（URLENCODE编码,计算签名使用编码前数值）
        /// </summary>
        public string callbackUrl { get; set; }

        /// <summary>
        /// 特殊参数（JSON格式，URLENCODE编码,计算签名使用编码前数值）（{“userName”:”test”, “userEmail”:”test@gmail.com”, “userPhone”:”7428731223”}）
        /// </summary>
        public string extra { get; set; }

        /// <summary>
        /// 接口版本号，固定：1.0）
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// 巴西代收必须填写收款人税号
        /// </summary>
        public string identityNo { get; set; }

        /// <summary>
        /// 韩国，日本必传
        /// </summary>
        public string bankCode { get; set; }

        /// <summary>
        /// 签名值，详见签名算法
        /// </summary>
        public string sign { get; set; }

        public class ExtraModel
        {
            public string userName { get; set; }
            public string userEmail { get; set; }
            public string userPhone { get; set; }
            public override string ToString()
            {
                return SerializerUtil.SerializeJsonNet(this);
            }
        }
    }

    public class PayRsp
    {
        /// <summary>
        /// 0000-处理成功，其他-处理有误，详见错误码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 具体错误原因，例如：签名失败、参数格式校验错误
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据成功为支付链接，访问链接唤起支付
        /// </summary>
        public DataModel Data { get; set; }
        public class DataModel
        {
            /// <summary>
            /// 系统订单号
            /// </summary>
            public string OrderNo { get; set; }

            /// <summary>
            /// 支付链接
            /// </summary>
            public string PayUrl { get; set; }
        }
    }
}
