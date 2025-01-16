using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Letspay.Resp;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Letspay.Ipo
{
    public class QueryPayOrderIpo : BankIpoBase
    {
        public string OrderId { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType =>typeof(QueryPayOrderDto);
    }

    public class QueryPayOrderDto: PayDtoBase
    {
        public QueryPayOrderResponse OrderInfo { get; set; }
    }
}
