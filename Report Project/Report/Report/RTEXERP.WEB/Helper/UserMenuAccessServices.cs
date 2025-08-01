

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using System.Linq;

namespace RTEXERP.WEB.Helper
{
    public class UserMenuAccessServices
    {
        private readonly IUserAccessInfoService _userAccessInfoService;
        private readonly ILogger<UserMenuAccessServices> _logger;
        public UserMenuAccessServices(IUserAccessInfoService userAccessInfoService
            , ILogger<UserMenuAccessServices> logger)
        {
            _userAccessInfoService = userAccessInfoService;
            _logger = logger;
        }
        public void SetSessionUserAccess(string userName)
        {
            var userInfo = _userAccessInfoService.GetLoggedUserInfo(userName);
            if (userInfo != null && userInfo.EmployeeId > 0)
            {
                var AllaccessList = _userAccessInfoService.GETAllMenuItem(userInfo.CompanyId);
                var UserAccessList = _userAccessInfoService.GetLogedUserAccessItem(userInfo.RoleId, userInfo.EmployeeId);
                var ParrentList = UserAccessList.Where(b => !b.ParentModuleId.HasValue).ToList();
                SessionData.SETSessionInfo(AllaccessList, UserAccessList, ParrentList, userInfo);
                SessionData.Session_COMPANY_ID = userInfo.CompanyId;
                SessionData.Session_EMPLOYEE_ID = userInfo.EmployeeId;
                SessionData.Session_User_IsSuperAdmin = userInfo.IsSuperAdminRole;
                SessionData.Session_Role_ID = userInfo.RoleId;
                SessionData.Session_USER_ID = userInfo.UserId;
                _logger.LogInformation("User logged in.");

            }
        }
    }
}
