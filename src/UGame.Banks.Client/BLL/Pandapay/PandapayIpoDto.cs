using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Pandapay
{
    internal class PandapayIpo : BaseIpo
    {
        public string AccName { get; set; }
        public string TaxId { get; set; }
    }

    public class PandapayDto : BaseDto
    {
        public string BarCode { get; set; }
    }
}
