using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Pandapay.PaySvc
{
    public class PandapayIpo : PayIpoBase
    {
        public string AccName { get; set; }
        public string TaxId { get; set; }
        ///// <summary>
        ///// INVOICE   BOLETO  BRCODE
        ///// </summary>
        //public string PayInType { get; set; }
        //public string StreetLineOne { get; set; }
        //public string StreetLineTwo { get; set; }
        //public string Disctrict { get; set; }
        //public string City { get; set; }
        //public string StateCode { get; set; }
        //public string ZipCode { get; set; }

        public override BankAction Action => BankAction.PandaPay;

        public override Type DtoType => typeof(PandapayDto);
    }

    public class PandapayDto : PayDtoBase
    {
        public string BarCode { get; set; }
    }
}
