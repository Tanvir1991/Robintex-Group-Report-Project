using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class User_SetupService : IUser_SetupService
    {
        private readonly IUser_SetupRepository _user_SetupRepository;
        public User_SetupService(IUser_SetupRepository user_SetupRepository)
        {
            _user_SetupRepository = user_SetupRepository;
        }
        public async Task<List<User_Setup>> GetUserInfo(string UserName, string Password = null)
        {
            return await _user_SetupRepository.GetUserInfo(UserName, Password);
        }
    }
}
