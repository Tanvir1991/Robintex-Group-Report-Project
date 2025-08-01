using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.Maxco;

namespace RTEXERP.WEB.Controllers
{
    public class MerchandisingOrderCostingController : BaseController
    {
        private IDropdownService dropdownService;
        private readonly IFabricType_SetupService fabricType_SetupService;
        private readonly IFabricQuality_SetupService fabricQuality_SetupService;
        private readonly IMAC_OrderCostingInfoService mAC_OrderCostingInfoService;
        private readonly IBuyer_SetupService buyer_SetupService;
        private readonly IMaxcoDDLService maxcoDDLService;

        public MerchandisingOrderCostingController(IDropdownService dropdownService, IMAC_OrderCostingInfoService mAC_OrderCostingInfoService
            , IFabricQuality_SetupService fabricQuality_SetupService, IFabricType_SetupService fabricType_SetupService, IBuyer_SetupService buyer_SetupService
            , IMaxcoDDLService maxcoDDLService)
        {
            this.dropdownService = dropdownService;
            this.mAC_OrderCostingInfoService = mAC_OrderCostingInfoService;
            this.fabricQuality_SetupService = fabricQuality_SetupService;
            this.fabricType_SetupService = fabricType_SetupService;
            this.buyer_SetupService = buyer_SetupService;
            this.maxcoDDLService = maxcoDDLService;

        }
        public async Task<IActionResult> OrderCosting()
        {
            MAC_OrderCostingInfoVM model = new MAC_OrderCostingInfoVM();
            model.DDLBuyer = await buyer_SetupService.DDLBuyer();
            model.DDLFabricType =dropdownService.RenderDDL(await fabricType_SetupService.DDLFabricType());
            model.DDLQuality = dropdownService.DefaultDDL();
            model.DDLYarnCount = await maxcoDDLService.DDLYarnCountValue(0);
            model.DDLTrim = dropdownService.RenderDDL(await maxcoDDLService.DDLTrims());
            model.InderectCostingItemList = await mAC_OrderCostingInfoService.GetIndirectCostingItem();
            model.CostingDate = DateTime.Now;
            return View(model);
        }

        public async Task<JsonResult> OrderCostingSave(MAC_OrderCostingInfoVM model)
        {
            RResult rResult = new RResult();

            if (ModelState.IsValid)
            {
                model.OrderNo = model.OrderNo.Trim();
                model.CostingDate = DateTime.Now;
                model.Code = $"{model.OrderNo}_{model.StyleName}";

                rResult = await mAC_OrderCostingInfoService.OrderCostingSave(model, Session_USER_ID);
            }
            else
            {
                rResult.result = 0;
                rResult.message = "Data Format is not correct.";
            }

            return Json(rResult);

        }
        public async Task<JsonResult> OrderCostingUpdate(MAC_OrderCostingInfoVM model)
        {
            RResult rResult = new RResult();

            if (ModelState.IsValid)
            {
                model.CostingDate = DateTime.Now;
                model.Code = $"{model.OrderNo}_{model.StyleName}";

                rResult = await mAC_OrderCostingInfoService.OrderCostingUpdate(model, Session_USER_ID);
            }
            else
            {
                rResult.result = 0;
                rResult.message = "Data Format is not correct.";
            }

            return Json(rResult);

        }
        
