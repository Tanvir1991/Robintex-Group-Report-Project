using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
  public  interface IUser_SetupService
    {

        Task<List<User_Setup>> GetUserInfo(string UserName,string Password=null);
    }
}
