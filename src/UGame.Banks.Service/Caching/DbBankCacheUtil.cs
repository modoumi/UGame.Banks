using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.DbCaching;
using UGame.Banks.Repository;
using Xxyy.DAL;

namespace UGame.Banks.Service.Caching
{
    public static class DbBankCacheUtil
    {
        public static Sb_bankPO GetBank(string bankId, bool excOnNull = true, string errorCode = null)
        {
            var ret = DbCachingUtil.GetSingle<Sb_bankPO>(bankId);
            if (null == ret)
            {
                if (excOnNull)
                {
                    if (string.IsNullOrWhiteSpace(errorCode))
                        throw new Exception($"bankId不存在: {bankId}");
                    else
                        throw new CustomException(errorCode, $"bankId不存在: {bankId}");
                }
                else
                    return null;
            }
            return ret;
        }
        public static Sb_bank_currencyPO GetBankCurrency(string bankId, string currencyId, bool excOnNull = true)
        {
            var ret = DbCachingUtil.GetSingle<Sb_bank_currencyPO>(it => new { it.BankID, it.CurrencyID }, new Sb_bank_currencyPO
            {
                BankID = bankId,
                CurrencyID = currencyId,
            });
            if (ret == null)
            {
                if (excOnNull)
                {
                    throw new Exception($"bankId：{bankId}和currencyId:{currencyId}不存在");
                }
                return null;
            }
            return ret;
        }

        public static List<Sb_mongopay_bankcodePO> GetMongopayBankCodeList()
        {
            return DbCachingUtil.GetAllList<Sb_mongopay_bankcodePO>();
        }

        #region bankpaytypechanneldict
        public static Sb_bank_paytype_channelPO GetBankPaytypeChannel(string bankId, int paytypeId, int channelId, bool excOnNull = true)
        {
            var ret = DbCachingUtil.GetSingle<Sb_bank_paytype_channelPO>(it => new
            { it.BankID, it.PaytypeID, it.PaytypeChannel }, new Sb_bank_paytype_channelPO
            {
                BankID = bankId,
                PaytypeID = paytypeId,
                PaytypeChannel = channelId

            });
            if (ret == null)
            {
                if (excOnNull)
                    throw new Exception($"bankId:{bankId},channelId:{channelId}不存在!");
                return null;
            }
            return ret;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankId"></param>
        /// <returns></returns>
        public static List<Sb_bankcodePO> GetBankList(string bankId)
        {
            return DbCachingUtil.GetList<Sb_bankcodePO>(it=>it.BankID,bankId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankId"></param>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public static List<Sb_bankcodePO> GetBankList(string bankId,string countryId)
        {
            var ret = DbCachingUtil.GetList<Sb_bankcodePO>(it => new { it.BankID ,it.CountryID}, new { BankID=bankId , CountryID=countryId });
            return ret;
        }
    }
}
