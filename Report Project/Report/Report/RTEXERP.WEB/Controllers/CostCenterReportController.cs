using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using RTEXERP.Common.Constants;
using RTEXERP.Common.DataInterChange;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.Materials;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.Contracts.Interfaces.Services.Materials;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using SSRSReport.Library;

namespace RTEXERP.WEB.Controllers
{
    public class CostCenterReportController : BaseController
    {
        private readonly IALLMMReportService aLLMMReportService;
        private readonly IUserAccessInfoService userAccessInfoService;
        private readonly IDropdownService dropdownService;
        private readonly ILotNoService lotNoService;
        private readonly IMaxcoDDLService maxcoDDLService;
        private readonly IYarnBalanceService yarnBalanceService;
        private readonly IBasicCOAService basicCOAService;
        private readonly IMM_MRPItemService mM_MRPItemService;
        private readonly IYarnReportService yarnReportService;
        public readonly IBuyer_SetupService buyer_SetupService;
        public CostCenterReportController(IALLMMReportService aLLMMReportService, IUserAccessInfoService userAccessInfoService, IDropdownService dropdownService, ILotNoService lotNoService
            , IMaxcoDDLService maxcoDDLService, IYarnBalanceService yarnBalanceService, IBasicCOAService basicCOAService, IMM_MRPItemService mM_MRPItemService
            , IYarnReportService yarnReportService, IBuyer_SetupService buyer_SetupService)
        {
            this.aLLMMReportService = aLLMMReportService;
            this.userAccessInfoService = userAccessInfoService;
            this.dropdownService = dropdownService;
            this.lotNoService = lotNoService;
            this.maxcoDDLService = maxcoDDLService;
            this.yarnBalanceService = yarnBalanceService;
            this.basicCOAService = basicCOAService;
            this.mM_MRPItemService = mM_MRPItemService;
            this.yarnReportService = yarnReportService;
            this.buyer_SetupService = buyer_SetupService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BankPaymentVoucher()
        {
            // ViewData["defaultData"] = dropdownService.DefaultDDL();

            ViewBag.defaultData = dropdownService.DefaultDDL();
            return View();
        }
        public async Task<IActionResult> GetBankPaymentVoucher(DateTime DateFrom, DateTime DateTo, int ComapnyId, int CostCenterId, int ActivityId, string VoucherType, string ReportFormat)
        {
            var report = new CallSSRSReport();
            int BusinessTypeId = new DataInterChangeMap().CompanyWiseDefaultBusinessType(ComapnyId); ;
            string reportName = "BankPaymentVoucher";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DateFrom", DateFrom.ToString("dd-MMM-yyyy"));
            parameters.Add("DateTo", DateTo.ToString("dd-MMM-yyyy"));
            parameters.Add("ComapnyId", ComapnyId.ToString());
            parameters.Add("BusinessTypeId", BusinessTypeId.ToString());
            parameters.Add("CostCenterId", CostCenterId.ToString());
            parameters.Add("ActivityId", ActivityId.ToString());
            parameters.Add("VoucherType", VoucherType);

            //    parameters = null;
            //    byte[] reportContent = await report.RenderReport(reportName, parameters, languageCode, ReportFormat);
            // ReportExportFormat.ExcelFormat
            return await PrintSSRSReport(reportName, parameters, ReportFormat);

        }
        public async Task<JsonResult> getBlanceLotYarn(DateTime DateFrom, DateTime DateTo)
        {
            var nDDlist = new List<SelectListItem>();
            nDDlist.Add(new SelectListItem { Text = "Please Select", Value = "" });
            var nDBList = await lotNoService.DDLLotList(DateFrom, DateTo);
            nDDlist.AddRange(nDBList);
            return Json(nDDlist);

        }
        public async Task<JsonResult> getDDLYarnCount(int CompositionId)
        {
            var nDDlist = new List<SelectListItem>();
            nDDlist.Add(new SelectListItem { Text = "Please Select", Value = "" });
            var nDBList = await maxcoDDLService.DDLYarnCount(CompositionId);
            nDDlist.AddRange(nDBList);
            return Json(nDDlist);

        }
        public IActionResult BalanceYarnList()
        {
            YarnLotNo yrn = new YarnLotNo();
            yrn.DDLReportType = new CommonDropDown().YarnStockReportTYpe();
            yrn.DDlLotNo = dropdownService.DefaultDDL();
            return View(yrn);
        }
        public async Task<IActionResult> BlanceYrnLotReport(string lotNo, DateTime? DateFrom, DateTime? DateTo, string ReportFormat)
        {

            string reportName = "BlanceYrnLotReport";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            if (DateFrom.HasValue == false)
            {
                DateFrom = DateTime.Now;
            }
            if (DateTo.HasValue == false)
            {
                DateTo = DateTime.Now;
            }

            parameters.Add("LotNo", lotNo);
            parameters.Add("DateFrom", DateFrom.Value.ToString("dd-MMM-yyyy"));
            parameters.Add("DateTo", DateTo.Value.ToString("dd-MMM-yyyy"));


            int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        public async Task<JsonResult> GetYarnStock(DateTime DateFrom, DateTime DateTo, int WithAllTransaction)
        {
            var stockList = await yarnReportService.GetYarnStock(DateFrom, DateTo, WithAllTransaction);
            return Json(stockList);
        }
        public async Task<IActionResult> GetYarnStockReport(DateTime? DateFrom, DateTime? DateTo, int WithAllTransaction, int ShowEmptyClosing, string ReportFormat)
        {

            string reportName = "GetYarnStock";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            if (DateFrom.HasValue == false)
            {
                DateFrom = DateTime.Now;
            }
            if (DateTo.HasValue == false)
            {
                DateTo = DateTime.Now;
            }
            parameters.Add("DateFrom", DateFrom.Value.ToString("dd-MMM-yyyy"));
            parameters.Add("DateTo", DateTo.Value.ToString("dd-MMM-yyyy"));
            parameters.Add("WithAllTransaction", WithAllTransaction);
            parameters.Add("ShowEmptyClosing", ShowEmptyClosing);

            int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        public async Task<IActionResult> YarnBalanceSummary()
        {
            YarnLotNo yrn = new YarnLotNo();
            yrn.DDlLotNo = dropdownService.DefaultDDL();
            var yarnComposition = await maxcoDDLService.DDLYarnComposition();
            yrn.DDLYarnCompositionList = dropdownService.RenderDDL(yarnComposition, true);
            yrn.DDLYarnCountList = dropdownService.RenderDDL(await maxcoDDLService.DDLYarnCountValue(0), true);
            return View(yrn);
        }

        public async Task<JsonResult> YarnLotBalanceSummaryByCountComposition(string LotNo, DateTime? DateFrom, DateTime? DateTo, string YarnCountId, int? YarnCompositionId, int IsDetails = 0)
        {
            RResult rResult = new RResult();
            var _LotNo = LotNo == null ? string.Empty : LotNo;
            YarnCountId = YarnCountId == null ? string.Empty : YarnCountId;
            var list = await yarnBalanceService.YarnLotBalanceSummaryByCountComposition(_LotNo, DateFrom, DateTo, YarnCountId, YarnCompositionId, IsDetails);
            rResult.data = list;
            return Json(rResult);
        }

        public async Task<IActionResult> YarnLotBalanceSummaryByCountCompositionReport(string LotNo, DateTime? DateFrom, DateTime? DateTo, int? YarnCountId, int? YarnCompositionId, int IsDetails = 0, string ReportFormat = "PDF")
        {
            var report = new CallSSRSReport();
            string reportName = "";
            if (IsDetails == 0)
            {
                reportName = "YarnBalanceSummaryByCountComposition";
            }
            else
            {
                reportName = "SubDetails_YarnBalanceSummaryByCountComposition";
            }


            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("LotNo", LotNo);
            parameters.Add("DateFrom", DateFrom.Value.ToString("dd-MMM-yyyy"));
            parameters.Add("DateTo", DateTo.Value.ToString("dd-MMM-yyyy"));
            parameters.Add("YarnCountId", YarnCountId.ToString());
            parameters.Add("YarnCompositionId", YarnCompositionId.ToString());
            parameters.Add("IsDetails", IsDetails.ToString());


            //    parameters = null;
            //    byte[] reportContent = await report.RenderReport(reportName, parameters, languageCode, ReportFormat);
            // ReportExportFormat.ExcelFormat
            return await PrintSSRSReport(reportName, parameters, ReportFormat);

        }

        public async Task<IActionResult> LCDocumentsPrint()
        {
            LC_CM_CASH_MASTERViewModel model = new LC_CM_CASH_MASTERViewModel();
            model.DDLLCNoList = await maxcoDDLService.DDLLCNoList();
            return View(model);
        }
        public async Task<IActionResult> LCFormNo_MF_FX_13(string LCM_CODE, string ReportFormat)
        {

            string reportName = "ApplicationAndAgreementIrrevocable_FormFx13";

            IDictionary<string, object> parameters = new Dictionary<string, object>();


            parameters.Add("LCM_CODE", LCM_CODE);
            parameters.Add("RptType", "0");

            int connectionString = (int)enum_ServerType.MaxcoConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        public async Task<IActionResult> LCFormNo_MF_FX_20_Orginal(string LCM_CODE, string ReportFormat)
        {

            string reportName = "LCAuthorisationForIndustrialConsumersFormNo_FX20_2";

            IDictionary<string, object> parameters = new Dictionary<string, object>();


            parameters.Add("LCM_CODE", LCM_CODE);
            parameters.Add("RptType", "0");

            int connectionString = (int)enum_ServerType.MaxcoConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        public async Task<IActionResult> LCFormNo_MF_FX_20_Duplicate(string LCM_CODE, string ReportFormat)
        {

            string reportName = "LCAuthorisationForIndustrialConsumersFormNo_FX20_3";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("LCM_CODE", LCM_CODE);
            parameters.Add("RptType", "1");

            int connectionString = (int)enum_ServerType.MaxcoConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        public async Task<IActionResult> LCAuthorisationForIndustrialConsumersFormNo_FX_IMP(string LCM_CODE, string ReportFormat)
        {

            string reportName = "LCAuthorisationForIndustrialConsumersFormNo_FX_IMP";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("LCM_CODE", LCM_CODE);
            parameters.Add("RptType", "1");

            int connectionString = (int)enum_ServerType.MaxcoConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }

        public async Task<IActionResult> TrialBalance()
        {
            var model = new TrialBalanceViewModel();
            model.DDLAccCategory = await basicCOAService.DDLAccCategory(14);
            model.DateFromStr = $"1-{DateTime.Now.ToString("MMM")}-{DateTime.Now.Year}";
            model.DateToStr = DateTime.Now.ToString("dd-MMM-yyyy");

            model.DDLReportSummarizeType = new List<SelectListItem>()
             {
                 new SelectListItem{ Text="Expanded",Value="Activity",Selected=true},
                 new SelectListItem{ Text="Summarize",Value="",Disabled=true}
             };

            model.DDLPostedType = new List<SelectListItem>()
             {
                 new SelectListItem{ Text="Unposted",Value="0",Selected=true},
                 new SelectListItem{ Text="Posted",Value="1"}
             };
            var com = await basicCOAService.DDLChartOfAccounts(null, 1);
            model.DDLCompany = com;
            model.DDLBusiness = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(183, 2), true);

            return View(model);
        }

        public async Task<IActionResult> TrialBalanceActivity(int CompanyId, int BusinessId, DateTime DateFrom, DateTime DateTo, int AccCategoryId, int PostedType, int SelectWithDetail, int IsExcludeZeroBalance, string ReportFormat)
        {
            try
            {
                string reportName = "TrialBalanceActivity";

                IDictionary<string, object> parameters = new Dictionary<string, object>();

                // SelectLevel int,
                // CompID bigint,                   
                // BusinessID bigint,
                // DateFrom varchar(10),                  
                // DateTo varchar(10),                  
                // WithDetail int,
                // Status int = 0,
                // WithClosingBalance int

                parameters.Add("SelectLevel", AccCategoryId);
                parameters.Add("CompID", CompanyId);
                parameters.Add("BusinessID", BusinessId);
                parameters.Add("DateFrom", DateFrom.ToString("dd-MMM-yyyy"));
                parameters.Add("DateTo", DateTo.ToString("dd-MMM-yyyy"));
                parameters.Add("WithDetail", SelectWithDetail);
                parameters.Add("Status", PostedType);
                parameters.Add("WithClosingBalance", IsExcludeZeroBalance);
                int connectionString = (int)enum_ServerType.EmbroConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IActionResult> PurchaseOrderWiseStock()
        {
            PurchaseOrderReport POOrderModel = new PurchaseOrderReport();
            POOrderModel.DateFrom = DateTime.Now;
            POOrderModel.DateTo = DateTime.Now;
            POOrderModel.CompanyID = 183;
            POOrderModel.DDLCompany = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(0, 1), true);
            POOrderModel.DDLBusiness = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(POOrderModel.CompanyID, 2), true);
            POOrderModel.DDLMRPItem = dropdownService.RenderDDL(mM_MRPItemService.GetTrimMRPItem(), true);
            POOrderModel.DDLBuyer = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer(), true);
            POOrderModel.DDLOrder = dropdownService.DefaultDDL();

            List<SelectListItem> reportType = new List<SelectListItem>();
            reportType.Add(new SelectListItem { Text = "Item Wise Stock Status", Value = "1" });
            reportType.Add(new SelectListItem { Text = "Orderwise Purchase Order", Value = "2" });
            reportType.Add(new SelectListItem { Text = "Individual Purchase Order", Value = "3" });

            POOrderModel.DDLReportType = reportType;
            return View(POOrderModel);
        }


        public async Task<IActionResult> ItemWiseOrderStockReport(DateTime DateFrom, DateTime DateTo, int CompanyID, int BusinessID, int MRPItemCode, long OrderID, int WithAllTransaction, string ReportFormat)
        {
            try
            {
                string reportName = "ItemWiseOrderStockStatus";

                IDictionary<string, object> parameters = new Dictionary<string, object>();

                // SelectLevel int,
                // CompID bigint,                   
                // BusinessID bigint,
                // DateFrom varchar(10),                  
                // DateTo varchar(10),                  
                // WithDetail int,
                // Status int = 0,
                // WithClosingBalance int

                if (OrderID > 0)
                {
                    DateFrom = new DateTime(2010, 1, 1);
                    DateTo = DateTime.Now;
                }

                parameters.Add("DateFrom", DateFrom.Date);
                parameters.Add("DateTo", DateTo.Date);
                parameters.Add("CompanyID", CompanyID);
                parameters.Add("BusinessID", BusinessID);
                parameters.Add("MrpItemCode", MRPItemCode);
                parameters.Add("OrderID", OrderID);
                parameters.Add("WithAllTransaction", WithAllTransaction);
                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IActionResult> OrderTrimHistoryReport(string DateFrom, string DateTo, int CompanyID, int BusinessID, int MRPItemCode, long OrderID, string ReportFormat)
        {
            try
            {
                string reportName = "OrderTrimHistory";

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                //DateFrom = DateFrom == null ? null : DateFrom;
                //DateTo = DateTo == null ? null : DateTo;
                parameters.Add("DateFrom", DateFrom);
                parameters.Add("DateTo", DateTo);
                parameters.Add("CompanyID", CompanyID);
                parameters.Add("BusinessID", BusinessID);
                parameters.Add("MrpItemCode", MRPItemCode);
                parameters.Add("OrderID", OrderID);               
                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<IActionResult> PurchaseOrderWiseStockReport(DateTime DateFrom, DateTime DateTo, int CompanyID, int BusinessID, int MRPItemCode, long OrderID, int WithAllTransaction, string ReportFormat)
        {
            try
            {
                string reportName = "PurchaseOrderWiseStockStatus";

                IDictionary<string, object> parameters = new Dictionary<string, object>();

                // SelectLevel int,
                // CompID bigint,                   
                // BusinessID bigint,
                // DateFrom varchar(10),                  
                // DateTo varchar(10),                  
                // WithDetail int,
                // Status int = 0,
                // WithClosingBalance int

                if (OrderID > 0)
                {
                    DateFrom = new DateTime(2010, 1, 1);
                    DateTo = DateTime.Now;
                }

                parameters.Add("DateFrom", DateFrom.Date);
                parameters.Add("DateTo", DateTo.Date);
                parameters.Add("CompanyID", CompanyID);
                parameters.Add("BusinessID", BusinessID);
                parameters.Add("MrpItemCode", MRPItemCode);
                parameters.Add("OrderID", OrderID);
                parameters.Add("WithAllTransaction", WithAllTransaction);
                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public async Task<IActionResult> OrderTrimHistory() {
            PurchaseOrderReport POOrderModel = new PurchaseOrderReport();
            POOrderModel.DateFrom = DateTime.Now;
            POOrderModel.DateTo = DateTime.Now;
            POOrderModel.CompanyID = 183;
            POOrderModel.DDLCompany = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(0, 1), true);
            POOrderModel.DDLBusiness = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(POOrderModel.CompanyID, 2), true);
            POOrderModel.DDLMRPItem = dropdownService.RenderDDL(mM_MRPItemService.GetTrimMRPItem(), true);
            POOrderModel.DDLBuyer = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer(), true);
            POOrderModel.DDLOrder = dropdownService.DefaultDDL();            
            return View(POOrderModel);
        }
        public async Task<IActionResult> OrderWiseTrimTransaction()
        {
            PurchaseOrderReport POOrderModel = new PurchaseOrderReport();
            POOrderModel.DateFrom = DateTime.Now;
            POOrderModel.DateTo = DateTime.Now;
            POOrderModel.DDLCompany = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(0, 1), true);
            POOrderModel.DDLMRPItem = dropdownService.RenderDDL(mM_MRPItemService.GetTrimMRPItem(), true);
            POOrderModel.DDLBuyer = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer(), true);
            POOrderModel.DDLOrder = dropdownService.DefaultDDL();
            return View(POOrderModel);
        }
        public async Task<IActionResult> OrderWiseTrimTransactionReport(DateTime? DateFrom=null, DateTime? DateTo=null, int CompanyID=0, int BuyerID=0, int MRPItemCode=0,int OrderID=0, int IsShowBalanceItem = 0, string ReportFormat="PDF")
        {
            try
            {
                string reportName = "OrderWiseTrimTransaction";
           
                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("DateFrom", DateFrom);
                parameters.Add("DateTo", DateTo);
                parameters.Add("CompanyID", CompanyID);
                parameters.Add("BuyerID", BuyerID);
                parameters.Add("OrderID", OrderID);
                parameters.Add("MrpItemCode", MRPItemCode);
                parameters.Add("IsShowBalanceItem", IsShowBalanceItem);
                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<IActionResult> PurchaseOrder_IndividualStockReport(DateTime DateFrom, DateTime DateTo, int CompanyID, int BusinessID, int MRPItemCode, int WithAllTransaction, string ReportFormat)
        {
            try
            {
                string reportName = "PurchaseOrder_Individual_StockStatus";

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("DateFrom", DateFrom);
                parameters.Add("DateTo", DateTo);
                parameters.Add("CompanyID", CompanyID);
                parameters.Add("BusinessID", BusinessID);
                parameters.Add("MrpItemCode", MRPItemCode);
                parameters.Add("WithAllTransaction", WithAllTransaction);
                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<IActionResult> YarnStockStatus()
        {
            YarnStockModel yarnStockModel = new YarnStockModel();
            yarnStockModel.TransactionDate = DateTime.Now;
            yarnStockModel.DDLCompany = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(0, 1), true);
            yarnStockModel.CompanyID = 183;
            return View(yarnStockModel);
        }
        public async Task<IActionResult> YarnStockGroup()
        {
            YarnStockModel yarnStockModel = new YarnStockModel();
            yarnStockModel.TransactionDate = DateTime.Now;
            yarnStockModel.DDLCompany = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(0, 1), true);
            yarnStockModel.DDLYarnCount = dropdownService.RenderDDL(await maxcoDDLService.DDLYarnCountALLSTR(), true);
            yarnStockModel.DDLYarnComposition = dropdownService.RenderDDL(await maxcoDDLService.DDLYarnCompositionSTR(), true);
            yarnStockModel.CompanyID = 183;
            return View(yarnStockModel);
        }
        public async Task<IActionResult> YarnStockGroupReport(DateTime StockDate, string CompositionGroup = "", string YarnCount = "", int CompanyID = 0, string ReportFormat = "PDF")
        {
            try
            {
                string reportName = "YarnStockGroup";

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("StockDate", StockDate);
                parameters.Add("CompositionGroup", CompositionGroup);
                parameters.Add("YarnCount", YarnCount);
                parameters.Add("CompanyID", CompanyID);
                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public JsonResult YarnStocSummeryCompositionWise(DateTime StockDate, int CompanyID = 0)
        {
            var data = this.yarnBalanceService.YarnSummaryCompositionWise(StockDate, CompanyID);
            return Json(data);
        }

        public async Task<ActionResult> YarnStockDetails(string YarnComposition, string YarnCount, DateTime TransactionDate, long CompanyID)
        {
            RResult<YarnStockDetailsSPModel> rResult = new RResult<YarnStockDetailsSPModel>();
            var yarnDetails = await yarnBalanceService.YarnStockDetails(YarnComposition, YarnCount, TransactionDate, CompanyID);
            rResult.modelObjectList = new List<YarnStockDetailsSPModel>();
            rResult.modelObjectList = yarnDetails;
            return View(rResult);

        }
        public async Task<ActionResult> YarnLotDetails(string LotNo)
        {
            RResult<YarnStockDetailsSPModel> rResult = new RResult<YarnStockDetailsSPModel>();
            var yarnDetails = await yarnBalanceService.YarnLotDetails(LotNo.Trim());
            rResult.modelObjectList = new List<YarnStockDetailsSPModel>();
            rResult.modelObjectList = yarnDetails;
            return View(rResult);

        }
        //YarnLotDetails
        public async Task<JsonResult> GetPurchaseOrderWiseStock(DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction)
        {
            var list = await aLLMMReportService.GetPurchaseOrderWiseStock(DateFrom, DateTo, MrpItemCode, CompanyID, BusinessID, WithAllTransaction);
            return Json(list);
        }
        public async Task<JsonResult> Get_Individual_PO_ItemStock(DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction)
        {
            var list = await aLLMMReportService.Get_Individual_PO_ItemStock(DateFrom, DateTo, MrpItemCode, CompanyID, BusinessID, WithAllTransaction);
            return Json(list);
        }
        public async Task<ActionResult> IndividuaPOItemDetails(int BuyerID, DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction, long AttributeInstanceID)
        {
            RResult<PurchaseOrderStockSPModel> rResult = new RResult<PurchaseOrderStockSPModel>();
            var itemDetails = await aLLMMReportService.Get_Individual_PO_ItemStockDetail(BuyerID, DateFrom, DateTo, MrpItemCode, CompanyID, BusinessID, WithAllTransaction, AttributeInstanceID);
            rResult.modelObjectList = new List<PurchaseOrderStockSPModel>();
            rResult.modelObjectList = itemDetails;
            return View(rResult);
        }

        public async Task<IActionResult> CompanyWiseyarnStock()
        {
            YarnLotNo yarn = new YarnLotNo();
            yarn.DateFrom = DateTime.Now;
            yarn.DateTo = DateTime.Now;
            yarn.DDLCompany = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(0, 1), true);
            return View(yarn);
        }
        public async Task<IActionResult> CompanyWiseyarnStockReport(DateTime DateFrom, DateTime DateTo, int CompanyID, string LotNo, int WithAllTransaction=0,string ReportFormat = "PDF")
        {
            try
            {
                string reportName = "CompanyWiseYarnLotStockReport";

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("DateFrom", DateFrom);
                parameters.Add("DateTo", DateTo);
                parameters.Add("CompanyID", CompanyID);
                parameters.Add("LotNo", LotNo);
                parameters.Add("IsNotZeroBalance", WithAllTransaction);
                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}