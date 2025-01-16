using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Logging;
using TinyFx;
using UGame.Banks.Client.BLL;
using TinyFx.AspNet;
using UGame.Banks.Client.BLL.Tejeepay;

namespace UGame.Banks.Client.BLL.Tejeepay
{
    public class TejeepayClient : BaseClient
    {
        public TejeepayClient(string clientName = "xxyy.banks") : base(clientName)
        {

        }

        #region tejeePay
        /// <summary>
        /// tejeePay充值
        /// </summary>
        /// <param name="xxyyIpo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<TejeeCommonPayDto>> TejeePay(XxyyTejeeCommonPayIpo xxyyIpo)
        {
            var ipo = new TejeeCommonPayIpo
            {
                Amount = xxyyIpo.Amount,
                ClientIp = xxyyIpo.UserIp,
                UserIp = xxyyIpo.UserIp,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                BankId = "tejeepay",
                BizEnum = xxyyIpo.BizEnum,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId=xxyyIpo.CountryId,
                Meta = xxyyIpo.Meta,
                ReceiveBonus = xxyyIpo.ReceiveBonus,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                ActivityIds= xxyyIpo.ActivityIds,
                IsAddBalance=xxyyIpo.IsAddBalance,
                Name = xxyyIpo.Name,
                Phone= xxyyIpo.Phone,
                Email= xxyyIpo.Email
            };
            if (string.IsNullOrWhiteSpace(ipo.UserIp))
                ipo.UserIp = AspNetUtil.GetRemoteIpString();
            if (string.IsNullOrWhiteSpace(ipo.ClientIp))
                ipo.ClientIp = AspNetUtil.GetRemoteIpString();
            switch (xxyyIpo.CurrencyId)
            {
                case "MXN":
                    ipo.Name = "testabc";
                    ipo.Phone = "0123456789";
                    ipo.Email = "test@qq.com";
                    ipo.BizEnum = (int)BizInEnum.mc101;
                    break;
                default:
                    break;
            }
            SetIpoData(ipo);
            var rsp = await PostJson<TejeeCommonPayIpo, TejeeCommonPayDto>(ipo, "api/bank/tejeepay/pay2");
            return rsp;
        }

        /// <summary>
        /// tejee提现
        /// </summary>
        /// <param name="xxyyIpo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<TejeeProxyPayDto>> TejeeCash(XxyyTejeeProxyPayIpo xxyyIpo)
        {
            var ipo = new TejeeProxyPayIpo
            {
                Amount = xxyyIpo.Amount,
                AppId = xxyyIpo.AppId,
                AppOrderId = xxyyIpo.AppOrderId,
                bankCardName = xxyyIpo.BankCardName,
                bankCardNo = xxyyIpo.BankCardNo,
                bankCardType = xxyyIpo.BankCardType,
                bankCode = xxyyIpo.BankCode,
                BankId = "tejeepay",
                BizEnum = xxyyIpo.BizEnum,
                CashAuditId = xxyyIpo.CashAuditId,
                certId = xxyyIpo.CertId,
                certType = xxyyIpo.CertType,
                creditCvv = xxyyIpo.CreditCvv,
                creditValid = xxyyIpo.CreditValid,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId=xxyyIpo.CountryId,
                Meta = xxyyIpo.Meta,
                ReceiveBonus = 0,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = xxyyIpo.UserIp,
                Mobile=xxyyIpo.Mobile,
                Email=xxyyIpo.Email,
                CashRate = xxyyIpo.CashRate
            };
            if (string.IsNullOrWhiteSpace(ipo.UserIp))
                ipo.UserIp = AspNetUtil.GetRemoteIpString();
            switch (ipo.CurrencyId)
            {
                case "MXN":
                    if (ipo.BizEnum != (int)BizOutEnum.df101 && ipo.BizEnum != (int)BizOutEnum.df103)
                        throw new CustomException($"墨西哥支付{nameof(ipo.BizEnum)}参数错误！");
                    if (string.IsNullOrWhiteSpace(ipo.bankCardName))
                        throw new CustomException($"墨西哥支付{nameof(ipo.bankCardName)}不能为空！");
                    if (string.IsNullOrWhiteSpace(ipo.bankCardNo))
                        throw new CustomException($"墨西哥支付{nameof(ipo.bankCardNo)}不能为空！");
                    ipo.Mobile = "0123456789";
                    ipo.Email = "test@qq.com";
                    //if (string.IsNullOrWhiteSpace(ipo.Mobile))
                    //    throw new CustomException($"墨西哥支付{nameof(ipo.Mobile)}不能为空！");
                    //if (string.IsNullOrWhiteSpace(ipo.Email))
                    //    throw new CustomException($"墨西哥支付{nameof(ipo.Email)}不能为空！");
                    break;
                default:
                    break;
            }
            SetIpoData(ipo);
            var rsp = await PostJson<TejeeProxyPayIpo, TejeeProxyPayDto>(ipo,"api/bank/tejeepay/cash2");
            return rsp;
        }

        public async Task<ApiResult<List<BankCodeModel>>> BankList(XxyyTejeeBankListIpo xxyyIpo)
        {
            var ipo = new TejeeBankListIpo { 
                UserId= xxyyIpo.UserId,
                AppId= xxyyIpo.AppId,
                BankId= "tejeepay",
                CountryId= xxyyIpo.CountryId
            };
            var rsp = await PostJson<TejeeBankListIpo, List<BankCodeModel>>(ipo, "api/bank/tejeepay/banklist");
            return rsp;
        }
        #endregion
    }
}
