using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    public class knittingRequirementSheetController : BaseController
    {
        private readonly IBuyer_SetupService buyer_SetupService;
        private readonly IDropdownService dropdownService;
        private readonly IMAC_OrderCostingInfoService mAC_OrderCostingInfoService;
        private readonly IKRS_MASTERService kRS_MASTERService;

        public knittingRequirementSheetController(IBuyer_SetupService _buyer_SetupService,
            IDropdownService _dropdownService,
            IMAC_OrderCostingInfoService _mAC_OrderCostingInfoService,
            IKRS_MASTERService _kRS_MASTERService)
        {
            buyer_SetupService = _buyer_SetupService;
            dropdownService = _dropdownService;
            mAC_OrderCostingInfoService = _mAC_OrderCostingInfoService;
            kRS_MASTERService = _kRS_MASTERService;
        }
        public async Task<IActionResult> OrderWiseKRSInfo()
        {
            var model = new KnittingRequirementSheetVM();
            model.BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer());
            model.OrderList = dropdownService.DefaultDDL();
            model.DateFrom = DateTime.Now.AddDays(-360).ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            return View(model);
        }

        //public async Task<IActionResult>GetBuyerWiseOrderList(int buyerID)
        //{
        //    var listOfBuyer = dropdownService.RenderDDL( await mAC_OrderCostingInfoService.DDLOrder(buyerID));
        //    return Json(listOfBuyer);
        //}
        public async Task<IActionResult> GetKRSOrderFabricListByKrsIDAndOrderID( int orderID = 0)
        {
            try
            {
                int kRSID = 0;
                var orderFabricList = await kRS_MASTERService.GetKRSOrderFabricList(kRSID, orderID);
                return Json(orderFabricList);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }
        //IKRS_MASTERService
    }
}
