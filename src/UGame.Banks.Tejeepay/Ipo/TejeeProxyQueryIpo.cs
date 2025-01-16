using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Tejeepay.Model;
using Xxyy.Banks.DAL;

namespace UGame.Banks.Tejeepay.Dto
{
    public class TejeeProxyQueryIpo : PayIpoBase
    {
        public BizOutEnum BizEnum { get; set; } = 0;
        //[RequiredEx("OrderId不能为空")]
        public string OrderId { get; set; }

        //[RequiredEx("TradeId不能为空")]
        public string TradeId { get; set; }
        public Sb_bank_orderEO OrderEo { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action => BankAction.TejeeProxyQuery;

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(TejeeProxyQueryDto);
    }

    public class TejeeProxyQueryDto : PayDtoBase
    {
        public string Status { get; set; }
    }
}
