using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using TinyFx;
using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.BLL;
using Xxyy.DAL;
using TinyFx.Data;
using Xxyy.Banks.Mongopay.Controller;
using TinyFx.Logging;
using System.Security.Cryptography;
using TinyFx.Security;
using System.Text.Json.Nodes;
using Org.BouncyCastle.Ocsp;
using Xxyy.Common.Caching;
using Xxyy.Common;
using Xxyy.Banks.Mongopay.Core;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using EasyNetQ;

using Xxyy.Common.Services;
using Serilog.Enrichers;
using TinyFx.Net;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using TinyFx.Extensions.RabbitMQ;
using Xxyy.Banks.BLL.Services.Consumers;
using Xxyy.MQ.Bank;
using Xxyy.Banks.DAL;

namespace Xxyy.Banks.Mongopay.PaySvc
{
    internal class MongoPayService:BankServiceBase //: PayCallbackServiceBase<CallbackIpoCommonBase, string>
    {
        //private readonly S_userMO _userMo = new();
        //private readonly Sb_bank_orderMO _bankOrderMo = new();
        //private readonly Sb_order_trans_logMO _orderTransLog = new();
        private readonly Sb_user_vanumberMO _userVanumberMo = new();
        private readonly Sc_cash_auditMO _cashAuditMo = new();
        

        //private const int AMOUNT = 100000;
        private const string BANKID = "mongopay";

        private HttpRequest _request;

        /// <summary>
        /// 
        /// </summary>
        public MongoPayService()
        {
            _request = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext.Request;
        }



        /// <summary>
        /// spei支付
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<SpeiDto> Pay(SpeiIpo ipo)
        {
            var ret = BankUtil.CreateDto<SpeiDto>(ipo);

            try
            {
                if (ipo.Amount < 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"充值金额Amount必须大于等于0");
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                LogUtil.Info($"mongopay.pay:2,param:{SerializerUtil.SerializeJsonNet(new { ipo,ret})}");

                //0.用户是否存在vanumber,存在则返回
                var userVanumberEo = await _userVanumberMo.GetByPKAsync(ipo.UserId);
                if (null != userVanumberEo && !string.IsNullOrWhiteSpace(userVanumberEo.VaNumber))
                {
                    ret.VaNumber = userVanumberEo.VaNumber;
                    return ret;
                }
                LogUtil.Info($"mongopay.pay:3,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    var proxy = new BankProxy(ipo.BankId);
                    await proxy.Pay(ipo, ret);
                    //添加vanumer
                    await AddUserVaNumber(ipo, ret, tm);
                };
                //2.执行下单和支付流程
                await PayExecuteWithVaNumber(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Spei, func);
                LogUtil.Info($"mongopay.pay:4,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                LogUtil.Error(ex,$"mongopay.pay:5,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

            }
            return ret;
        }


        #region 添加用户vanumber
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        private async Task AddUserVaNumber(PayIpoBase ipo, SpeiDto dto,TransactionManager tm)
        {
            var eo = new Sb_user_vanumberEO
            {
                UserID = ipo.UserId,
                OrderID = ipo.OrderId,
                VaNumber = dto.VaNumber,
                PlatOrderNum = dto.BankOrderId,
                AppID = ipo.AppId,
                CurrencyID = ipo.CurrencyId,
                OperatorID = ipo.Operator.OperatorID
            };
            var rows = await _userVanumberMo.AddAsync(eo,tm);
            if (rows <= 0)
            {
                eo = await _userVanumberMo.GetByPKAsync(ipo.UserId,tm);
                if(null==eo)
                    throw new CustomException($"根据userid:{ipo.UserId}获取Sb_user_vanumberEo为空！");
                dto.VaNumber= eo.VaNumber;
            }
            //throw new Exception($"添加Sb_user_vanumber失败！eo:{SerializerUtil.SerializeJsonNet(userVaNumberEo)}");
        }
        #endregion

        /// <summary>
        /// spei提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<CashSpeiDto> Cash(CashSpeiIpo ipo)
        {
            var ret = BankUtil.CreateDto<CashSpeiDto>(ipo);
           
            try
            {
                if (string.IsNullOrWhiteSpace(ipo.AccNumber))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行账号AccNumber不能为空");

                if (string.IsNullOrWhiteSpace(ipo.BankCode))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款银行代码BankCode不能为空");

                if (string.IsNullOrWhiteSpace(ipo.AccName))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"收款账号名称AccName不能为空");

                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"BankId不能为空");

                if (ipo.Amount <= 0)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于0");

                LogUtil.Info($"mongopay.cash:2,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");


                var func = async (TransactionManager tm) =>
                {
                    if (!string.IsNullOrWhiteSpace(ipo.CashAuditId))
                    {
                        var cashAuditEo=await _cashAuditMo.GetByPKAsync(ipo.CashAuditId);
                        if(null==cashAuditEo) 
                            throw new CustomException($"参数异常!CashAuditId:{ipo.CashAuditId}");
                        if(cashAuditEo.Status!=0)
                            throw new CustomException($"参数异常!CashAuditId:{ipo.CashAuditId},已审核");
                        //ret.EndBalance= await DbSink.BuildUserMo(ipo.UserId).GetCashByPKAsync(ipo.UserId, tm);
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
                        string _where = "UserID=@UserID and Cash>=@amount2 and Bonus>=@amountBonus2";
                        var rows = await DbSink.BuildUserMo(ipo.UserId).PutAsync(_set, _where, tm, ipo.Amount, amountBonus, ipo.UserId, ipo.Amount, amountBonus);
                        //var rows = await DbSink.BuildUserMo(ipo.UserId).PutAsync("Cash=Cash-@Amount", "UserID=@UserID and Cash>=@amount2", tm, ipo.Amount, ipo.UserId, ipo.Amount);
                        if (rows <= 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额");

                        //获取最新账户
                        userEo= await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId, tm);
                        ret.EndBalance = userEo.Cash; //await DbSink.BuildUserMo(ipo.UserId).GetCashByPKAsync(ipo.UserId, tm);
                        ret.EndBonus = userEo.Bonus;
                        if (ret.EndBalance < 0|| ret.EndBonus < 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额,扣除账户余额出错");
                        //if (ret.EndBonus < 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"扣除bonus异常");
                    }

                    //生成我方传给对方的交易流水号
                    //var ownOrderId = StringUtil.GetGuidString();
                    ipo.OwnOrderId = ipo.OrderId; //StringUtil.GetGuidString();
                    var proxy = new BankProxy(ipo.BankId); //BankUtil.CreateSpeiProxy(ipo.BankId);
                    await proxy.Cash(ipo, ret);
                };
                //1.执行下单和支付流程
                //await Execute(ipo, ret);
                //await _cashSvc.Execute(ipo,ret,OrderTypeEnum.Draw,PayTypeEnum.Spei,func);
                await Execute(ipo, ret, OrderTypeEnum.Draw, PayTypeEnum.Spei, _request.Path.Value, 0, func, isolationLevel: System.Data.IsolationLevel.RepeatableRead);
                LogUtil.Info($"mongopay.cash:3,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                
                LogUtil.Error(ex,$"mongopay.pay:4,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

            }
            return ret;
        }



        protected override void SetSbBankOrderEo(Sb_bank_orderEO order, PayIpoBase ipo)
        {
            var cashSpeiIpo = (CashSpeiIpo)ipo;
            order.AccName = cashSpeiIpo.AccName;
            order.AccNumber = cashSpeiIpo.AccNumber;
            order.BankCode = cashSpeiIpo.BankCode;
        }
    }
}
