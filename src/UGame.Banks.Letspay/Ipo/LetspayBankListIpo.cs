using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Services.Pay;
using Xxyy.Banks.DAL;

namespace UGame.Banks.Letspay.Ipo
{
    public class LetspayBankListIpo : BankIpoBase
    {
        public string CountryId { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(LetspayBankListDto);
    }

    public class LetspayBankListDto
    {
        public List<Sb_bankcodePO> BankList { get; set; }
    }
}
