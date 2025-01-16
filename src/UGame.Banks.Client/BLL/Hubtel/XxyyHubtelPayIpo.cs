using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Hubtel
{
    public class XxyyHubtelPayIpo
    {
        /// <summary>
        /// 还款（充值）时的用户钱包
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 还款（充值）时的用channel
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 充值或提现的金额
        /// </summary>
        public long Amount { get; set; }

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
        /// 国家编码
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// 充值参与领取bonus状态，2不参与，1参与
        /// </summary>
        public int ReceiveBonus { get; set; }
        /// <summary>
        /// 用户ip
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 请求备注
        /// </summary>
        public string ReqComment { get; set; }

        /// <summary>
        /// 活动id集合
        /// </summary>
        public List<string> ActivityIds { get; set; }

        /// <summary>
        /// 是否操作账户余额，默认true
        /// </summary>
        public bool IsAddBalance { get; set; } = true;
        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }
    }
}
