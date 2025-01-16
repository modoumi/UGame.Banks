using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Hubtel
{
    public enum TransferOrderStatuEnum
    {
        None = 0,
        RequestSuccess=1,
        RequestFailed=2,
        CallbackSuccess=3,
        CallbackFailed = 4
    }
}
