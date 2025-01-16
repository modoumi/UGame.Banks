using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Orionpay.Model
{
    /// <summary>
    /// Pix代付时的PIX账号类型(1)
    /// 银行卡代付(2) ---传固定值5
    ///(1)pix代付时的PIX账号，即CPF或CNPJ或Phone或E-mail或Random key(EVP)
    ///(2)银行卡代付时传：agencia，conta，contaDigito
    /// </summary>
    public enum CertTypeEnum
    {
        /// <summary>
        /// Brazilian legal person identification, 11位
        /// </summary>
        CPF = 0,
        /// <summary>
        /// Brazilian legal entity identification，14位
        /// </summary>
        CNPJ = 1,
        /// <summary>
        /// Phone number(11位): must be formatted as 08007012141
        /// </summary>
        PhoneNum = 2,
        /// <summary>
        /// 
        /// </summary>
        Email = 3,
        /// <summary>
        /// a 4-block hash separated by hyphens
        /// </summary>
        EVP = 4,
        /// <summary>
        /// 
        /// </summary>
        CardPay = 5
    }

  
}
