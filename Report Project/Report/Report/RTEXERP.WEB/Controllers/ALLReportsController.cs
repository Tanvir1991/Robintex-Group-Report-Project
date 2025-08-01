using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.AOP.DigitalPrintReportModel;
using RTEXERP.Contracts.BLModels.AOP.ReportModel;
using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel.BatchCosting;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.AOP;
using RTEXERP.Contracts.Interfaces.Services.CMS;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.Maxco;

namespace RTEXERP.WEB.Controllers
{
    [AllowAnonymous]
    public class ALLReportsController : Controller
    {
        private readonly IBasicCOAService basicCOAService;
        private readonly IAOPCostringService iAOPCostringService;
        private readonly IALLMMReportService iALLMMReportService;
        private readonly Itbl_Currency_DetailService itbl_Currency_DetailService;
        private readonly IOvalPrintingReportMasterService ovalPrintingReportMasterService;
        private readonly ITbl_CHirarchyService _tbl_CHirarchyService;
        private readonly IDropdownService dropdownService;
        private readonly IBuyer_SetupService buyer_SetupService;
        private readonly IStyleService styleService;
        private readonly IDepartmentSalaryForProductionService _departmentSalaryForProductionService;
        private readonly ITbl_KnittingMachinesService _tbl_KnittingMachinesService;
        private readonly IGreige_StockTransactionsService _greige_StockTransactionsService;
        private readonly IProductionLineEmployeeService _iProductionLineEmployeeService;
        private readonly IMaxcoReportService _maxcoReportService;
        private readonly ITbl_marker_short_cuttingService tbl_Marker_Short_CuttingService;
        private readonly IDFS_LotMakingMasterService dFS_LotMakingMasterService;

