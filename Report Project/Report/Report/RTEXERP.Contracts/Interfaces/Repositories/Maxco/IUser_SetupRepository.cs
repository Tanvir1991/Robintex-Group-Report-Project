
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
   public interface IUser_SetupRepository:IGenericRepository<User_Setup>
    {
        Task<List<User_Setup>> GetUserInfo(string UserName, string Password = null);
    }
}
