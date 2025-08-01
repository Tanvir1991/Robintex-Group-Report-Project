using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.Maxco.ViewModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.Maxco.Controllers
{
    [Area("Maxco")]
    public class IEOrderEfficiencyController : BaseController
    {
        private readonly IDropdownService dropdownService;
        private readonly IBuyer_SetupService buyer_SetupService;
        private readonly IStyleService styleService;
        private readonly Ivw_OrderGarmentAssortmentOrder_PantoneService ivw_OrderGarmentAssortmentOrder_PantoneService;
        private readonly IIE_OrderEfficiencyService iE_OrderEfficiencyService;
        private readonly ISFS_ProductionResourceSpecificationService sFS_ProductionResourceSpecificationService;

        public IEOrderEfficiencyController(IDropdownService _dropdownService,
            IBuyer_SetupService _buyer_SetupService, IStyleService _styleService,
            Ivw_OrderGarmentAssortmentOrder_PantoneService _ivw_OrderGarmentAssortmentOrder_PantoneService,
            IIE_OrderEfficiencyService _iE_OrderEfficiencyService,
            ISFS_ProductionResourceSpecificationService _sFS_ProductionResourceSpecificationService)
        {
            dropdownService = _dropdownService;
            buyer_SetupService = _buyer_SetupService;
            styleService = _styleService;
            ivw_OrderGarmentAssortmentOrder_PantoneService = _ivw_OrderGarmentAssortmentOrder_PantoneService;
            iE_OrderEfficiencyService = _iE_OrderEfficiencyService;
            sFS_ProductionResourceSpecificationService = _sFS_ProductionResourceSpecificationService;
        }
        public async Task<IActionResult> Index()
        {
            var model= new OrderEfficiencyViewModel();//IIE_OrderEfficiencyService
            model.DateFrom = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DateTo = DateTime.Now.ToString("dd-MMM-yyyy");
            model.IsSupperAdmin = Session_User_IsSuperAdmin;
            model.BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer());
            model.OrderList = dropdownService.DefaultDDL();
            model.StyleList = dropdownService.DefaultDDL();
            model.PantoneNoList = dropdownService.DefaultDDL();
            model.OrderEfficiency = await iE_OrderEfficiencyService.GetOrderEfficientList(DateTime.Now, DateTime.Now, 0, 0, null);
            return View(model);
        }
        public async Task<IActionResult> CreateIEOrderEfficiency()
        {
            var model = new IE_OrderEfficiencyViewModel();
            model.BuyerList= dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer());
            model.OrderList = dropdownService.DefaultDDL();
            model.StyleList = dropdownService.DefaultDDL();
            model.PantoneNoList = dropdownService.DefaultDDL();
            model.ReportDateSTR = DateTime.Now.ToString("dd-MMM-yyyy");
            model.DDLProductionLine = await sFS_ProductionResourceSpecificationService.DDLGetProductionLineNo(4);
            model.TargetEffiency = 55;
            return View(model);
        }
        public async Task<IActionResult> EditIEOrderEfficiency(int Id)
        {
            var model = new IE_OrderEfficiencyViewModel();
            model= await iE_OrderEfficiencyService.GetIEOrderEfficient(Id);
            model.BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer());
            //   model.OrderList = await styleService.DDLBuyerWiseOrder(model.BuyerID, null, null, null);
            model.OrderList = dropdownService.DefaultDDL();
            model.StyleList = await styleService.DDLOrderWiseStyle(model.OrderID);
           // var orderInfo = await styleService.GetStyleInfo(model.OrderID);
            model.ReportDateSTR = model.ReportDateSTR;
            model.PantoneNoList = await ivw_OrderGarmentAssortmentOrder_PantoneService.DDLGetOrderStyleColor(model.StyleID);
            model.DDLProductionLine = await sFS_ProductionResourceSpecificationService.DDLGetProductionLineNo(4);
         //   model.OrderNo = orderInfo.OrderNo;
            return View("CreateIEOrderEfficiency", model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateIEOrderEfficiency(IE_OrderEfficiencyViewModel iEorderEfficient)
        {
            var rResult = new RResult();
            rResult= await iE_OrderEfficiencyService.SaveIEOrderEfficiency(iEorderEfficient);
            return Json(rResult);
        }

        public async Task<IActionResult>DDLGetOrderWiseStyle(int orderID)
        {
            var listOfOrder = dropdownService.RenderDDL( await styleService.DDLOrderWiseStyleGroup(orderID),true);
            return Json(listOfOrder);
        }
        public async Task<IActionResult> DDLGetStyleWisePantonList(int styleID)
        {
            var listOfPanton = dropdownService.RenderDDL(await ivw_OrderGarmentAssortmentOrder_PantoneService.DDLGetOrderStyleColor(styleID),false);
            return Json(listOfPanton);
        }
       public async Task<IActionResult>GetIEOrderEfficeient(DateTime? dateFrom, DateTime? dateTo, int orderID, int styleID, string pantoneNo)
        {
            var data= await iE_OrderEfficiencyService.GetOrderEfficientList(dateFrom, dateTo,orderID, styleID, pantoneNo);
            return Json(data);
        }
        public async Task<IActionResult> Remove(int Id)
        {
            var result = await iE_OrderEfficiencyService.Remove(Id);
            return Json(result);
        }


        public async Task<IActionResult> OrderEfficiencyReportPage(DateTime DateFrom, DateTime DateTo, int OrderID, int StyleID, string PantoneNo, string ReportFormat)
        {
            string reportName = "IE_OrderEfficiencyAndSMV";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DateFrom", DateFrom.ToString("dd-MMM-yyyy"));
            parameters.Add("DateTo", DateTo.ToString("dd-MMM-yyyy"));
            parameters.Add("OrderID", OrderID);
            parameters.Add("StyleID", StyleID);
            parameters.Add("PantoneNo", PantoneNo);
            int connectionString = (int)enum_ServerType.MaxcoConnectionString;
            return await PrintSSRSReport(reportName, parameters, ReportFormat, connectionString);


        }
    }
}
