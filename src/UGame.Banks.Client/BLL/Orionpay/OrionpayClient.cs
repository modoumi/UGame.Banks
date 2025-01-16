using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using UGame.Banks.Client.BLL.Letspay;

namespace UGame.Banks.Client.BLL.Orionpay
{
    public class OrionpayClient : BaseClient
    {
        public OrionpayClient(string clientName = "xxyy.banks") : base(clientName)
        {

        }

        /// <summary>
        /// orionPay充值
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<OrionCommonPayDto>> OrionPay(XxyyOrionCommonPayIpo xxyyIpo)
        {
            var ipo = new OrionCommonPayIpo
            {
                BankId = "orionpay",
                Amount = xxyyIpo.Amount,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                CurrencyId = xxyyIpo.CurrencyId,
                email = xxyyIpo.email,
                Meta = xxyyIpo.Meta,
                name = xxyyIpo.name,
                phone = xxyyIpo.phone,
                number = xxyyIpo.number,
                type = xxyyIpo.type,
                zipCode = xxyyIpo.zipCode,
                ReceiveBonus = xxyyIpo.ReceiveBonus,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = xxyyIpo.UserIp,
                ClientIp = xxyyIpo.UserIp
            };
            SetIpoData(ipo);
            var rsp = await PostJson<OrionCommonPayIpo, OrionCommonPayDto>(ipo, "api/bank/Orionpay/pay");
            return rsp;
        }

        /// <summary>
        /// orionpay提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<OrionProxyPayDto>> OrionCash(XxyyOrionProxyPayIpo xxyyIpo)
        {
            var ipo = new OrionProxyPayIpo
            {
                BankId = "orionpay",
                Amount = xxyyIpo.Amount,
                AppId = xxyyIpo.AppId,
                AppOrderId = xxyyIpo.cashAuditId,
                CurrencyId = xxyyIpo.CurrencyId,
                UserIp = xxyyIpo.UserIp,
                UserId = xxyyIpo.UserId,
                cashAuditId = xxyyIpo.cashAuditId,
                email = xxyyIpo.email,
                Meta = xxyyIpo.Meta,
                phone = xxyyIpo.phone,
                certType = xxyyIpo.certType,
                certValue = xxyyIpo.certValue,
                identifyType = xxyyIpo.identifyType,
                identifyValue = xxyyIpo.identifyValue,
                name = xxyyIpo.name,
                zipCode = xxyyIpo.zipCode,
                ReceiveBonus = 0,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null
            };
            SetIpoData(ipo);
            var rsp = await PostJson<OrionProxyPayIpo, OrionProxyPayDto>(ipo, "api/bank/Orionpay/cash");
            return rsp;
        }


        /// <summary>
        /// orionpay支付二维码
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<OrionQRCodeDto>> QRCode(XxyyOrionQrCodeIpo xxyyIpo)
        {
            var ipo = new OrionpayQRCodeIpo
            {
                BankId = "orionpay",
                Amount = 0,
                AppOrderId=null,
                BankOrderId=xxyyIpo.BankOrderId,
                AppId = xxyyIpo.AppId,
                UserId = xxyyIpo.UserId,
                RequestUUID = null
            };
            SetIpoData(ipo);
            var rsp = await PostJson<OrionpayQRCodeIpo, OrionQRCodeDto>(ipo, "api/bank/Orionpay/code");
            return rsp;
        }
    }
}
