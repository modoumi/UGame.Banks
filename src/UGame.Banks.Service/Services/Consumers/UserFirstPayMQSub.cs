using EasyNetQ;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Web;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Configuration;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Net;
using TinyFx.Security;
using TinyFx.Text;
using UGame.Banks.Service.Common;
using UGame.Banks.Repository;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.MQ.Bank;

namespace UGame.Banks.Service.Services.Consumers
{
    /// <summary>
    /// 用户充值打点消息
    /// </summary>
    public class UserFirstPayMQSub : MQBizSubConsumer<UserFirstPayMsg>
    {
        private static ConcurrentDictionary<string, HttpClientEx> _clientDict = new();
        private readonly Sb_order_trans_logMO _orderTranslogMo = new();
        private readonly Sb_bank_orderMO _bankOrderMo = new();

        public override MQSubscribeMode SubscribeMode =>  MQSubscribeMode.OneQueue;

        /// <summary>
        /// 
        /// </summary>
        public UserFirstPayMQSub()
        {
            AddHandler(SendFacebookPayPointRequest);
            AddHandler(SendKwaiPayPointRequest);
            AddHandler(SendAppsflyerPayPointRequest);
            AddHandler(SendGAPayPointRequest);
            AddHandler(SendTiktokPayPointRequest);
            AddHandler(SendMintegralPointRequest);
        }

