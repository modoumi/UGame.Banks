using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Bfpay
{
    public class XxyyBfpayCashIpo
    {
        public string AccountName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccountNo { get; set; }


        public string Email { get; set; } // "520155@gmail.com",
        public string Phone { get; set; } //"9784561230",

        /// <summary>
        /// 巴西：对应5种提现类型：CPF、CNPJ、PHONE、EMAIL、EVP 其他国家对应的各个国家银行编码
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 巴西代付使用-填写收款人税号
        /// </summary>
        public string TaxId { get; set; }

        public string CashAuditId { get; set; }

        /// <summary>
        /// 充值或提现的金额
        /// </summary>
        public long Amount { get; set; }
        /// <summary>
        /// vip提现时扣除的手续费
        /// </summary>
        public decimal CashRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 货币编码
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// 国家编码
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// 用户ip
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 请求备注
        /// </summary>
        public string ReqComment { get; set; }

        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }
        /// <summary>
        /// lobby订单id----CashAuditId
        /// </summary>
        public string AppOrderId { get; set; }

        /// <summary>
        /// 巴西支付时必填账号类型 默认0CPF 1CNPF 2 phone 3 email 4 evp hash 5 bank
        /// 墨西哥支付时非必填
        /// </summary>
        public int CertType { get; set; } = 0;

        private string _certId;

        /// <summary>
        /// 巴西支付时必填，pix账号
        /// </summary>
        public string CertId
        {
            get
            {
                return _certId;
            }
            set
            {
                if (CertType == 0 && value?.Length != 11)
                {
                    throw new Exception("CPF值非法");
                }
                else if (CertType == 1 && value?.Length != 14)
                {
                    throw new Exception("CNPF值非法");
                }
                else if (CertType == 2 && value?.Length != 11)
                {
                    throw new Exception("phone值非法");
                }
                else if (CertType == 3 && !TinyFx.StringUtil.IsEmail(value))
                {
                    throw new Exception("邮箱值非法");
                }
                else
                {
                    _certId = value;
                }
            }
        }

        /// <summary>
        /// 巴西支付时非必填-收款人的CPF或CNPJ 对公司传CNPJ值 对个人传CPF值
        /// 墨西哥支付必填--收款人账号（ 不限于钱包账号、银行卡号、虚拟银行号等等）钱包代付时传CLABEL号码，银行卡代付时传银行账户号码
        /// </summary>
        public string BankCardNo
        {
            get; set;
        }

        /// <summary>
        /// 收款用户姓名
        /// </summary>
        public string BankCardName { get; set; }

     
    }
}
