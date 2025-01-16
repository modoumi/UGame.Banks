using Lobby.Flow.Common;

namespace Lobby.Flow.Services.CashServices
{
    internal static class CashValidateServiceFactory
    {
        public static ICashValidateService Create(string operatorId)
        {
            var sOperatorEo =Xxyy.Common.Caching.DbCacheUtil.GetOperator(operatorId);
            var withdrawRuleMode = sOperatorEo.WithdrawRuleMode;
            return withdrawRuleMode switch
            {
                (int)WithdrawRuleModeEnum.Zero => new CashValidateServiceZero(),
                (int)WithdrawRuleModeEnum.One => new CashValidateServiceOne(),
                (int)WithdrawRuleModeEnum.Two => new CashValidateServiceTwo(),
                //(int)WithdrawRuleModeEnum.Three => new CashValidateServiceThree(),
                _ => throw new ArgumentOutOfRangeException(nameof(withdrawRuleMode))
            };
        }
    }
}
