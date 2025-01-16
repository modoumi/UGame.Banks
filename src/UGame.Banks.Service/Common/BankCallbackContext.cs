using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using UGame.Banks.Repository;
using Xxyy.Common.Contexts;

namespace UGame.Banks.Service.Common
{
    public class BankCallbackContext //: UserContext
    {
        public object Ipo { get; set; }
        public Sb_bank_orderEO OrderEo { get; set; }
        public Sb_order_trans_logEO OrderTranslogEo { get; set; }
        public BankCallbackContext(object ipo,Sb_bank_orderEO orderEo) //: base(orderEo.UserID)
        {
            this.Ipo = ipo;
            this.OrderEo = orderEo;
        }

        public BankCallbackContext SetTranslog(Sb_order_trans_logEO orderTranslogEo)
        {
            this.OrderTranslogEo = orderTranslogEo;
            return this;
        }

        public static BankCallbackContext Create(object ipo, Sb_bank_orderEO orderEo)
        {
            var context = new BankCallbackContext(ipo,orderEo);
            HttpContextEx.SetContext(context);
            return context;
        }
    }
}
