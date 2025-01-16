using Lobby.Flow.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xxyy.Common.Caching;

namespace Lobby.Flow
{
    public static class FlowServiceFactory
    {
        public static IFlowService CreateFlowService(string userId, string appId, string operatorId)
        {
            var operatorInfo = DbCacheUtil.GetOperator(operatorId);
            return operatorInfo.FlowMode switch
            {
                (int)FlowModeEnum.One => new FlowModeOneService(userId, appId, operatorId),
                (int)FlowModeEnum.Three => new FlowModeThreeService(userId, appId, operatorId),
                (int)FlowModeEnum.Two => new FlowModeTwoService(userId, appId, operatorId),
                _ => throw new Exception($"CreateFlowService参数错误，FlowMode:{operatorInfo.FlowMode}")
            } ;
        }
    }
}
