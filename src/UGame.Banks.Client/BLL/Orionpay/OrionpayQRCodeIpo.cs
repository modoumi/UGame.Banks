using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;

namespace UGame.Banks.Client.BLL.Orionpay
{
    internal class OrionpayQRCodeIpo : BaseIpo
    {
        public string BankOrderId { get; set; }
    }

    public class OrionQRCodeDto : BaseDto
    {
        public string brCode { get; set; }

        public string qrCode { get; set; }
    }
}
