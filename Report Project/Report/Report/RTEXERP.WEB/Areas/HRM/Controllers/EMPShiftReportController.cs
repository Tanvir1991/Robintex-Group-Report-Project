using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.Contracts.Interfaces.Repositories.Hrm;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.WEB.Controllers;

namespace RTEXERP.WEB.Areas.HRM.Controllers
{
    [Area("HRM")]
    public class EMPShiftReportController : BaseController
    {
        private readonly ITbl_EmpService tbl_EmpService;
        public EMPShiftReportController(ITbl_EmpService tbl_EmpService)
        {
            this.tbl_EmpService = tbl_EmpService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetEmpReport(string EmpCodeList,string ShiftA,string ShiftB,string ShiftC)
        {
             ShiftReportViewModel model = new ShiftReportViewModel();
            var emplist = await tbl_EmpService.Get_EmpsForShiftReport(EmpCodeList);
            model.EmpList = emplist;
            model.AShift = tbl_EmpService.EnglishNumberToBangla(ShiftA);
            model.BShift = tbl_EmpService.EnglishNumberToBangla(ShiftB);
            model.CShift = tbl_EmpService.EnglishNumberToBangla(ShiftC);
            return Json(model);
        }
    }
}