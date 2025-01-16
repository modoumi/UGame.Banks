using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Data;
using Xxyy.Common.Services;
using Xxyy.DAL;
using Lobby.Flow.IpoDto;

namespace Lobby.Flow.Services
{
    public static class WithdrawUserServiceFactory
    {
        public static IWithdrawUserService Create(WithdrawUserServiceDto dto) => new WithdrawUserOneService(dto);
    }
}
