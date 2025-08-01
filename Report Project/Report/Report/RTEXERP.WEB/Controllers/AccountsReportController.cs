using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Common.AccDefaultSetups;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;

namespace RTEXERP.WEB.Controllers
{
    public class AccountsReportController : BaseController
    {
        private readonly IBasicCOAService basicCOAService;
        private readonly IDropdownService dropDownService;
        public AccountsReportController(IBasicCOAService basicCOAService, IDropdownService dropDownService)
        {
            this.basicCOAService = basicCOAService;
            this.dropDownService = dropDownService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GeneralLedger()
        {
            AccDefaultSetup accDefault = new AccDefaultSetup(183);
            GeneralLedgerReportViewModel model = new GeneralLedgerReportViewModel();
            model.CompanyID = 183;
            model.AccCategoryID = 0;
            var companyList = await basicCOAService.DDLChartOfAccounts(null, 1);
            model.DDLCompany = companyList.Where(b => b.Value != "3684").ToList();
            //11 = Cost Center
            var costcenterlist = await basicCOAService.DDLChartOfAccounts(accDefault.BusinessID, 11);
            costcenterlist = costcenterlist.Where(b => b.Text != "Not to Use").ToList();
            model.DDLCostCenterList = dropDownService.RenderDDL(costcenterlist, true);
            model.DDLActivityList = dropDownService.DefaultDDL();
            model.DateFrom = accDefault.FinincialDateFrom(DateTime.Now);
            model.DateTo = Convert.ToDateTime(model.DateFrom).AddYears(1).AddDays(-1).ToString("dd-MMM-yyyy");
            //Category
            var categoryList = await basicCOAService.DDLChartOfAccounts(model.CompanyID, 4);
            model.DDLCategoryList = dropDownService.RenderDDL(categoryList, true);
            var chartList = await basicCOAService.DDLCategoryChartOfAccounts(model.CompanyID, model.AccCategoryID);
            model.DDLAccList = chartList;


            return View(model);
        }

        public async Task<IActionResult> ChartOfAccountsGeneralLedger(string inputXML, string ReportFormat)
        {
            try
            {
                string reportName = "GeneralLedger";
                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("inputXML", inputXML);
                int connectionString = (int)enum_ServerType.EmbroConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}