using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
   public class User_SetupRepository : GenericRepository<User_Setup>, IUser_SetupRepository
    {
        private MaxcoDBContext dbCon;

        public User_SetupRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<User_Setup>> GetUserInfo(string UserName, string Password = null)
        {
            var userq = dbCon.User_Setup.Where(b => b.UserName == UserName && b.Status>0);
            if (!string.IsNullOrEmpty(Password))
            {
                userq = userq.Where(b => b.Password == Password);
            }
            var userData = await userq.ToListAsync();
            return userData;

        }
    }
}
