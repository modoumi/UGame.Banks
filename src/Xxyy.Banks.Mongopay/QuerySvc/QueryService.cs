using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Query;
using Xxyy.Banks.BLL;
using TinyFx.Extensions.AutoMapper;

using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.DAL;

namespace Xxyy.Banks.Mongopay.QuerySvc
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryService
    {
        private Sb_mongopay_bankcodeMO _bankCodeMo = new();

        /// <summary>
        /// 获取指定渠道的银行名称列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<GetBankNameListDto> GetBankNameList(BankNameListIpo ipo)
        {
            var ret = new GetBankNameListDto()
            {
                Status = PartnerCodes.RS_OK
            };
            try
            {
                if (string.IsNullOrWhiteSpace(ipo.BankId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"GetBankNameList时BankId不能为空！");

                await BankUtil.CheckAndSetIpo(ipo);

                ret.BankList = DbBankCacheUtil.GetMongopayBankCodeList().Map<List<BankNameListDto>>();
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = (exc != null) ? exc.Code : PartnerCodes.RS_UNKNOWN;
            }
            return ret;
        }
    }
}
