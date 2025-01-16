using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;
using Xxyy.Common;

namespace UGame.Banks.Tejeepay.Dto
{
    public class TejeeCommonPayIpo : PayIpoBase
    {
        public int BizEnum { get; set; } = 1;

        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIp { get; set; }

        /// <summary>
        /// 币种是BRL,USDT,THB,PHP，此参数可不传
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// 币种是BRL,USDT,THB,PHP，此参数可不传
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 币种是BRL,USDT,THB,PHP，此参数可不传
        /// </summary>
        public string? Email { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action => BankAction.TejeeCommonPay;

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(TejeeCommonPayDto);
    }


    public class TejeeCommonPayDto : PayDtoBase
    {
        /// <summary>
        /// 商户编号,不参与签名
        /// </summary>
        public string mchtId { get; set; }

        /// <summary>
        /// 支付URL地址
        /// </summary>
        public string payUrl { get; set; }

        /// <summary>
        /// 支付平台返回的交易流水号
        /// </summary>
        public string tradeId { get; set; }
    }
}
