using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Mongopay.Models.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class PayIpo : PayIpoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override BankAction Action => BankAction.SpeiPay;

        /// <summary>
        /// 
        /// </summary>
        public override Type DtoType => typeof(PayIpo);
    }
}
