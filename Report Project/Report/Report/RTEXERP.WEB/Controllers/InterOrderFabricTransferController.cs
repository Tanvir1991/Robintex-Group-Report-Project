using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.DataTransferModel;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Controllers
{
    public class InterOrderFabricTransferController : BaseController
    {
        private readonly IDropdownService dropdownService;
        private readonly IStyleService styleService;
        private readonly IInterOrderFabricTransferService interOrderFabricTransferService;
        private readonly IFabricAdjustmentTransferTypeService fabricAdjustmentTransferTypeService;

        public InterOrderFabricTransferController(IDropdownService _dropdownService, IStyleService _styleService
            , IInterOrderFabricTransferService _interOrderFabricTransferService,
            IFabricAdjustmentTransferTypeService _fabricAdjustmentTransferTypeService)
        {
            dropdownService = _dropdownService;
            styleService = _styleService;
            interOrderFabricTransferService = _interOrderFabricTransferService;
            fabricAdjustmentTransferTypeService = _fabricAdjustmentTransferTypeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var model = new InterOrderFabricTransferVM();
            model.TransferDate = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DDLFromOrder = dropdownService.RenderDDL(await styleService.DDLOrderNumbers(),true);
            model.DDLToOrder = dropdownService.RenderDDL(await styleService.DDLOrderNumbers(6), true);
            model.DDLTransferType = dropdownService.RenderDDL(await fabricAdjustmentTransferTypeService.DDLFabricAdjustmentTransferType(), false);
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> Create(InterOrderFabricTransferDTM transferObject)
        {
            var data = await interOrderFabricTransferService.SaveInterOrderFabricTransfer(transferObject,Session_USER_ID);
            return Json(data);
        }
        public async Task<JsonResult> GetFabricTransferReceiverInfo(int orderID)
        {
            var data = await interOrderFabricTransferService.GetFabricTransferReceiverInfo(orderID);
            return Json(data);
        }
        public async Task<JsonResult> GetFabricTransferSenderInfo(int orderID)
        {
            var data = await interOrderFabricTransferService.GetFabricTransferSenderInfo(orderID);
            return Json(data);
        }
        public async Task<IActionResult> TransferedFabricInfo()
        {
            TransferedFabricInfoSearchVM model = new TransferedFabricInfoSearchVM();
            model.DDLFabricAdjustmentTransfer = await fabricAdjustmentTransferTypeService.DDLFabricAdjustmentTransferType();
            model.DDLReceiveType = new List<SelectListItem>
            {
                new SelectListItem{Text="Sender",Value="Sender" },
                new SelectListItem{Text="Receiver",Value="Receiver" },
            };
            model.DDLOrder = dropdownService.DefaultDDL();
            model.DateFrom = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            return View(model);
        }
        public async Task<JsonResult> DDLFabricTransferedFromToOrders(string receiveType,string Predict)
        {
            var data = await interOrderFabricTransferService.DDLFabricTransferedFromToOrders(DateTime.Now.AddYears(-2),DateTime.Now, receiveType,Predict);
            return Json(data);
        }

        public async Task<IActionResult> FabricGeneralAdjusted(string receiveType,int transferTypeID, long orderID,  string ReportFormat, DateTime? dateFrom, DateTime? dateTo)
        {
            var currentDate = DateTime.Now.Date;
            dateFrom = dateFrom == null ? new DateTime(currentDate.Year, currentDate.Month,1) : dateFrom;
            dateTo = dateTo == null ? currentDate : dateTo;
            string reportName = "FabricAdditionalReport";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("ReceiveType", receiveType);
            parameters.Add("TransferTypeID", transferTypeID);
            parameters.Add("OrderID", orderID);
            parameters.Add("DateFrom", dateFrom);
            parameters.Add("DateTo", dateTo);
            int connectionString = (int)enum_ServerType.MaxcoConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);
           
        }

        //
    }
}
