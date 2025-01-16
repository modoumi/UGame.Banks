using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Mongopay
{
    /// <summary>
    /// 
    /// </summary>
    public class CashReq
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
        /// 手续费收取方式(费率（feeType：0 - 指代付手续费从请求的代付交易金额中扣除，比如请求代付金额1000，我方平台需要收取5元手续费，那么代付到账金额为995；1 - 从商户余额中扣除，即请求代付金额1000，实际到账1000，商户余额减去1005。）)
        /// </summary>
        public string FeeType { get; set; }

        /// <summary>
        /// 收款银行代码（银行代码，具体见 5.附录）
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 收款账号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 收款账号类型-----40。收款账号类型(3：DebitCard，40：CLABE))
        /// </summary>
        public string NumberType { get; set; }

        /// <summary>
        /// 收款账号名称（收款账号对应的账号名称）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 订单金额（单位墨西哥比索，保留两位小数）
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 转账描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 支付异步通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 请求发起时间
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
    }

    /// <summary>
    /// 体现
    /// </summary>
    public class CashRsp:MongopayBaseRsp
    {
       

        //以下字段在 platRespCode 为 SUCCESS时才有返回
        
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderNum { get; set; }

        /// <summary>
        /// 平台订单号
        /// </summary>
        public string PlatOrderNum { get; set; }

        /// <summary>
        /// 手续费收取方式
        /// </summary>
        public string FeeType { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public string Money { get; set; }

        /// <summary>
        /// 手续非金额
        /// </summary>
        public string Fee { get; set; }

        /// <summary>
        /// 收款银行代码
        /// </summary>
        public string BankCode{ get; set; }

        /// <summary>
        /// 收款银行账号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 收款账号名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 交易描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string PlatSign { get; set; }
    }
}
