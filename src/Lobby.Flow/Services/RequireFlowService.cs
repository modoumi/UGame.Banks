using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Text;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.DAL;
using Xxyy.MQ.Xxyy;

namespace Lobby.Flow.Services
{
    public class RequireFlowService
    {
        public async Task AddRequireFlowOrder(CurrencyChangeMsg message)
        {
            var app = DbCacheUtil.GetApp(message.AppId);
            var orderEo = new S_requireflow_orderEO
            {
                OrderID = ObjectId.NewId(),
                ProviderID = app.ProviderID,
                AppID = message.AppId,
                OperatorID = message.OperatorId,
                UserID = message.UserId,
                FromMode = message.FromMode,
                FromId = message.FromId,
                UserKind = (int)message.UserKind,
                CountryID = message.CountryId,
                CurrencyID = message.CurrencyId,
                CurrencyType = (int)message.CurrencyType,

                IsBonus = message.Bonus!=0,
                BonusReason = message.Reason,
                BonusSourceType = message.SourceType,
                SourceId = message.SourceId,
                SourceTable = message.SourceTable,
                FlowMultip = message.FlowMultip,
                OrderAmount = message.Amount,
                OrderRemain = message.Amount,
                RequireFlow = (long)(message.Amount * (decimal)message.FlowMultip),

                EndBonus = message.EndBonus,
                EndBalance = message.EndBalance,
                Status = message.FlowMultip > 0 ? 0 : 1,
                RecDate = message.ChangeTime,
                EndBonusList = (message.Bonus!=0) ? $"+{message.Amount}" : string.Empty,
                UpdateTime = message.ChangeTime,
            };
            if (await DbSink.BuildRequireFlowOrderMo(message.UserId).AddAsync(orderEo, null) < 0)
                throw new Exception($"CurrencyChangeService：{message.Reason}，领取bonus时，写入流水表s_requireflow_order出错");
        }
    }
}
