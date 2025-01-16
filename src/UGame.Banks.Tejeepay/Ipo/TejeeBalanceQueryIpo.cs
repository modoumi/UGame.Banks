using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Tejeepay.Model;

namespace UGame.Banks.Tejeepay.Dto
{
    public class TejeeBalanceQueryIpo : PayIpoBase
    {
        public BizOutEnum BizEnum { get; set; } = 0;
        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action => BankAction.TejeeBalanceQuery;

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(TejeeBalanceQueryDto);
    }
    public class TejeeBalanceQueryDto : PayDtoBase
    {
        public string Status { get; set; }
    }
}
