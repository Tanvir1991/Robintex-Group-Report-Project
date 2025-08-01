using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using RTEXERP.WEB.Helper;

namespace RTEXERP.WEB.Controllers
{
    public class LotWiseCuttingController : BaseController
    {
        private readonly IDropdownService dropdownService;
        private readonly ILotWiseCuttingInfoService lotWiseCuttingInfoService;
        private readonly Ivw_OrderLotFinishQuantityService vw_OrderLotFinishQuantityService;
        private readonly IMarkerCuttingPlanMaster_ExcelService markerCuttingPlanMaster_ExcelService;
        private readonly IMarkerCuttingSizes_ExcelService markerCuttingSizes_ExcelService;
        private readonly Ivw_OrderLotConfirmQuantityService _vw_OrderLotConfirmQuantityService;
        public LotWiseCuttingController(IDropdownService dropdownService, ILotWiseCuttingInfoService lotWiseCuttingInfoService
            , Ivw_OrderLotFinishQuantityService vw_OrderLotFinishQuantityService
            , IMarkerCuttingPlanMaster_ExcelService markerCuttingPlanMaster_ExcelService
            , IMarkerCuttingSizes_ExcelService markerCuttingSizes_ExcelService
            , Ivw_OrderLotConfirmQuantityService vw_OrderLotConfirmQuantityService)
        {
            this.dropdownService = dropdownService;
            this.lotWiseCuttingInfoService = lotWiseCuttingInfoService;
            this.vw_OrderLotFinishQuantityService = vw_OrderLotFinishQuantityService;
            this.markerCuttingPlanMaster_ExcelService = markerCuttingPlanMaster_ExcelService;
            this.markerCuttingSizes_ExcelService = markerCuttingSizes_ExcelService;
            _vw_OrderLotConfirmQuantityService = vw_OrderLotConfirmQuantityService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new LotWiseCuttingInfoViewModel();
            model.OrderList = dropdownService.RenderDDL(await lotWiseCuttingInfoService.GetDDLOrderListForLotWiseCutting(), true);
            model.LotList = dropdownService.DefaultDDL();
            model.MarkerList = dropdownService.DefaultDDL();
            model.ColorList = dropdownService.DefaultDDL();
            return View(model);
        }

        public async Task<IActionResult> LotWiseCuttingStatus()
        {
            var model = new LotWiseCuttingStatusViewModel();
            model.OrderList = dropdownService.RenderDDL(await lotWiseCuttingInfoService.GetDDLOrderListForLotWiseCutting(), true);
            model.ColorList = dropdownService.DefaultDDL();
            return View(model);
        }
        public async Task<IActionResult> LotWiseCuttingStatusSearch()
        {
            var model = new LotWiseCuttingStatusViewModel();
            model.OrderList = dropdownService.RenderDDL(await lotWiseCuttingInfoService.GetDDLOrderListForLotWiseCutting(), true);
            model.ColorList = dropdownService.DefaultDDL();
           
            return View(model);
        }
        public IActionResult LotWiseCuttingStatusReport(string orderNo, string color,int? MarkerCuttingPlanMaster_ExcelID)
        {
            int MarkerCuttingPlanMaster = 0;
            var model = new LotWiseCuttingStatusViewModel();
            model.OrderNo = orderNo;
            model.Color = color;

            if (MarkerCuttingPlanMaster_ExcelID.HasValue)
            {
                MarkerCuttingPlanMaster = MarkerCuttingPlanMaster_ExcelID.Value;
            }

            model.MarkerCuttingPlanMaster_ExcelID = MarkerCuttingPlanMaster;
            return View(model);
        }
        public async Task<IActionResult> ConsumptionSheet()
        {
            var model = new LotWiseCuttingStatusViewModel();
            model.OrderList = dropdownService.RenderDDL(await lotWiseCuttingInfoService.GetDDLOrderListForLotWiseCutting(), true);
            model.ColorList = dropdownService.DefaultDDL();
            return View(model);
        }
        public async Task<IActionResult> ConsumptionSheetSearch()
        {
            var model = new LotWiseCuttingStatusViewModel();
            model.OrderList = dropdownService.RenderDDL(await lotWiseCuttingInfoService.GetDDLOrderListForLotWiseCutting(), true);
            model.ColorList = dropdownService.DefaultDDL();
            return View(model);
        }
        public async Task<IActionResult> ConsumptionSheetReport(long orderID, string orderNo, string color, int? MarkerCuttingPlanMaster_ExcelID)
        {
            var model = new LotWiseCuttingStatusViewModel();
            model.OrderID = orderID;
            model.OrderNo = orderNo;
            model.Color = color;
            int MarkerCuttingPlanMaster = 0;
            if (MarkerCuttingPlanMaster_ExcelID.HasValue)
            {
                MarkerCuttingPlanMaster = MarkerCuttingPlanMaster_ExcelID.Value;
            }
            model.MarkerCuttingPlanMaster_ExcelID = MarkerCuttingPlanMaster;
            return View(model);
        }
        public async Task<IActionResult> ConsumptionSheetUpdate()
        {
            var model = new LotWiseCuttingStatusViewModel();
            model.OrderList = dropdownService.RenderDDL(await lotWiseCuttingInfoService.GetDDLOrderListForLotWiseCutting(), true);
            model.ColorList = dropdownService.DefaultDDL();
            return View(model);
        }
        

