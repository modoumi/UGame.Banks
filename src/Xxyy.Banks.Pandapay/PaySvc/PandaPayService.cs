using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx;
using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Common.Caching;

using Xxyy.Common;
using Xxyy.DAL;
using Xxyy.MQ.Bank;
using TinyFx.Data;
using TinyFx.ShortId;
using Xxyy.Banks.BLL.Services.Query;
using TinyFx.Extensions.AutoMapper;
using Microsoft.AspNetCore.Components.RenderTree;
using Xxyy.Banks.Pandapay.Caching;
using Xxyy.Banks.DAL;

namespace Xxyy.Banks.Pandapay.PaySvc
{
    /// <summary>
    /// 
    /// </summary>
    public class PandaPayService : BankServiceBase
    {
        private readonly Sb_bank_orderMO _bankOrderMo = new();
        private readonly Sb_order_trans_logMO _orderTransLog = new();
        private readonly Sc_cash_auditMO _cashAuditMo = new();
        private readonly Sb_panda_user_barcodeMO _userBarcodeMo = new();
        private const int TryCount = 3;
        private static ShortIdOptions _shortIdOptions = new ShortIdOptions
        {
            UseUuidSpecials = false,
            UseLowerLetters = true,
            UseNumbers = true,
            UseUpperLetters = false,
        };
        private const string BANKID = "pandapay";

        private HttpRequest _request;

        /// <summary>
        /// 
        /// </summary>
        public PandaPayService()
        {
            _request = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext?.Request;
        }

