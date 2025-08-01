using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Contracts.BLModels.Shared.ChartOFACC;
using RTEXERP.Contracts.Interfaces.Repositories.Hrm;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.DAL.ImpRepository.Hrm;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.BLL.ImpService.Hrm
{

    public class UserAccessInfoService : IUserAccessInfoService
    {
        IUserAccessInfoRepository userAccessInfoRepository;
        public UserAccessInfoService(IUserAccessInfoRepository userAccessInfoRepository)
        {
            this.userAccessInfoRepository = userAccessInfoRepository;

        }

        public LoggedUserInfoViewModel GetLoggedUserInfo(string UserName)
        {
            return userAccessInfoRepository.GetLoggedUserInfo(UserName);
        }

        public List<LogedUserAccessViewModel> GetLogedUserAccessItem(int RoleId, int? EmployeeId)
        {
            return userAccessInfoRepository.GetLogedUserAccessItem(RoleId, EmployeeId);
        }

        public List<LogedUserAccessViewModel> GETAllMenuItem(int CompanyId)
        {
            return userAccessInfoRepository.GETAllMenuItem(CompanyId);
        }

        public List<ChartOfAccounts> GetChantOfAccounts(int ParentID = 0, int LevelId = 1)
        {
           return userAccessInfoRepository.GetChantOfAccounts(ParentID,LevelId);
        }
    }
}