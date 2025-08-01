using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    public class AccOrderWiseStatusController : BaseController
    {
        private readonly IDropdownService dropdownService;
        private readonly IBuyer_SetupService buyer_SetupService;

        public AccOrderWiseStatusController(IDropdownService _dropdownService,
            IBuyer_SetupService _buyer_SetupService)
        {
            dropdownService = _dropdownService;
            buyer_SetupService = _buyer_SetupService;
        }
        public async  Task<IActionResult> OrderWiseStatus()
        {
            var model = new AccOrderWiseStatusViewModel();
            model.DateFrom = DateTime.Now;
            model.DateTo = DateTime.Now;
            model.BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer(), true);
            model.OrderList= dropdownService.DefaultDDL();
            return View(model);
        }


        public async Task<IActionResult> AccountOrderWiseStatusReportPrint(int BuyerID, int OrderID, string DateFrom, string DateTo, string ReportFormat)
        {
            try
            {
                string reportName = "Acc_OrderWiseFabricCostingInfo";

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("BuyerID", BuyerID);
                parameters.Add("OrderID", OrderID);
                parameters.Add("DateFrom", DateFrom);
                parameters.Add("DateTo", DateTo);

                int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IActionResult> OrderFabricCuttingSewingShipment()
        {
            var model = new OrderFabricCuttingSewingShipmentViewModel();
            model.DDLBuyerList= dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer(), true);
            model.DDLOrderList= dropdownService.DefaultDDL();
            model.DateFrom = DateTime.Now.AddYears(-2).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            return View(model);
        }
        //
        public async Task<IActionResult> AccountOrderFabricCuttingSewingShipmentReportPrint(int BuyerID, List<string> OrderID,  string ReportFormat)
        {
            try
            {
                string orderString = "";
                string reportName = "AccOrderFabCutSewingShipmentInfo";
                if (OrderID.Count > 0)
                {
                    orderString = string.Join(",", OrderID);
                }
                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("BuyerID", BuyerID);
                parameters.Add("OrderStr", orderString);
               
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
