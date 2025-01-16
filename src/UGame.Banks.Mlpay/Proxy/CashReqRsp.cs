using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Mlpay.Proxy
{
    public class CashReq
    {
        /// <summary>
        /// 支付中心分配的商户号
        /// </summary>
        public string partnerId { get; set; }

        /// <summary>
        /// 商户生成的代付号,切记订单号唯一
        /// </summary>
        public string partnerWithdrawNo { get; set; }

        /// <summary>
        /// 支付金额,单位分
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// 货币代码
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// 用户游戏ID
        /// </summary>
        public string gameId { get; set; }

        /// <summary>
        /// 支付结果异步回调URL（URLENCODE编码,计算签名使用编码前数值）
        /// </summary>
        public string notifyUrl { get; set; }

        /// <summary>
        /// 收款方式 
        ///<para>currency=INR时收款方式0:UPI;1:IMPS；</para>
        ///<para> currency=BRL时收款方式 0：CPF；1：CNPJ；2：PHONE；3：EMAIL；4：EVP；
        ///<para> currency=BDT 0：nagad 1：bkash;
        ///<para>currency=IDR时 0 :银行卡 1:钱包;
        ///<para>currency=MXN时 0:bank 1：钱包(暂不支持);</para>
        ///<para>currency=RUB时 0：BANK;</para>
        ///<para>currency=PHP时 0：BANK;</para>
        ///<para>currency=PKR时 0：Easypaisa，1：BANK，2：Jazzcash</para>
        ///</summary>
        public int receiptMode { get; set; }

        /// <summary>
        /// 收款账户（URLENCODE编码,计算签名使用编码前数值）
        /// </summary>
        public string accountNumber { get; set; }

        /// <summary>
        /// 收款姓名（URLENCODE编码,计算签名使用编码前数值）
        /// </summary>
        public string accountName { get; set; }

        /// <summary>
        /// 收款电话（URLENCODE编码,计算签名使用编码前数值）
        /// </summary>
        public string accountPhone { get; set; }

        /// <summary>
        /// 收款邮箱（URLENCODE编码,计算签名使用编码前数值）
        /// </summary>
        public string accountEmail { get; set; }

        /// <summary>
        /// currency=INR时，收款特殊参数1（当receiptMode为1时，此参数必填）（IFSC CODE）
        /// </summary>
        public string accountExtra1 { get; set; }

        /// <summary>
        /// 收款特殊参数2
        ///<para> currency=INR时，收款特殊参数2（当receiptMode为1时IFSC CODE前4位)</para>
        ///<para>currency=IDR时 receiptMode = 0时填印尼银行编码，receiptMode=1时 填对应的钱包OVO, DANA, GOPAY, SHOPEEPAY, LINKAJA</para>
        ///<para>currency=MXN时 填墨西哥银行编码）</para>
        ///<para>currency=JPY时 填日本银行编码</para>
        ///<para>currency=KRW时 填韩国代付银行编码</para>
        ///<para>currency=PHP时 填菲律宾代付银行编码</para>
        ///<para>currency=PKR时 receiptMode = 0, 填Easypaisa；receiptMode=2，填Jazzcash；receiptMode=1，填银行名称</para>
        /// </summary>
        public string accountExtra2 { get; set; }

        /// <summary>
        /// 巴西代付必须填写收款人税号
        /// </summary>
        public string identityNo { get; set; }

        /// <summary>
        /// 接口版本号，固定：1.0
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// 签名值，详见签名算法
        /// </summary>
        public string sign { get; set; }
    }

    public class CashRsp
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
        /// 返回参数为代付结果，返回同步代付结果。
        /// </summary>
        public string Data { get; set; }
    }
}