        public ALLReportsController(IBasicCOAService basicCOAService, IALLMMReportService iALLMMReportService, Itbl_Currency_DetailService itbl_Currency_DetailService,
            IAOPCostringService iAOPCostringService, IOvalPrintingReportMasterService ovalPrintingReportMasterService
            , ITbl_CHirarchyService tbl_CHirarchyService, IDropdownService dropdownService, IBuyer_SetupService _buyer_SetupService, IStyleService _styleService
            , IDepartmentSalaryForProductionService departmentSalaryForProductionService, ITbl_KnittingMachinesService tbl_KnittingMachinesService
            , IGreige_StockTransactionsService greige_StockTransactionsService, IProductionLineEmployeeService iProductionLineEmployeeService
            , IMaxcoReportService maxcoReportService, ITbl_marker_short_cuttingService _tbl_Marker_Short_CuttingService
            , IDFS_LotMakingMasterService _dFS_LotMakingMasterService
            )
        {
            this.basicCOAService = basicCOAService;
            this.iALLMMReportService = iALLMMReportService;
            this.itbl_Currency_DetailService = itbl_Currency_DetailService;
            this.iAOPCostringService = iAOPCostringService;
            this.ovalPrintingReportMasterService = ovalPrintingReportMasterService;
            _tbl_CHirarchyService = tbl_CHirarchyService;
            this.dropdownService = dropdownService;
            buyer_SetupService = _buyer_SetupService;
            styleService = _styleService;
            _departmentSalaryForProductionService = departmentSalaryForProductionService;
            _tbl_KnittingMachinesService = tbl_KnittingMachinesService;
            _greige_StockTransactionsService = greige_StockTransactionsService;
            _iProductionLineEmployeeService = iProductionLineEmployeeService;
            _maxcoReportService = maxcoReportService;
            tbl_Marker_Short_CuttingService = _tbl_Marker_Short_CuttingService;
            dFS_LotMakingMasterService = _dFS_LotMakingMasterService;
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
            // obj.ComPerDayTotalSalary = await _tbl_CHirarchyService.GetComptexDyeingDailySalary(8, IgnoreDpeartment, IgnoreSection, DateFrom);
            /*
            var salaryInfo = await _departmentSalaryForProductionService.GetSalary(MDReportName.BatchCosting, DateFrom, DateTo);
            int SalaryDateDuration = DateTo.Subtract(DateFrom).Days + 1;
            obj.ComPerDayTotalSalary = salaryInfo.Sum(b => b.TotalSalary);
            */
            var salaryInfo = (await _departmentSalaryForProductionService.GetSalary("Batch Costing", DateFrom, DateTo));
            obj.ComPerDayTotalSalary = salaryInfo.Sum(b => b.TotalSalary);
            return View(obj);
        }
        public async Task<IActionResult> MonthlyBatchPage()
        {
            BatchCostingMap obj = new BatchCostingMap();
            obj.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            obj.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
            obj.ddlCompany = (await basicCOAService.DDLChartOfAccounts(0, 1)).OrderByDescending(b => Convert.ToInt32(b.Value)).ToList();
            var currencyInfo = await itbl_Currency_DetailService.GetCurrencyRate(2);
            obj.CurrencyRate = Convert.ToDouble(currencyInfo.RateInPakRs.Value);
            obj.MonthID = DateTime.Now.Month;
            obj.Year = DateTime.Now.Year;
            return View(obj);
        }
        public async Task<IActionResult> MonthlyBatchReportPage(int MonthID, int Year, int? CompanyId = 0, double? CurrencyRate = 80, long? OrderID = 0)
        {
            BatchCostingMap objList = new BatchCostingMap();
            int _companyId = CompanyId.Value;
            var CompanyInfo = await basicCOAService.AccInfo(_companyId);
            //List<int> IgnoreDpeartment = new List<int> { 3, 15, 44 };
            //List<int> IgnoreSection = new List<int> { 40, 50, 368 };

            var ReportDate = new DateTime(Year, MonthID, 1);
            var ReportDateTo = DateTime.Now.Month == ReportDate.Month ? DateTime.Now.AddDays(-1) : ReportDate.AddMonths(1).AddDays(-1);
            var obj = new BatchCostingMap();
            obj = await iALLMMReportService.FULLBatchCosting(ReportDate, ReportDateTo, _companyId, 0, OrderID);
            var salaryInfo = await _departmentSalaryForProductionService.GetSalary(MDReportName.BatchCosting, ReportDate, ReportDateTo);

            var productionInfo = obj.BatchProduction
                .GroupBy(g => new { g.ReportDate })
                .Select(s => new
                {
                    ReportDate = s.Key.ReportDate,
                    FinishFabricDelQty = s.Sum(b => b.FinishFabricDelQty),
                    DyesAndChemicalCost = s.Sum(b => b.DyesCost + b.ChemicalCost),
                    Earning = s.Sum(b => b.FinishFabricDelQty * b.DyeingRate * CurrencyRate)
                });
            var SampleInfo = obj.SampleProductionCost
                .GroupBy(g => new { g.ReportDate })
                .Select(s => new
                {
                    ReportDate = s.Key.ReportDate,
                    DyesAndChemicalCost = s.Sum(b => b.DyesCost + b.ChemicalCost),

                });
            var MachineWashCost = obj.MachineWashCost
                .GroupBy(g => new { g.ReportDate })
                  .Select(s => new
                  {
                      ReportDate = s.Key.ReportDate,
                      DyesAndChemicalCost = s.Sum(b => b.DyesCost + b.ChemicalCost),

                  });
            var ShadeProductionCost = obj.ShadeProductionCost
                .GroupBy(g => new { g.ReportDate })
                .Select(s => new
                {
                    ReportDate = s.Key.ReportDate,
                    DyesAndChemicalCost = s.Sum(b => b.DyesCost + b.ChemicalCost)
                });

            var salaryMonthInfo = salaryInfo
                .GroupBy(b => new { b.SalaryDate })
                .Select(s => new
                {
                    ReportDat = s.Key.SalaryDate,
                    TotalSalary = s.Sum(b => b.TotalSalary)
                });

            var finalData = from p in productionInfo
                            join s in SampleInfo on p.ReportDate equals s.ReportDate into ps
                            from ps1 in ps.DefaultIfEmpty()
                            join sh in ShadeProductionCost on p.ReportDate equals sh.ReportDate into psh
                            from psh1 in psh.DefaultIfEmpty()
                            join mw in MachineWashCost on p.ReportDate equals mw.ReportDate into pmw
                            from pmw1 in pmw.DefaultIfEmpty()
                            join sal in salaryMonthInfo on p.ReportDate equals sal.ReportDat into psal
                            from psal1 in psal.DefaultIfEmpty()
                            orderby p.ReportDate ascending
                            select new MonthlyBatchCost
                            {
                                ReportDate = p.ReportDate,
                                ProductionQuantity = (decimal)p.FinishFabricDelQty,
                                ProductionCost = p.DyesAndChemicalCost,
                                SamplingCost = ps1 == null ? 0 : ps1.DyesAndChemicalCost,
                                MachineWashCost = pmw1 == null ? 0 : pmw1.DyesAndChemicalCost,
                                ShadeCorrectionCost = psh1 == null ? 0 : psh1.DyesAndChemicalCost,
                                Salary = psal1 == null ? 0 : psal1.TotalSalary,
                                Earning = (decimal)p.Earning
                            };
            objList.MonthlyCostSummary = finalData.ToList();
            objList.DateTo = $"Date From :{ReportDate:dd-MMM-yyyy} To {ReportDate.AddMonths(1).AddDays(-1):dd-MMM-yyyy}"; ;
            objList.CurrencyRate = CurrencyRate.Value;
            objList.CompanyName = CompanyInfo.Description;
            if (_companyId == 20183)
            {
                objList.StoreLocation = "Comptex Sub-Store";
            }
            else
            {
                objList.StoreLocation = "RobinTex Sub-Store";
            }
            /*
            for (DateTime i = ReportDate; ReportDateTo.CompareTo(i) >= 0; i = i.AddDays(1))
            {
                var obj = new BatchCostingMap();
                obj = await iALLMMReportService.FULLBatchCosting(i, i, _companyId, 0, OrderID);
                obj.DateFrom = i.ToString("dd-MMM-yyyy");
                obj.DateTo = $"Date From :{ReportDate:dd-MMM-yyyy} To {ReportDate.AddMonths(1).AddDays(-1):dd-MMM-yyyy}"; ;
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
                obj.ComPerDayTotalSalary = await _tbl_CHirarchyService.GetComptexDyeingDailySalary(8, IgnoreDpeartment, IgnoreSection, i);
                //int SalaryDateDuration = DateTo.Subtract(DateFrom).Days + 1;
                obj.ComPerDayTotalSalary = obj.ComPerDayTotalSalary; //* SalaryDateDuration;
                objList.Add(obj);
            }*/
            return View(objList);
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
            var salaryInfo = (await _departmentSalaryForProductionService.GetSalary(MDReportName.AOPCosting, DateFrom, DateTo));
            obj.AopPerDayTotalSalary = salaryInfo.Sum(b => b.TotalSalary);
            obj.DateFrom = DateFrom.ToString("dd-MMM-yyyy");
            obj.DateTo = DateTo.ToString("dd-MMM-yyyy");

            return View(obj);
        }
        public IActionResult DigitalPrintCostingReport()
        {
            AOPCostingSPData obj = new AOPCostingSPData();
            obj.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            obj.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            return View(obj);
        }
        public async Task<IActionResult> DigitalPrintCostingReportPage(DateTime DateFrom, DateTime DateTo)
        {
            DigitalPrintCostingReportModel obj = new DigitalPrintCostingReportModel();
            obj = await iAOPCostringService.DigitalPrint_Cost_Summary_Issue(DateFrom, DateTo);
            var salaryInfo = (await _departmentSalaryForProductionService.GetSalary(MDReportName.DigitalPrint, DateFrom, DateTo));
            obj.DigitalPrintPerDayTotalSalary = salaryInfo.Sum(b => b.TotalSalary);
            obj.DateFrom = DateFrom.ToString("dd-MMM-yyyy");
            obj.DateTo = DateTo.ToString("dd-MMM-yyyy");

            return View(obj);
        }

