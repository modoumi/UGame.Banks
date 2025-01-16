using EasyNetQ;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Configuration;
using TinyFx.Data.SqlSugar;
using TinyFx.Logging;
using TinyFx.Net;
using TinyFx.Security;
using TinyFx.Text;
using UGame.Banks.Hubtel.PaySvc;
using UGame.Banks.Hubtel.Proxy;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using Xxyy.Banks.DAL;
using UGame.Banks.Hubtel;
using Xxyy.Common;

using static System.Net.WebRequestMethods;

namespace UGame.Banks.Hubtel
{
    public class BankProxy//:HubtelProxyBase
    {
        #region Base
        //private HttpClientEx _clientPay;
        //private HttpClientEx _clientCash;
        //private HttpClientEx _clientVerifyCustomer;
        //private HttpClientEx _verifyPayOrder;
        //private HttpClientEx _verifyCashOrder;
        //private HttpClientEx _queryPosSalesAccount;
        private const string SIGNHEADERNAME = "Authorization";
        public HubtelConfig _hubtelConfig;
        private Sb_bankEO _bank;
        protected string _bankId;
        protected static ConcurrentDictionary<string, HttpClientEx> _clientDict = new();
        public BankProxy() : this("hubtel")
        {

        }

        public BankProxy(string bankId)//: base(bankId)
        {
            _bankId = bankId;
            _bank = DbBankCacheUtil.GetBank(bankId);
            _hubtelConfig = SerializerUtil.DeserializeJsonNet<HubtelConfig>(_bank.BankConfig);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task Pay(PayIpo ipo, PayDto dto)
        {
            var payMoney = ipo.Amount.AToM(ipo.CurrencyId);
            //var payFee=ipo.PayFee = CalcPayFee(payMoney,ipo.Channel);
            //payMoney -= payFee;
            var req = new RequestMoneyReq()
            {
                CustomerName = ipo.Mobile,
                CustomerMsisdn = ipo.Mobile,
                CustomerEmail = "",
                Channel = ipo.Channel,
                Amount = Math.Ceiling(payMoney * 100) / 100,//Math.Truncate(payMoney * 100) / 100, 
                Description = ipo.OrderId,
                ClientReference = ipo.OrderId,
                PrimaryCallbackURL = _hubtelConfig.PayCallbackUrl
            };
            dto.TransMoney = req.Amount;//
            dto.OrderMoney = req.Amount;//元,保留2位小数
            HubtelRspDtoBase<RequestMoneyRsp> ret = null;
            if (_hubtelConfig.IsTesting)
            {
                ipo.PayFee = CalcPayFee(payMoney, ipo.Channel);
                ret = new HubtelRspDtoBase<RequestMoneyRsp> {
                    Message = "Transaction pending. Expect callback request for final state.",
                    ResponseCode = "0001",
                    Data = new RequestMoneyRsp {
                       Amount=req.Amount,
                       AmountAfterCharges=req.Amount- ipo.PayFee,
                       AmountCharged=req.Amount,
                       Charges= ipo.PayFee,
                       ClientReference=ipo.OrderId,
                       Description=ipo.OrderId,
                       ExternalTransactionId="",
                       TransactionId=Guid.NewGuid().ToString("N")
                    }
                };
            }
            else
            {
                ret = await this.Pay(req);
            }
            dto.OperatorSuccess = null != ret?.Data && (ret.ResponseCode == "0000" || ret.ResponseCode == "0001");
            if (!dto.OperatorSuccess)
            {
                LogUtil.Warning($"hubtel支付过程出错,orderid:{ipo.OrderId},:ret--{SerializerUtil.SerializeJson(ret)}");
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, "支付过程出错");
            }
            //dto.Amount = (long)(ret.Money*100000);
            dto.BankOrderId = ret.Data.TransactionId;
        }



        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<HubtelRspDtoBase<RequestMoneyRsp>> Pay(RequestMoneyReq req)
        {
            var clientPay = _clientDict.GetOrAdd("hubtel.pay", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _hubtelConfig.PayBaseAddress,
                    Name = k
                });
            });
            //string repayUrl = "/merchantaccount/merchants/";
            //string posId = _hubtelConfig.PosId; //"2016722/";
            //string url = repayUrl + posId + "/receive/mobilemoney";
            string url = $"/merchantaccount/merchants/{_hubtelConfig.PosId}/receive/mobilemoney";
            var rsp = await PostJson<HubtelRspDtoBase<RequestMoneyRsp>, HubtelRspDtoBase<string>>(clientPay, url, req);
            if (!rsp.Success)
            {
                LogUtil.Warning($"调用hubtel支付过程出错,req:{SerializerUtil.SerializeJson(req)},:ret--{SerializerUtil.SerializeJson(rsp)}");
                await HubtelErrorHandler(rsp.ErrorResult?.ResponseCode,rsp.ErrorResult?.Message);
            }
            return rsp.SuccessResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="responseCode"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private async Task HubtelErrorHandler(string responseCode,string errMsg)
        {
            switch (responseCode)
            {
                case "4080":
                case "2050":
                case "2102":
                    throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY,errMsg);
                case "3013":
                case "4010":
                case "3024":
                case "2051":
                case "2103":
                case "2152":
                case "2153":
                case "2154":
                case "2200":
                case "2201":
                case "3008":
                case "3022":
                case "3009":
                case "3012":
                    throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, errMsg);
                default:
                    throw new CustomException(PartnerCodes.RS_UNKNOWN, errMsg);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task Cash(CashIpo ipo, CashDto dto)
        {
            var cashMoney = (ipo.Amount - ipo.UserFeeAmount).AToM(ipo.CurrencyId);
            ipo.CashFee = CalcCashFee(cashMoney, ipo.Channel);
            if (ipo.UserFeeAmount == 0)
            {
                var cashFee=ipo.CashFee = CalcCashFee(cashMoney, ipo.Channel);
                cashMoney -= cashFee;
            }
            var req = new SendMoneyReq()
            {
                RecipientName = ipo.Mobile,
                RecipientMsisdn = ipo.Mobile,
                CustomerEmail = "",
                Channel = ipo.Channel,
                Amount = Math.Truncate(cashMoney * 100) / 100,
                PrimaryCallbackURL = _hubtelConfig.CashCallbackUrl,
                Description = ipo.OrderId,
                ClientReference = ipo.OrderId
            };
            dto.TransMoney = req.Amount;
            dto.OrderMoney = req.Amount;//元，保留2位小数
            HubtelRspDtoBase<SendMoneyRsp> ret = null;
            if (_hubtelConfig.IsTesting) {
                ret = new HubtelRspDtoBase<SendMoneyRsp> { 
                 Data=new SendMoneyRsp { 
                  Amount=req.Amount,
                  AmountDebited=0,
                  Charges=ipo.CashFee,
                  ClientReference=ipo.OrderId,
                  Description=ipo.OrderId,
                  ExternalTransactionId="",
                  Meta="",
                  RecipientName="",
                  TransactionId=Guid.NewGuid().ToString("N"),
                 },
                 Message="",
                 ResponseCode="0001"
                };
            }
            else
            {
                //验证用户是否在钱包上注册
                var verifyResp = await VerifyCustomer(req.Channel, req.RecipientMsisdn);
                if (null == verifyResp || verifyResp.ResponseCode != "0000" || !verifyResp.Data.IsRegistered)
                {
                    LogUtil.Warning($"验证用户是否在钱包上注册失败！orderid:{ipo.OrderId},返回结果为verifyresp:{SerializerUtil.SerializeJson(verifyResp)}");
                    throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, "支付过程出错!用户未在钱包上注册");
                }
                ret = await this.Cash(req);
            }
            
            dto.OperatorSuccess = null != ret && (ret.ResponseCode == "0000" || ret.ResponseCode == "0001");
            if (!dto.OperatorSuccess)
            {
                LogUtil.Warning($"支付过程异常！orderid:{ipo.OrderId},CashResp:{SerializerUtil.SerializeJsonNet(ret)}");
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, "支付过程出错");
            }
            dto.BankOrderId = ret.Data.TransactionId;
        }

        /// <summary>
        /// 计算代收手续费
        /// </summary>
        /// <param name="payMoney"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        private decimal CalcPayFee(decimal payMoney, string channel)
        {
            if (!this._hubtelConfig.PayFeeRule.TryGetValue(channel, out List<HubtelConfig.HubtelChannelFeeItem> feeItems) && feeItems.Count == 0)
                throw new Exception($"该渠道:{channel}的费率配置为空！");

            var feeItem = feeItems.FirstOrDefault(x => x.Start <= payMoney && payMoney <= x.End);
            if(null==feeItem)
                throw new Exception($"没有匹配到该渠道:{channel}的费率配置,money:{payMoney}！");

            if (feeItem.FixedValue > 0m)
            {
                return feeItem.FixedValue;
            }
            //var feeRate = feeItem.FixedValue == 0m ? feeItem.VariableValue : feeItem.FixedValue;
            return Math.Truncate(100*feeItem.VariableValue * payMoney)/100;
        }

        /// <summary>
        /// 计算代付手续费
        /// </summary>
        /// <param name="payMoney"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public decimal CalcCashFee(decimal payMoney, string channel)
        {
            if (!this._hubtelConfig.CashFeeRule.TryGetValue(channel, out List<HubtelConfig.HubtelChannelFeeItem> feeItems) && feeItems.Count == 0)
                throw new Exception($"该渠道的费率配置为空！");

            var feeItem = feeItems.FirstOrDefault(x => x.Start <= payMoney && payMoney <= x.End);
            if(null==feeItem)
                throw new Exception($"没有匹配到该渠道:{channel}的费率配置,money:{payMoney}！");

            if (feeItem.FixedValue > 0m)
            {
                return feeItem.FixedValue;
            }
            //var feeRate = feeItem.FixedValue == 0m ? feeItem.VariableValue : feeItem.FixedValue;
            return Math.Truncate(feeItem.VariableValue * payMoney*100)/100;
        }

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="req"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<HubtelRspDtoBase<SendMoneyRsp>> Cash(SendMoneyReq req)
        {
            var clientCash = _clientDict.GetOrAdd("hubtel.cash", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _hubtelConfig.CashBaseAddress,
                    Name = k
                });
            });
            //string loanUrl = "/api/merchants/";// "https://smp.hubtel.com/api/merchants/";
            //string prepaId = _hubtelConfig.PrepaId; //"2016574/";
            //string url = loanUrl + prepaId + "/send/mobilemoney";
            string url = $"/api/merchants/{_hubtelConfig.PrepaId}/send/mobilemoney";
            var rsp = await PostJson<HubtelRspDtoBase<SendMoneyRsp>, HubtelRspDtoBase<string>>(clientCash, url, req);
            if (!rsp.Success)
            {
                await HubtelErrorHandler(rsp.ErrorResult?.ResponseCode, rsp.ErrorResult?.Message);
            }
            return rsp.SuccessResult;
        }

        /// <summary>
        /// 验证用户是否注册电子钱包
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<HubtelRspDtoBase<VerifyMobileMoneyRsp>> VerifyCustomer(string channel, string customerMsisdn)
        {
            var clientVerifyCustomer = _clientDict.GetOrAdd("hubtel.verifycustomer", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _hubtelConfig.VerifyCustomerBaseAddress,
                    Name = k
                });
            });
            //string loanUrl = "/merchantaccount/merchants/";
            //string url = loanUrl + _hubtelConfig.PosId + $"/mobilemoney/verify?channel={channel}&customerMsisdn={customerMsisdn}";
            string url = $"/merchantaccount/merchants/{_hubtelConfig.PosId}/mobilemoney/verify?channel={channel}&customerMsisdn={customerMsisdn}";
            var rsp = await GetJson<HubtelRspDtoBase<VerifyMobileMoneyRsp>, HubtelRspDtoBase<VerifyMobileMoneyRsp>>(clientVerifyCustomer, url);
            if (!rsp.Success)
            {
                await HubtelErrorHandler(rsp.ErrorResult?.ResponseCode,rsp.ErrorResult?.Message);
            }
            return rsp.SuccessResult;
        }

        public async Task<HubtelRspDtoBase<ReceiveStatusCheckRsp>> ReceiveMoneyStatusCheck(string orderId)
        {
            var verifyPayOrder = _clientDict.GetOrAdd("hubtel.verifypayorder", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _hubtelConfig.VerifyPayOrderBaseAddress,
                    Name = k
                });
            });
            string url = $"transactions/{_hubtelConfig.PosId}/status?clientReference={orderId}";
            var rsp = await GetJson<HubtelRspDtoBase<ReceiveStatusCheckRsp>, HubtelRspDtoBase<string>>(verifyPayOrder, url);
            return rsp.SuccessResult;
        }

        public async Task<HubtelRspDtoBase<SendStatusCheckRsp>> SendMoneyStatusCheck(string orderId)
        {
            var verifyCashOrder = _clientDict.GetOrAdd("hubtel.verifycashorder", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _hubtelConfig.VerifyCashOrderBaseAddress,
                    Name = k
                });
            });
            string url = $"/api/merchants/{_hubtelConfig.PrepaId}/transactions/status?clientReference={orderId}";
            var rsp = await GetJson<HubtelRspDtoBase<SendStatusCheckRsp>, HubtelRspDtoBase<string>>(verifyCashOrder, url);
            return rsp.SuccessResult;
        }

        public async Task<HubtelRspDtoBase<QueryPosSalesAccountRsp>> QueryPosSalesAccount()
        {
            var queryPosSalesAccount = _clientDict.GetOrAdd("hubtel.possalesaccount", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _hubtelConfig.QueryPosSalesAccountBaseAddress,
                    Name = k
                });
            });
            string url = $"/api/inter-transfers/{_hubtelConfig.PosId}";
            var rsp = await GetJson<HubtelRspDtoBase<QueryPosSalesAccountRsp>, HubtelRspDtoBase<string>>(queryPosSalesAccount, url);
            return rsp.SuccessResult;
        }

        public async Task<HubtelRspDtoBase<QueryPosSalesAccountRsp>> QueryPrepaidAccount()
        {
            var queryPosSalesAccount = _clientDict.GetOrAdd("hubtel.prepaidaccount", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = "https://trnf.hubtel.com/",
                    Name = k
                });
            });
            string url = $"api/inter-transfers/prepaid/{_hubtelConfig.PrepaId}";
            var rsp = await GetJson<HubtelRspDtoBase<QueryPosSalesAccountRsp>, HubtelRspDtoBase<string>>(queryPosSalesAccount, url);
            return rsp.SuccessResult;
        }

        public async Task<HubtelRspDtoBase<BalanceTransferRsp>> BalanceTransfer(decimal amount)
        {
            var queryPosSalesAccount = _clientDict.GetOrAdd("hubtel.possalesaccount", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _hubtelConfig.QueryPosSalesAccountBaseAddress,
                    Name = k
                });
            });//https://trnf.hubtel.com/api/inter-transfers/{POS_SALES_ACCOUNT_NUMBER}
            var clientReference = ObjectId.NewId();
            var req = new BalanceTransferReq
            {
                Description = $"{clientReference} transfer",
                Amount = amount,
                ClientReference = clientReference,
                DestinationAccountNumber = _hubtelConfig.PrepaId,
                PrimaryCallbackUrl = _hubtelConfig.TransferCallbackUrl
            };
            var transferOrderPo = new Sb_hubtel_transferorderPO
            {
                OrderId = clientReference,
                PosSalesAccount = _hubtelConfig.PosId,
                DestinationAccount = _hubtelConfig.PrepaId,
                Description = req.Description,
                PlanAmount = req.Amount,
                RecDate = DateTime.UtcNow,
                Status = (int)TransferOrderStatuEnum.None,
                PrimaryCallbackUrl = req.PrimaryCallbackUrl,
                RecipientName = "",
                //RequestContent = SerializerUtil.SerializeJsonNet(req)
            };
            var hubtelTransferRepo =await DbUtil.InsertAsync(transferOrderPo);
            var hubtelTransferLog = new Sb_hubtel_transferorder_logPO
            {
                TransferLogId=ObjectId.NewId(),
                OrderId=clientReference,
                RequestTime=transferOrderPo.RecDate,
                Status=1,
                TransType=0
            };
            HubtelRspDtoBase<BalanceTransferRsp> ret = null;
            var tm = new DbTransactionManager();
            try
            {
                await tm.BeginAsync();
                string url = $"/api/inter-transfers/{_hubtelConfig.PosId}";
                var rsp = await PostJson<HubtelRspDtoBase<BalanceTransferRsp>, HubtelRspDtoBase<BalanceTransferRsp>>(queryPosSalesAccount, url, req);
                if (rsp.Success && (rsp.SuccessResult?.ResponseCode == "0001" || rsp.SuccessResult?.ResponseCode == "0000"))
                    transferOrderPo.Status = (int)TransferOrderStatuEnum.RequestSuccess;
                else
                    transferOrderPo.Status = (int)TransferOrderStatuEnum.RequestFailed;
                //transferOrderPo.ResponseContent = rsp.ResultString;
                //transferOrderPo.ResponseTime = DateTime.UtcNow;
                hubtelTransferLog.TransMark = rsp.Request?.RequestUri;
                hubtelTransferLog.RequestBody =SerializerUtil.SerializeJsonNet(rsp.Request.RequestContent);
                hubtelTransferLog.ResponseBody = rsp.ResultString;
                hubtelTransferLog.ResponseTime = DateTime.UtcNow;
                var rows =await tm.GetRepository<Sb_hubtel_transferorderPO>().UpdateSetColumnsTrueAsync(it=> new Sb_hubtel_transferorderPO { Status = transferOrderPo.Status },it=>it.OrderId==transferOrderPo.OrderId&&it.Status== 0);
                rows = await tm.GetRepository<Sb_hubtel_transferorder_logPO>().InsertAsync(hubtelTransferLog);
                //var rows = await DbUtil.UpdateAsync<Sb_hubtel_transferorderPO>(transferOrderPo);
                //var ret= rsp.SuccessResult;
                ret = rsp.SuccessResult;
                await tm.CommitAsync();
            }
            catch (Exception ex)
            {
                await tm.RollbackAsync();
                hubtelTransferLog.Status = 2;
                hubtelTransferLog.ResponseTime = DateTime.UtcNow;
                hubtelTransferLog.Exception = SerializerUtil.SerializeJsonNet(ex);
                await DbUtil.InsertAsync(hubtelTransferLog);
            }
            return ret;
        }


        private async Task<HttpResponseResult<TSuccess, TError>> PostJson<TSuccess, TError>(HttpClientEx client, string url, object req)
        {
            var json = SerializerUtil.SerializeJson(req);
            var sign = SecurityUtil.Base64Encrypt($"{_hubtelConfig.ApiID}:{_hubtelConfig.ApiKey}", Encoding.ASCII);
            var logger = LogUtil.GetContextLogger()
               .AddField("banks.hubtel.req", json)
               .SetLevel(Microsoft.Extensions.Logging.LogLevel.Information)
               .AddMessage($"开始请求hubtel接口url:{url}");
            
            var rsp = await client.CreateAgent()
                .AddUrl(url)
                .AddRequestHeader(SIGNHEADERNAME, $"Basic {sign}")
                .BuildJsonContent(json)
                .PostAsync<TSuccess, TError>();

            logger.AddField("banks.hubtel.rsp", rsp?.ResultString);
            if (!(rsp?.Success ?? false))
            {
                logger.SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                .AddMessage($"请求hubtel接口出错!");
            }
            logger.Save();
            return rsp;
        }

        private async Task<HttpResponseResult<TSuccess, TError>> GetJson<TSuccess, TError>(HttpClientEx client, string url)
        {
            var sign = SecurityUtil.Base64Encrypt($"{_hubtelConfig.ApiID}:{_hubtelConfig.ApiKey}", Encoding.ASCII);

            var logger = LogUtil.GetContextLogger()
               .AddField("banks.hubtel.req", url)
               .SetLevel(Microsoft.Extensions.Logging.LogLevel.Information)
               .AddMessage($"开始请求hubtel接口url:{url}");

            var rsp = await client.CreateAgent()
                .AddUrl(url)
                .AddRequestHeader(SIGNHEADERNAME, $"Basic {sign}")
                .GetAsync<TSuccess, TError>();

            logger.AddField("banks.hubtel.rsp", rsp?.ResultString);
            if (!(rsp?.Success ?? false))
            {
                logger.SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                .AddMessage($"请求hubtel接口出错!");
            }
            logger.Save();

            return rsp;
        }
        #endregion
    }
}
