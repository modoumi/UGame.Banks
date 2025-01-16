using TinyFx.AspNet;

namespace UGame.Banks.Client.BLL.Mlpay
{
    public class MlpayClient : BaseClient
    {
        public MlpayClient(string clientName = "xxyy.banks") : base(clientName)
        {
            
        }

        public async Task<ApiResult<MlpayPayDto>> MlpayPay(XxyyMlpayPayIpo xxyyIpo)
        {
            var ipo = new MlpayPayIpo
            {
                BankId = "mlpay",
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
            var rsp = await PostJson<MlpayPayIpo, MlpayPayDto>(ipo, "api/bank/mlpay/pay");
            return rsp;
        }

        public async Task<ApiResult<BaseDto>> MlpayCash(XxyyMlpayCashIpo xxyyIpo)
        {
            var ipo = new MlpayCashIpo
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
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null
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
            var rsp = await PostJson<MlpayCashIpo, BaseDto>(ipo, "api/bank/mlpay/cash");
            return rsp;
        }
    }
}
