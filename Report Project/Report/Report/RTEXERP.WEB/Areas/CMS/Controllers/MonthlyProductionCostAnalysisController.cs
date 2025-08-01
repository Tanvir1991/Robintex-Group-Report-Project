using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.CMS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.CMS.Controllers
{
    [Area("CMS")]
    public class MonthlyProductionCostAnalysisController : Controller
    {
        private readonly IDropdownService dropdownService;
        private readonly IMonthlyProductionCostAnalysisService monthlyProductionCostAnalysisService;

        public MonthlyProductionCostAnalysisController(IDropdownService _dropdownService, IMonthlyProductionCostAnalysisService _monthlyProductionCostAnalysisService)
        {
            dropdownService = _dropdownService;
            monthlyProductionCostAnalysisService = _monthlyProductionCostAnalysisService;
        }
        [HttpGet]
        public IActionResult CreateMonthlyProductionCostAnalysis()
        {
            var model = new MonthlyProductionCostAnalysisMasterVM();
            model.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year, DateTime.Now.Year, false, DateTime.Now.Year).ToList();
            model.MDReportItem = MDReportName.GetReports();
            model.MonthID = DateTime.Now.Month;
            return View(model); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateMonthlyProductionCostAnalysis(MonthlyProductionCostAnalysisMasterVM productionCost)
        {
            var rResult = new RResult();
            rResult = await monthlyProductionCostAnalysisService.SaveMonthWiseProduction(productionCost);
            return Json(rResult);
        }

        public async Task<IActionResult> GetMonthlyProductionCostAnalysList( int monthID, int yearID)
        {
          
            var dataList = await monthlyProductionCostAnalysisService.GetMonthlyProductionCostAnalysisList(monthID, yearID);
            if (dataList.Count>0)
            {
               
                return Json(dataList);
            }
            else
            {
               var lddist= MDReportName.GetReports();
                return Json(lddist);
            }
           
        }
    }
}
