using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RTEXERP.Common.Constants;
using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.DAL.DataContext;
using RTEXERP.Extension.Extensions;
using RTEXERP.WEB.Helper;
using SSRSReport.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Controllers
{
    [Authorize]
    [SessionExpireFilter]
    public class BaseController : Controller
    {
        private ReportDBContext context;
      

        public BaseController()
        {
  
        }

        public BaseController(ReportDBContext context)
        {
            this.context = context;
          
        }

        protected int Session_EMPLOYEE_ID
        {
            get
            {
                var info = HttpContext.Session.Get<int>(SessionKey.LOGGEDIN_EMPLOYEE);
                return info;
            }
            // set { HttpContext.Session.Set<int>(SessionKey.LOGGEDIN_EMPLOYEE, value); }
        }
        protected int Session_COMPANY_ID
        {
            get
            {
                var info = HttpContext.Session.Get<int>(SessionKey.COMPANY_Id);
                return info;
            }
            //  set { HttpContext.Session.Set<int>(SessionKey.COMP_ID, value); }
        }
        protected bool Session_User_IsSuperAdmin
        {
            get
            {
                var info = HttpContext.Session.Get<bool>(SessionKey.LogedIsSuperAdminRole);
                return info;
            }
            //  set { HttpContext.Session.Set<int>(SessionKey.COMP_ID, value); }
        }
        protected int Session_USER_ID
        {
            get
            {
                var info = HttpContext.Session.Get<int>(SessionKey.Logged_USER_ID);
                return info;
            }
            //  set { HttpContext.Session.Set<int>(SessionKey.COMP_ID, value); }
        }
        protected int Session_RoleID
        {
            get
            {
                var info = HttpContext.Session.Get<int>(SessionKey.ROLE_ID);
                return info;
            }
            //  set { HttpContext.Session.Set<int>(SessionKey.COMP_ID, value); }
        }

 
        protected LoggedUserInfoViewModel SessionUserInfo()
        {
            var info = HttpContext.Session.Get<LoggedUserInfoViewModel>(SessionKey.LOGGEDIN_EMPLOYEE_INFO_Model);
            return info;

        }
 

        #region SSRS Report Call
        /// <summary>
        /// ServerType ="Remote" = 8 Server
        /// /// ServerType ="Own" = 7 Server
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="parameters"></param>
        /// <param name="ReportFormat"></param>
        /// <returns></returns>
        [NonAction]
        protected async Task<FileStreamResult> PrintSSRSReport(string reportName, IDictionary<string, object> parameters, string ReportFormat,int ServerConnectionString=0)
        {
            try
            {
                string languageCode = "en-us";
                byte[] reportContent = await new CallSSRSReport().RenderReport(reportName, parameters, languageCode, ReportFormat, ServerConnectionString);
                var ContentType = "";
                Stream stream = new MemoryStream(reportContent);
                if (ReportFormat == ReportExportFormat.ExcelFormat)
                {
                    ContentType = "application/vnd.ms-excel";

                }
                else if (ReportFormat == ReportExportFormat.PdfFormat)
                {
                    ContentType = "application/pdf";
                }
                return new FileStreamResult(stream, ContentType);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

       
    }
}