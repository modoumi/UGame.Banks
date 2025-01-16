using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Inx
{
    /// <summary>
    /// 
    /// </summary>
    public class VisaIpo : PayIpoBase
    {

        ///// <summary>
        ///// 3d验证返回的reference3d,交易的唯一编号
        ///// </summary>
        //public string ControlNumber { get; set; }

        /// <summary>
        /// 银行卡号
        /// 【字段 varchar(50)】
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 过期时间
        /// 【字段 varchar(10)】
        /// </summary>
        public string ExpiryDate { get; set; }
        /// <summary>
        /// CVV
        /// 【字段 varchar(10)】
        /// </summary>
        public string CVV { get; set; }

        /// <summary>
        /// 支付类型1-visa 2-spei
        /// 【字段 int】
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 用户名字
        /// 【字段 varchar(50)】
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 用户姓氏
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostalCode { get; set; }


        //public string UserId { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 州
        /// </summary>
        public string State { get; set; }




        //public string TransactionUUID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public override BankAction Action => BankAction.VisaPay;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override Type DtoType => typeof(VisaDto);
    }

    /// <summary>
    /// 
    /// </summary>
    public class VisaDto : PayDtoBase
    {
        /// <summary>
        /// 对方银行返回的支付html
        /// </summary>
        public string PayHtml { get; set; }
    }
}
