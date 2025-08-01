using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.MaterialsManagement.Controllers
{
    [Area("MaterialsManagement")]
    public class POSearchController : Controller
    {
        private readonly IStyleService styleService;
        private readonly IDD_PurchaseOrderService dD_PurchaseOrderService;
        private readonly IDropdownService dropdownService;

        public POSearchController(IStyleService _styleService, IDD_PurchaseOrderService _dD_PurchaseOrderService, IDropdownService _dropdownService)
        {
            styleService = _styleService;
            dD_PurchaseOrderService = _dD_PurchaseOrderService;
            dropdownService = _dropdownService;
        }



        public async Task<IActionResult> Index()
        {
            POSearchViewModel model = new POSearchViewModel();

            model.DDDLOrder = dropdownService.RenderDDL(await styleService.DDLBuyerWiseOrder(0, DateTime.Now.AddMonths(-3), DateTime.Now));
            model.DDLPO = dropdownService.RenderDDL(await dD_PurchaseOrderService.DDLPurchaseOrder(0, DateTime.Now.AddMonths(-3), DateTime.Now));
            model.DDLStatus = dropdownService.RenderDDL(await dD_PurchaseOrderService.DDLPurchaseOrderStatus());
            return View(model);
        }

        public async Task<IActionResult> ShowPO(int POID,int IsShowStyleSizeWiseQuantity)
        {
            var rtnModel = await dD_PurchaseOrderService.GetPOReport(POID, IsShowStyleSizeWiseQuantity);
            rtnModel.ShowStyleWise = IsShowStyleSizeWiseQuantity;
            return View(rtnModel);
        }

        


        #region Json

        public async Task<JsonResult> GetOrderPOList(int OrderID = 0, int POID = 0, DateTime? PODateFrom = null, DateTime? PODateTo = null, int StatusID = 0)
        {
            var list = await dD_PurchaseOrderService.GetOrderPOList(OrderID, POID, PODateFrom, PODateTo, StatusID);
            return Json(list);
        }

        #endregion
    }
}
