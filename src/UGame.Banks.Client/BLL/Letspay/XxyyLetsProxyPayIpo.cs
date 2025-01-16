namespace UGame.Banks.Client.BLL.Letspay
{
    public class XxyyLetsProxyPayIpo
    {
        /// <summary>
        /// 审核订单需要传该参数-非审核订单不用传
        /// </summary>
        public string cashAuditId { get; set; }
        public string accountName { get; set; }
        /// <summary>
        /// accountNo 类型有 cpf,cnpj,email,phone,evp
        /// </summary>
        public string accountNo { get; set; }

        /// <summary>
        /// 巴西 ：cpf|cnpj|email|phone|evp  
        /// 墨西哥：CLABE,OXXO,PAYCASH
        /// </summary>
        public string bankCode { get; set; } //cpf

        public string email { get; set; } // "520155@gmail.com",
        public string phone { get; set; } //"9784561230",
        
        public string cpf { get; set; } //

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
        /// 提现模式
        /// <para>墨西哥：bank和clabe</para>
        /// <para>巴西：忽略该参数</para>
        /// </summary>
        public string mode { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        public string taxId { get; set; }

        /// <summary>
        /// lobby订单id----CashAuditId
        /// </summary>
        public string AppOrderId { get; set; }
    }
}
