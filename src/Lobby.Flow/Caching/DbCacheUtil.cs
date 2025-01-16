using Lobby.Flow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.DbCaching;

namespace Lobby.Flow.Caching
{
    public static class DbCacheUtil
    {
        public static DAL.Sc_vip_configPO GetVipConfig(string operatorId, int vipGrade)
        {
            var list = GetOperatorVipConfigList(operatorId);

            if (list == null || !list.Any())
                throw new Exception($"sc_vip_config不存在定义1。operatorId:{operatorId}");

            var ret = list.Where(d => d.VipGrade == vipGrade).FirstOrDefault();

            if (ret == null)
                throw new Exception($"sc_vip_config不存在定义1。operatorId:{operatorId},vipGrade:{vipGrade}");

            return ret;
        }

        public static DAL.Sc_vip_configPO GetVipConfigNoException(string operatorId, int vipGrade)
        {
            var list = GetOperatorVipConfigList(operatorId);
            return list.Where(d => d.VipGrade == vipGrade).FirstOrDefault();
        }

        public static List<DAL.Sc_vip_configPO> GetOperatorVipConfigList(string operatorId)
        {
            var ret = DbCachingUtil.GetList<DAL.Sc_vip_configPO>(d => new { d.OperatorID }, new DAL.Sc_vip_configPO
            {
                OperatorID = operatorId,
            });

            if (ret == null || !ret.Any())
                return new List<DAL.Sc_vip_configPO>();

            return ret.OrderBy(d => d.VipGrade).ToList();
        }

        public static List<Sc_cash_condition_configPO> GetAllCashConditionConfig(string operatorId, string currencyId)
        {
            var ret = DbCachingUtil.GetList<Sc_cash_condition_configPO>(d => new { d.OperatorID, d.CurrencyID }, new Sc_cash_condition_configPO
            {
                OperatorID = operatorId,
                CurrencyID = currencyId
            });

            if (ret == null || !ret.Any())
                return new List<Sc_cash_condition_configPO>();

            return ret;
        }
    }
}
