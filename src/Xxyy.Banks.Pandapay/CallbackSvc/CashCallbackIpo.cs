using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Pandapay.CallbackSvc
{
    public class CashCallbackIpo: CallbackIpoCommonBase
    {
        public string amount { get; set; }
        public string bankAccountNumber { get; set; }
        public string bankCode { get; set; }
        public string bankName { get; set; }
        public decimal fee { get; set; }
        public string payTime { get; set; }
        public string reference { get; set; }
        public string status { get; set; }
        public string transactionId { get; set; }
        public string transactionDescription { get; set; }
    }
}
