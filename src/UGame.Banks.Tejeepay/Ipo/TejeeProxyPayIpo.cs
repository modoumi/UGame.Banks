using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Tejeepay.Model;

namespace UGame.Banks.Tejeepay.Dto
{
    public class TejeeProxyPayIpo : PayIpoBase
    {
        //public string CashAuditId { get; set; }
        /// <summary>
        /// df104
        /// </summary>
        public BizOutEnum BizEnum { get; set; } = 0;
        /// <summary>
        /// 默认CPF
        /// </summary>
        public int certType { get; set; } = 0;
    
        public string certId { get; set; }

        public string bankCardNo { get; set; }
     
        public string bankCardName { get; set; }



        /// <summary>
        /// 银行编码（银行卡代付时必传）
        /// </summary>
        public string bankCode { get; set; }

        /// <summary>
        /// 1借记卡 2信用卡
        /// </summary>
        public string bankCardType { get; set; }
        /// <summary>
        /// 银行卡类型为2信用卡时必传 信用卡有效期,MMyy
        /// </summary>
        public string creditValid { get; set; }
        /// <summary>
        /// 银行卡类型为2信用卡时必传 卡背面后3位数字
        /// </summary>
        public string creditCvv { get; set; }

        /// <summary>
        /// 收款人手机号(墨西哥代付下单必填)
        /// </summary>
        public string? mobile { get; set; }

        /// <summary>
        /// 收款人邮箱(墨西哥代付下单必填)
        /// </summary>
        public string? email { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string? bankName { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action => BankAction.TejeeProxyPay;

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(TejeeProxyPayDto);
    }


    public class TejeeProxyPayDto : PayDtoBase
    {
         //public override string status { get; set; }
        public string tradeId { get; set; }
        public string batchOrderNo { get; set;}
        public string mchtId { get; set;}
    }
}
