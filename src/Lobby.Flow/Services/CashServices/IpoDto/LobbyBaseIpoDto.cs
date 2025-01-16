using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;

namespace Lobby.Flow.Services.CashServices
{
    public class LobbyBaseIpo
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        [RequiredEx("", "UserId cannot be empty.")]
        public string UserId { get; set; }
        /// <summary>
        /// 运营商编码
        /// </summary>
        [RequiredEx("", "OperatorId cannot be empty.")]
        public string OperatorId { get; set; }
        /// <summary>
        /// 国家编码
        /// </summary>
        [RequiredEx("", "CountryId cannot be empty.")]
        public string CountryId { get; set; }
        /// <summary>
        /// 货币编码
        /// </summary>
        [RequiredEx("", "CurrencyId cannot be empty.")]
        public string CurrencyId { get; set; }
        /// <summary>
        /// 语言编码
        /// </summary>
        [RequiredEx("", "LangId cannot be empty.")]
        public string LangId { get; set; }
        /// <summary>
        /// 应用ID
        /// </summary>
        [RequiredEx("", "AppId cannot be empty.")]
        public string AppId { get; set; }
    }

    public class LobbyBaseDto
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 运营商编码
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// 国家编码
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// 货币编码
        /// </summary>
        public string CurrencyId { get; set; }
    }
}
