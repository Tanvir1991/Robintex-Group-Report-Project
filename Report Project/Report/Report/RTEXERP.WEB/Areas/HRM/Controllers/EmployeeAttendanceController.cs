using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.Contracts.Common;
using RTEXERP.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.HRM.Controllers
{
    [Area("HRM")]
    public class EmployeeAttendanceController : BaseController
    {
        private readonly IDropdownService dropdownService;

        public EmployeeAttendanceController(IDropdownService _dropdownService)
        {
            dropdownService = _dropdownService;
        }
        public IActionResult EmployeeAttendancePage()
        {
            var model = new EmployeeAttendancePageViewModel();
            var list = new List<SelectListItem>()
            {
                new SelectListItem(){Text="All Department" ,Value="0"},
                new SelectListItem(){Text="AOP" ,Value="1"},
                new SelectListItem(){Text="Knitting" ,Value="2"},
                new SelectListItem(){Text="Dyeing" ,Value="3"},
                 new SelectListItem(){Text="Store" ,Value="4"},
                  new SelectListItem(){Text="M.P.C" ,Value="5"}
            };
           
            if (Session_RoleID == 23 || Session_RoleID==1)
            {
                model.DepartmentList = list;
            }else if (Session_RoleID == 22)
            {
                model.DepartmentList= list.Where(b => b.Value == "1").ToList();
            }else if (Session_RoleID == 27)
            {                                            
                model.DepartmentList= list.Where(b => b.Value == "2").ToList();
            }
            else if (Session_RoleID == 21)
            {
                model.DepartmentList= list.Where(b => b.Value == "3").ToList();
            }
            else if (Session_RoleID == 15)
            {
                model.DepartmentList = list.Where(b => b.Value == "4").ToList();
            }

            model.StatusList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="All" ,Value="2,3,7"},
                 new SelectListItem(){Text="Present" ,Value="3,7"},
                  new SelectListItem(){Text="Absent" ,Value="2"},
            };
            
            model.PresentStatusList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="All" ,Value="ALL"},
                 new SelectListItem(){Text="In Time" ,Value="In Time"},
                  new SelectListItem(){Text="Late" ,Value="Late"}
            };

            return View(model);
        }





        #region Report
        public async Task<IActionResult> ShowAttendanceReport(int DepartmentID,string StatusID,string PresentStatusID,DateTime AttendanceDate, string ReportFormat)
        {
           
            string reportName = "HR_GetEmployeeAttendanceDaily";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DepartmentID", DepartmentID);
            parameters.Add("AttendanceStatus", StatusID);
            parameters.Add("PresentStatus", PresentStatusID);
            parameters.Add("AttendanceDate", AttendanceDate.ToString("dd-MMM-yyyy"));
 
            int connectionString = (int)enum_ServerType.HRMSConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        #endregion
    }
}