        #region paynullcheck
        /// <summary>
        /// 充值时字段空检查
        /// </summary>
        /// <param name="ipo"></param>
        /// <exception cref="CustomException"></exception>
        private void PayNullCheck(PandapayIpo ipo)
        {
            if (ipo.Amount < 0)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"充值金额Amount必须大于等于0");
            if (string.IsNullOrWhiteSpace(ipo.BankId))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");
            if (string.IsNullOrWhiteSpace(ipo.AccName))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"{nameof(ipo.AccName)}不能为空");
            if (string.IsNullOrWhiteSpace(ipo.TaxId))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"税号{nameof(ipo.TaxId)}不能为空");
        }

        #endregion

        /// <summary>
        /// panda支付
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<PandapayDto> Pay(PandapayIpo ipo)
        {
            var ret = BankUtil.CreateDto<PandapayDto>(ipo);

            try
            {
                PayNullCheck(ipo);
                LogUtil.Info("pandapay.pay:2,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));

                //0.用户是否存在vanumber,存在则返回
                var userVanumberEo = await _userBarcodeMo.GetByPKAsync(ipo.UserId);
                if (null != userVanumberEo && !string.IsNullOrWhiteSpace(userVanumberEo.BarCode))
                {
                    ret.BarCode = userVanumberEo.BarCode;
                    return ret;
                }
                LogUtil.Info("pandapay.pay:3,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));

                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = await GetOwnOrderId(BANKID);
                    var proxy = new BankProxy();
                    await proxy.Pay(ipo, ret);

                    //添加vanumber
                    await AddUserVaNumber(ipo, ret, "", tm);
                };
                //2.执行下单和支付流程
                await PayExecuteWithVaNumber(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Pandapay, func);
                LogUtil.Info("pandapay.pay:4,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));

            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : "获取barcode失败！";
                if (null != exc)
                {
                    LogUtil.Warning(ex, "pandapay.pay:5,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));
                }
                else
                {
                    LogUtil.Error(ex, "pandapay.pay:5,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));
                }
            }
            return ret;
        }

        #region 添加用户vanumber
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <param name="platOrderNum"></param>
        /// <param name="bankId"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        private async Task AddUserVaNumber(PayIpoBase ipo,PandapayDto dto, string platOrderNum,TransactionManager tm)
        {
            var eo = new Sb_panda_user_barcodeEO
            { 
                UserID = ipo.UserId,
                OwnOrderId = ipo.OwnOrderId,
                BarCode = dto.BarCode,
                PlatOrderNum = platOrderNum,
                AppID = ipo.AppId,
                CurrencyID = ipo.CurrencyId,
                OperatorID = ipo.Operator.OperatorID,
                RecDate = DateTime.UtcNow
            };
            var rows = await _userBarcodeMo.AddAsync(eo, tm,true);
            if (rows <= 0)
            {
                //throw new Exception($"添加userbarcodeEo失败！eo:{SerializerUtil.SerializeJsonNet(eo)}");
                //添加返回rows==0,直接读取
                var eoExist = await _userBarcodeMo.GetByPKAsync(ipo.UserId, tm);
                if (eoExist == null)
                    throw new CustomException($"根据userid:{ipo.UserId},获取Sb_panda_user_barcodeEO为空!eo:{SerializerUtil.SerializeJsonNet(eo)}");
                dto.BarCode = eo.BarCode;
            }
        }
        #endregion

        /// <summary>
        /// 生成交易流水号--也就是对方的orderid(商户下唯一)
        /// </summary>
        /// <param name="bankId"></param>
        /// <returns></returns>
        private async Task<string> GetOwnOrderId(string bankId)
        {
            string bankTransactionId = ShortIdUtil.Generate(_shortIdOptions, 21);
            List<Sb_bank_orderEO> bankOrders = null;
            int tryCount = 0;
            while (tryCount < TryCount)
            {
                tryCount++;
                bankOrders = await _bankOrderMo.GetTopAsync("BankID=@BankID and OwnOrderId=@OwnOrderId", 1, bankId, bankTransactionId);
                if (null == bankOrders || bankOrders.Count == 0)
                {
                    return bankTransactionId;
                }
                bankTransactionId = ShortIdUtil.Generate(_shortIdOptions, 21);
            }
            throw new Exception("无法生成panda交易流水号：OwnOrderId");
        }

        /// <summary>
        /// panda提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<PandaCashDto> Cash(PandaCashIpo ipo)
        {
            var ret = BankUtil.CreateDto<PandaCashDto>(ipo);

            try
            {
                if (string.IsNullOrWhiteSpace(ipo.AccNumber))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行账号AccNumber不能为空");
                if (string.IsNullOrWhiteSpace(ipo.BankCode))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行代码BankCode不能为空");
                if (string.IsNullOrWhiteSpace(ipo.BankName))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行名称BankName不能为空");
                if (string.IsNullOrWhiteSpace(ipo.BranchCode))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款人银行账户分行BranchCode不能为空");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");
                if (string.IsNullOrWhiteSpace(ipo.AccName))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"AccName不能为空");
                if (string.IsNullOrWhiteSpace(ipo.TaxId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"TaxId不能为空");
                if (ipo.Amount < 1M.MToA(ipo.CurrencyId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount不能小于1雷亚尔");

                LogUtil.Info("pandapay.cash:2,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));

                var func = async (TransactionManager tm) =>
                {
                    if (!string.IsNullOrWhiteSpace(ipo.CashAuditId))
                    {
                        var cashAuditEo = await _cashAuditMo.GetByPKAsync(ipo.CashAuditId);
                        if (null == cashAuditEo) throw new CustomException($"参数异常!CashAuditId:{ipo.CashAuditId}");
                        //ret.EndBalance = await DbSink.BuildUserMo(ipo.UserId).GetCashByPKAsync(ipo.UserId, tm);
                        var userEo = await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId, tm);
                        if (null == userEo)
                            throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"userEo为null,参数userId:{ipo.UserId}错误");
                        ret.EndBalance = userEo.Cash;
                        ret.EndBonus = userEo.Bonus;
                    }
                    else
                    {
                        //账户余额是否满足
                        var userEo = await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId, tm, true);
                        if (ipo.Amount > userEo.Cash)
                            throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额");
                        long amountBonus = 0;
                        if (userEo.Bonus > 0 && userEo.Bonus >= ipo.Amount)
                            amountBonus = ipo.Amount;
                        else
                            amountBonus = userEo.Bonus <= 0 ? 0 : userEo.Bonus;//没有bonus，或者bonus余额不足押注
                        //扣账户
                        string _set = $"Cash=Cash-@Amount,Bonus=Bonus-@amountBonus";
                        string _where = "UserID=@UserID and Cash>=@amount2 and Bonus>=@amountBonus";
                        var rows = await DbSink.BuildUserMo(ipo.UserId).PutAsync(_set,_where,tm,ipo.Amount, amountBonus, ipo.UserId,ipo.Amount);
                        if (rows <= 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额");
                        //赋值amountbonus
                        ipo.Order.AmountBonus= -amountBonus;
                        //var rows = await DbSink.BuildUserMo(ipo.UserId).PutAsync("Cash=Cash-@Amount,Bonus=Bonus-(case when Bonus>=@Amount then @Amount else Bonus end)", "UserID=@UserID and Cash>=@amount2 and (Bonus-(case when Bonus>=@Amount then @Amount else Bonus end))>=0", tm, ipo.Amount, ipo.UserId, ipo.Amount);

                        //获取最新账户
                        userEo= await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId, tm);
                        ret.EndBalance = userEo.Cash;
                        ret.EndBonus = userEo.Bonus;
                        if (ret.EndBalance < 0 || ret.EndBonus < 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额,扣除账户余额出错");
                        //if (ret.EndBonus < 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"扣除bonus异常");
                    }

                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    var proxy = new BankProxy();
                    await proxy.Cash(ipo, ret);
                };
                //1.执行下单和支付流程
                //await Execute(ipo, ret);
                await Execute(ipo, ret, OrderTypeEnum.Draw, PayTypeEnum.Pandapay, this._request.Path.Value, 0, func, System.Data.IsolationLevel.RepeatableRead);
                LogUtil.Info("pandapay.cash:3,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));

            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : "提款失败";
                if (null != exc)
                {
                    LogUtil.Warning(ex, "pandapay.cash:4,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));
                }
                else
                {
                    LogUtil.Error(ex, "pandapay.cash:4,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));
                }
            }
            return ret;
        }

        /// <summary>
        /// 获取指定渠道的银行名称列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<GetBankListDto> GetBankList(BankListIpo ipo)
        {
            var ret = new GetBankListDto()
            {
                Status = PartnerCodes.RS_OK
            };
            try
            {
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"GetBankList时BankId不能为空！");

                LogUtil.Info("pandapay.BankList:2,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));

                await BankUtil.CheckAndSetIpo(ipo);
                LogUtil.Info("pandapay.BankList:3,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));

                var bankList = PandaDbCacheUtil.Banks;
               
                //var proxy = new BankProxy();
                //var bankList =await proxy.QueryBankList();
                if (bankList != null&&bankList.data!=null&&bankList.data.Any())
                {
                    ret.BankList = bankList.data.Select(b=>new BankListItemDto {
                     BankCode=b.spiCode,
                     BankName=b.name,
                     DisplayName=b.displayName,
                     StrCode=b.strCode
                    });

                }
                LogUtil.Info("pandapay.BankList:4,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = (exc != null) ? exc.Code : PartnerCodes.RS_UNKNOWN;
                if (null != exc)
                {
                    LogUtil.Warning(ex, "pandapay.BankList:5,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));
                }
                else
                {
                    LogUtil.Error(ex, "pandapay.BankList:5,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));
                }
            }
            return ret;
        }

        /// <summary>
        /// 根据pixkey查询个人开户银行信息
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<QueryDictKeyDto> QueryDictKey(QueryDictKeyIpo ipo)
        {
            var ret = new QueryDictKeyDto()
            {
                Status = PartnerCodes.RS_OK
            };
            try
            {
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"QueryDictKey时BankId不能为空！");
                LogUtil.Info("pandapay.QueryDictKey:2,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));

                await BankUtil.CheckAndSetIpo(ipo);
                LogUtil.Info("pandapay.QueryDictKey:3,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));


                //var result = await new BankProxy().QueryDictKey(ipo);
                var cacheItem =await new PandaQueryDictkeyDCache(ipo.QueryKey).GetOrLoadAsync(false,TimeSpan.FromDays(3));
                if (cacheItem == null||!cacheItem.HasValue)
                {
                    throw new CustomException($"没有查到该querydictkey:{ipo.QueryKey}对应的信息！");
                }
                LogUtil.Info("pandapay.QueryDictKey:4,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));

                var result = cacheItem.Value;
                //if (null != result)
                //{
                ret.Data = new QueryDictKeyItemModel
                    {
                        bankCode = result.data.ispb,
                        accountCreated = result.data.accountCreated,
                        accountNumber = result.data.accountNumber,
                        accountType = result.data.accountType,
                        bankName = result.data.bankName,
                        branchCode = result.data.branchCode,
                        created = result.data.created,
                        name = result.data.name,
                        owned = result.data.owned,
                        ownerType = result.data.ownerType,
                        status = result.data.status,
                        taxId = result.data.taxId,
                        type = result.data.type,
                    };
                    //ret.Data= queryData;
                //}
                return ret;
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = (exc != null) ? exc.Code : PartnerCodes.RS_UNKNOWN;
                if(null!=exc)
                {
                    LogUtil.Warning(ex, "pandapay.QueryDictKey:5,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));
                }
                else
                {
                    LogUtil.Error(ex, "pandapay.QueryDictKey:5,param:{0}", SerializerUtil.SerializeJsonNet(new { ipo, ret }));
                }
            }
            return ret;
        }

        protected override void SetSbBankOrderEo(Sb_bank_orderEO order, PayIpoBase ipo)
        {
            var pandaCashIpo = (PandaCashIpo)ipo;
            order.AccName = pandaCashIpo.AccName;
            order.AccNumber = pandaCashIpo.AccNumber;
            order.BankCode = pandaCashIpo.BankCode;
        }
    }
}
