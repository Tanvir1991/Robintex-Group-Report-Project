using Microsoft.AspNetCore.Mvc;
using RTEXERP.Common.Constants;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Controllers
{
    public class FabricBookingController : BaseController
    {
        private readonly IDropdownService dropdownService;
        private readonly IBuyer_SetupService buyer_SetupService;
        private readonly IFabricBookingMasterService fabricBookingMasterService;
        private readonly IFabricBookingService fabricBookingService;

        public FabricBookingController(IDropdownService _dropdownService, IBuyer_SetupService _buyer_SetupService, IFabricBookingMasterService _fabricBookingMasterService
            ,IFabricBookingService _fabricBookingService)
        {
            dropdownService = _dropdownService;
            buyer_SetupService = _buyer_SetupService;
            fabricBookingMasterService = _fabricBookingMasterService;
            fabricBookingService = _fabricBookingService;
        }
        public async Task<ActionResult> Test()
        {
            var model = new FabricBookingMasterViewModel();
            model.BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer());
            model.OrderList = dropdownService.DefaultDDL();
            return View(model);
        }
        public async Task<IActionResult> Index()
        {
            var model = new FabricBookingMasterViewModel();
            model.BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer());
            model.OrderList = dropdownService.DefaultDDL();
            return View(model);
        }
        public async Task<IActionResult> Create(int? FabricBookingID=0,int ? OrderID=0)
        {
            var model = new FabricBookingMasterViewModel();
            model.BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer());
            if (FabricBookingID==0 && OrderID==0)
            {                
                model.OrderList = dropdownService.DefaultDDL();
                model.StyleList = dropdownService.DefaultDDL();
            }
            else
            {
                var entity = await fabricBookingService.GetFabticBookingMasterByBookingID(FabricBookingID.Value);
                model.FabricBookingID = FabricBookingID.Value;
                model.BuyerID = entity.BuyerID;
                model.OrderID = entity.OrderID;
                model.DeliveryStartDateMsg = entity.DeliveryStartDate.ToString("dd-MMM-yyyy");
                model.DeliveryEndDateMsg = entity.DeliveryEndDate.ToString("dd-MMM-yyyy");
                model.Reference = entity.Reference;
                model.SpecialInstruction = entity.SpecialInstruction;
                model.RevisionReason = entity.RevisionReason;
            }        
            
            return View(model);
        }

        public async Task<ActionResult> BookingVersions(int FabricBookingID, int OrderID)
        {
            var data = new List<FabricBookingVersionViewModel>();
            if (FabricBookingID>0 && OrderID>0)
            {
                data = await fabricBookingService.FabricBookingVersions(FabricBookingID, OrderID);
            }
            return View(data);
        }

        public async Task<IActionResult> FabricBookingReport(int FabricBookingID, int BookingMasterID, string ReportFormat)
        {
            try
            {
                string reportName = "FabricBookingVersions";
                IDictionary<string, object> parameters = new Dictionary<string, object>();                
                parameters.Add("FabricBookingID", FabricBookingID);
                parameters.Add("BookingMasterID", BookingMasterID);                
                int connectionString = (int)enum_ServerType.MaxcoConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> GetSearchedData(List<int> StyleIDList)
        {
            var data = await fabricBookingMasterService.GETFRSFabricFullDataForBooking(StyleIDList);
            return Json(data);
        }        
        public async Task<JsonResult> DDLOrderWiseStyleForFabricBooking(int OrderID,int? FabricBookingID=0)
        {
            var Orderlist = await fabricBookingService.DDLOrderWiseStyleForFabricBooking(OrderID, FabricBookingID);
            var returnOrderList = dropdownService.RenderDDL(Orderlist, false);
            return Json(returnOrderList);
        }
        [HttpPost]
        public async Task<JsonResult> FabricBookingSave(FabricBookingViewModel fabricBooking)
        {
            var data = await fabricBookingService.FabricBookingSave(fabricBooking,Session_USER_ID,true);
            return Json(data);
        }
        public async Task<JsonResult> GetFabricBookingList(int OrderID = 0, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            var data = await fabricBookingService.GetFabricBookingList(OrderID,DateFrom,DateTo);
            return Json(data);
        }

    }
}
