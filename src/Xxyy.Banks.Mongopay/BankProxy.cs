using EasyNetQ;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Configuration;
using TinyFx.Data;
using TinyFx.Logging;
using TinyFx.Net;
using TinyFx.Security;
using Xxyy.Banks.BLL;
using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.DAL;
using Xxyy.Common;
using Xxyy.Common.Caching;

using Xxyy.Common.Services;
using Xxyy.DAL;

namespace Xxyy.Banks.Mongopay.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class BankProxy //: SpeiProxyBase
    {
        #region Base
        //private MongoBankConfig _config;
        private HttpClientEx _client;
        private Sb_bankEO _bank;

        private const string CLIENT_NAME = "banks.mongopay";
        private const string MERCHANTCODE = "MerchantCode";
        private const string BANKCODE = "BankCode";
        private const string PAYCALLBACKURL = "PayCallbackUrl";
        private const string CASHCALLBACKURL = "CashCallbackUrl";
        //private BankErrorDCache _bankErrorDCache = new();
        private const string BANKID = "mongopay";
        //private readonly S_user_dayMO _userDayMo = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankId"></param>
        public BankProxy(string bankId)// : base(bankId)
        {
           // _config = new MongoBankConfig();
            _client = HttpClientExFactory.CreateClientExFromConfig(CLIENT_NAME);
            _bank = DbBankCacheUtil.GetBank(bankId);
           // _codes = new StatusCodes();
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task Pay(SpeiIpo ipo, SpeiDto dto)
        {
            var merchantCode = _client.GetSettingValue<string>(MERCHANTCODE);
            var bankCode = _client.GetSettingValue<string>(BANKCODE);
            var payCallbackUrl = _client.GetSettingValue<string>(PAYCALLBACKURL);
            var payReq = new CreateVAReq
            {
                MerchantCode = merchantCode, //MongoBankConfig.MerchantCode,
                OrderNum = ipo.OrderId,
                BankCode = bankCode, //MongoBankConfig.BankCode,
                Name = ipo.UserId,
                NotifyUrl = payCallbackUrl,
                DateTime = DateTime.UtcNow.ToString("yyyyMMddHHmmss")
            };
            //请求数据签名
            payReq.Sign = SignDataByPrivateKey(SignHelper.GetSign(payReq),_bank.OwnPrivateKey);

            var ret = await this.Pay(payReq,dto);
            //验证返回的数据签名
            if (!VerifyResponseDataByPublicKey(ret, ret.PlatSign, _bank.TrdPublicKey))
            {
                throw new CustomException(PartnerCodes.RS_INVALID_SIGNATURE, "验证签名错误");
            }
            dto.OperatorSuccess = ret.PlatRespCode == "SUCCESS";
            if (!dto.OperatorSuccess)
            {
                LogUtil.Warning($"mongopay充值失败！orderid:{ipo.OrderId},返回结果ret为:{SerializerUtil.SerializeJsonNet(ret)}");
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, "支付过程出错");
            }
           // dto.Amount = ret.Amount;
            dto.VaNumber=ret.VaNumber;
            dto.BankOrderId = ret.PlatOrderNum;
        }

        private bool VerifyResponseDataByPublicKey<T>(T source, string sign, string publicKey)
        {
            var decryptdata = SecurityUtil.RSADecryptUsePublicKey(sign, publicKey); //RSAUtil.DecryptByPublicKey(sign, publicKey);
            var sourceToVerify = SignHelper.GetSign(source);
            return sourceToVerify==decryptdata;
        }

        /// <summary>
        /// 线上还款
        /// </summary>
        /// <param name="req"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<CreateVARsp> Pay(CreateVAReq req, SpeiDto dto)
        {
            string requestUrl = "/gateway/createVA";
            dto.TransMark = requestUrl;
            var rsp = await PostJson<CreateVARsp, MongopayBaseRsp>(requestUrl, req);
            if (!rsp.Success||rsp.SuccessResult?.PlatRespCode!="SUCCESS")
            {
                //await _bankErrorDCache.IncrError(BANKID);
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, rsp.SuccessResult?.PlatRespMessage?? "创建虚拟账户出错");
            }
            //else
            //{
            //    await _bankErrorDCache.SetAsync(BANKID,0);
            //}
            return rsp.SuccessResult;
        }

        /// <summary>
        /// 提现（出款）
        /// </summary>
        /// <param name="req"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<CashRsp> Cash(CashReq req, CashSpeiDto dto)
        {
            string requestUrl = "/gateway/cash";
            dto.TransMark = requestUrl;
            var rsp = await PostJson<CashRsp, MongopayBaseRsp>(requestUrl, req);
            if (!rsp.Success || rsp.SuccessResult?.PlatRespCode != "SUCCESS")
            {
                //await _bankErrorDCache.IncrError(BANKID);
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, rsp.SuccessResult?.PlatRespMessage ?? "提款出错");
            }
            //else
            //{
            //    await _bankErrorDCache.SetAsync(BANKID, 0);
            //}
            return rsp.SuccessResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Cash(CashSpeiIpo ipo, CashSpeiDto dto,TransactionManager tm=null)
        {
            var merchantCode = _client.GetSettingValue<string>(MERCHANTCODE);
            var cashCallbackUrl = _client.GetSettingValue<string>(CASHCALLBACKURL);
            var getNumberTypeFunc = (string bankNumber) => {
                switch (bankNumber.Trim().Length)
                {
                    case 18:
                        return "40";
                    case 16:
                        return "3";
                    default:
                        throw new Exception("不支持的银行卡账号！");
                }
            };
            string feeType = "0";
            //每天首提免手续费
            var userDCache = new GlobalUserDCache(ipo.UserId);
            var lastCashDate=await userDCache.GetLastCashDateAsync();
            if (lastCashDate.ToString("yyyyMMdd") != DateTime.UtcNow.ToString("yyyyMMdd"))
            {
                dto.IsFirstCashOfDay = true;
                feeType = "1";
               await userDCache.SetLastCashDateAsync(DateTime.UtcNow);
            }
            //待提现的金额
            //decimal cashMoney = ipo.Amount.AToM(ipo.CurrencyId);
            decimal cashMoney = Math.Truncate(100 * ipo.Amount.AToM(ipo.CurrencyId)) / 100; 
            dto.TransMoney = cashMoney;
            var cashReq = new CashReq
            {
                MerchantCode = merchantCode,
                OrderNum = ipo.OrderId,
                FeeType= feeType,//暂定0
                BankCode = ipo.BankCode,//银行代码，具体见 5.附录
                Number=ipo.AccNumber,//
                NumberType= getNumberTypeFunc(ipo.AccNumber),//ipo.BankNumber.Trim().Length==18?"40":"3",//40。收款账号类型(3：DebitCard，40：CLABE)
                Name = ipo.AccName,
                Money= cashMoney,
                Description= ipo.OrderId,//转账描述-我方订单号
                NotifyUrl = cashCallbackUrl, 
                DateTime = DateTime.UtcNow.ToString("yyyyMMddHHmmss")
            }; 
            cashReq.Sign = SignDataByPrivateKey(SignHelper.GetSign(cashReq), _bank.OwnPrivateKey);
           
            var ret =await this.Cash(cashReq,dto);
            //验证返回的数据签名
            if (!VerifyResponseDataByPublicKey(ret, ret.PlatSign, _bank.TrdPublicKey))
            {
                throw new CustomException(PartnerCodes.RS_INVALID_SIGNATURE, $"验证签名错误！platsign:{ret.PlatSign}");
            }
            dto.OperatorSuccess = ret.PlatRespCode == "SUCCESS";
            if (!dto.OperatorSuccess)
            {
                LogUtil.Warning($"mongopay提现失败！orderid:{ipo.OrderId},返回结果ret为:{SerializerUtil.SerializeJsonNet(ret)}");
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, $"提款过程出错!,ret:{SerializerUtil.SerializeJsonNet(ret)}");
            }
            //dto.Amount = (long)(ret.Money*100000);
            dto.BankOrderId = ret.PlatOrderNum;
            //dto.CashAmount = cashMoney.MToA(ipo.CurrencyId);
        }



        private async Task<HttpResponseResult<TSuccess, TError>> PostJson<TSuccess, TError>(string url, object req)
        {
            var json = SerializerUtil.SerializeJson(req);
            LogUtil.Info($"请求mongopay接口url:{url}，req:{json}");
            //var sign = SignData(json, Provider.OwnPrivateKey);
            var rsp = await _client.CreateAgent()
                .AddUrl(url)
                //.AddRequestHeader(_config.SignHeaderName, sign)
                .BuildJsonContent(json)
                .PostAsync<TSuccess, TError>();
            LogUtil.Info($"请求mongopay接口url:{url}，req:{json},success:{rsp?.Success}，返回值resultstring：{rsp?.ResultString}");
            return rsp;
        }
        private string SignData(string source, string privateKey)
        {
            return SecurityUtil.RSASignData(source, privateKey
                , RSAKeyMode.PrivateKey
                , HashAlgorithmName.SHA256
                , CipherEncode.Base64
                , Encoding.UTF8);
        }
        private string SignDataByPrivateKey(string source, string privateKey)
        {
            //var netkey = RSAUtil.RSAPrivateKeyJavaToDotNet(privateKey);
            //return RSAUtil.PrivateKeyEncrypt(netkey, source);

            return SecurityUtil.RSAEncryptUsePrivateKey(source,privateKey,RSAKeyMode.PrivateKey);

        }


        #endregion

    }
}
