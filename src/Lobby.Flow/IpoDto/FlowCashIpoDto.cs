using Lobby.Flow.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Extensions.AutoMapper;
using UGame.Banks.Client.BLL;
using UGame.Banks.Client.BLL.Tejeepay;
using Xxyy.Common;

namespace Lobby.Flow.IpoDto
{
    public class FlowCashIpo:FlowBaseIpo
    {  
        public string Channel { get; set; }
        public int Channels { get; set; }
        public decimal Amount { get; set; }
        public string UserBankId { get; set; }
        #region 新版提现新增字段
        /// <summary>
        /// 提现类型（0、CPF;1、CNPJ;2、PHONE;3、EMAIL;4、EVP）
        /// </summary>
        public TejeePayMethodEnum CashType { get; set; }

        /// <summary>
        /// 固定值：税号-对应巴西的CPF，无论那种提现方式都需要，不能为空
        /// </summary>
        public string TaxId { get; set; }

        /// <summary>
        /// 账户号码--如：CPF对应CPF号码，CNPJ-对应的CNPJ号码，Email对应邮箱地址，PHONE-对应手机号等
        /// </summary>
        public string AccountNo { get; set; }
        #endregion

        /// <summary>
        /// 额外的字典字段支持不同支付方式的不同参数
        /// </summary>
        public Dictionary<string, object> AdditionalParameters { get; set; }
    }

    public class FlowCashDto : FlowBaseDto
    {
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public long Balance { get; set; }

        public string OrderId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 扩展书
        /// </summary>
        public object Meta { get; set; }

        /// <summary>
        /// 是否进入提现审核
        /// </summary>
        public bool IsAudit { get; set; } = false;

    }
}
