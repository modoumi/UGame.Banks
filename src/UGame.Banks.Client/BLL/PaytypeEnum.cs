using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public enum PayTypeEnum
    {
        /// <summary>
        /// 综合
        /// </summary>
        Common = 0,
        /// <summary>
        /// visa
        /// </summary>
        Visa = 1,
        /// <summary>
        /// spei
        /// </summary>
        Spei = 2,
        /// <summary>
        /// hubtel(电子钱包)
        /// </summary>
        Wallet = 3,
        /// <summary>
        /// pandapay
        /// </summary>
        Pandapay = 4,
        /// <summary>
        /// tejeepay
        /// </summary>
        Tejeepay = 5,
        /// <summary>
        /// orionpay
        /// </summary>
        Orionpay = 6,
        /// <summary>
        /// letspay
        /// </summary>
        Letspay = 7

    }
}
