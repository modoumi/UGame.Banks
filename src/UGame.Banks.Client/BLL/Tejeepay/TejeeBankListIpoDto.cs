using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Tejeepay
{
    internal class TejeeBankListIpo:BaseIpo
    {
        public string CountryId { get; set; }
    }

    public class BankCodeModel
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
    }
}
