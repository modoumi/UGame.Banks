using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Req
{
    public class PayInRequest
    {
        public string mchId { get; set; }   
        public string orderNo { get; set; }

        public string amount { get; set; }
        /// <summary>
        /// baxipix ,argbank ,mexbank ,turbank ,cobank,  pebank ,ecbank
        /// </summary>
        public string product { get; set; }
        /// <summary>
        /// CLABE OXXO PAYCASH
        /// </summary>
        public string bankcode { get; set; }

        public string goods { get; set; }


        public string notifyUrl { get; set; }
        public string returnUrl { get; set; }
        public string sign { get; set; }

    }
    public class Goods
    {
        //mail:520155@gmail.com/name:tom/phone:7894561230
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        public override string ToString()
        {
            return $"email:{email}/name:{name}/phone:{phone}";
        }

    }
}