        public async Task<IActionResult> Index()
        {
            MAC_OrderCostingListVM model = new MAC_OrderCostingListVM();
            model.DateFromSTR = DateTime.Now.AddMonths(-2).ToString("dd-MMM-yyyy");
            model.DateToSTR = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DDLBuyer =dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer());
            model.DDLOrder = dropdownService.DefaultDDL();
            model.DDLStyle = dropdownService.DefaultDDL();
            return View(model);
        }
        public async Task<IActionResult> InactiveCostingList()
        {
            MAC_OrderCostingListVM model = new MAC_OrderCostingListVM();
            model.DateFromSTR = DateTime.Now.AddMonths(-2).ToString("dd-MMM-yyyy");
            model.DateToSTR = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DDLBuyer = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer());
            model.DDLOrder = dropdownService.DefaultDDL();
            model.DDLStyle = dropdownService.DefaultDDL();
            return View(model);
        }

        public async Task<JsonResult> DDLCostingOrder(int BuyerID)
        {
            var data = dropdownService.RenderDDL(await mAC_OrderCostingInfoService.DDLOrder(BuyerID));
            return Json(data);
        }
        public async Task<JsonResult> DDLCostingOrderStyle(string OrderNo)
        {
            var data = await mAC_OrderCostingInfoService.DDLStyle(OrderNo);
            return Json(data);
        }
        public async Task<JsonResult> MAC_GetOrderCostingList(int OrderCostingID = 0, int BuyerID = 0,string OrderNo=null, string StyleName = null, string FabricInfo = null, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            var data = await mAC_OrderCostingInfoService.MAC_GetOrderCostingList(OrderCostingID, BuyerID, OrderNo, StyleName, FabricInfo, DateFrom, DateTo);
            //foreach (var item in data)
            //{
            //    var a = item.FabricInfo.Replace("&gt ;", ">").Replace("&lt ;", "<");
            //}
            return Json(data);
        }
        public async Task<JsonResult> MAC_GetInactiveOrderCostingList(int OrderCostingID = 0, int BuyerID = 0, string OrderNo = null, string StyleName = null, string FabricInfo = null, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            var data = await mAC_OrderCostingInfoService.MAC_GetInaciveOrderCostingList(OrderCostingID, BuyerID, OrderNo, StyleName, FabricInfo, DateFrom, DateTo);
            return Json(data);
        }
        
        public async Task<IActionResult> CloneCosting(int ID)
        {
            MAC_OrderCostingInfoVM model = new MAC_OrderCostingInfoVM();
            model = await mAC_OrderCostingInfoService.GetOrderCostingInfoByIDForClone(ID);
            model.DDLBuyer = await buyer_SetupService.DDLBuyer();
            model.DDLFabricType = dropdownService.RenderDDL(await fabricType_SetupService.DDLFabricType());
            model.DDLQuality = dropdownService.DefaultDDL();
            model.DDLYarnCount = await maxcoDDLService.DDLYarnCountValue(0);
            model.DDLTrim = dropdownService.RenderDDL(await maxcoDDLService.DDLTrims());
            model.InderectCostingItemList = await mAC_OrderCostingInfoService.GetIndirectCostingItem();
            
            model.CostingDate = DateTime.Now;
            model.OrderNo = "";
            model.ID = 0;
            return View(model);
        }

     //   [Authorize(Roles = "S Admin,Business Co Admin")]
        public async Task<IActionResult> CostingSheetEdit(int ID)
        {
            //var dd = SessionData.UserMenuList.Where(b => b.IsMenuItem == true).ToList()

            MAC_OrderCostingInfoVM model = new MAC_OrderCostingInfoVM();
            model = await mAC_OrderCostingInfoService.GetOrderCostingInfoByIDForClone(ID);
            model.DDLBuyer = await buyer_SetupService.DDLBuyer();
            model.DDLFabricType = dropdownService.RenderDDL(await fabricType_SetupService.DDLFabricType());
            model.DDLQuality = dropdownService.DefaultDDL();
            model.DDLYarnCount = await maxcoDDLService.DDLYarnCountValue(0);
            model.DDLTrim = dropdownService.RenderDDL(await maxcoDDLService.DDLTrims());
            model.InderectCostingItemList = await mAC_OrderCostingInfoService.GetIndirectCostingItem();

            var costingData = (await mAC_OrderCostingInfoService.MAC_GetOrderCostingList(ID, 0, model.OrderNo)).FirstOrDefault();
            if(costingData.IsInsertedAlgo==0 || (User.Identity.Name == "SuperAdmin" || User.Identity.Name== "sharif"))
            {
                return View("CloneCosting", model);
            }
            else
            {
                return View("/Page/Identity/Account/AccessDenied");
            }

        }

        [HttpPost]
        public async Task<JsonResult> RemoveCostingSheet(int ID,string Remarks)
        {
            RResult rResult = new RResult();
            var costingData = (await mAC_OrderCostingInfoService.MAC_GetOrderCostingList(ID)).FirstOrDefault();
            if (costingData.IsInsertedAlgo == 0 || (User.Identity.Name == "SuperAdmin" || User.Identity.Name == "sharif"))
            {
                rResult = await this.mAC_OrderCostingInfoService.RemoveCostingSheet(ID, Remarks, Session_USER_ID);
            }
            else
            {
                rResult.result = 0;
                rResult.message = "your are not valid user.";
            }
            return Json(rResult);
        }


  

        #region Report
        public async Task<IActionResult> OrderCostingReport(int ID, string ReportFormat,int Removed=0)
        {
            try
            {
                string reportName = "Merchandisingassessmentcost";

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("OrderCostingID", ID);
                parameters.Add("Removed", Removed);
                int connectionString = (int)enum_ServerType.MaxcoConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
