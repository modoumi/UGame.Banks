using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Tejeepay
{
    public class XxyyTejeeCommonPayIpo
    {
        /// <summary>
        /// 支付方式
        ///  巴西扫码API[区别于bq101是直接返回支付底链信息商户自主生成二维码，bq102 = 1,
        ///  墨西哥转账支付，mc101 = 4,
        /// </summary>
        public int BizEnum { get; set; } = 1;

        /// <summary>
        /// IP
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public long Amount { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 应用appid编码
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
        /// 充值参与领取bonus状态，0不参与，1参与
        /// </summary>
        public int ReceiveBonus { get; set; }


        /// <summary>
        /// 请求备注
        /// </summary>
        public string ReqComment { get; set; }

        /// <summary>
        /// 活动id集合
        /// </summary>
        public List<string> ActivityIds { get; set; }

        /// <summary>
        /// 充值是否添加用户余额
        /// </summary>
        public bool IsAddBalance { get; set; } = true;

        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }

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
    }
}
