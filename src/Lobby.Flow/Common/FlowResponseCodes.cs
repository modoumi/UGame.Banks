using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Common
{
    public class FlowResponseCodes
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const string RS_OK = "RS_OK";

        /// <summary>
        /// 用户余额不足
        /// </summary>
        public const string RS_NOT_ENOUGH_MONEY = "RS_NOT_ENOUGH_MONEY";

        /// <summary>
        /// 非法请求
        /// </summary>
        public const string RS_ILLEGAL_REQUEST = "RS_ILLEGAL_REQUEST";

        /// <summary>
        /// 数据已存在
        /// </summary>
        public const string RS_DATA_ALREADY_EXISTS = "RS_DATA_ALREADY_EXISTS";

        /// <summary>
        /// 一般性错误状态
        /// </summary>
        public const string RS_UNKNOWN = "RS_UNKNOWN";

        /// <summary>
        /// 参数错误
        /// </summary>
        public const string RS_PARAMETER_ERROR = "RS_PARAMETER_ERROR";

        /// <summary>
        /// 幸运转盘没有次数
        /// </summary>
        public const string RS_ROULETTE_NO_FREESPIN = "RS_ROULETTE_NO_FREESPIN";

        /// <summary>
        /// 不是注册用户
        /// </summary>
        public const string RS_UNREGISTER = "RS_UNREGISTER";

        /// <summary>
        /// 充值失败
        /// </summary>
        public const string RS_PAY_ERROR = "RS_PAY_ERROR";

        /// <summary>
        /// 提现失败
        /// </summary>
        public const string RS_CASH_ERROR = "RS_CASH_ERROR";

        /// <summary>
        /// 提现自动审批拒单
        /// </summary>
        public const string RS_CASH_AUTO_AUDIT_ERROR = "RS_CASH_AUTO_AUDIT_ERROR";

        /// <summary>
        /// 提现时，未绑定手机号
        /// </summary>
        public const string RS_CASH_NOTEXISTSMOBILE = "RS_CASH_NOTEXISTSMOBILE";

        /// <summary>
        /// 提现时，未满足最低充值额度
        /// </summary>
        public const string RS_CASH_NOTMEETMINPAY = "RS_CASH_NOTMEETMINPAY";

        /// <summary>
        /// 重复添加
        /// </summary>
        public const string RS_REPEAT_ADDITION = "RS_REPEAT_ADDITION";

        /// <summary>
        /// 提现次数限制
        /// </summary>
        public const string RS_CASH_NUM_LIMIT = "RS_CASH_NUM_LIMIT";


        /// <summary>
        /// 活动已过期
        /// </summary>
        public const string RS_ACTIVITY_EXPIRED = "RS_ACTIVITY_EXPIRED";

        /// <summary>
        /// 当前operatorId中不存在appId
        /// </summary>
        public const string RS_OPERATOR_EXISTS_APP = "RS_OPERATOR_EXISTS_APP";

        /// <summary>
        /// 进入游戏时，不满足充值金额
        /// </summary>
        public const string RS_IN_APP_NOT_PAYLIMIT = "RS_IN_APP_NOT_PAYLIMIT";


        /// <summary>
        /// 活动无效
        /// </summary>
        public const string RS_INVALID_ACTIVITY = "RS_INVALID_ACTIVITY";

        /// <summary>
        /// 不满足充值金额
        /// </summary>
        public const string RS_NOT_PAYLIMIT = "RS_NOT_PAYLIMIT";

        /// <summary>
        /// bra添加银行卡时，CPF已存在
        /// </summary>
        public const string RS_BRA_CPF_ALREADY = "RS_BRA_CPF_ALREADY";

        /// <summary>
        /// 抽奖轮盘101001没有次数
        /// </summary>
        public const string RS_ROULETTE101001_NO_SPIN = "RS_ROULETTE101001_NO_SPIN";

        /// <summary>
        /// 提现时，超出当天提现上限
        /// </summary>
        public const string RS_DAY_CASH_AMOUNT_LIMIT = "RS_DAY_CASH_AMOUNT_LIMIT";

        /// <summary>
        /// tejeePay.banklist异常
        /// </summary>
        public const string RS_TEJEEPAY_BANKLIST_ERROR = "RS_TEJEEPAY_BANKLIST_ERROR";

        /// <summary>
        /// letsPay.banklist异常
        /// </summary>
        public const string RS_LETSPAY_BANKLIST_ERROR = "RS_LETSPAY_BANKLIST_ERROR";
    }
}
