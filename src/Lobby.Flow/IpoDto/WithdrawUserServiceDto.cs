using TinyFx.Data;
using Xxyy.Common.Services;
using Xxyy.DAL;

namespace Lobby.Flow.IpoDto
{
    public class WithdrawUserServiceDto
    {
        public UserService UserSvc { get; set; }
        public V_s_operatorEO OperatorEo { get; set; }
        public string CurrencyId { get; set; }
        public TransactionManager TM { get; set; }
        public S_appEO AppEo { get; set; }
        public Xxyy.DAL.S_requireflow_orderMO RequireFlowOrderMo { get; set; }
        public BalanceInfo BalanceInfo { get; set; }
    }
}
