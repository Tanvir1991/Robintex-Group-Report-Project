using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    public class Tbl_KnittingMachinesController : Controller
    {
        private readonly ITbl_KnittingMachinesService _tbl_KnittingMachinesService;
        private readonly IDropdownService _dropdownService;
        public Tbl_KnittingMachinesController(ITbl_KnittingMachinesService tbl_KnittingMachinesService, IDropdownService dropdownService)
        {
            _tbl_KnittingMachinesService = tbl_KnittingMachinesService;
            _dropdownService = dropdownService;
        }
        public IActionResult Index()
        {
            return View();
        }



        #region Json

        public async Task<JsonResult> GetDDLMachine(int CompanyID=0)
        {
            var data = await _tbl_KnittingMachinesService.DDLMachine(CompanyID);
            var rdata = _dropdownService.RenderDDL(data, true);
            rdata[0].Value = "-1";
            return Json(rdata);
        }

        #endregion
    }
}
