using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using RTEXERP.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    [Route("FiniteScheduler/[controller]/[action]")]
    public class LotCuttingController : BaseController
    {
        private readonly ITbl_cutting_part_okService tbl_Cutting_Part_OkService;
        private readonly IDropdownService dropdownService;
        private readonly ITbl_Cutting_Defect_LotService tbl_Cutting_Defect_LotService;

        public LotCuttingController(ITbl_cutting_part_okService _tbl_Cutting_Part_OkService, IDropdownService _dropdownService,
            ITbl_Cutting_Defect_LotService _tbl_Cutting_Defect_LotService)
        {
            tbl_Cutting_Part_OkService = _tbl_Cutting_Part_OkService;
            dropdownService = _dropdownService;
            tbl_Cutting_Defect_LotService = _tbl_Cutting_Defect_LotService;
        }
        public async Task<IActionResult> Defect()
        {
            var model = new Tbl_Cutting_Defect_LotViewModel();
            model.LotList = dropdownService.RenderDDL(await tbl_Cutting_Part_OkService.DDLLotForCuttingDefect(3));
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> SaveCutting_Defect_Lot(Tbl_Cutting_Defect_Lot entity)
        {
            entity.CreatedBy = Session_USER_ID;
            var result = await tbl_Cutting_Defect_LotService.SaveCutting_Defect_Lot(entity);
            return Json(result);
        }
        public async Task<JsonResult> RemoveCutting_Defect_Lot(int id)
        {
            var result = await tbl_Cutting_Defect_LotService.RemoveCutting_Defect_Lot(id,Session_USER_ID);
            return Json(result);
        }
        public async Task<JsonResult> GetDefectLot(DateTime? dateFrom, DateTime? dateTo)
        {
            var data = await tbl_Cutting_Defect_LotService.GetDefectLotList(dateFrom, dateTo);
            return Json(data);
        }
    }
}
