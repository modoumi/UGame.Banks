using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Client.BLL;

namespace UGame.Banks.Client
{
    internal class GetBankListIpo : BaseIpo
    {
        public string CountryId { get; set; }
    }

    public class BankCodeModel
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
    }
}
