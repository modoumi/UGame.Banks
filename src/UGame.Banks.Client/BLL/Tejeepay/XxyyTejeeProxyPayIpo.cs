namespace UGame.Banks.Client.BLL.Tejeepay
{
    public class XxyyTejeeProxyPayIpo
    {
        public string UserId { get; set; }
        public string AppId { get; set; }
        public string CurrencyId { get; set; }
        /// <summary>
        /// 国家编码
        /// </summary>
        public string CountryId { get; set; }
        public long Amount { get; set; }

        /// <summary>
        /// vip提现时扣除的手续费费率
        /// </summary>
        public decimal CashRate { get; set; }
        public string CashAuditId { get; set; }

        /// <summary>
        /// 巴西代付下单(提现) pix代付传 df104 = 0,
        /// 墨西哥代付下单(提现)银行卡代付  df101 = 1,
        /// 墨西哥代付下单(提现)钱包代付[也叫SPEI]传：df103 = 3
        /// </summary>
        public int BizEnum { get; set; } = 0;

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
                if (BizEnum != 0)
                {
                    _certId = value;
                    return;
                }
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

        private string _bankCode;

        /// <summary>
        /// 银行编码（银行卡代付时必传），墨西哥支付调用BankList接口获取支持的银行列表
        /// </summary>
        public string BankCode
        {
            get
            {
                return _bankCode;
            }
            set
            {
                if (CertType == 5 && String.IsNullOrEmpty(value))
                {
                    throw new Exception("BankCode值非法");
                }
                else
                {
                    this._bankCode = value;
                }
            }
        }

        /// <summary>
        /// 1借记卡 2信用卡
        /// </summary>
        public string BankCardType { get; set; }

        /// <summary>
        /// 银行卡类型为2信用卡时必传 信用卡有效期,MMyy
        /// </summary>
        public string CreditValid { get; set; }

        /// <summary>
        /// 银行卡类型为2信用卡时必传 卡背面后3位数字
        /// </summary>
        public string CreditCvv { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReqComment { get; set; }

        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }

        /// <summary>
        /// 收款人手机号---墨西哥支付必填
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 收款人邮箱---墨西哥支付必填
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// lobby订单id----CashAuditId
        /// </summary>
        public string AppOrderId { get; set; }
    }
}
