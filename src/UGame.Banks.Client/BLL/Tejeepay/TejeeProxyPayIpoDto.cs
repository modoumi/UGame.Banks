using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Tejeepay
{
    internal class TejeeProxyPayIpo:BaseIpo
    {
        public string CashAuditId { get; set; }
        /// <summary>
        /// df104
        /// </summary>
        public int BizEnum { get; set; } = 0;
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
        ///  收款人手机号
        /// </summary>
        public string? Mobile { get; set; }

        /// <summary>
        /// 收款人邮箱
        /// </summary>
        public string? Email { get; set; }

    }

    public class TejeeProxyPayDto:BaseDto
    {
        public string tradeId { get; set; }
        public string batchOrderNo { get; set; }
        public string mchtId { get; set; }
    }
}
