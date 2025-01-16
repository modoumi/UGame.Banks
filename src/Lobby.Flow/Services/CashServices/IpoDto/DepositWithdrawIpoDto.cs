using Lobby.Flow.Common;
using Lobby.Flow.DAL;
using System.Text.Json.Serialization;
using TinyFx.AspNet;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.DAL;

namespace Lobby.Flow.Services.CashServices
{
    /// <summary>
    /// 巴西提现ipo
    /// </summary>
    public class BraWithDrawIpo : LobbyBaseIpo
    {
        /// <summary>
        /// 应用编码
        /// </summary>
        [RequiredEx("", "AppId cannot be empty.")]
        public string AppId { get; set; }

        /// <summary>
        /// 提现金额
        /// </summary>
        public decimal Amount { get; set; }

        ///// <summary>
        ///// 加纳支付需要的通道（mtn-gh,vodafone-gh,tigo-gh）移至AdditionalParameters
        ///// </summary>
        //public string HubtelChannel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserBankId { get; set; }

        /// <summary>
        /// 支付渠道编码4、pandapay;5、tejeepay
        /// </summary>
        public int Channels { get; set; }

        /// <summary>
        /// 提现类型（0、CPF;1、CNPJ;2、PHONE;3、EMAIL;4、EVP）
        /// </summary>
        public TejeePayMethodEnum CashType { get; set; }

        /// <summary>
        /// 固定值：税号-对应巴西的CPF，无论那种提现方式都需要，11位数字不带横线，不能为空！
        /// </summary>
        public string TaxId { get; set; }

        /// <summary>
        /// 账户号码和CashType对应--如：CPF对应CPF号码，CNPJ-对应的CNPJ号码，Email对应邮箱地址，PHONE-对应手机号等
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        /// 支付渠道枚举
        /// </summary>
        [JsonIgnore]
        public BraPayChannelEnum BraPayChannel { get; set; }

        /// <summary>
        /// 巴西用户税号、户名eo
        /// </summary>
        //[JsonIgnore]
        //public L_bra_userEO BraUserEo { get; set; }

        /// <summary>
        /// 巴西用户银行卡缓存
        /// </summary>
        [JsonIgnore]
        public List<L_bra_user_bankPO> BraUserBankEoList { get; set; }

        /// <summary>
        /// 提现使用的银行卡
        /// </summary>
        [JsonIgnore]
        public L_bra_user_bankPO BraUserBankEo { get; set; }

        /// <summary>
        /// s_user_ex
        /// </summary>
        [JsonIgnore]
        public S_user_exEO UserExEo { get; set; }

        /// <summary>
        /// s_user
        /// </summary>
        [JsonIgnore]
        public S_userPO UserEo { get; set; }

        /// <summary>
        /// sc_cash_config
        /// </summary>
        [JsonIgnore]
        public Lobby.Flow.DAL.Sc_cash_configEO CashConfigEo { get; set; }

        /// <summary>
        /// CommonUserService
        /// </summary>
        [JsonIgnore]
        public UserService CommonUserServices { get; set; }

        /// <summary>
        /// CurrencyChangeService
        /// </summary>
        [JsonIgnore]
        public CurrencyChangeService CurrencyChangeServices { get; set; }

        /// <summary>
        /// 数据查询起始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 数据查询截止时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 用户当天提现总次数
        /// </summary>
        [JsonIgnore]
        public long SumCashNum { get; set; }
        /// <summary>
        /// 用户当天提现总额
        /// </summary>
        [JsonIgnore]
        public long SumCashAmount { get; set; }

        /// <summary>
        /// 用户提现审批中非拒绝状态的提现总额
        /// </summary>
        //[JsonIgnore]
        //public long UserAllAuditCashSumAmount { get; set; }

        //[JsonIgnore]
        //public SqlSink sqlSink { get; set; } = new SqlSink();

        [JsonIgnore]
        public GlobalUserDCache GlobalUserDCache { get; set; }

        /// <summary>
        /// 用户ip
        /// </summary>
        [JsonIgnore]
        public string UserIp { get; set; }

        /// <summary>
        /// 审核id
        /// </summary>
        [JsonIgnore]
        public string CashAuditId { get; set; }

        /// <summary>
        /// 提现审核条件配置
        /// </summary>
        [JsonIgnore]
        public List<Sc_cash_condition_configPO> CashConditionConfigEoList { get; set; } = new List<Sc_cash_condition_configPO>();

        [JsonIgnore]
        public V_s_operatorPO SOperatorEO { get; set; }

        /// <summary>
        /// 用户当前vip等级，目前只在长版本生效
        /// </summary>
        [JsonIgnore]
        public Sc_vip_configEO CurrVipConfig { get; set; } = null;
        [JsonIgnore]
        public float CashRate { get; set; }

        [JsonIgnore]
        public UserCashService UserCashService { get; set; } = new UserCashService();

        /// <summary>
        /// 用户历史提现次数、金额
        /// </summary>
        [JsonIgnore]
        public UserCashInfo HistoryUserCashInfo { get; set; } = new UserCashInfo();

        /// <summary>
        /// 用户当天提现次数、金额
        /// </summary>
        [JsonIgnore]
        public UserCashInfo UserCurrDayCashInfo { get; set; } = new UserCashInfo();

        /// <summary>
        /// 是否首次提现
        /// </summary>
        public bool IsFirstCash { get; set; } = false;

        public Dictionary<string, object> AdditionalParameters { get; set; }
    }
}
