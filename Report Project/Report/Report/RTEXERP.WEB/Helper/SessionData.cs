using Microsoft.AspNetCore.Http;
using RTEXERP.Common.Constants;
using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.DBEntities.dbo;
using System.Collections.Generic;
using RTEXERP.Extension.Extensions;
using System.Linq;

namespace RTEXERP.WEB.Helper
{
    public class SessionData
    {
        public static bool IsAuthenticated
        {
            get { return HttpContextHelper.Current.User.Identity.IsAuthenticated; }
        }

        public static void SETSessionInfo(List<LogedUserAccessViewModel> AllMenu, List<LogedUserAccessViewModel> UserList, List<LogedUserAccessViewModel> ParentList, LoggedUserInfoViewModel userinfo)
        {
            if (HttpContextHelper.Current.Session != null)
            {
                HttpContextHelper.Current.Session.Set<List<LogedUserAccessViewModel>>(SessionKey.All_Modules, AllMenu);
                HttpContextHelper.Current.Session.Set<List<LogedUserAccessViewModel>>(SessionKey.USER_SECURITY_MODULES, UserList);
                HttpContextHelper.Current.Session.Set<List<LogedUserAccessViewModel>>(SessionKey.PARENT_MODULES, ParentList);
                HttpContextHelper.Current.Session.Set<LoggedUserInfoViewModel>(SessionKey.LOGGEDIN_EMPLOYEE_INFO_Model, userinfo);
            }
        }

        public static List<LogedUserAccessViewModel> UserMenuList
        {
            get
            {
                var UserModule = HttpContextHelper.Current.Session.Get<List<LogedUserAccessViewModel>>(SessionKey.USER_SECURITY_MODULES);

                if (IsAuthenticated && UserModule != null)
                    return UserModule as List<LogedUserAccessViewModel>;
                else
                    return new List<LogedUserAccessViewModel>();
            }
        }

        public static List<LogedUserAccessViewModel> AllModules
        {
            get
            {
                var UserModule = HttpContextHelper.Current.Session.Get<List<LogedUserAccessViewModel>>(SessionKey.All_Modules);

                if (IsAuthenticated && UserModule != null)
                    return UserModule as List<LogedUserAccessViewModel>;
                else
                    return new List<LogedUserAccessViewModel>();
            }
        }

        public static List<LogedUserAccessViewModel> PARENT_MODULES
        {
            get
            {
                var parrentMenu = HttpContextHelper.Current.Session.Get<List<LogedUserAccessViewModel>>(SessionKey.PARENT_MODULES);

                if (IsAuthenticated && parrentMenu != null)
                    return parrentMenu as List<LogedUserAccessViewModel>;
                else
                    return null;
            }
        }
        public static int Session_EMPLOYEE_ID
        {

            get { return HttpContextHelper.Current.Session.Get<int>(SessionKey.LOGGEDIN_EMPLOYEE); }
            set
            {

                HttpContextHelper.Current.Session.Set<int>(SessionKey.LOGGEDIN_EMPLOYEE, value);
            }
        }
        public static bool Session_User_IsSuperAdmin
        {

            get { return HttpContextHelper.Current.Session.Get<bool>(SessionKey.LogedIsSuperAdminRole); }
            set
            {

                HttpContextHelper.Current.Session.Set<bool>(SessionKey.LogedIsSuperAdminRole, value);
            }
        }
        public static int Session_COMPANY_ID
        {
            get { return HttpContextHelper.Current.Session.Get<int>(SessionKey.COMPANY_Id); }
            // get { return HttpContextHelper.Current.Session.Get<LoggedUserInfoViewModel>(SessionKey.COMPANY_Id) == null ? default(System.Int32) : HttpContextHelper.Current.Session.Get<LoggedUserInfoViewModel>(SessionKey.LOGGEDIN_EMPLOYEE_INFO_Model).CompanyId; }
            set
            {
                HttpContextHelper.Current.Session.Set<int>(SessionKey.COMPANY_Id, value);
            }
        }
        public static int Session_Role_ID
        {
            get { return HttpContextHelper.Current.Session.Get<int>(SessionKey.ROLE_ID); }
            // get { return HttpContextHelper.Current.Session.Get<LoggedUserInfoViewModel>(SessionKey.COMPANY_Id) == null ? default(System.Int32) : HttpContextHelper.Current.Session.Get<LoggedUserInfoViewModel>(SessionKey.LOGGEDIN_EMPLOYEE_INFO_Model).CompanyId; }
            set
            {
                HttpContextHelper.Current.Session.Set<int>(SessionKey.ROLE_ID, value);
            }
        }
        public static int Session_USER_ID
        {
            get { return HttpContextHelper.Current.Session.Get<int>(SessionKey.Logged_USER_ID); }
            // get { return HttpContextHelper.Current.Session.Get<LoggedUserInfoViewModel>(SessionKey.COMPANY_Id) == null ? default(System.Int32) : HttpContextHelper.Current.Session.Get<LoggedUserInfoViewModel>(SessionKey.LOGGEDIN_EMPLOYEE_INFO_Model).CompanyId; }
            set
            {
                HttpContextHelper.Current.Session.Set<int>(SessionKey.Logged_USER_ID, value);
            }
        }

        public static  LoggedUserInfoViewModel loggedUserInfoViewModel
{
            get { return HttpContextHelper.Current.Session.Get<LoggedUserInfoViewModel>(SessionKey.LOGGEDIN_EMPLOYEE_INFO_Model); }
    // get { return HttpContextHelper.Current.Session.Get<LoggedUserInfoViewModel>(SessionKey.COMPANY_Id) == null ? default(System.Int32) : HttpContextHelper.Current.Session.Get<LoggedUserInfoViewModel>(SessionKey.LOGGEDIN_EMPLOYEE_INFO_Model).CompanyId; }

        }

    }
}
