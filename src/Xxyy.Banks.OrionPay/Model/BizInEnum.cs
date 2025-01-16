using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Orionpay.Model
{
    public enum BizInEnum
    { 
        ///pix代付传
        bq101 = 0,
        ///巴西扫码API[区别于bq101是直接返回支付底链信息商户自主生成二维码
        bq102 = 1,
        ///收银台支付方式
        ca001 = 2,
        /// <summary>
        /// 数字货币支付
        /// </summary>
        us101 = 3
    }
}
