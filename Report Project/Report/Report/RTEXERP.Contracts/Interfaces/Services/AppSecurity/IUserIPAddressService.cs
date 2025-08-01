using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.Interfaces.Services.AppSecurity
{
   public interface IUserIPAddressService
    {
          string GetLocalIpAddress();
    }
}
