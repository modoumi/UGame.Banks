using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.BFpay.IpoDto
{
    public class BfpayCashIpo : PayIpoBase
    {
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
        //public override BankAction Action => BankAction.None;

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(BfpayCashDto);
    }

    public class BfpayCashDto : PayDtoBase
    {

    }
}