        public IActionResult MonthlyDigitalPrintCostingReport()
        {
            AOPCostingSPData model = new AOPCostingSPData();
            model.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
            model.MonthID = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            return View(model);
        }
        public async Task<IActionResult> MonthlyDigitalPrintCostingReportPage(int MonthID, int Year)
        {
            List<DigitalReportMonthlyResponseModel> objList = new List<DigitalReportMonthlyResponseModel>();
            var ReportDate = new DateTime(Year, MonthID, 1);
            var ReportDateTo = DateTime.Now.Month == ReportDate.Month ? DateTime.Now.AddDays(-1) : ReportDate.AddMonths(1).AddDays(-1);

            var salaryInfo = await _departmentSalaryForProductionService.GetSalary(MDReportName.DigitalPrint, ReportDate, ReportDateTo);

            var salaryMonthInfo = salaryInfo
              .GroupBy(b => new { b.SalaryDate })
              .Select(s => new
              {
                  ReportDate = s.Key.SalaryDate,
                  TotalSalary = s.Sum(b => b.TotalSalary)
              }).ToList();

            var costList = await iAOPCostringService.DigitalPrint_Cost_Summary_Issue(ReportDate, ReportDateTo);

            var inhouse = costList.InHouseDigitalPrintCosting
                                   .GroupBy(x => new { x.Req_Date_AC, x.Unit })
                                   .Select(s => new
                                   {
                                       Req_Date_AC = s.Key.Req_Date_AC,
                                       Unit = s.Key.Unit,
                                       ProductionQty = s.Sum(b => b.Delivered_Qty),
                                       TotalEarning = s.Sum(b => b.Total_Price_order_dol * Convert.ToDecimal(b.doller_rate)),
                                       TotalCost = s.Sum(b => b.Total_COst_BDT)
                                   }).ToList();

            var subContract = costList.SubContractDigitalPrintCosting
                .GroupBy(x => new { x.Req_Date_AC, x.Unit })
                .Select(s => new
                {
                    Req_Date_AC = s.Key.Req_Date_AC,
                    Unit = s.Key.Unit,
                    ProductionQty = s.Sum(b => b.ProcessQty),
                    TotalEarning = s.Sum(b => b.ClientRate),
                    TotalCost = s.Sum(b => b.ttlCost)
                }).ToList();

            for (DateTime i = ReportDate; ReportDateTo.CompareTo(i) >= 0; i = i.AddDays(1))
            {
                var obj = new DigitalReportMonthlyResponseModel();
                var _inhouseData = inhouse.Where(b => b.Req_Date_AC == i).FirstOrDefault();
                var _subContract = subContract.Where(b => b.Req_Date_AC == i).FirstOrDefault();

                var salary = salaryMonthInfo.Find(b => b.ReportDate == i);
                obj.DailySalary = salary == null ? 0 : salary.TotalSalary;// * SalaryDateDuration;

                obj.InhouseProductionUnit = _inhouseData == null ? "" : _inhouseData.Unit;
                obj.SubContractProductionUnit = _subContract == null ? "" : _subContract.Unit;

                obj.InHouseProduction = _inhouseData == null ? 0 : _inhouseData.ProductionQty;
                obj.SubContractProduction = _subContract == null ? 0 : _subContract.ProductionQty;

                obj.InHouseEarning = _inhouseData == null ? 0 : _inhouseData.TotalEarning;
                obj.SubContractEarning = _subContract == null ? 0 : _subContract.TotalEarning;



                obj.InHouseCost = _inhouseData == null ? 0 : _inhouseData.TotalCost;
                obj.SubContractCost = _subContract == null ? 0 : _subContract.TotalCost;

                obj.DateDuration = $"Date Duration :{ReportDate:dd-MMM-yyyy} To {ReportDateTo:dd-MMM-yyyy}";
                obj.CurrentDateSTR = $"{i:dd-MMM-yyyy}";
                obj.CurrentDate = i;
                objList.Add(obj);
            }
            return View(objList);
        }

