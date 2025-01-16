using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL
{
    internal class BaseIpo
    {
        /// <summary>
        /// 充值或提现的金额
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// app订单编码
        /// </summary>
        public string AppOrderId { get; set; }


        /// <summary>
        /// 请求备注
        /// </summary>
        public string ReqComment { get; set; }

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
        public bool IsAddBalance { get; set; } = true;
        
        /// <summary>
        /// vip提现时扣除的手续费费率
        /// </summary>
        public decimal CashRate { get; set; }
    }

    public class BaseDto
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
        public long Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string CurrencyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsFirstCashOfDay { get; set; }

        /// <summary>
        /// 扩展书
        /// </summary>
        public object Meta { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Message { get; set; }
    }
}
