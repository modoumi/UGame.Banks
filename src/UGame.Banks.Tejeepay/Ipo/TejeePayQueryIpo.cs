using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Tejeepay.Model;
using Xxyy.Banks.DAL;

namespace UGame.Banks.Tejeepay.Dto
{
    public class TejeePayQueryIpo : PayIpoBase
    {
        public BizInEnum BizEnum { get; set; } = BizInEnum.bq102;
        public string OrderId { get; set; }
        public string OrderTime { get; set; }
        public Sb_bank_orderEO OrderEo { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action => BankAction.TejeePayQuery;

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(TejeePayQueryDto);

    }

    public class TejeePayQueryDto : PayDtoBase
    {
        public string Status { get; set; }
    }

}
