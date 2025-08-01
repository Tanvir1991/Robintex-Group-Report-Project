using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Shared.ChartOFACC;
using RTEXERP.Contracts.Common;
using RTEXERP.DAL.DataContext;
using RTEXERP.WEB.Scheduler;
using SSRSReport.Library;
using StoredProcedureEFCore;

namespace RTEXERP.WEB.Controllers
{
    public class AOPCostController : BaseController
    {
        private ReportDBContext dbCon;
        public AOPCostController(ReportDBContext dbCon)
        {
            this.dbCon = dbCon;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GETAOPCostSummary(DateTime DateFrom, DateTime DateTo, string ReportFormat)
        {
            var report = new CallSSRSReport();
            string reportName = "Aop_Cost_Summary";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("stdate", DateFrom.ToString("dd-MMM-yyyy"));
            parameters.Add("enddate", DateTo.ToString("dd-MMM-yyyy"));

            //await new SCH_AOPCostSummery().StoreReport();
            //    parameters = null;
            //    byte[] reportContent = await report.RenderReport(reportName, parameters, languageCode, ReportFormat);
            // ReportExportFormat.ExcelFormat
            int connectionString = (int)enum_ServerType.AOPConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }


        public IActionResult BCIYarnImport()
        {
            var model = new SupplierReportViewModel();
            var suplierList = this.GetSupplierWIseCompanyList().Select(b=> new SelectListItem
            {
                Text = b.SupplierAndCompany,
                Value = b.SupplierId.ToString()
                
            });
            model.SupplierList = suplierList;
            return View(model);
        }

        public IActionResult ExtraDyeingCost()
        {
            return View();
        }
        public async Task<IActionResult> GetAOPRedyeingCost(DateTime DateFrom, DateTime DateTo, string ReportFormat)
        {
            var report = new CallSSRSReport();
            string reportName = "DyeingDuplicateRecipe";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("stdate", DateFrom.ToString("dd-MMM-yyyy"));
            parameters.Add("enddate", DateTo.ToString("dd-MMM-yyyy"));

            //await new SCH_AOPCostSummery().StoreReport();
            //    parameters = null;
            //    byte[] reportContent = await report.RenderReport(reportName, parameters, languageCode, ReportFormat);
            // ReportExportFormat.ExcelFormat
            int connectionString = (int)enum_ServerType.AOPConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }

        public List<SupplierWIseCompanyNameViewModel> GetSupplierWIseCompanyList()
        {
            List<SupplierWIseCompanyNameViewModel> orderList = new List<SupplierWIseCompanyNameViewModel>();
            try
            {
                dbCon.LoadStoredProc("usp_GET_YarnSuplierList")
                        .Exec(r => orderList = r.ToList<SupplierWIseCompanyNameViewModel>());


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return orderList;


            
        }
        public async Task<IActionResult> GetBCIYarnImport(DateTime DateFrom, DateTime DateTo, string ReportFormat)
        {
            var report = new CallSSRSReport();
            string reportName = "YarnImport_BCI";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("stdate", DateFrom.ToString("dd-MMM-yyyy"));
            parameters.Add("enddate", DateTo.ToString("dd-MMM-yyyy"));

            //await new SCH_AOPCostSummery().StoreReport();
            //    parameters = null;
            //    byte[] reportContent = await report.RenderReport(reportName, parameters, languageCode, ReportFormat);
            // ReportExportFormat.ExcelFormat
            int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
        public async Task<IActionResult> GetBCIYarnImportSupplierWise(DateTime DateFrom, DateTime DateTo, string ReportFormat)
        {
            var report = new CallSSRSReport();
            string reportName = "SupplierWiseCompanyYarnImport_BCI";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("stdate", DateFrom.ToString("dd-MMM-yyyy"));
            parameters.Add("enddate", DateTo.ToString("dd-MMM-yyyy"));

            int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
    }
}