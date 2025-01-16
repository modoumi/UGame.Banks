using Google.Protobuf.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.BFpay.Proxy
{
    public class CashReq
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
            public string Biz { get; set; } = "df104";


        }

        public class Body
        {
            /// <summary>
            ///  商户代付批次号，值唯一
            /// </summary>
            public string BatchOrderNo { get; set; }

            /// <summary>
            /// 商户代付笔数，与detail代付明细集合数一致
            /// </summary>
            public int TotalNum { get; set; }

            /// <summary>
            /// 商户代付总金额，单位：分，为detail代付明细集合中金额总和
            /// </summary>
            public string TotalAmount { get; set; }

            /// <summary>
            /// 异步通知地址
            /// </summary>
            public string NotifyUrl { get; set; }

            /// <summary>
            ///  
            /// </summary>
            public string AppId { get; set; }

            /// <summary>
            /// 币种BRL
            /// </summary>
            public string CurrencyType { get; set; }

            public Detail[] Detail { get; set; }

        }

        public  class Detail
        {
            /// <summary>
            /// 序号，商户自定义
            /// </summary>
            public string Seq { get; set; }

            /// <summary>
            /// 金额 单位：分
            /// </summary>
            public string Amount { get; set; }


            /// <summary>
            /// 固定值 0
            /// </summary>
            public string AccType { get; set; } = "0";

            /// <summary>
            /// (1)Pix代付时的PIX账号类型
            /// 0: CPF(Brazilian legal person identification, 11位)
                ///1: CNPJ(Brazilian legal entity identification，14位)
               ///2: Phone number(11位): must be formatted as 08007012141
               ///3: E-mail
               ///4: EVP: a 4-block hash separated by hyphens
               ///(2)银行卡代付，传固定值5
            /// </summary>
            public string CertType { get; set; }

            /// <summary>
            /// (1)pix代付时的PIX账号，即CPF或CNPJ或Phone或E-mail或Random key(EVP)
            ///(2)银行卡代付时传：agencia，conta，contaDigito 此三项值由银行分配，用户自己知道，只需搜集好即可，银行给的参考见【附录1】
            /// </summary>
            public string CertId { get; set; }

            /// <summary>
            /// 收款人的CPF或CNPJ 对公司传CNPJ值 对个人传CPF值 Pix代付时不能为空
            /// </summary>
            public string BankCardNo { get; set; }

            /// <summary>
            /// 收款用户姓名
            /// </summary>
            public string BankCardName { get; set; }

            /// <summary>
            /// 银行编码（银行卡代付时必传）
            /// </summary>
            public string BankCode { get; set; }

            /// <summary>
            /// 银行账户绑定的手机号码
            /// </summary>
            public string Mobile { get; set; }

            /// <summary>
            /// 邮箱
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// 银行卡类型 1:借记卡2:信用卡
            /// </summary>
            public string BankCardType { get; set; }

            /// <summary>
            /// 银行卡类型为2信用卡时必输 信用卡有效期,MMyy
            /// </summary>
            public string CreditValid { get; set; }

            /// <summary>
            /// 银行卡类型为2信用卡时必输 卡背面后3位数字
            /// </summary>
            public string CreditCvv { get; set; }

            /// <summary>
            /// 开户行所属省份
            /// </summary>
            public string BankProvince { get; set; }

            /// <summary>
            /// 开户行所属市
            /// </summary>
            public string BankCity { get; set; }

            /// <summary>
            /// 联行号
            /// </summary>
            public string BankLineCode { get; set; }

            /// <summary>
            /// 银行名称
            /// </summary>
            public string BankName { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string Remark { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string FirstName { get; set; }


            /// <summary>
            /// 
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// 卡年份
            /// </summary>
            public string CardYear { get; set; }
            /// <summary>
            /// 卡月份
            /// </summary>
            public string CardMonth { get; set; }
        }

        public string body { get; set; }
        public Head head { get; set; }

  
    }

    public class CashRsp
    { 
        public class Head
        {
            public string respCode { get; set; }
        }

        public Head head { get; set; }

        public string body { get; set; }
    }
    public class ProxyPayRespBody
    {
        /// <summary>
        /// 订单受理状态，不代表代付最终结果，SUCCESS 受理成功（会对其做代付操作），FAIL 受理失败
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 平台批次号
        /// </summary>
        public string tradeId { get; set; }
        /// <summary>
        /// 商户批次号
        /// </summary>
        public string batchOrderNo { get; set; }
        /// <summary>
        /// 商户编号,支付平台提供
        /// </summary>
        public string mchtId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string desc { get; set; }
    }
}
