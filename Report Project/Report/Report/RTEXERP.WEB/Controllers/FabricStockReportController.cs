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
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;

namespace RTEXERP.WEB.Controllers
{
    public class FabricStockReportController : BaseController
    {
        private readonly IBasicCOAService basicCOAService;
        private readonly IDropdownService dropdownService;
        private readonly IALLFiniteSchedulerReportService aLLFiniteSchedulerReportService;
        public FabricStockReportController(IBasicCOAService basicCOAService, IDropdownService dropdownService
            , IALLFiniteSchedulerReportService _aLLFiniteSchedulerReportService)
        {
            this.basicCOAService = basicCOAService;
            this.dropdownService = dropdownService;
            aLLFiniteSchedulerReportService = _aLLFiniteSchedulerReportService;
        }
        public  IActionResult Index()
        {
            var model = new FabricStockReport();
            model.ReportTypeList = GetReportTypeList();           
            model.DateTo = DateTime.Now;           
            return View(model);
        }
        public List<SelectListItem> GetReportTypeList()
        {
            var list = new List<SelectListItem>(){
            new SelectListItem{ Text="Greige Fabric Stock Report",Value="GF"},
            new SelectListItem { Text="Finish Fabric Stock Report",Value="FF"}
            };
            return list;
        }        
        public async Task<ActionResult> FabricLotStockDetails(int LotID, int AttributeInstanceID, DateTime DateTo)
        {
            RResult<FabricStockReportSPModel> rResult = new RResult<FabricStockReportSPModel>();
            var itemDetails = await aLLFiniteSchedulerReportService.GetFabricLotStockList(LotID, AttributeInstanceID, DateTo);
            rResult.modelObjectList = new List<FabricStockReportSPModel>();
            rResult.modelObjectList = itemDetails;
            return View(rResult);
        }
        public async Task<IActionResult> StockReport(string ReportType, string DateTo, string ReportFormat)
        {
            try
            {
                int connectionString = 0;
                string reportName = "";
                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("DateTo", DateTo);
                if (ReportType=="FF")
                {
                    parameters.Add("BuyerID", 0);
                    parameters.Add("OrderID", 0);
                    connectionString = (int)enum_ServerType.FiniteSchedulerConnectionString;
                    reportName = "FinishFabricStockReport";
                }
                else if(ReportType == "GF")
                {
                    parameters.Add("OrderID", "0");
                    parameters.Add("BuyerID", "0");
                    parameters.Add("IsAllTransaction", "0");
                    
                    connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
                    reportName = "GreigeFabricStockReport";
                }
                
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}