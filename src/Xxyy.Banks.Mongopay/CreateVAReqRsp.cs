using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Mongopay
{

    public class CreateVAReq
    {
        /// <summary>
        /// 商户编号
        /// </summary>
        public string MerchantCode { get; set; }


        /// <summary>
        /// 商户订单号（合作方自定义订单号，唯一标识一笔交易）
        /// </summary>
        public string OrderNum { get; set; }

        /// <summary>
        /// 机构代码（机构代码，固定 646）
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 客户名称（创建的虚拟账号对应的账户名称）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 支付异步通知地址（支付成功后交易结果通知到该地址，通知参数见章节 4.异步通知）
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 请求发起时间（请求时间，形如 yyyyMMddHHmmss）
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
    }

    public class CreateVARsp:MongopayBaseRsp
    {
        //public string PlatRespCode { get; set; }
        //public string PlatRespMessage { get; set; }

        //以下字段在 platRespCode为 SUCCESS时才有返回
        public string BankCode { get; set; }
        public string PlatOrderNum { get; set; }
        public string OrderNum { get; set; }
        public string VaNumber { get; set; }
        public string Name { get; set; }
        public string PlatSign { get; set; }
    }
}
