using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Orionpay.Ipo
{
    public class QRCodeIpo : PayIpoBase
    {
        public string BankOrderId { get; set; }

    

        public QRCodeIpo() { }
        public override BankAction Action => BankAction.OrionPay;

        public override Type DtoType => typeof(QRCodeDto);
    }


    public class QRCodeDto : PayDtoBase
    {

       public string brCode { get; set; }

        public string qrCode { get; set; }
    }


}
