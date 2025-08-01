using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;

namespace RTEXERP.WEB.Controllers
{
    public class SampleGateReceivingController : BaseController
    {
        private readonly ICMBL_SampleService cmbl_SampleService;
        private readonly ICMBL_SampleGateReceivingService cmbl_SampleGateReceivingService;
        public SampleGateReceivingController(ICMBL_SampleService cmbl_SampleService, ICMBL_SampleGateReceivingService cmbl_SampleGateReceivingService)
        {
            this.cmbl_SampleService = cmbl_SampleService;
            this.cmbl_SampleGateReceivingService = cmbl_SampleGateReceivingService;
        }
        public IActionResult Index()
        {
            var model = new CMBL_SampleGateReceivingViewModel();
            model.DeliveryChallanDate = DateTime.Now;
            return View(model);
        }
        public async Task<JsonResult> GetRequisitionWiseItemListForGateReceiving( long SampleNo)
        {
            var itemList = new List<CMBL_SampleItemViewModel>();
            try
            {
                itemList = await cmbl_SampleService.GetRequisitionWiseItemListForGateReceiving(SampleNo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Json(itemList);
        }
        [HttpPost]
        public async Task<JsonResult> SampleGateReceivingSave(CMBL_SampleGateReceivingViewModel sampleReceiving)
        {
            RResult rResult = new RResult();
            try
            {
                rResult = await cmbl_SampleGateReceivingService.SampleGateReceivingSave(sampleReceiving,Session_EMPLOYEE_ID,true);
            }
            catch (Exception)
            {
                
                throw;
            }
            return Json(rResult);
        }
    }
}