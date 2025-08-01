using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Controllers
{
    public class GarmentsProductionController : BaseController
    {
        private readonly IPro_MasterService _pro_MasterService;
        private readonly ISubcontractStyleChargeService _subcontractStyleChargeService;
        public GarmentsProductionController(IPro_MasterService pro_MasterService, ISubcontractStyleChargeService subcontractStyleChargeService)
        {
            _pro_MasterService = pro_MasterService;
            _subcontractStyleChargeService = subcontractStyleChargeService;
        }
        public IActionResult GarmentsProductionReport()
        {
            GarmentsProductionReportVM model = new GarmentsProductionReportVM();
            model.DateFrom = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
            return View(model);
        }

        public async Task<IActionResult> AddSubContractOrderPcieRate()
        {
            SubcontractStyleChargeVM model = new SubcontractStyleChargeVM();
            model.DDLOrder = await _pro_MasterService.DDLProductionOrder(DateTime.Now.AddYears(-1).Date, DateTime.Now.Date, 0);
            return View(model);
        }

        public async Task<JsonResult> SaveSubcontractPrice(SubcontractStyleChargeVM model)
        {
            RResult result = new RResult();
            if (ModelState.IsValid)
            {
                result = await _subcontractStyleChargeService.AddSubcontract(model);
                
            }
            else
            {
                result.result = 0;
                result.message = "Required data needed.";
            }
            return Json(result);
        }

        public async Task<JsonResult> GetSubContractRateList(DateTime? DateFrom,DateTime? DateTo)
        {
            RResult rtnResult = new RResult();
            DateTime _DateFrom = DateTime.Now.AddMonths(-6);
            DateTime _DateTo = DateTime.Now;
            if (DateFrom.HasValue == true)
            {
                _DateFrom = DateFrom.Value;
            }
            if (DateTo.HasValue == true)
            {
                _DateTo = DateTo.Value;
            }
            var list = await _subcontractStyleChargeService.GetSubContractCharge(_DateFrom, _DateTo);
            rtnResult.data = list;
            rtnResult.result = 1;
            return Json(rtnResult);
        }
    }
}
