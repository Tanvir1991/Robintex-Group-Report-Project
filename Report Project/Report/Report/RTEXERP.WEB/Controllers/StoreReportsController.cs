using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.AOP.ReportModel;
using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.Maxco.SPModel.BatchCosting;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.AOP;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Controllers
{
    public class StoreReportsController : BaseController
    {
        private readonly IBasicCOAService basicCOAService;
        private readonly IAOPCostringService iAOPCostringService;
        private readonly IALLMMReportService iALLMMReportService;
        private readonly Itbl_Currency_DetailService itbl_Currency_DetailService;
        private readonly IOvalPrintingReportMasterService ovalPrintingReportMasterService;
        private readonly ITbl_CHirarchyService _tbl_CHirarchyService;
        private readonly IDropdownService dropdownService;

        public StoreReportsController(IBasicCOAService basicCOAService, IALLMMReportService iALLMMReportService, Itbl_Currency_DetailService itbl_Currency_DetailService,
            IAOPCostringService iAOPCostringService, IOvalPrintingReportMasterService ovalPrintingReportMasterService
            , ITbl_CHirarchyService tbl_CHirarchyService,
            IDropdownService _dropdownService)
        {
            this.basicCOAService = basicCOAService;
            this.iALLMMReportService = iALLMMReportService;
            this.itbl_Currency_DetailService = itbl_Currency_DetailService;
            this.iAOPCostringService = iAOPCostringService;
            this.ovalPrintingReportMasterService = ovalPrintingReportMasterService;
            _tbl_CHirarchyService = tbl_CHirarchyService;
            dropdownService = _dropdownService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> BatchPage()
        {
            BatchCostingMap obj = new BatchCostingMap();
            obj.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            obj.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            obj.ddlCompany = (await basicCOAService.DDLChartOfAccounts(0, 1)).OrderByDescending(b => Convert.ToInt32(b.Value)).ToList();
            var currencyInfo = await itbl_Currency_DetailService.GetCurrencyRate(2);
            obj.CurrencyRate = Convert.ToDouble(currencyInfo.RateInPakRs.Value);
            return View(obj);
        }
        public async Task<IActionResult> BatchReportPage(DateTime DateFrom, DateTime DateTo, int? CompanyId = 0, double? CurrencyRate = 80, long? OrderID = 0)
        {
            BatchCostingMap obj = new BatchCostingMap();
            int _companyId = CompanyId.Value;
            var CompanyInfo = await basicCOAService.AccInfo(_companyId);
            List<int> IgnoreDpeartment = new List<int> { 3, 15, 44 };
            List<int> IgnoreSection = new List<int> { 40, 50, 368 };



            obj = await iALLMMReportService.FULLBatchCosting(DateFrom, DateTo, _companyId, 0, OrderID);
            obj.DateFrom = DateFrom.ToString("dd-MMM-yyyy");
            obj.DateTo = DateTo.ToString("dd-MMM-yyyy");
            obj.CurrencyRate = CurrencyRate.Value;
            obj.CompanyName = CompanyInfo.Description;
            if (_companyId == 20183)
            {
                obj.StoreLocation = "Comptex Sub-Store";
            }
            else
            {
                obj.StoreLocation = "RobinTex Sub-Store";
            }
            obj.ComPerDayTotalSalary = await _tbl_CHirarchyService.GetComptexDyeingDailySalary(8, IgnoreDpeartment, IgnoreSection, DateFrom);
            int SalaryDateDuration = DateTo.Subtract(DateFrom).Days + 1;
            obj.ComPerDayTotalSalary = obj.ComPerDayTotalSalary * SalaryDateDuration;
            return View(obj);
        }
        public IActionResult AOPCostingReport()
        {
            AOPCostingSPData obj = new AOPCostingSPData();
            obj.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            obj.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            return View(obj);
        }
        public async Task<IActionResult> AOPCostingReportPage(DateTime DateFrom, DateTime DateTo)
        {
            AOPCostingSPData obj = new AOPCostingSPData();

            obj.AOPCostingReport = await iAOPCostringService.Aop_Cost_Summary_Issue(DateFrom, DateTo);
            //obj.AOPList = obj.AOPCostingReport.Where(b => b.LotType == "AOP").ToList();
            //obj.CPBList = obj.AOPCostingReport.Where(b => b.LotType == "CPB").ToList();
            obj.AopPerDayTotalSalary = await _tbl_CHirarchyService.GetAOPDailySalary(11, DateFrom);
            int SalaryDateDuration = DateTo.Subtract(DateFrom).Days + 1;
            obj.AopPerDayTotalSalary = obj.AopPerDayTotalSalary * SalaryDateDuration;
            obj.DateFrom = DateFrom.ToString("dd-MMM-yyyy");
            obj.DateTo = DateTo.ToString("dd-MMM-yyyy");

            return View(obj);
        }

        public IActionResult OvalPrintingReport()
        {
            OvalPrintingReportMasterViewModel model = new OvalPrintingReportMasterViewModel();
            model.ReportDateMsg = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            model.ReportDateToMsg = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            return View(model);
        }
        public async Task<IActionResult> OvalPrintingReportPage(DateTime ReportDate, int ID = 0, DateTime? ReportDateTo = null)
        {
            OvalPrintingReportMasterViewModel model = new OvalPrintingReportMasterViewModel();
            if (ReportDateTo == null || ReportDateTo.HasValue == false)
            {
                ReportDateTo = ReportDate;
            }
            try
            {
                model = await ovalPrintingReportMasterService.GetOvalPrintingInformation(ReportDate, ID, ReportDateTo);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            model.OvalPerDayTotalSalary = await _tbl_CHirarchyService.GetOvalPrintDailySalary(2, ReportDate);
            int SalaryDateDuration = ReportDateTo.Value.Subtract(ReportDate).Days + 1;
            model.OvalPerDayTotalSalary = model.OvalPerDayTotalSalary * SalaryDateDuration;

            return View(model);
        }

        public IActionResult GarmentsProductionReport()
        {
            GarmentsProductionReportVM model = new GarmentsProductionReportVM();
            model.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            return View(model);
        }
        public async Task<IActionResult> GarmentsProductionReportPage(DateTime ReportDate, DateTime ReportDateTo, int ReportFor = 2)
        {
            GarmentsProductionData data = new GarmentsProductionData();
            try
            {
                data.ReportFor = ReportFor;
                var ReportData = await iALLMMReportService.GetGarmentsProductionsReportData(ReportDate, ReportDateTo, 0, ReportFor);

                data.DateFrom = ReportDate.ToString("dd-MMM-yyyy");
                data.DateTo = ReportDateTo.ToString("dd-MMM-yyyy");
                data.InhouseGarmentsProductionList = ReportData.Where(b => b.ISInhouse == 1)
                   .OrderBy(b => b.BuildingID)
                   .ThenBy(b => b.FloorID)
                   .ThenBy(b => b.LineID).ToList();

                data.SubContractGarmentsProductionList = ReportData.Where(b => b.ISInhouse == 0)
                    .OrderBy(b => b.BuildingID)
                    .ThenBy(b => b.FloorID)
                    .ThenBy(b => b.LineID).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("No Data Found");
            }
            return View(data);
        }

        public async Task<IActionResult> BatchPageVPUser()
        {
            BatchCostingMap obj = new BatchCostingMap();
            obj.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            obj.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            obj.ddlCompany = (await basicCOAService.DDLChartOfAccounts(0, 1)).OrderByDescending(b => Convert.ToInt32(b.Value)).ToList();
            var currencyInfo = await itbl_Currency_DetailService.GetCurrencyRate(2);
            obj.CurrencyRate = Convert.ToDouble(currencyInfo.RateInPakRs.Value);
            return View(obj);
        }

        public IActionResult AOPCostingReportVPUser()
        {
            AOPCostingSPData obj = new AOPCostingSPData();
            obj.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            obj.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            return View(obj);
        }

        public IActionResult OvalPrintingReportVPUser()
        {
            OvalPrintingReportMasterViewModel model = new OvalPrintingReportMasterViewModel();
            model.ReportDateMsg = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            model.ReportDateToMsg = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            return View(model);
        }
        public IActionResult GarmentsProductionReportVPUser()
        {
            GarmentsProductionReportVM model = new GarmentsProductionReportVM();
            model.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            return View(model);
        }

        public async Task<IActionResult> KnittingProductionReport()
        {
            KnittingProductionReportPageModel model = new KnittingProductionReportPageModel();
            model.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            model.DDLMachineCompany = dropdownService.RenderDDL((await basicCOAService.DDLChartOfAccounts(0, 1)).OrderByDescending(b => Convert.ToInt32(b.Value)).ToList(), true);
            model.DDLMachine = dropdownService.DefaultDDL();
            model.DDLMachine[0].Value = "-1";
            return View(model);
        }

        public IActionResult MonthlyKnittingProductionReport()
        {
            MonthlyKnittingProductionReportDataPageModel model = new MonthlyKnittingProductionReportDataPageModel();
            model.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
            model.MonthID = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            return View(model);
        }
    }
}
