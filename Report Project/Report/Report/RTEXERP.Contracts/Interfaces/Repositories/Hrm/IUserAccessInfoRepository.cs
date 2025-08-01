using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Contracts.BLModels.Shared.ChartOFACC;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.Interfaces.Repositories.Hrm
{
  
    public interface IUserAccessInfoRepository: IGenericRepository<LogedUserAccessViewModel>
    {
        List<LogedUserAccessViewModel> GetLogedUserAccessItem(int RoleId, int? EmployeeId);
        LoggedUserInfoViewModel GetLoggedUserInfo(string UserName);
        List<LogedUserAccessViewModel> GETAllMenuItem(int CompanyId);

        List<ChartOfAccounts> GetChantOfAccounts( int ParentID= 0, int LevelId  = 1);

      

    }
}
