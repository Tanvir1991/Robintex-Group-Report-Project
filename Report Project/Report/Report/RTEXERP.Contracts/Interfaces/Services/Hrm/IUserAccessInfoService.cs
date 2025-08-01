using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Contracts.BLModels.Shared.ChartOFACC;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.Interfaces.Services.Hrm
{
   public interface IUserAccessInfoService
    {
        /// <summary>
        /// Role Id , Employee Id
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        List<LogedUserAccessViewModel> GetLogedUserAccessItem(int RoleId, int? EmployeeId);
        List<LogedUserAccessViewModel> GETAllMenuItem(int CompanyId);
        LoggedUserInfoViewModel GetLoggedUserInfo(string UserName);
        List<ChartOfAccounts> GetChantOfAccounts(int ParentID = 0, int LevelId = 1);
      
    }
}
