using System.Text.Json.Serialization;
using Xxyy.Common.Caching;
using Xxyy.DAL;

namespace UGame.Banks.Service.Services.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BankIpoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string RequestUUID { get; set; }
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
        /// 银行编码
        /// </summary>
        public string BankId { get; set; }

        /// <summary>
        /// 国家编码
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }

        /// <summary>
        /// 充值参与领取bonus状态，2不参与，1参与
        /// </summary>
        public int ReceiveBonus { get; set; }

        /// <summary>
        /// 用户ip
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 活动id集合
        /// </summary>
        public List<string> ActivityIds { get; set; }

        /// <summary>
        /// 是否添加账户余额
        /// </summary>
        public bool IsAddBalance { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        public string CashAuditId { get; set; }



        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public string LoginToken { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore,Newtonsoft.Json.JsonIgnore]
        //public abstract Type DtoType { get; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //public LoginTokenDO LoginTokenDo { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //public string ProviderId => LoginTokenDo?.ProviderId;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //public string OperatorId => LoginTokenDo?.OperatorId;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //public string CountryId => LoginTokenDo?.CountryId;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public S_appEO App { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public S_providerEO Provider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public V_s_operatorEO Operator { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //[Newtonsoft.Json.JsonIgnore]
        //public S_operator_appEO OperatorApp { get; set; }
    }
}