        #region Json Function
        public async Task<JsonResult> GetDDLOrderWiseLot(int orderID, string color)
        {
            var lotList = dropdownService.RenderDDL(await vw_OrderLotFinishQuantityService.GetDDLOrderWiseLot(orderID, color), true);
            return Json(lotList);
        }
        public async Task<JsonResult> GetDDLOrderWiseConfirmLot(int orderID, string color)
        {
            var lotList = dropdownService.RenderDDL(await _vw_OrderLotConfirmQuantityService.GetDDLOrderWiseLot(orderID, color), true);
            return Json(lotList);
        }
        public async Task<JsonResult> GetDDLOrderWiseColor(string orderNo)
        {
            var lotList = dropdownService.RenderDDL(await markerCuttingPlanMaster_ExcelService.DDLOrderWiseColor(orderNo), true);
            return Json(lotList);
        }
        public async Task<JsonResult> DDLOrderWiseColorCustome(string orderNo)
        {
            var lotList = dropdownService.RenderDDLCustome(await markerCuttingPlanMaster_ExcelService.DDLOrderWiseColorCustome(orderNo), true);
            return Json(lotList);
        }
        public async Task<JsonResult> DDLOrderWiseMarker(string orderNo)
        {
            var lotList = dropdownService.RenderDDL(await markerCuttingPlanMaster_ExcelService.DDLOrderWiseMarker(orderNo), true);
            return Json(lotList);
        }
        public async Task<JsonResult> GetOrderWiseLotFinishQuantity(int orderID, long lotID)
        {
            var lotDetail = await vw_OrderLotFinishQuantityService.GetOrderWiseLotFinishQuantity(orderID, lotID);
            return Json(lotDetail);
        }
        public async Task<JsonResult> GetMarkerCuttingSizesByOrder(string orderNo, string color,int? MarkerCuttingPlanMaster_ExcelID)
        {
            int _MarkerCuttingPlanMaster_ExcelID = 0;
            if (MarkerCuttingPlanMaster_ExcelID.HasValue == true)
            {
                _MarkerCuttingPlanMaster_ExcelID = MarkerCuttingPlanMaster_ExcelID.Value;
            }
            var markerList = await markerCuttingSizes_ExcelService.GetMarkerCuttingSizesExcel_ByOrder(orderNo, color, _MarkerCuttingPlanMaster_ExcelID);
            return Json(markerList);
        }
        public async Task<JsonResult> GetMarkerShortCuttingSizesByOrder(string orderNo, string pantoneNo, int quantity)
        {
            var markerList = await markerCuttingSizes_ExcelService.GetMarkerShortCuttingSizesExcel_ByOrder(orderNo,  pantoneNo,  quantity);
            return Json(markerList);
        }
        [HttpPost]
        public async Task<JsonResult> LotWiseCuttingInfoSave(LotWiseCuttingInfoViewModel cuttingInfo)
        {
            cuttingInfo.IsActive = true;
            cuttingInfo.IsRemoved = false;
            cuttingInfo.CreatedBy = SessionData.Session_USER_ID;
            cuttingInfo.CreatedDate = DateTime.Now;
            cuttingInfo.LotWiseCuttingInfoMarkers.ForEach(x =>
            {
                x.IsActive = true; x.IsRemoved = false; x.CreatedBy = SessionData.Session_USER_ID; x.CreatedDate = DateTime.Now;
                x.LotWiseCuttingInfoMarkersSizes.ForEach(s => { s.IsActive = true; s.IsRemoved = false; s.CreatedBy = SessionData.Session_USER_ID; s.CreatedDate = DateTime.Now; });
            });
            cuttingInfo.LotWiseShortCuttingInfo.ForEach(c => { c.IsActive = true; c.IsRemoved = false; c.CreatedBy = SessionData.Session_USER_ID; c.CreatedDate = DateTime.Now; });
            var rResult = await lotWiseCuttingInfoService.Save(cuttingInfo);
            return Json(rResult);
        }
        public async Task<JsonResult> GetLotWiseCuttingStatus(string orderNo, string color,int? MarkerCuttingPlanMaster_ExcelID)
        {
            int MarkerCuttingPlanMaster = 0;
            if (MarkerCuttingPlanMaster_ExcelID.HasValue == true)
            {
                MarkerCuttingPlanMaster = MarkerCuttingPlanMaster_ExcelID.Value;
            }
            var data = await lotWiseCuttingInfoService.GetLotWiseCuttingStatus(orderNo, color, MarkerCuttingPlanMaster);
            return Json(data);
        }
        public async Task<JsonResult> LotWiseCuttingInfoUpdate(ConsumptionSheetUpdateViewModel updateModel)
        {
            var rResult = await markerCuttingPlanMaster_ExcelService.LotWiseCuttingInfoUpdate(updateModel);

            return Json(rResult);
        }

