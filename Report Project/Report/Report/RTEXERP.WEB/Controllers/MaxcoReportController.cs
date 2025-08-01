using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;

namespace RTEXERP.WEB.Controllers
{
    public class MaxcoReportController : BaseController
    {
        private readonly IMaxcoReportService maxcoReportService;
        public MaxcoReportController(IMaxcoReportService maxcoReportService)
        {
        this.maxcoReportService = maxcoReportService;
    }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OrderVersion()
        {
            return View();
        }
        public async Task<JsonResult> GetOrderVersion(string OrderNo)
        {
            var data= await this.maxcoReportService.GetOrderVersion(OrderNo);
            return Json(data);
        }
        public async Task<IActionResult> OrderSheetReport(int CurrentVersionID)
        {
            var data = await maxcoReportService.OrderSheetReportData(CurrentVersionID);
            return View(data);
        }

        public IActionResult OrderSheetSummary()
        {
            return View();
        }
        public async Task<IActionResult> PrintOrderSheetSummary(string DateFrom, string DateTo, string ReportFormat)
        {
            try
            {
                int connectionString = 0;
                string reportName = "";
                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("IsMail", 0);
                parameters.Add("DateFrom", DateFrom);
                parameters.Add("DateTo", DateTo);

                connectionString = (int)enum_ServerType.MaxcoConnectionString;
                reportName = "OrderFinalSheetSummary";

                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
