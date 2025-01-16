//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;
//using TinyFx.Net;
//using TinyFx.Security;
//using TinyFx;
//using Xxyy.Common.Caching;
//using Xxyy.Common;
//using Xxyy.Banks.BLL.Services.Pay;
//using Xxyy.Banks.BLL;
//using Xxyy.Banks.Inx.Core;
//using Xxyy.Banks.BLL.Common;
//using Xxyy.Banks.DAL;
//using MySqlX.XDevAPI.Common;
//using TinyFx.Data;
//using Org.BouncyCastle.Asn1.Ocsp;
//using Xxyy.DAL;
//using TinyFx.ShortId;
//using TinyFx.Logging;
//using TinyFx.Configuration;
//

//namespace Xxyy.Banks.Inx
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class BankProxy// : VisaProxyBase
//    {
//        #region Base
//        private InxBankConfig _config;
//        private HttpClientEx _client;
//        private Sb_bank_orderMO _bankOrderMo = new();
//        private const int TryCount = 3;
//        private static ShortIdOptions _shortIdOptions = new ShortIdOptions
//        {
//            CustomAlphabet = ",.;:?!/@#$%^&()=+*{}[]<>|~"
//        };
//        public BankProxy(string bankId)// : base(bankId)
//        {
//            _config = new InxBankConfig();
//            if (_config.BankId != bankId)
//                throw new Exception("当前工程的Xxyy.Banks.XXX名称与BankId必须相同！");
//            _client = HttpClientExFactory.CreateClientEx(bankId);
//        }
//        private async Task<HttpResponseResult<TSuccess, TError>> PostJson<TSuccess, TError>(string url, object req, string transId)
//        {
//            var json = SerializerUtil.SerializeJson(req);
//            var rsp = await _client.CreateAgent()
//                .AddUrl(url)
//                .BuildJsonContent(json)
//                .PostAsync<TSuccess, TError>();
           
//            return rsp;
//        }
//        private string SignData(string source, string privateKey)
//        {
//            return SecurityUtil.RSASignData(source, privateKey
//                 , RSAKeyMode.RSAPrivateKey
//                , HashAlgorithmName.SHA256               
//                , CipherEncode.Base64               
//                , Encoding.UTF8);
//        }
//        #endregion

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="req"></param>
//        /// <param name="transId"></param>
//        /// <returns></returns>
//        /// <exception cref="CustomException"></exception>
//        public async Task<PayWorksRsp> Pay(PayWorksReq req, string transId)
//        {
//            var rsp = await PostJson<PayWorksRsp, object>("/api/Banorte/Pay", req, transId);
//            if (!rsp.Success)
//                throw new CustomException(PartnerCodes.RS_UNKNOWN);
//            return rsp.SuccessResult;
//        }


//        ///// <summary>
//        ///// 生成交易流水号--也就是对方的orderid(商户下唯一)
//        ///// </summary>
//        ///// <param name="bankId"></param>
//        ///// <returns></returns>
//        //private async Task<string> GetOwnOrderId(string bankId)
//        //{
//        //    string bankTransactionId = ShortIdUtil.Generate(_shortIdOptions, 15);
//        //    List<Sb_bank_orderEO> bankOrders = null;
//        //    int tryCount = 0;
//        //    while (tryCount<TryCount)
//        //    {
//        //        tryCount++;
//        //        bankOrders = await _bankOrderMo.GetTopAsync("BankID=@BankID and OwnOrderId=@OwnOrderId", 1, bankId, bankTransactionId);
//        //        if (null == bankOrders || bankOrders.Count == 0)
//        //        {
//        //            return bankTransactionId;
//        //        }
//        //        bankTransactionId=ShortIdUtil.Generate(_shortIdOptions, 15);
//        //    }
//        //    throw new Exception("无法生成交易流水号：OwnOrderId");
//        //}

       

//        #region payvisa
//        /// <summary>
//        /// 支付接口
//        /// </summary>
//        /// <param name="ipo"></param>
//        /// <param name="dto"></param>
//        /// <returns></returns>
//        /// <exception cref="CustomException"></exception>
//        public async Task Pay(VisaIpo ipo,VisaDto dto)
//        {
//            //获取交易流水号
//            //string bankTransationId = await GetOwnOrderId(ipo.BankId);
//            var timeStamp = DateTime.UtcNow.Ticks;
//            var payWorksReq = new PayWorksReq()
//            {
//                CardNumber = ipo.CardNo,
//                CardExp = ipo.ExpiryDate,
//                Amount = Math.Round(ipo.Amount.AToM(ipo.CurrencyId),2),//Math.Round(XxyyUtil.Amount2Money(ipo.CurrencyId,ipo.Amount),2),
//                CardType =0,
//                IdSecureTransaction= ipo.OwnOrderId,
//                City= ipo.City,
//                Country=ipo.Country,
//                Email= ipo.Email,
//                Name=ipo.FirstName,
//                LastName=ipo.LastName,
//                PostalCode= ipo.PostalCode,
//                State= ipo.State,
//                Street= ipo.Street,
//                MobilePhone= ipo.MobilePhone,
//                CreditType= 0,
//                SecurityCode = ipo.CVV,
//                Callback=ConfigUtil.GetCustomConfig<InxBankConfig>().PayCallbackUrl, //DIUtil.GetRequiredService<AppOptions>().InxVisaCallbackUrl,
//                Timestamp = timeStamp,
//                AppId = InxBankConfig.BankAppId
//            };
//            payWorksReq.Sign = SignHelper.GetSign(payWorksReq, InxBankConfig.BankAppSecret);
//            //dto.Amount = ipo.Amount;
//            //dto.BankOrderId = payWorksReq.IdSecureTransaction;
//            //dto.OwnOrderId = payWorksReq.IdSecureTransaction;
//            var payWorksRet = await this.Pay(payWorksReq, null);
//            dto.OperatorSuccess = payWorksRet.Success&&payWorksRet.Code==(int)InxResponseCodeEnum.Success;
//            if (payWorksRet.Code != (int)InxResponseCodeEnum.Success)
//            {
//                throw new CustomException(PartnerCodes.RS_UNKNOWN,"支付过程出错");
//            }
//            //dto.BankOrderId = payWorksRet.IdSecureTransaction;
//            dto.PayHtml = payWorksRet.Obj;
//        }
//        #endregion


       
//    }
//}