        private async Task SendMintegralPointRequest(UserFirstPayMsg message, CancellationToken token)
        {
            var userDCache = await GlobalUserDCache.Create(message.UserId);
            var fromMode = await userDCache.GetFromModeAsync();
            var fromId = await userDCache.GetFromIdAsync();

            var channelEo = fromMode switch
            {
                2 => DbCacheUtil.GetChannel(fromId, false),
                _ => null
            };
            if (null == channelEo || string.IsNullOrWhiteSpace(channelEo.TrackConfigs)) return;
            var traceConfigObj = JObject.Parse(channelEo.TrackConfigs);
            var mintegralBaseAddress = traceConfigObj.SelectToken("mintegral.baseaddress")?.ToString();
            var enabaleCallback = traceConfigObj.SelectToken("mintegral.enablecallback")?.Value<bool>();
            if (string.IsNullOrWhiteSpace(mintegralBaseAddress) || enabaleCallback == null || !enabaleCallback.Value)
                return;

            var registerDate = await userDCache.GetRegistDateAsync();

            var localRegisterDate = registerDate.Value.ToLocalTime(message.OperatorId).Date;
            var localPayDate = message.PayTime.ToLocalTime(message.OperatorId).Date;
            if (localPayDate != localRegisterDate)
                return;
            var client = _clientDict.GetOrAdd("point.mintegral", (k) =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = mintegralBaseAddress,
                    Timeout = 30 * 1000
                });
            });

            //var clientUserIp = await userDCache.GetClientUserIp();
            //clientUserIp = string.IsNullOrWhiteSpace(clientUserIp) ? "127.0.0.1" : clientUserIp;

            //var clientUserAgent = await userDCache.GetClientUserAgent();
            //clientUserAgent = string.IsNullOrWhiteSpace(clientUserAgent) ? "testua" : clientUserAgent;

            var orderEo = await _bankOrderMo.GetByPKAsync(message.OrderID);
            if (null == orderEo || string.IsNullOrWhiteSpace(orderEo.Meta)) return;

            var metaJobject = orderEo.Meta.ToSafeDeserialize<JObject>();
            var campuuid = metaJobject?.SelectToken("appMeta.mtg_campaign_uuid")?.Value<string>();
            var clickid = metaJobject?.SelectToken("appMeta.mtg_click_id")?.Value<string>();
            //var gaid = metaJobject?.SelectToken("appMeta.gaid")?.Value<string>();
            if (string.IsNullOrWhiteSpace(campuuid) || string.IsNullOrWhiteSpace(clickid))
                return;
            string url = "";
            HttpResponseResult<JObject, object> rsp = null;
            try
            {
                //event?campuuid=game_ios_us_mtg&clickid=mtg0a1b2c3d4e5f6g7h8i9j1x2y&idfa=3E0046F7-8BD4-4F3E-9F91-358B137D2BF0&type=s2s&install_name=1486088825&event_time=1486088900&event_name=purchase&event_value={\"currency\":\"USD\",\"revenue\":1.9}
                url = $"event?campuuid={campuuid}&clickid={clickid}&type=s2s&event_time={DateTime.UtcNow.ToTimestamp(false)}&event_name=purchase&event_value={{\\\"currency\\\":\\\"{message.CurrencyId}\\\",\\\"revenue\\\":{message.PayAmount.AToM(message.CurrencyId)}}}";
                rsp = await client.CreateAgent().AddUrl(url).GetAsync<JObject, object>();
                LogUtil.Info("请求mintegral打点！url:{0},resultstring:{1}", url, rsp?.ResultString);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "请求mintegral打点异常！url:{0}", url);
            }
            var orderTransLogStatus = (rsp?.SuccessResult?.SelectToken("ret")?.Value<int>() == 0) ? 1 : 2;
            await AddOrderTranslog(message, orderTransLogStatus, rsp);
        }

        /// <summary>
        /// 请求facebook打点
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendFacebookPayPointRequest(UserFirstPayMsg message, CancellationToken cancellationToken)
        {
            //var disableFaceBookPoint = ConfigUtil.AppSettings.GetOrDefault("PayPoint.DisableFaceBookPoint", true);
            //if (disableFaceBookPoint) return;
            var userDCache = await GlobalUserDCache.Create(message.UserId);
            var fromMode = await userDCache.GetFromModeAsync();
            var fromId = await userDCache.GetFromIdAsync();

            var channelEo = fromMode switch
            {
                2 => DbCacheUtil.GetChannel(fromId, false),
                _ => null
            };
            if (null== channelEo||string.IsNullOrWhiteSpace(channelEo.TrackConfigs)) return;
            var traceConfigObj=JObject.Parse(channelEo.TrackConfigs);
            var faceBookPointConfig = traceConfigObj.SelectToken("FaceBook")?.ToObject<FaceBookPointConfig>();
            if (null == faceBookPointConfig||!faceBookPointConfig.EnableCallback || string.IsNullOrWhiteSpace(faceBookPointConfig.PixelId) || string.IsNullOrWhiteSpace(faceBookPointConfig.Access_Token))
                return;

            var registerDate = await userDCache.GetRegistDateAsync();

            var localRegisterDate = registerDate.Value.ToLocalTime(message.OperatorId).Date;
            var localPayDate = message.PayTime.ToLocalTime(message.OperatorId).Date;
            if (localPayDate != localRegisterDate)
                return;
            var client = _clientDict.GetOrAdd("point.facebook", (k) =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = "https://graph.facebook.com",
                    Timeout = 30 * 1000
                });
            });
            var agent = client
            .CreateAgent();

            //var clientUserIp = await userDCache.GetClientUserIp();
            //clientUserIp = string.IsNullOrWhiteSpace(clientUserIp) ? "127.0.0.1" : clientUserIp;

            var clientUserAgent = await userDCache.GetClientUserAgent();
            clientUserAgent = string.IsNullOrWhiteSpace(clientUserAgent) ? "testua" : clientUserAgent;

            var orderEo = await _bankOrderMo.GetByPKAsync(message.OrderID);
            if (null == orderEo || string.IsNullOrWhiteSpace(orderEo.Meta)) return;

            var metaJobject = orderEo.Meta.ToSafeDeserialize<JObject>();
            var fbc = metaJobject?.SelectToken("appMeta.fbc")?.Value<string>() ?? string.Empty;
            var fbp = metaJobject?.SelectToken("appMeta.fbp")?.Value<string>() ?? string.Empty;
            //var fbLoginId = metaJobject?.SelectToken("appMeta.fb_login_id")?.Value<string>() ?? string.Empty;
            var userMobile = await userDCache.GetMobileAsync();
            if (!string.IsNullOrWhiteSpace(userMobile))
                userMobile = SecurityUtil.SHA256Hash(userMobile, CipherEncode.Bit32Lower);
            var userEmail = await userDCache.GetMobileAsync();
            if (!string.IsNullOrWhiteSpace(userEmail))
                userEmail = SecurityUtil.SHA256Hash(userEmail.ToLower(), CipherEncode.Bit32Lower);
            var fbLoginId = await userDCache.GetOAuthIDAsync();
            var countryEo = DbCacheUtil.GetCountry(orderEo.CountryID);
            var json = SerializerUtil.SerializeJson(new
            {
                data = new[] {
                    new {
                        event_name = "Purchase",
                        event_id=message.OrderID,
                        event_source_url=await userDCache.GetRegistClientUrlAsync(),
                        event_time = message.PayTime.ToTimestamp(false,true),
                        action_source="website",
                        //opt_out=false,
                        user_data=new {
                            em=new[]{ userEmail},
                            ph=new[]{ userMobile },
                            client_user_agent=clientUserAgent,
                            client_ip_address=string.IsNullOrWhiteSpace(orderEo?.UserIP)?"127.0.0.1":orderEo.UserIP,
                            fbc,
                            fbp,
                            fb_login_id=fbLoginId,
                            external_id =message.UserId,
                            country= SecurityUtil.SHA256Hash(countryEo.CountryID2.ToLower(), CipherEncode.Bit32Lower)
                        },
                        custom_data=new {
                            //content_ids=new []{""},
                            //content_type="product",
                            currency=message.CurrencyId,
                            value= float.Parse(message.PayAmount.AToM(message.CurrencyId).ToString("0.00"))
                      }
                    }
                }
            });
            agent.AddUrl($"v18.0/{faceBookPointConfig.PixelId}/events?access_token={faceBookPointConfig.Access_Token}").BuildJsonContent(json);
            HttpResponseResult<JObject, object> rsp = null;
            try
            {
                rsp = await agent.PostAsync<JObject, object>();
                LogUtil.Info("请求facebook打点！body:{0},resultstring:{1}", SerializerUtil.SerializeJsonNet(message), rsp.ResultString);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "请求facebook打点异常！{0}", SerializerUtil.SerializeJsonNet(message));
            }
            var orderTransLogStatus = ((rsp?.SuccessResult?.TryGetValue("fbtrace_id", out var traceid) ?? false) && !string.IsNullOrWhiteSpace(traceid.Value<string>())) ? 1 : 2;
            await AddOrderTranslog(message, orderTransLogStatus, rsp);
        }

        /// <summary>
        /// 记录打点日志(transtype=8)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <param name="rsp"></param>
        /// <returns></returns>
        private async Task AddOrderTranslog(UserFirstPayMsg message, int status, HttpResponseResult rsp)
        {
            var utcNow = DateTime.UtcNow;
            var translogEo = new Sb_order_trans_logEO
            {
                AppID = message.AppId,
                BankID = message.BankId,
                ClientIP = "",
                OrderID = message.OrderID,
                TransLogID = ObjectId.NewId(),
                RequestTime = rsp?.RequestUtcTime ?? utcNow,
                ResponseTime = rsp?.ResponseUtcTime,
                TransMark = rsp?.Request?.RequestUri,
                ReceiveBonus = 0,
                TransType = 8,
                Status = status
            };
            if (rsp?.Exception != null)
                translogEo.Exception = SerializerUtil.SerializeJsonNet(rsp.Exception);
            if (rsp?.Request != null)
                translogEo.RequestBody = SerializerUtil.SerializeJsonNet(rsp.Request);
            if (rsp?.Response != null)
                translogEo.ResponseBody = SerializerUtil.SerializeJsonNet(rsp.Response);
            try
            {
                await _orderTranslogMo.AddAsync(translogEo);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "记录_orderTranslogMo请求打点异常！{0}", SerializerUtil.SerializeJsonNet(translogEo));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendBranchPayPointRequest(UserFirstPayMsg message, CancellationToken cancellationToken)
        {
            var userDCache = await GlobalUserDCache.Create(message.UserId);
            var gaid = await userDCache.GetGAIDAsync();

            var fromMode = await userDCache.GetFromModeAsync();
            var fromId = await userDCache.GetFromIdAsync();

            var branchKey = (fromMode) switch
            {
                2 => DbCacheUtil.GetChannel(fromId, false)?.BranchKey,
                0 => DbCacheUtil.GetOperator(message.OperatorId, false)?.BranchKey,
                _ => null
            };
            if (string.IsNullOrWhiteSpace(branchKey))
                return;

            var registerDate = await userDCache.GetRegistDateAsync();
            if (registerDate == null) return;

            var localRegisterDate = registerDate.Value.ToLocalTime(message.OperatorId).Date;
            var localPayDate = message.PayTime.ToLocalTime(message.OperatorId).Date;
            if (localPayDate != localRegisterDate)
                return;

            var client = _clientDict.GetOrAdd("point.branch", (k) =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    Timeout = 30 * 1000,
                    BaseAddress = "https://api2.branch.io"
                });
            });
            var agent = client
            .CreateAgent();
            var eventdata = new { currency = message.CurrencyId, revenue = message.PayAmount.AToM(message.CurrencyId), shipping = 0, tax = message.OwnFee, transaction_id = message.OrderID };

            var userdata = new
            {
                aaid = gaid,
                developer_identity = message.UserId,
                os = "Android"
            };
            var customdata = new
            {
                userid = message.UserId,
                paytype = message.PayType.ToString()
            };

            var json = SerializerUtil.SerializeJson(new
            {
                name = "PURCHASE",
                event_data = eventdata,
                user_data = userdata,
                custom_data = customdata,
                branch_key = branchKey
            });
            agent.AddUrl("v2/event/standard").BuildJsonContent(json);
            try
            {
                var rsp = await agent.PostAsync<object, object>();
                LogUtil.Info("请求branch打点！body:{0},resultstring:{1}", SerializerUtil.SerializeJsonNet(message), rsp.ResultString);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "请求branch打点异常！{0}", SerializerUtil.SerializeJsonNet(message));
            }
        }

        /// <summary>
        /// 发送快手打点
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendKwaiPayPointRequest(UserFirstPayMsg message, CancellationToken cancellationToken)
        {
            var userDCache = await GlobalUserDCache.Create(message.UserId);

            var fromMode = await userDCache.GetFromModeAsync();
            var fromId = await userDCache.GetFromIdAsync();

            var channelEo = (fromMode) switch
            {
                2 => DbCacheUtil.GetChannel(fromId, false),
                _ => null
            };
            if (null==channelEo||string.IsNullOrWhiteSpace(channelEo.TrackConfigs))
                return;
            var traceConfigObj = JObject.Parse(channelEo.TrackConfigs);
            var kwaiConfig = traceConfigObj.SelectToken("Kwai")?.ToObject<KwaiPointConfig>();//SerializerUtil.DeserializeJsonNet<KwaiPointConfig>(kwaiConfigStr);
            if (null == kwaiConfig) return;

            var registerDate = await userDCache.GetRegistDateAsync();
            if (registerDate == null) return;

            var localRegisterDate = registerDate.Value.ToLocalTime(message.OperatorId).Date;
            var localPayDate = message.PayTime.ToLocalTime(message.OperatorId).Date;
            if (localPayDate != localRegisterDate)
                return;

            //var client = HttpClientExFactory.CreateClientEx(new HttpClientConfig { 
            //    Timeout=30*1000,
            //    BaseAddress= "http://www.adsnebula.com"
            //});

            var client = _clientDict.GetOrAdd("point.kwai", (k) =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    Timeout = 30 * 1000,
                    BaseAddress = "http://www.adsnebula.com"
                });
            });
            var agent = client
            .CreateAgent();

            var payMoney = message.PayAmount.AToM(message.CurrencyId);
            var properties = SerializerUtil.SerializeJsonNet(new
            {
                content_id = message.OrderID,
                content_type = "product",
                value = payMoney,
                quantity = 1,
                price = payMoney,
                currency = message.CurrencyId
            });

            var orderEo = await _bankOrderMo.GetByPKAsync(message.OrderID);
            if (null == orderEo || string.IsNullOrWhiteSpace(orderEo.Meta)) return;

            var metaDynamic = orderEo.Meta.ToSafeDeserialize<JObject>();
            if (null == metaDynamic) return;
            var clickIdObj = metaDynamic.SelectToken("appMeta.clickid");
            if (null == clickIdObj) return;
            var purchaseJson = new
            {
                access_token = kwaiConfig.Access_Token,
                clickid = clickIdObj.ToString(),
                event_name = "EVENT_PURCHASE",
                is_attributed = 1,
                mmpcode = "PL",
                pixelId = kwaiConfig.PixelId,
                pixelSdkVersion = "9.9.9",
                properties,
                testFlag = false,
                third_party = "lucro777.com",
                trackFlag = false
            };
            var json = SerializerUtil.SerializeJson(purchaseJson);
            agent.AddUrl("log/common/api").BuildJsonContent(json);
            HttpResponseResult<JObject, object> rsp = null;
            try
            {
                rsp = await agent.PostAsync<JObject, object>();
                //LogUtil.GetContextLog().AddMessage($"请求kwai打点！body:{json},resultstring:{rsp.ResultString}");
                LogUtil.Info("请求kwai打点！body:{0},resultstring:{1}", json, rsp.ResultString);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "请求kwai打点异常！{0}", json);
            }
            var orderTranslogStatus = (rsp?.SuccessResult?.SelectToken("result")?.Value<int>() == 1) ? 1 : 2;
            await AddOrderTranslog(message, orderTranslogStatus, rsp);
        }

        /// <summary>
        /// 发送appsflyer打点
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendAppsflyerPayPointRequest(UserFirstPayMsg message, CancellationToken cancellationToken)
        {
            var userDCache = await GlobalUserDCache.Create(message.UserId);

            var fromMode = await userDCache.GetFromModeAsync();
            var fromId = await userDCache.GetFromIdAsync();

            var trackConfigsStr = (fromMode) switch
            {
                2 => DbCacheUtil.GetChannel(fromId, false)?.TrackConfigs,
                _ => null
            };
            if (string.IsNullOrWhiteSpace(trackConfigsStr))
                return;

            var orderEo = await _bankOrderMo.GetByPKAsync(message.OrderID);
            if (null == orderEo || string.IsNullOrWhiteSpace(orderEo.Meta)) return;

            var afappsflyer_id = orderEo.Meta.ToSafeDeserialize<JObject>()?.SelectToken("appMeta.AFID")?.ToString();
            if (string.IsNullOrWhiteSpace(afappsflyer_id)) return;

            var trackConfigs = JObject.Parse(trackConfigsStr);
            var afbaseAddress = trackConfigs.SelectToken("appsflyer.baseaddress")?.ToString();
            var afapp_id = trackConfigs.SelectToken("appsflyer.app_id")?.ToString();
            var afeventname = trackConfigs.SelectToken("appsflyer.eventname")?.ToString();
            var afdevkey = trackConfigs.SelectToken("appsflyer.devkey")?.ToString();

            if (string.IsNullOrWhiteSpace(afbaseAddress) || string.IsNullOrWhiteSpace(afapp_id) || string.IsNullOrWhiteSpace(afeventname) || string.IsNullOrWhiteSpace(afdevkey)) return;

            var registerDate = await userDCache.GetRegistDateAsync();
            if (registerDate == null) return;

            var localRegisterDate = registerDate.Value.ToLocalTime(message.OperatorId).Date;
            var localPayDate = message.PayTime.ToLocalTime(message.OperatorId).Date;
            if (localPayDate != localRegisterDate)
                return;

            var payMoney = message.PayAmount.AToM(message.CurrencyId);
            var eventValue = SerializerUtil.SerializeJsonNet(new
            {
                af_revenue = payMoney.ToString(),
                eventCurrency = message.CurrencyId,
                af_currency = message.CurrencyId,
                af_content_type = "wallets",
                af_content_id = message.OrderID
            });

            var purchaseJson = new
            {
                appsflyer_id = afappsflyer_id,
                customer_user_id=message.UserId,
                eventName = afeventname,
                eventCurrency = message.CurrencyId,
                eventValue
            };
            var json = SerializerUtil.SerializeJson(purchaseJson);
            var client = _clientDict.GetOrAdd("point.appsflyer", (k) =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = afbaseAddress
                });
            });
            HttpResponseResult rsp = null;
            try
            {
                rsp = await client.CreateAgent().AddUrl($"inappevent/{HttpUtility.UrlEncode(afapp_id)}").AddRequestHeader("authentication", afdevkey).BuildJsonContent(json).PostStringAsync();
                LogUtil.Info("请求appsflyer打点！body:{0},resultstring:{1}", json, rsp.ResultString);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "请求appsflyer打点异常！{0}", json);
            }
            var orderTranslogStatus = rsp?.ResultString == "ok" ? 1 : 2;
            await AddOrderTranslog(message, 1, rsp);
        }

        /// <summary>
        /// 发送GA4打点
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendGAPayPointRequest(UserFirstPayMsg message, CancellationToken cancellationToken)
        {
            var userDCache = await GlobalUserDCache.Create(message.UserId);

            var fromMode = await userDCache.GetFromModeAsync();
            var fromId = await userDCache.GetFromIdAsync();

            var trackConfigsStr = fromMode switch
            {
                2 => DbCacheUtil.GetChannel(fromId, false)?.TrackConfigs,
                _ => null
            };
            if (string.IsNullOrWhiteSpace(trackConfigsStr))
                return;

            var orderEo = await _bankOrderMo.GetByPKAsync(message.OrderID);
            if (null == orderEo || string.IsNullOrWhiteSpace(orderEo.Meta)) return;

            var ga_clientid = orderEo.Meta.ToSafeDeserialize<JObject>()?.SelectToken("appMeta.ga_clientid")?.ToString();
            if (string.IsNullOrWhiteSpace(ga_clientid)) return;

            var trackConfigs = JObject.Parse(trackConfigsStr);
            var ga_baseaddress = trackConfigs.SelectToken("GA.baseaddress")?.ToString();
            var ga_measurement_id = trackConfigs.SelectToken("GA.measurement_id")?.ToString();
            var ga_apisecret = trackConfigs.SelectToken("GA.apisecret")?.ToString();

            if (string.IsNullOrWhiteSpace(ga_baseaddress) || string.IsNullOrWhiteSpace(ga_measurement_id) || string.IsNullOrWhiteSpace(ga_apisecret)) return;

            var registerDate = await userDCache.GetRegistDateAsync();
            if (registerDate == null) return;

            var localRegisterDate = registerDate.Value.ToLocalTime(message.OperatorId).Date;
            var localPayDate = message.PayTime.ToLocalTime(message.OperatorId).Date;
            if (localPayDate != localRegisterDate)
                return;

            var payMoney = message.PayAmount.AToM(message.CurrencyId);

            var purchaseJson = new
            {
                client_id = ga_clientid,
                user_id = message.UserId,
                events = new[] {
                    new {
                        name="purchase",
                        @params = new {
                              currency=message.CurrencyId,
                              value=payMoney,
                              transaction_id=message.OrderID,
                              items=new[]{
                                        new{
                                            item_id=message.OrderID
                                        }
                                   }
                              }
                    }
                }
            };
            var json = SerializerUtil.SerializeJson(purchaseJson);
            var client = _clientDict.GetOrAdd("point.ga", (k) =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = ga_baseaddress
                });
            });
            HttpResponseResult rsp = null;
            try
            {
                rsp = await client.CreateAgent().AddUrl($"mp/collect?measurement_id={ga_measurement_id}&api_secret={ga_apisecret}").BuildJsonContent(json).PostStringAsync();
                LogUtil.Info("请求GA4打点！body:{0},resultstring:{1}", json, rsp.ResultString);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "请求GA4打点异常！{0}", json);
            }
            var orderTranslogStatus = rsp?.Success ?? false ? 1 : 2;
            await AddOrderTranslog(message, 1, rsp);
        }

        /// <summary>
        /// 发送tiktok打点
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendTiktokPayPointRequest(UserFirstPayMsg message, CancellationToken cancellationToken)
        {
            var userDCache = await GlobalUserDCache.Create(message.UserId);

            var fromMode = await userDCache.GetFromModeAsync();
            var fromId = await userDCache.GetFromIdAsync();

            var trackConfigsStr = fromMode switch
            {
                2 => DbCacheUtil.GetChannel(fromId, false)?.TrackConfigs,
                _ => null
            };
            if (string.IsNullOrWhiteSpace(trackConfigsStr))
                return;

            var orderEo = await _bankOrderMo.GetByPKAsync(message.OrderID);
            if (null == orderEo || string.IsNullOrWhiteSpace(orderEo.Meta)) return;

            var metaJobject = orderEo.Meta.ToSafeDeserialize<JObject>();
            var ttclid = metaJobject?.SelectToken("appMeta.ttclid")?.ToString();
            var ttp = metaJobject?.SelectToken("appMeta.ttp")?.ToString();


            var trackConfigs = JObject.Parse(trackConfigsStr);
            var pixel_code = trackConfigs.SelectToken("tiktok.pixel_code")?.ToString();
            var tiktok_baseaddress = trackConfigs.SelectToken("tiktok.baseaddress")?.ToString();
            var tiktok_accesstoken = trackConfigs.SelectToken("tiktok.accesstoken")?.ToString();

            if (string.IsNullOrWhiteSpace(pixel_code)||string.IsNullOrWhiteSpace(tiktok_baseaddress)||string.IsNullOrWhiteSpace(tiktok_accesstoken)) return;

            var registerDate = await userDCache.GetRegistDateAsync();
            if (registerDate == null) return;

            var localRegisterDate = registerDate.Value.ToLocalTime(message.OperatorId).Date;
            var localPayDate = message.PayTime.ToLocalTime(message.OperatorId).Date;
            if (localPayDate != localRegisterDate)
                return;

            var payMoney = message.PayAmount.AToM(message.CurrencyId);
            var purchaseJson = new
            {
                pixel_code,
                @event = "CompletePayment",
                event_id = orderEo.OrderID,
                //test_event_code= "TEST28685",
                properties = new
                {
                    currency = message.CurrencyId,
                    value = payMoney
                },
                context = new
                {
                    ad = new
                    {
                        callback = ttclid
                    },
                    user = new
                    {
                        external_id = SecurityUtil.SHA256Hash(orderEo.UserID),
                        ttp
                    },
                    user_agent = await userDCache.GetClientUserAgent(),
                    ip = orderEo.UserIP
                }
            };
            var json = SerializerUtil.SerializeJson(purchaseJson);
            var client = _clientDict.GetOrAdd("point.tiktok", (k) =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = tiktok_baseaddress
                });
            });
            HttpResponseResult<JObject,JObject> rsp = null;
            try
            {
                rsp = await client.CreateAgent()
                    .AddUrl($"/open_api/v1.3/pixel/track/")
                    .BuildJsonContent(json)
                    .AddRequestHeader("Access-Token", tiktok_accesstoken)
                    .PostAsync<JObject,JObject>();
                LogUtil.Info("请求tiktok打点！body:{0},resultstring:{1}", json, rsp.ResultString);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "请求tiktok打点异常！{0}", json);
            }
            var orderTranslogStatus = (rsp?.SuccessResult?.SelectToken("message")?.Value<string>()=="OK")? 1 : 2;
            await AddOrderTranslog(message, 1, rsp);
        }

        protected override void Configuration(ISubscriptionConfiguration config)
        {
            
        }

        protected override Task OnMessage(UserFirstPayMsg message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
