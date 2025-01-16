using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.BLL.Services.Query;

namespace Xxyy.Banks.Mongopay
{

    /// <summary>
    /// 
    /// </summary>
    public class SpeiIpo : PayIpoBase
    {

        /// <summary>
        /// 
        /// </summary>
        public override BankAction Action => BankAction.SpeiPay;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override Type DtoType => typeof(SpeiDto);
    }

    /// <summary>
    /// 
    /// </summary>
    public class SpeiDto : PayDtoBase
    {
        /// <summary>
        /// 创建的虚拟账号
        /// </summary>
        public string VaNumber { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CashSpeiIpo : PayIpoBase
    {
        /// <summary>
        /// 收款账号名称
        /// </summary>
        public string AccName { get; set; }

        /// <summary>
        /// 收款银行代码：见附录
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 收款银行账号
        /// </summary>
        public string AccNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CashAuditId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override BankAction Action => BankAction.SpeiCash;

        ///// <summary>
        ///// 费率（feeType：0 - 指代付手续费从请求的代付交易金额中扣除，比如请求代付金额1000，我方平台需要收取5元手续费，那么代付到账金额为995；1 - 从商户余额中扣除，即请求代付金额1000，实际到账1000，商户余额减去1005。）
        ///// </summary>
        //[JsonIgnore]
        //public string FeeType { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override Type DtoType => typeof(CashSpeiIpo);
    }

    /// <summary>
    /// 
    /// </summary>
    public class CashSpeiDto : PayDtoBase
    {
       
    }
}
