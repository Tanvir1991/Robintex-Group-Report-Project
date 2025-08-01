using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Common.AccDefaultSetups;
namespace RTEXERP.WEB.Controllers
{
    public class ChartOfAccountsController : BaseController
    {
        private readonly IBasicCOAService basicCOAService;
        public ChartOfAccountsController(IBasicCOAService basicCOAService)
        {
            this.basicCOAService = basicCOAService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetBusinessCompanyWise(int CompanyId)
        {
            var businessList =await this.basicCOAService.DDLChartOfAccounts(CompanyId, EmbroConstant.AccLevel.Business);
            return Json(businessList);
        }
        public async Task<JsonResult> GetLocationBusinessWise(int CompanyId)
        {
            var businessList = await this.basicCOAService.DDLChartOfAccounts(CompanyId, EmbroConstant.AccLevel.Location);
            return Json(businessList);
        }
        public async Task<JsonResult> GetCostCenterLocationWise(int BusinessId)
        {
            var businessList = await this.basicCOAService.DDLChartOfAccounts(BusinessId, EmbroConstant.AccLevel.CostCenter);
            return Json(businessList);
        }
        public async Task<JsonResult> GetActivityCostCenterWise(int CostCenterID)
        {
            var businessList = await this.basicCOAService.DDLChartOfAccounts(CostCenterID, EmbroConstant.AccLevel.Activity);
            return Json(businessList);
        }

        public async Task<JsonResult> ChartOfAccountsSupplierGroup(int CompanyId, int? CategoryID = 0)
        {
            var businessList = await this.basicCOAService.ChartOfAccountsSupplierGroup(CompanyId, CategoryID);
            return Json(businessList);
        }
        public async Task<JsonResult> ChartOfAccountsGroup(int CompanyId, int? CategoryID = 0)
        {
            var businessList = await this.basicCOAService.ChartOfAccountsGroup(CompanyId, CategoryID);
            return Json(businessList);
        }
        public async Task<JsonResult> ChartOfAccounts(int? parentId, int levelId)
        {
            var businessList = await this.basicCOAService.ChartOfAccounts(parentId, levelId);
            return Json(businessList);
        }

    }
}   