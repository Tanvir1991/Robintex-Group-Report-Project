using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;

namespace RTEXERP.WEB.Controllers
{
    public class SampleReceivingController : BaseController
    {
        private readonly IBasicCOAService basicCOAService;
        private readonly IDropdownService dropdownService;
        private readonly ICMBL_SampleService cmbl_SampleService;
        private readonly ICMBL_UnitService cMBL_UnitService;
        private readonly Itbl_Currency_SetupService currency_SetupService;
        public SampleReceivingController(IBasicCOAService basicCOAService, IDropdownService dropdownService, ICMBL_SampleService cmbl_SampleService, ICMBL_UnitService cMBL_UnitService
            , Itbl_Currency_SetupService currency_SetupService)
        {
            this.basicCOAService = basicCOAService;
            this.dropdownService = dropdownService;
            this.cmbl_SampleService = cmbl_SampleService;
            this.cMBL_UnitService = cMBL_UnitService;
            this.currency_SetupService = currency_SetupService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new CMBL_SampleViewModel();
            model.CompanyList = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccounts(null, 1), true);
            model.CurrencyList = dropdownService.RenderDDL(await currency_SetupService.DDLCurrencyList(), true);
            model.SupplierList = dropdownService.DefaultDDL();
            return View(model);
        }
        public async Task<IActionResult> ReceivingReport()
        {
            var model = new CMBL_SampleViewModel();
            model.SampleList = dropdownService.RenderDDL(await cmbl_SampleService.DDLSampleNo(), true);
            return View(model);
        }
        public async Task<JsonResult> GetRequisitionWiseItemList(long CompanyId, long RequisitionNo)
        {
            var itemList = new List<CMBL_SampleItemViewModel>();
            try
            {
                itemList = await cmbl_SampleService.GetRequisitionWiseItemList(CompanyId, RequisitionNo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Json(itemList);
        }
        public async Task<JsonResult> GetUnitList(long CompanyId)
        {
            var unitList = new List<SelectListItem>();
            try
            {
                unitList = dropdownService.RenderDDL(await cMBL_UnitService.DDLUnitListByCompany(CompanyId), true);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Json(unitList);
        }
        public async Task<JsonResult> GetSupplierList(long CompanyId)
        {
            var supplierList = new List<SelectListItem>();
            try
            {
                supplierList = dropdownService.RenderDDL(await basicCOAService.DDLChartOfAccountsCompanyWiseSupplier(Convert.ToInt32(CompanyId)), true);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Json(supplierList);
        }
        [HttpPost]
        public async Task<JsonResult> SampleReceivingSave(CMBL_SampleViewModel sample)
        {
            RResult rResult = new RResult();
            try
            {
                rResult = await cmbl_SampleService.CMBL_SampleSave(sample, Session_EMPLOYEE_ID,true);
            }
            catch (Exception e)
            {

                throw;
            }
            return Json(rResult);
        }
        public async Task<IActionResult> GetReceivingReport(long SampleNo, string ReportFormat)
        {
           
            string reportName = "SamplePurchaseOrderReport";

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("SampleNo", SampleNo);           
            int connectionString = (int)enum_ServerType.MaterialsManagementConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

        }
    }
}