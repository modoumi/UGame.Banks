//using Lobby.Flow.Common;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xxyy.Common.Caching;

//namespace Lobby.Flow.Services.CashServices
//{
//    public static class CashServiceFactory<T>
//    {
//        public static ICashService<T> CreateCashService(string operatorId, string currencyId)
//        {
//            var sOperatorEo = DbCacheUtil.GetOperator(operatorId);

//            if (sOperatorEo != null && sOperatorEo.OperatorVersion == (int)OperatorVersionsEnum.longVersion)
//                return new LongVersionService<T>();

//            return new DefaultVersionService<T>();
//        }

//    }
//}
