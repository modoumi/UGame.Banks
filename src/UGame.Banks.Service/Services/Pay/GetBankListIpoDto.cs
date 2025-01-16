using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Repository;

namespace UGame.Banks.Service.Services.Pay
{

    public class GetBankListIpo : BankIpoBase
    {
        public string CountryId { get; set; }
        //public override Type DtoType => typeof(GetBankListDto);
    }

    public class GetBankListDto
    {
        public List<Sb_bankcodePO> BankList { get; set; }
    }
}
