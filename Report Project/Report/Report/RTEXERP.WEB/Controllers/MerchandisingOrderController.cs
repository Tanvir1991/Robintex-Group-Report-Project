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
    public class MerchandisingOrderController : BaseController
    {
        private readonly IBuyer_SetupService buyer_SetupService;
        private readonly IDropdownService dropdownService;
        private readonly IMer_StyleMasterService mer_OrderMasterService;
        private readonly IMER_ZoneService mER_ZoneService;
        private readonly ISeason_SetupService season_SetupService;

        public MerchandisingOrderController(IBuyer_SetupService _buyer_SetupService
            ,IDropdownService _dropdownService
            , IMer_StyleMasterService _mer_OrderMasterService
            ,IMER_ZoneService _mER_ZoneService
            ,ISeason_SetupService _season_SetupService
            )
        {
            buyer_SetupService = _buyer_SetupService;
            dropdownService = _dropdownService;
            mer_OrderMasterService = _mer_OrderMasterService;
            mER_ZoneService = _mER_ZoneService;
            season_SetupService = _season_SetupService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var model = new Mer_StyleMasterVM() {

                BuyerList = dropdownService.RenderDDL(await buyer_SetupService.DDLBuyer()),

                ZoneList = dropdownService.RenderDDLCustome(await mER_ZoneService.DDLZone(),true),

                SeasonList = dropdownService.RenderDDLCustome(await season_SetupService.DDLSeason(),true),

                NoList = dropdownService.NumberDDL(1, 20, false)

            };

            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> OrderSave(Mer_StyleMasterVM orderMaster)
        {
            RResult rResult = new RResult();
            rResult = await mer_OrderMasterService.OrderMasterSave(orderMaster, Session_USER_ID);
            return Json(rResult);
        }

        public async Task<ActionResult> Report()
        {
            var model = new Mer_StyleMasterVM()
            {
                DateFrom=DateTime.Now.AddMonths(-1).ToString("dd-MMM-yyyy"),
                DateTo= DateTime.Now.ToString("dd-MMM-yyyy"),
                ZoneList= dropdownService.RenderDDLCustome(await mER_ZoneService.DDLZone(), true)
            };
            return View(model);
        }
        public async Task<JsonResult> GetMerOrderShipment(int ZoneID = 0, string StyleNo = "", DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            StyleNo= StyleNo ==null? "": StyleNo;
            var data = await mer_OrderMasterService.GetMerOrderShipment(ZoneID,StyleNo,DateFrom,DateTo);
            return Json(data);
        }
        public async Task<IActionResult> PrintReport(int ZoneID = 0, string StyleNo = "", DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            try
            {
                string reportName = "Get_MerOrderShipment";

                IDictionary<string, object> parameters = new Dictionary<string, object>();

                StyleNo = StyleNo == null ? "" : StyleNo;
                parameters.Add("ZoneID", ZoneID);
                parameters.Add("StyleNo", StyleNo);
                parameters.Add("DateFrom", DateFrom);
                parameters.Add("DateTo", DateTo);   
                int connectionString = (int)enum_ServerType.MaxcoConnectionString;
                return await PrintSSRSReport(reportName, parameters, ReportExportFormat.PdfFormat, connectionString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
