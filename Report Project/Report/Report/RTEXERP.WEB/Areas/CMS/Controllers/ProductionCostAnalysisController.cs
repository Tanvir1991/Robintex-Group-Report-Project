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
    public class ProductionCostAnalysisController : Controller
    {
        private readonly IDropdownService dropdownService;
        private readonly IMonthlyProductionCostAnalysisService monthlyProductionCostAnalysisService;

        public ProductionCostAnalysisController(IDropdownService _dropdownService, IMonthlyProductionCostAnalysisService _monthlyProductionCostAnalysisService)
        {
            dropdownService = _dropdownService;
            monthlyProductionCostAnalysisService = _monthlyProductionCostAnalysisService;
        }
        public IActionResult MonthWiseSalaryAnalysis()
        {

            var model = new SalaryAnalysisDataPageViewModel();
            model.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
            model.MonthID = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            model.PeriodList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Please Select" ,Value=""},
                new SelectListItem(){Text="Monthly" ,Value="MonthLy"},
                new SelectListItem(){Text="Yearly" ,Value="Yearly"},
            };
            return View(model);
        }
        public async Task<IActionResult> MonthWiseSalaryAnalysisReportPage(int MonthID, int Year)
        {
            var model = new SalaryAnalysisDataPageViewModel();
            var DateFrom = new DateTime(Year, MonthID, 1);
            var DateTo = DateTime.Now.Month == DateFrom.Month ? DateTime.Now.AddDays(-1) : DateFrom.AddMonths(1).AddDays(-1);
            model.MonthlyProductionCostAnalysisDetails = await  monthlyProductionCostAnalysisService.GetMonthlyProductionCostAnalysisList(MonthID, Year);
            model.DateDuration = $"{DateFrom.ToString("dd-MMM-yyyy")} To {DateTo.ToString("dd-MMM-yyyy")}";
            model.MonthID = MonthID;
            model.Year = Year;
            return View(model);
        }

        public IActionResult YearlySalaryAnalysis()
        {
            var model = new SalaryAnalysisDataPageViewModel();
           // model.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
          
            model.Year = DateTime.Now.Year;
            return View(model);
        }

        public async Task<IActionResult> YearlySalaryAnalysisReportPage( int Year)
        {
            var model = new SalaryAnalysisDataPageViewModel();
            var DateFrom = new DateTime(Year, 1, 1);
           // var DateTo = DateTime.Now.Month == DateFrom.Month ? DateTime.Now.AddDays(-1) : DateFrom.AddMonths(1).AddDays(-1);
            var DateTo= new DateTime(Year, 12, 31);
           var CostAnalysisDetails = await monthlyProductionCostAnalysisService.GetYearlyWiseProductionCostAnalysisList(Year);

            var finalData = CostAnalysisDetails.GroupBy(b => new { b.YearID,b.ReportName })
                .Select(b => new MonthlyProductionCostAnalysisDetailsVM
                {
                    YearID=b.Key.YearID,
                    ReportName = b.Key.ReportName,
                    Earning = b.Sum(s=>s.Earning),
                    SalaryCost = b.Sum(s=>s.SalaryCost)

                }).ToList();
            model.MonthlyProductionCostAnalysisDetails = finalData;
            model.DateDuration = $"{DateFrom.ToString("dd-MMM-yyyy")} To {DateTo.ToString("dd-MMM-yyyy")}";
            return View(model);
        }

    }
}
