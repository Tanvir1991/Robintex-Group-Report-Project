using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.Maxco;

namespace RTEXERP.WEB.Controllers
{
    public class CommonAutoCompleteController : BaseController
    {
        private readonly IBasicCOAService basicCOAService;
        private readonly IStyleService styleService;
        public CommonAutoCompleteController(IBasicCOAService basicCOAService, IStyleService styleService)
        {
            this.basicCOAService = basicCOAService;
            this.styleService = styleService;
        }
        public async Task<JsonResult> GetSupplierListAutocomplete(string prefix,int companyId)
        {
            var supplier = await basicCOAService.GetsSupplierListAutocomplete(prefix, companyId);
            return Json(supplier);
        }
        public async Task<JsonResult> GetAutoCompleteChartOfAccounts(string prefix, int companyId)
        {
            var supplier = await basicCOAService.GetAutoCompleteChartOfAccounts(prefix, companyId);
            return Json(supplier);
        }
        public async Task<JsonResult> GetBankAccountAutocomplete(string prefix, int companyId)
        {
            var supplier = await basicCOAService.GetBankAccountAutocomplete(prefix, companyId);
            return Json(supplier);
        }
        public async Task<JsonResult> GetOrderNumber(string prefix)
        {
            var orderNumbers = await styleService.GetOrderNumbers(prefix);
            return Json(orderNumbers);
        }
    }
}