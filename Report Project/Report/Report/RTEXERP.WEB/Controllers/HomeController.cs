using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RTEXERP.Common.Constants;
using RTEXERP.Contracts;
using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.AppSecurity;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.Extension.Extensions;
using RTEXERP.WEB.Helper;
using RTEXERP.WEB.Models;
using SSRSReport.Library;

namespace RTEXERP.WEB.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserIPAddressService _ip;
        private readonly IMM_MRPItemAttributeInstanceRepository _attributeInstanceInfo;
        private readonly IUserAccessInfoService _userAccessInfoService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUserIPAddressService ip, IMM_MRPItemAttributeInstanceRepository attributeInstanceInfo, IUserAccessInfoService userAccessInfoService
            , ILogger<HomeController> logger)
        {
            this._ip = ip;
            _attributeInstanceInfo = attributeInstanceInfo;
            _userAccessInfoService = userAccessInfoService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var user = User.Identity.IsAuthenticated;
            var userIp = _ip.GetLocalIpAddress();
            var model = await _attributeInstanceInfo.GetForAttributeInstanceXMLToObject(81677);
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> GetPDFReport()
        {
            var report = new CallSSRSReport();
            string reportName = "Bangladesh";
            //    IDictionary<string, object> parameters = new Dictionary<string, object>();
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            //paramValues.Add(new ParameterValue() { Name = "companyId", Value ="3" });
            parameters.Add("customerId", "123");
            string languageCode = "en-us";
            //    parameters = null;
            byte[] reportContent = await report.RenderReport(reportName, parameters, languageCode, "PDF");

            return await PrintSSRSReport(reportName, parameters, ReportExportFormat.ExcelFormat);

        }


    }
}
