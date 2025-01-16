using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Common
{
    /// <summary>
    /// tejeePay提现方式
    /// </summary>
    public enum TejeePayMethodEnum
    {
        /// <summary>
        /// CPF
        /// </summary>
        CPF = 0,

        /// <summary>
        /// CNPJ
        /// </summary>
        CNPJ = 1,

        /// <summary>
        /// PHONE
        /// </summary>
        PHONE = 2,

        /// <summary>
        /// EMAIL
        /// </summary>
        EMAIL = 3,

        /// <summary>
        /// EVP
        /// </summary>
        EVP = 4
    }
}