        public async Task<JsonResult> GetConsumptionSheetInfo(long orderID,string orderNo, string color,int? MarkerCuttingPlanMasterExcel_ID)
        {
            int MarkerCuttingPlanMaster = 0;
            if (MarkerCuttingPlanMasterExcel_ID.HasValue)
            {
                MarkerCuttingPlanMaster = MarkerCuttingPlanMasterExcel_ID.Value;
            }
            var data = await lotWiseCuttingInfoService.GetConsumptionSheetInfo(orderID,orderNo, color, MarkerCuttingPlanMaster);
            return Json(data);
        }
        public async Task<JsonResult> GetConsumptionSheetReport(long orderID, string orderNo, string color,int? MarkerCuttingPlanMasterExcel_ID)
        {
            int MarkerCuttingPlanMaster = 0;
            if (MarkerCuttingPlanMasterExcel_ID.HasValue)
            {
                MarkerCuttingPlanMaster = MarkerCuttingPlanMasterExcel_ID.Value;
            }
            var data = await lotWiseCuttingInfoService.GetConsumptionSheetInfo(orderID, orderNo, color, MarkerCuttingPlanMaster);
            
            return Json(data);
        }
        public async Task<JsonResult> DeleteLotInfo(long orderId, string color, int lotId, decimal lotQuantity)
        {
            var data = await lotWiseCuttingInfoService.DeleteLotInfo(orderId, color,lotId,lotQuantity,Session_USER_ID);
            return Json(data);
        }

        public async Task<JsonResult> GetLotWiseCuttingStatusSearchResult(string dateFrom, string dateTo,string orderNo ,string color,int? MarkerCuttingPlanMaster_ExcelID)
        {
            dateTo = dateTo == null ? dateFrom : dateTo;
            dateFrom = dateFrom == null ? dateTo : dateFrom;
            int MarkerCuttingPlanMaster = 0;
            if (MarkerCuttingPlanMaster_ExcelID.HasValue)
            {
                MarkerCuttingPlanMaster = MarkerCuttingPlanMaster_ExcelID.Value;
            }
            var data = await lotWiseCuttingInfoService.GetLotWiseCuttingStatusSearchResult(dateFrom, dateTo, orderNo, color, MarkerCuttingPlanMaster);
            return Json(data);
        }

        #endregion Json Function
    }
}
