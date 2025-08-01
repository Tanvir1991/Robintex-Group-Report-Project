using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Common.AccDefaultSetups;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;

namespace RTEXERP.WEB.Controllers
{
    public class ChemicalStockReportController : BaseController
    {
        private readonly IBasicCOAService basicCOAService;
        private readonly IDropdownService dropdownService;
        private readonly IChemicalReportService chemicalReportService;
        public ChemicalStockReportController(IBasicCOAService basicCOAService, IDropdownService dropdownService
            , IChemicalReportService chemicalReportService)
        {
            this.basicCOAService = basicCOAService;
            this.dropdownService = dropdownService;
            this.chemicalReportService = chemicalReportService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ChemicalStockReport();
            model.ReportTypeList = GetReportTypeList();
            model.DateFrom = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            model.CompanyList = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(0, 1), false);
            return View(model);
        }
        public List<SelectListItem> GetReportTypeList()
        {
            var list = new List<SelectListItem>(){
            new SelectListItem{ Text="General Store",Value="General Store"},
            new SelectListItem { Text="Dyes & Chemical",Value="Dyes & Chemical"}
            };
            return list;
        }
        public async Task<JsonResult> GetChemicalStock(int CompanyId, string ReportType, DateTime DateFrom, DateTime DateTo, int WithAllTransaction)
        {
            var list = await chemicalReportService.GetChemicalStock(CompanyId, DateFrom, DateTo, ReportType.Replace("_", "&"), WithAllTransaction);
            return Json(list);
        }
        public async Task<IActionResult> StockReport(int CompanyId, string ReportType, string DateFrom, string DateTo, int WithAllTransaction, string ReportFormat)
        {
            try
            {
                string reportName = "ChemicalAndGeneralStockStatus";

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("CompanyID", CompanyId);
                parameters.Add("DateFrom", DateFrom);
                parameters.Add("DateTo", DateTo);
                parameters.Add("ReportItemType", ReportType.Replace("_", "&"));
                parameters.Add("WithAllTransaction", WithAllTransaction);

                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<ActionResult> ChemicalItemDetails(int CompanyID,int ItemID ,int UnitID,DateTime DateFrom,DateTime DateTo,string ReportItemType,int WithAllTransaction)
        {
            RResult<ChemicalStockSPModel> rResult = new RResult<ChemicalStockSPModel>();
            var itemDetails = await chemicalReportService.GetChemicalItemDetail(CompanyID, ItemID, UnitID, DateFrom, DateTo, ReportItemType.Replace("_", "&"), WithAllTransaction);
            rResult.modelObjectList = new List<ChemicalStockSPModel>();
            rResult.modelObjectList = itemDetails;
            return View(rResult);
        }
    }
}