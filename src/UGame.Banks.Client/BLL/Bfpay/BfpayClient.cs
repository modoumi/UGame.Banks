using TinyFx.AspNet;

namespace UGame.Banks.Client.BLL.Bfpay
{
    public class BfpayClient : BaseClient
    {
        public BfpayClient(string clientName = "xxyy.banks") : base(clientName)
        {
            
        }

        public async Task<ApiResult<BfpayPayDto>> BfpayPay(XxyyBfpayPayIpo xxyyIpo)
        {
            var ipo = new BfpayPayIpo
            {
                BankId = "bfpay",
                Amount = xxyyIpo.Amount,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId = xxyyIpo.CountryId,
                Email = xxyyIpo.Email,
                Meta = xxyyIpo.Meta,
                Name = xxyyIpo.Name,
                Phone = xxyyIpo.Phone,
                ReceiveBonus = xxyyIpo.ReceiveBonus,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = xxyyIpo.UserIp,
                ActivityIds = xxyyIpo.ActivityIds,
                IsAddBalance = xxyyIpo.IsAddBalance,
                BankCode = null,
                TaxId = xxyyIpo.TaxId
            };
            if (string.IsNullOrWhiteSpace(ipo.UserIp))
                ipo.UserIp = AspNetUtil.GetRemoteIpString();
            switch (ipo.CountryId)
            {
                case "BRA":
                    if (string.IsNullOrWhiteSpace(ipo.Name))
                        ipo.Name = "name777";
                    if (string.IsNullOrWhiteSpace(ipo.Phone))
                        ipo.Phone = "12345678901";
                    if (string.IsNullOrWhiteSpace(ipo.Email))
                        ipo.Email = "test@lucro777.com";
                    break;
                default:
                    break;
            }
            SetIpoData(ipo);
            var rsp = await PostJson<BfpayPayIpo, BfpayPayDto>(ipo, "api/bank/bfpay/pay");
            return rsp;
        }

        public async Task<ApiResult<BaseDto>> BfpayCash(XxyyBfpayCashIpo xxyyIpo)
        {
            var ipo = new BfpayCashIpo
            {
                BankId = "mlpay",
                TaxId = xxyyIpo.TaxId,
                Amount = xxyyIpo.Amount,
                CashRate = xxyyIpo.CashRate,
                AppId = xxyyIpo.AppId,
                AppOrderId = xxyyIpo.AppOrderId,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId = xxyyIpo.CountryId,
                UserIp = xxyyIpo.UserIp,
                UserId = xxyyIpo.UserId,
                AccountName = xxyyIpo.AccountName,
                AccountNo = xxyyIpo.AccountNo,
                BankCode = xxyyIpo.BankCode,
                CashAuditId = xxyyIpo.CashAuditId,
                Email = xxyyIpo.Email,
                Meta = xxyyIpo.Meta,
                Phone = xxyyIpo.Phone,
                ReceiveBonus = 0,
               BankCardNo=xxyyIpo.BankCardNo,
               BankCardName=xxyyIpo.BankCardName,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                CertId = xxyyIpo.CertId,
               CertType = xxyyIpo.CertType,
               
            };
            if (string.IsNullOrWhiteSpace(ipo.UserIp))
                ipo.UserIp = AspNetUtil.GetRemoteIpString();
            switch(ipo.CountryId)
            {
                case "BRA":
                    if (string.IsNullOrWhiteSpace(ipo.Phone))
                        ipo.Phone = "12345678901";
                    if (string.IsNullOrWhiteSpace(ipo.Email))
                        ipo.Email = "test@lucro777.com";
                    break;
                default:
                    break;
            }
            SetIpoData(ipo);
            var rsp = await PostJson<BfpayCashIpo, BaseDto>(ipo, "api/bank/bfpay/cash");
            return rsp;
        }
    }
}
