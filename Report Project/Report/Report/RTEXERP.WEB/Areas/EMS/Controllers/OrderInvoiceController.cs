using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.EMS;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.EMS.Controllers
{
    [Area("EMS")]
    public class OrderInvoiceController : BaseController
    {
        private readonly IBuyer_SetupService _buyer_SetupService;
        private IDropdownService _dropdownService;

        public OrderInvoiceController(IBuyer_SetupService buyer_SetupService, IDropdownService dropdownService)
        {
            _buyer_SetupService = buyer_SetupService;
            _dropdownService = dropdownService;
        }
        public async Task<IActionResult> Index()
        {
            OrderInvoiceExfectoryViewModel model = new OrderInvoiceExfectoryViewModel();
            model.DDLBuyer = _dropdownService.RenderDDL(await _buyer_SetupService.DDLBuyer(), true);
            model.DDLOrder = _dropdownService.DefaultDDL();
            model.DDLShipTo = _dropdownService.DefaultDDL();
            model.DateFrom = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            return View(model);
        }
        public async Task<IActionResult> OrderExportRealization()
        {
            OrderInvoiceExfectoryViewModel model = new OrderInvoiceExfectoryViewModel();
            model.DDLBuyer = _dropdownService.RenderDDL(await _buyer_SetupService.DDLBuyer(), true);
            model.DDLOrder = _dropdownService.DefaultDDL();
            model.DDLShipTo = _dropdownService.DefaultDDL();
            model.DateFrom = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            return View(model);
        }

        #region report
        public async Task<IActionResult> OrderShipmentReport(int BuyerID = 0, int OrderID = 0, DateTime? DateFrom = null, DateTime? DateTo = null, string ReportFormat = "PDF")
        {
            string reportName = "EMS_OrderInvoiceShipmentExFactoryDT";
            IDictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("BuyerID", BuyerID);
            parameters.Add("OrderID", OrderID);
            if (DateFrom.HasValue == false)
            {
                DateFrom = DateTime.Now.AddYears(-3);
                DateTo = DateTime.Now.AddMonths(1);
            }

            parameters.Add("ExfactoryDateFrom", DateFrom);
            parameters.Add("ExfactoryDateTo", DateTo);

            parameters.Add("ShipTo", string.Empty);

            int connectionString = (int)enum_ServerType.EMSConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);


        }

        public async Task<IActionResult> OrderExportRealizationReport(int BuyerID = 0, int OrderID = 0, string ReportFormat = "PDF")
        {
            string reportName = "EMS_OrderExportRealization";
            IDictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("BuyerID", BuyerID);
            parameters.Add("OrderID", OrderID);
            
            int connectionString = (int)enum_ServerType.EMSConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);


        }
        #endregion
    }
}