        public IActionResult MonthlyAOPCostingReport()
        {
            AOPCostingSPData model = new AOPCostingSPData();
            model.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
            model.MonthID = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            return View(model);
        }
        public async Task<IActionResult> MonthlyAOPCostingReportPage(int MonthID, int Year)
        {
            List<AOPCostingSPData> objList = new List<AOPCostingSPData>();
            var ReportDate = new DateTime(Year, MonthID, 1);
            var ReportDateTo = DateTime.Now.Month == ReportDate.Month ? DateTime.Now.AddDays(-1) : ReportDate.AddMonths(1).AddDays(-1);

            var salaryInfo = await _departmentSalaryForProductionService.GetSalary(MDReportName.AOPCosting, ReportDate, ReportDateTo);

            var salaryMonthInfo = salaryInfo
              .GroupBy(b => new { b.SalaryDate })
              .Select(s => new
              {
                  ReportDate = s.Key.SalaryDate,
                  TotalSalary = s.Sum(b => b.TotalSalary)
              }).ToList();

            var costList = await iAOPCostringService.Aop_Cost_Summary_Issue(ReportDate, ReportDateTo);
            for (DateTime i = ReportDate; ReportDateTo.CompareTo(i) >= 0; i = i.AddDays(1))
            {
                var obj = new AOPCostingSPData();
                obj.AOPCostingReport = costList.Where(x => x.LotInspectedDate == i).ToList();
                var salary = salaryMonthInfo.Find(b => b.ReportDate == i);
                obj.AopPerDayTotalSalary = salary == null ? 0 : salary.TotalSalary;// * SalaryDateDuration;
                obj.DateFrom = $"Date From :{ReportDate:dd-MMM-yyyy} To {ReportDate.AddMonths(1).AddDays(-1):dd-MMM-yyyy}";
                obj.DateTo = $"{i:dd-MMM-yyyy}";
                objList.Add(obj);
            }
            return View(objList);
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
            ReportDateTo = ReportDateTo >= DateTime.Now.Date ? DateTime.Now.AddDays(-1) : ReportDateTo;
            try
            {
                model = await ovalPrintingReportMasterService.GetOvalPrintingInformation(ReportDate, ID, ReportDateTo);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            /*
            model.OvalPerDayTotalSalary = await _tbl_CHirarchyService.GetOvalPrintDailySalary(2, ReportDate);
            int totalFriday = _tbl_CHirarchyService.GetNumberOfSpecificeDaysInMonth(ReportDate, ReportDateTo.Value, DayOfWeek.Friday);
            int SalaryDateDuration = (ReportDateTo.Value.Subtract(ReportDate).Days + 1) - totalFriday;
            model.OvalPerDayTotalSalary = model.OvalPerDayTotalSalary * SalaryDateDuration;
            */
            var salaryInfo = (await _departmentSalaryForProductionService.GetSalary("Oval Costing", ReportDate, ReportDateTo.Value));
            model.OvalPerDayTotalSalary = salaryInfo.Sum(b => b.TotalSalary);
            return View(model);
        }
        public IActionResult MonthlyOvalPrintingReport()
        {
            OvalPrintingReportMasterViewModel model = new OvalPrintingReportMasterViewModel();
            model.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
            model.MonthID = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            return View(model);
        }
        public async Task<IActionResult> MonthlyOvalPrintingReportPage(int MonthID, int Year, int ID = 0)
        {
            List<OvalPrintingReportMasterViewModel> dataList = new List<OvalPrintingReportMasterViewModel>();
            var ReportDate = new DateTime(Year, MonthID, 1);
            var ReportDateTo = DateTime.Now.Month == ReportDate.Month ? DateTime.Now.AddDays(-1) : ReportDate.AddMonths(1).AddDays(-1);
            if (ReportDateTo == null)
            {
                ReportDateTo = ReportDate;
            }
            try
            {
                var salaryInfo = (await _departmentSalaryForProductionService.GetSalary("Oval Costing", ReportDate, ReportDateTo));
                for (DateTime i = ReportDate; ReportDateTo.CompareTo(i) >= 0; i = i.AddDays(1))
                {
                    if (i.DayOfWeek != DayOfWeek.Friday)
                    {
                        var model = await ovalPrintingReportMasterService.GetOvalPrintingInformation(i, ID, i);
                        // model.OvalPerDayTotalSalary = await _tbl_CHirarchyService.GetOvalPrintDailySalary(2, ReportDate);
                        //int SalaryDateDuration = ReportDateTo.Subtract(ReportDate).Days + 1;
                        model.OvalPerDayTotalSalary = salaryInfo.Where(b => b.SalaryDate == i).Sum(b => b.TotalSalary); // model.OvalPerDayTotalSalary; //* SalaryDateDuration;
                        model.ReportDateMsg = $"Date From :{ReportDate.ToString("dd-MMM-yyyy")} To {ReportDate.AddMonths(1).AddDays(-1).ToString("dd-MMM-yyyy")}";
                        dataList.Add(model);
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


            return View(dataList);
        }

        public IActionResult GarmentsProductionReport()
        {
            GarmentsProductionReportVM model = new GarmentsProductionReportVM();
            model.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            return View(model);
        }
        public IActionResult GarmentsProductionReportCostlyLine()
        {
            GarmentsProductionReportVM model = new GarmentsProductionReportVM();
            model.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            return View(model);
        }
        public async Task<IActionResult> GarmentsProductionReportCostlyLinePage(DateTime ReportDate, DateTime ReportDateTo)
        {
            GarmentsProductionData data = new GarmentsProductionData();
            try
            {
                var ReportData = await iALLMMReportService.GetGarmentsProductionsReportData(ReportDate, ReportDateTo, 0, 2, 0);
                data.ProductionLineEmployee = await _iProductionLineEmployeeService.GetProductionLineEmployee(ReportDate, ReportDateTo, 0);
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
        public async Task<IActionResult> GarmentsProductionReportCostlyLineEmployeeListPage(DateTime ReportDate, int LineID, int ReportFor = 0)
        {
            GarmentsProductionData data = new GarmentsProductionData();
            try
            {

                var datalist = await _iProductionLineEmployeeService.GetProductionLineEmployee(ReportDate, ReportDate, LineID);
                data.ProductionLineEmployee = datalist.OrderBy(b => b.DesignationName).ToList();
                data.DateFrom = ReportDate.ToString("dd-MMM-yyyy");
                data.ReportFor = ReportFor;
            }
            catch (Exception e)
            {
                throw new Exception("No Data Found");
            }
            return View(data);

        }

        public IActionResult GarmentsProductionReportLastCM()
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
                var ReportData = await iALLMMReportService.GetGarmentsProductionsReportData(ReportDate, ReportDateTo, 0, ReportFor, 0);

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

        public async Task<IActionResult> GarmentsProductionReportPageLastCM(DateTime ReportDate, DateTime ReportDateTo)
        {
            GarmentsProductionData data = new GarmentsProductionData();
            try
            {
                data.ReportFor = 2;
                var ReportData = await iALLMMReportService.GetGarmentsProductionsReportData(ReportDate, ReportDateTo, 0, 2, 1);

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
        public IActionResult MonthlyGarmentsProductionReport()
        {
            GarmentsProductionReportVM model = new GarmentsProductionReportVM();
            model.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
            model.MonthID = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            return View(model);
        }
        public IActionResult MonthlyGarmentsProductionReportLastCM()
        {
            GarmentsProductionReportVM model = new GarmentsProductionReportVM();
            model.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
            model.MonthID = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            return View(model);
        }
        public async Task<IActionResult> MonthlyGarmentsProductionReportPage(int MonthID, int Year, int ReportFor = 2)
        {
            GarmentsProductionData data = new GarmentsProductionData();
            try
            {
                var ReportDate = new DateTime(Year, MonthID, 1);

                var ReportDateTo = DateTime.Now.Month == ReportDate.Month ? DateTime.Now.AddDays(-1) : ReportDate.AddMonths(1).AddDays(-1);
                data.ReportFor = ReportFor;
                data.DateFrom = ReportDate.ToString("dd-MMM-yyyy");
                data.DateTo = ReportDateTo.ToString("dd-MMM-yyyy");
                var monthlyTotalProductionData = await iALLMMReportService.GetGarmentsProductionsReportData(ReportDate, ReportDateTo, 0, ReportFor);
                for (DateTime i = ReportDate; ReportDateTo.CompareTo(i) >= 0; i = i.AddDays(1))
                {
                    //if (i.DayOfWeek != DayOfWeek.Friday)
                    //{
                    var ReportData = monthlyTotalProductionData.Where(b => b.ProductionDate == i.ToString("dd-MMM-yyyy"));
                    var InhouseGarmentsProductionList = ReportData.Where(b => b.ISInhouse == 1)
                       .OrderBy(b => b.BuildingID)
                       .ThenBy(b => b.FloorID)
                       .ThenBy(b => b.LineID).ToList();

                    var LineListSummary = InhouseGarmentsProductionList.GroupBy(g => new { g.BuildingName, g.FloorName, g.LineName, g.LineSalary, g.Line_OT })
                            .Select(s => new GarmentsProductionReportSPModel
                            {

                                BuildingName = s.Key.BuildingName,
                                FloorName = s.Key.FloorName,
                                LineName = s.Key.LineName,
                                LineSalary = s.Key.LineSalary,
                                Line_OT = s.Key.Line_OT,
                                Ttl_Ok_Qty = s.Sum(b => b.Ttl_Ok_Qty),
                                TotalCMDol = s.Sum(b => b.TotalCMDol),
                                TotalCMTk = s.Sum(b => b.TotalCMTk)
                            }).ToList();

                    var SubContractGarmentsProductionList = ReportData.Where(b => b.ISInhouse == 0)
                        .OrderBy(b => b.BuildingID)
                        .ThenBy(b => b.FloorID)
                        .ThenBy(b => b.LineID).ToList();

                    var SubContractLineListSummary = SubContractGarmentsProductionList
                     .GroupBy(g => new { g.BuildingName, g.FloorName, g.LineName, g.LineSalary, g.Line_OT })
                   .Select(s => new GarmentsProductionReportSPModel
                   {

                       BuildingName = s.Key.BuildingName,
                       FloorName = s.Key.FloorName,
                       LineName = s.Key.LineName,
                       LineSalary = s.Key.LineSalary,
                       Line_OT = s.Key.Line_OT,
                       Ttl_Ok_Qty = s.Sum(b => b.Ttl_Ok_Qty),
                       TotalCMDol = s.Sum(b => b.TotalCMDol),
                       TotalCMTk = s.Sum(b => b.TotalCMTk),
                       StyleSubContractAmount = s.Sum(b => b.StyleSubContractAmount),
                       //TotalSubContractCharge = s.Sum(b => b.StyleSubContractAmount) + s.Key.LineSalary + s.Key.Line_OT,
                       //LineProfit = s.Sum(b => b.TotalCMTk) - (s.Sum(b => b.StyleSubContractAmount) + s.Key.LineSalary + s.Key.Line_OT)

                   }).ToList();

                    var inhouse = new GarmentsProductionReportSPModel()
                    {
                        ProductionDate = i.ToString("dd-MMM-yyyy"),
                        Ttl_Ok_Qty = LineListSummary.Sum(x => x.Ttl_Ok_Qty),
                        TotalCMDol = LineListSummary.Sum(x => x.TotalCMDol),
                        TotalCMTk = LineListSummary.Sum(x => x.TotalCMTk),
                        LineSalary = LineListSummary.Sum(x => x.LineSalary),
                        Line_OT = LineListSummary.Sum(x => x.Line_OT),
                        StyleSubContractAmount = 0,
                        DollerRate = (LineListSummary != null && LineListSummary.Count>0) ? LineListSummary[0].DollerRate : 0
                    };
                    var subContact = new GarmentsProductionReportSPModel()
                    {
                        ProductionDate = i.ToString("dd-MMM-yyyy"),
                        Ttl_Ok_Qty = SubContractLineListSummary.Sum(x => x.Ttl_Ok_Qty),
                        TotalCMDol = SubContractLineListSummary.Sum(x => x.TotalCMDol),
                        TotalCMTk = SubContractLineListSummary.Sum(x => x.TotalCMTk),
                        LineSalary = SubContractLineListSummary.Sum(x => x.LineSalary),
                        Line_OT = SubContractLineListSummary.Sum(x => x.Line_OT),
                        StyleSubContractAmount = SubContractLineListSummary.Sum(x => x.StyleSubContractAmount),
                    };

                    data.InhouseGarmentsProductionList.Add(inhouse);
                    data.SubContractGarmentsProductionList.Add(subContact);
                    //}
                }

            }
            catch (Exception e)
            {
                throw new Exception("No Data Found");
            }

            return View(data);
        }
        public async Task<IActionResult> MonthlyGarmentsProductionReportPageLastCM(int MonthID, int Year)
        {
            GarmentsProductionData data = new GarmentsProductionData();
            try
            {
                var ReportDate = new DateTime(Year, MonthID, 1);

                var ReportDateTo = DateTime.Now.Month == ReportDate.Month ? DateTime.Now.AddDays(-1) : ReportDate.AddMonths(1).AddDays(-1);
                data.ReportFor = 2;
                data.DateFrom = ReportDate.ToString("dd-MMM-yyyy");
                data.DateTo = ReportDateTo.ToString("dd-MMM-yyyy");
                var monthlyTotalProductionData = await iALLMMReportService.GetGarmentsProductionsReportData(ReportDate, ReportDateTo, 0, 2, 1);
                for (DateTime i = ReportDate; ReportDateTo.CompareTo(i) >= 0; i = i.AddDays(1))
                {
                    //if (i.DayOfWeek != DayOfWeek.Friday)
                    //{
                    var ReportData = monthlyTotalProductionData.Where(b => b.ProductionDate == i.ToString("dd-MMM-yyyy"));
                    var InhouseGarmentsProductionList = ReportData.Where(b => b.ISInhouse == 1)
                       .OrderBy(b => b.BuildingID)
                       .ThenBy(b => b.FloorID)
                       .ThenBy(b => b.LineID).ToList();

                    var LineListSummary = InhouseGarmentsProductionList.GroupBy(g => new { g.BuildingName, g.FloorName, g.LineName, g.LineSalary, g.Line_OT })
                            .Select(s => new GarmentsProductionReportSPModel
                            {

                                BuildingName = s.Key.BuildingName,
                                FloorName = s.Key.FloorName,
                                LineName = s.Key.LineName,
                                LineSalary = s.Key.LineSalary,
                                Line_OT = s.Key.Line_OT,
                                Ttl_Ok_Qty = s.Sum(b => b.Ttl_Ok_Qty),
                                TotalCMDol = s.Sum(b => b.TotalCMDol),
                                TotalCMTk = s.Sum(b => b.TotalCMTk)
                            }).ToList();

                    var SubContractGarmentsProductionList = ReportData.Where(b => b.ISInhouse == 0)
                        .OrderBy(b => b.BuildingID)
                        .ThenBy(b => b.FloorID)
                        .ThenBy(b => b.LineID).ToList();

                    var SubContractLineListSummary = SubContractGarmentsProductionList
                     .GroupBy(g => new { g.BuildingName, g.FloorName, g.LineName, g.LineSalary, g.Line_OT })
                   .Select(s => new GarmentsProductionReportSPModel
                   {

                       BuildingName = s.Key.BuildingName,
                       FloorName = s.Key.FloorName,
                       LineName = s.Key.LineName,
                       LineSalary = s.Key.LineSalary,
                       Line_OT = s.Key.Line_OT,
                       Ttl_Ok_Qty = s.Sum(b => b.Ttl_Ok_Qty),
                       TotalCMDol = s.Sum(b => b.TotalCMDol),
                       TotalCMTk = s.Sum(b => b.TotalCMTk),
                       StyleSubContractAmount = s.Sum(b => b.StyleSubContractAmount),
                       //TotalSubContractCharge = s.Sum(b => b.StyleSubContractAmount) + s.Key.LineSalary + s.Key.Line_OT,
                       //LineProfit = s.Sum(b => b.TotalCMTk) - (s.Sum(b => b.StyleSubContractAmount) + s.Key.LineSalary + s.Key.Line_OT)

                   }).ToList();

                    var inhouse = new GarmentsProductionReportSPModel()
                    {
                        ProductionDate = i.ToString("dd-MMM-yyyy"),
                        Ttl_Ok_Qty = LineListSummary.Sum(x => x.Ttl_Ok_Qty),
                        TotalCMDol = LineListSummary.Sum(x => x.TotalCMDol),
                        TotalCMTk = LineListSummary.Sum(x => x.TotalCMTk),
                        LineSalary = LineListSummary.Sum(x => x.LineSalary),
                        Line_OT = LineListSummary.Sum(x => x.Line_OT),
                        StyleSubContractAmount = 0,
                        DollerRate = (LineListSummary != null && LineListSummary.Count > 0) ? LineListSummary[0].DollerRate : 0 
                        // LineListSummary[0].DollerRate
                       
                    };
                    var subContact = new GarmentsProductionReportSPModel()
                    {
                        ProductionDate = i.ToString("dd-MMM-yyyy"),
                        Ttl_Ok_Qty = SubContractLineListSummary.Sum(x => x.Ttl_Ok_Qty),
                        TotalCMDol = SubContractLineListSummary.Sum(x => x.TotalCMDol),
                        TotalCMTk = SubContractLineListSummary.Sum(x => x.TotalCMTk),
                        LineSalary = SubContractLineListSummary.Sum(x => x.LineSalary),
                        Line_OT = SubContractLineListSummary.Sum(x => x.Line_OT),
                        StyleSubContractAmount = SubContractLineListSummary.Sum(x => x.StyleSubContractAmount),
                    };

                    data.InhouseGarmentsProductionList.Add(inhouse);
                    data.SubContractGarmentsProductionList.Add(subContact);
                    //}
                }

            }
            catch (Exception e)
            {
                throw new Exception("No Data Found");
            }

            return View(data);
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

        public async Task<IActionResult> KnittingProductionReportPage(DateTime DateFrom, DateTime DateTo, int CompanyID = 0, int MachineID = -1)
        {
            KnittingProductionReportDataPageModel model = new KnittingProductionReportDataPageModel();
            model.ReportDataList = await _greige_StockTransactionsService.GetKnittingProduction(DateFrom, DateTo, CompanyID, MachineID);
            var salaryInfo = (await _departmentSalaryForProductionService.GetSalary("Knitting", DateFrom, DateTo));
            model.Salary = Convert.ToDouble(salaryInfo.Sum(b => b.TotalSalary));
            model.DateDuration = $"Date Duration {DateFrom.ToString("dd-MMM-yyyy")} To {DateTo.ToString("dd-MMM-yyyy")} ";
            model.DateFrom = DateFrom.ToString("dd-MMM-yyyy");
            model.DateTo = DateTo.ToString("dd-MMM-yyyy");
            if (CompanyID == 0)
            {
                model.CompanyName = "All Company";
            }
            else if (CompanyID == 183)
            {
                model.CompanyName = "Robintex (Bangladesh) Limited";
            }
            else
            {
                model.CompanyName = "Comptex Bangladesh Limited";
            }
            return View(model);
        }

        public async Task<IActionResult> MachineProductionRollReportPage(DateTime DateFrom, DateTime DateTo, int MachineID = 0)
        {
            MachineProductionRollReportDataPageModel model = new MachineProductionRollReportDataPageModel();
            model.MachineProductionRoll = await _greige_StockTransactionsService.GetMachineProductionRollDetails(DateFrom, DateTo, MachineID);
            model.DateDuration = $"Date Duration {DateFrom.ToString("dd-MMM-yyyy")} To {DateTo.ToString("dd-MMM-yyyy")} ";
            return View(model);
        }

        public async Task<IActionResult> OrderKnittingProductionReportPage(long OrderID)
        {
            OrderKnittingProductionReportPageModel model = new OrderKnittingProductionReportPageModel();
            var orderKnittingProduction = await _greige_StockTransactionsService.GetOrderKnittingProduction(OrderID);
            var knittingFabricList = orderKnittingProduction.GroupBy(g => new { g.FABID })
                .Select(s => new
                {
                    FABID = s.Key.FABID,
                    KnittingDone = s.Sum(b => b.Quantity),
                    //KnittingQunatity = s.Sum(b => b.KnittingQunatity),
                    //KnittingQunatityWithWastage = s.Sum(b => b.KnittingQunatityWithWastage)

                }).ToList();
            var orderKnittingFabriclist = new List<OrderKnittingFabricDataModel>();
            foreach (var item in knittingFabricList)
            {
                var orderKnittingProductionobj = orderKnittingProduction.First(b => b.FABID == item.FABID);
                var obj = new OrderKnittingFabricDataModel();
                obj.FabricType = orderKnittingProductionobj.FabricType;
                obj.FabricQuality = orderKnittingProductionobj.FabricQuality;
                obj.FabricComposition = orderKnittingProductionobj.FabricComposition;
                obj.KnittingQunatity = orderKnittingProductionobj.KnittingQunatity;
                obj.KnittingDone = item.KnittingDone;
                obj.KnittingQunatityWithWastage = orderKnittingProductionobj.KnittingQunatityWithWastage;
                orderKnittingFabriclist.Add(obj);
            }
            model.OrderKnittingFabric = orderKnittingFabriclist;
            model.OrderKnittingProduction = orderKnittingProduction;
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

        public async Task<IActionResult> MonthlyKnittingProductionReportPage(int MonthID, int Year, int CompanyID = 0, int MachineID = -1)
        {
            MonthlyKnittingProductionReportPageViewModel model = new MonthlyKnittingProductionReportPageViewModel();
            var DateFrom = new DateTime(Year, MonthID, 1);
            var DateTo = DateTime.Now.Month == DateFrom.Month ? DateTime.Now.AddDays(-1) : DateFrom.AddMonths(1).AddDays(-1);

            var ReportDataList = await _greige_StockTransactionsService.GetKnittingProduction(DateFrom, DateTo, CompanyID, MachineID);
            var salaryInfo = (await _departmentSalaryForProductionService.GetSalary("Knitting", DateFrom, DateTo));

            var salaryMonthInfo = salaryInfo
               .GroupBy(b => new { b.SalaryDate })
               .Select(s => new
               {
                   ReportDate = s.Key.SalaryDate,
                   TotalSalary = s.Sum(b => b.TotalSalary)
               });

            var finalData = ReportDataList
               .GroupBy(b => new { b.TransactionDate, b.Companyname, b.CompanyID })
               .Select(s => new
               {
                   ReportDate = s.Key.TransactionDate,
                   CompanyName = s.Key.Companyname,
                   CompanyID = s.Key.CompanyID,
                   TotalShiftA = s.Sum(b => b.ShiftA),
                   TotalShiftB = s.Sum(b => b.ShiftB),
                   TotalShiftC = s.Sum(b => b.ShiftC),
                   TotalQuantity = s.Sum(b => b.TotalQuantity),
                   TotalValue = s.Sum(b => b.QuantityValue)
               });

            var calculationQuery = from fd in finalData
                                   join s in salaryMonthInfo on fd.ReportDate equals s.ReportDate into fdWithSalary
                                   from fds in fdWithSalary.DefaultIfEmpty()
                                   orderby fd.ReportDate ascending
                                   select new MonthlyKnittingProductionReportData
                                   {
                                       ReportDate = fd.ReportDate,
                                       CompanyName = fd.CompanyID == 183 ? "Robintex" : "Comptex",
                                       CompanyID = fd.CompanyID,
                                       ReportDateSTR = fd.ReportDate.ToString("dd-MMM-yyyy"),
                                       ShiftAProduction = fd.TotalShiftA,
                                       ShiftBProduction = fd.TotalShiftB,
                                       ShiftCProduction = fd.TotalShiftC,
                                       TotalProduction = fd.TotalQuantity,
                                       TotalEarning = fd.TotalValue,
                                       Rate = fd.TotalValue / fd.TotalQuantity,
                                       DailySalary = fds == null ? 0 : Convert.ToDouble(fds.TotalSalary),
                                   };
            model.ReportDataList = calculationQuery.ToList();
            model.DateDuration = $"{DateFrom.ToString("dd-MMM-yyyy")} To {DateTo.ToString("dd-MMM-yyyy")}";

            return View(model);
        }

        public IActionResult CuttingProductionReport()
        {
            CuttingProductionReportViewModel model = new CuttingProductionReportViewModel();
            model.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            //model.DDLCompany = dropdownService.RenderDDL((await basicCOAService.DDLChartOfAccounts(0, 1)).OrderByDescending(b => Convert.ToInt32(b.Value)).ToList(), true);

            return View(model);
        }
        public async Task<IActionResult> CuttingProductionReportPage(DateTime DateFrom, DateTime DateTo, int CompanyID = 0)
        {
            CuttingProductionReportPageMasterViewModel model = new CuttingProductionReportPageMasterViewModel();
            model = await tbl_Marker_Short_CuttingService.GetCuttingProductionReportData(DateFrom, DateTo);
            var salaryInfo = (await _departmentSalaryForProductionService.GetSalary(MDReportName.CuttingCosting, DateFrom, DateTo));
            model.TotalSalary = salaryInfo.Sum(b => b.TotalSalary);
            model.CostPerPiece = model.TotalCuttingQty > 0 ? model.TotalSalary / model.TotalCuttingQty : 0;
            return View(model);
        }
        public IActionResult MonthlyCuttingProductionReport()
        {
            MonthlyCuttingProductionReportViewModel model = new MonthlyCuttingProductionReportViewModel();
            model.DDLMonthList = Enumerable.Range(1, 12).Select(i => new SelectListItem() { Value = i.ToString(), Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) }).ToList();
            model.DDLYearList = dropdownService.NumberDDL(DateTime.Now.Year - 1, DateTime.Now.Year, false, DateTime.Now.Year).OrderByDescending(x => x.Value).ToList();
            model.MonthID = DateTime.Now.Month;
            model.Year = DateTime.Now.Year;
            return View(model);
        }
        public async Task<IActionResult> MonthlyCuttingProductionReportPage(int MonthID, int Year)
        { 
            List<MonthlyCuttingProductionResponseModel> objList = new List<MonthlyCuttingProductionResponseModel>();
            var ReportDate = new DateTime(Year, MonthID, 1);
            var ReportDateTo = DateTime.Now.Month == ReportDate.Month ? DateTime.Now.AddDays(-1) : ReportDate.AddMonths(1).AddDays(-1);

            var salaryInfo = await _departmentSalaryForProductionService.GetSalary(MDReportName.CuttingCosting, ReportDate, ReportDateTo);

            var salaryMonthInfo = salaryInfo
              .GroupBy(b => new { b.SalaryDate })
              .Select(s => new
              {
                  ReportDate = s.Key.SalaryDate,
                  TotalSalary = s.Sum(b => b.TotalSalary)
              }).ToList();

            var datamodel = await tbl_Marker_Short_CuttingService.GetDailyCompanyWiseCuttingQty(ReportDate, ReportDateTo);
            for (DateTime i = ReportDate; ReportDateTo.CompareTo(i) >= 0; i = i.AddDays(1))
            {
                var dailyObject = new MonthlyCuttingProductionResponseModel();
                var rbldata = datamodel.Where(b => b.ProductionDate == i && b.CompanyShortName == "rbl").FirstOrDefault();
                var cbldata = datamodel.Where(b => b.ProductionDate == i && b.CompanyShortName == "cbl").FirstOrDefault();
                var dailySalary = salaryMonthInfo.Where(b => b.ReportDate == i).FirstOrDefault();

                dailyObject.CurrentDateSTR = i.ToString("dd-MMM-yyyy");
                dailyObject.CurrentDate = i;
                dailyObject.RBLCuttingQty = rbldata == null ? 0 : rbldata.CuttingQuantity;
                dailyObject.RBLInspectionQty = rbldata == null ? 0 : rbldata.InspectionQuantity;
                dailyObject.RBLPassQty = rbldata == null ? 0 : rbldata.PassQuantity;

                dailyObject.CBLCuttingQty = cbldata == null ? 0 : cbldata.CuttingQuantity;
                dailyObject.CBLInspectionQty = cbldata == null ? 0 : cbldata.InspectionQuantity;
                dailyObject.CBLPassQty = cbldata == null ? 0 : cbldata.PassQuantity;

                dailyObject.DailySalary = dailySalary == null ? 0 : dailySalary.TotalSalary;
                objList.Add(dailyObject);
            }
            
            return View(objList);
        }
      
        #region json Data 
        public async Task<JsonResult> GetBatchCosting(DateTime DateFrom, DateTime DateTo, int CompanyId)
        {
            RResult rResult = new RResult();
            var list = await iALLMMReportService.FULLBatchCosting(DateFrom, DateTo, CompanyId, 0, 0);
            rResult.data = list;

            return Json(rResult);
        }

        public async Task<JsonResult> GetOSVersionDifference(int OrderID)
        {
            var data = await _maxcoReportService.GetOSVersionDifferenceInfo(OrderID, 0);

            return Json(data);

        }
        public async Task<JsonResult> GetOrderWiseLotRequisitionList(int OrderID)
        {
            var data = await dFS_LotMakingMasterService.GetOrderWiseLotRequisitionList(OrderID);
            return Json(data);
        }
        #endregion
    }
}