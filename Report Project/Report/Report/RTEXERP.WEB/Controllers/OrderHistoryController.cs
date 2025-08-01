using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.EMS.SPModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Controllers
{
    public class OrderHistoryController : BaseController
    {
        private readonly IDropdownService dropdownService;
        private readonly IBuyer_SetupService buyer_SetupService;
        private readonly IStyleService styleService;

        public OrderHistoryController(IDropdownService _dropdownService, IBuyer_SetupService _buyer_SetupService, IStyleService styleService)
        {
            dropdownService = _dropdownService;
            buyer_SetupService = _buyer_SetupService;
            this.styleService = styleService;
        }
        public async Task<IActionResult> OrderPrintHistory()
        {
            var model = new KnittingRequirementSheetVM()
            {
                BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer()),
                OrderList = dropdownService.DefaultDDL(),
                DateFrom = DateTime.Now.AddMonths(-6).ToString("dd-MMM-yyyy"),
                DateTo = DateTime.Now.ToString("dd-MMM-yyyy"),
            };
            return View(model);

        }
        [HttpPost]
        public async Task<JsonResult> GetOrderTotalHistory(List<string> OrderID, DateTime? UpToDate)
        {
            UpToDate = UpToDate == null ? DateTime.Now : UpToDate;
            var dateList =new List<OrderTotalHistoryViewModel>();
            if (OrderID.Count>0)
            {
                var orderId = string.Join(",", OrderID);
                dateList = await styleService.GetOrderTotalHistory(orderId,UpToDate.Value);
                
            }
            return Json(dateList);
        }
        public async Task<IActionResult> OrderHistoryReportPrint(List<string> OrderID,DateTime? UpToDate, string ReportFormat)
        {
            string orderId = "";
            //string reportName = "OrderHistory";
            string reportName = "GetOrderFabricHistory";
            if (OrderID.Count > 0)
            {
                 orderId = string.Join(",", OrderID);
            }
            UpToDate = UpToDate == null ? DateTime.Now : UpToDate;
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            //parameters.Add("OrderID", orderId); 
            parameters.Add("OrderString", orderId);
            parameters.Add("UpToDate", UpToDate);
            int connectionString = (int)enum_ServerType.MaxcoConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }

        public async Task<IActionResult> OrderAccessoriesCost()
        {
            var model = new OrderAccessoriesCostVM()
            {
                BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer(), true),
                OrderList = dropdownService.DefaultDDL(),
                DateFrom = DateTime.Now.ToString("dd-MMM-yyyy"),
                DateTo = DateTime.Now.ToString("dd-MMM-yyyy"),
            };
            return View(model);
        }

        public async Task<IActionResult> OrderHistoryReport()
        {
            var model = new KnittingRequirementSheetVM()
            {
                BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer()),
                OrderList = dropdownService.DefaultDDL(),
                DateFrom = DateTime.Now.AddMonths(-6).ToString("dd-MMM-yyyy"),
                DateTo = DateTime.Now.ToString("dd-MMM-yyyy"),
            };
            return View(model);

        }

        public async Task<IActionResult> OrderAccessoriesCostReportPrint(string DateFrom, string DateTo, string OrderID, int? BuyerID, string ReportFormat)
        {
            try
            {
                string reportName = "OrderTraceAndAccessories";

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("DateFrom", DateFrom);
                parameters.Add("DateTo", DateTo);
                parameters.Add("OrderID", OrderID);
                parameters.Add("BuyerID", BuyerID);
               
             
                int connectionString = (int)enum_ServerType.EMSConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<IActionResult> OrderPrintHistoryReportPrint(string DateFrom, string DateTo, string OrderID, string ReportFormat)
        {
            try
            {
                string reportName = "OrderPrintHistory";

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("OrderString", OrderID);
              

                int connectionString = (int)enum_ServerType.AOPConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public async Task<IActionResult> OrderProcessLoss()
        {
            var model = new KnittingRequirementSheetVM()
            {
                BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer()),
                OrderList = dropdownService.DefaultDDL(),
                DateFrom = DateTime.Now.ToString("dd-MMM-yyyy"),
                DateTo = DateTime.Now.ToString("dd-MMM-yyyy"),
            };
            return View(model);
        }
        public async Task<IActionResult> OrderProcessLossPrint(int OrderID=0,DateTime? DateFrom=null, DateTime? DateTo =null, string ReportFormat= "PDF")
        {
            try
            {
                string reportName = "OrderDyeingFabric";

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                string _Datefrom = DateFrom.HasValue == true ? DateFrom.Value.ToString("dd-MMM-yyyy") : "01 jan 2000";
                    string _DateTo = DateTo.HasValue == true ? DateFrom.Value.ToString("dd-MMM-yyyy") : DateTime.Now.ToString("dd-MMM-yyyy");
                parameters.Add("OrderID", OrderID);
                parameters.Add("IssuanceDateFrom", _Datefrom);
                parameters.Add("IssuanceDateTo", _DateTo);

                int connectionString = (int)enum_ServerType.FiniteSchedulerConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}
