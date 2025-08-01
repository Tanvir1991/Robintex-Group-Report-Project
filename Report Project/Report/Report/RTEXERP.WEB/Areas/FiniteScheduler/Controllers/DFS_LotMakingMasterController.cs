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
    public class DFS_LotMakingMasterController : Controller
    {
        private readonly IDFS_LotMakingMasterService _dfs_LotMakingMaster;
        private readonly IDropdownService _dropdownService;
        public DFS_LotMakingMasterController(IDropdownService dropdownService, IDFS_LotMakingMasterService dfs_LotMakingMaster)
        {
            _dropdownService = dropdownService;
            _dfs_LotMakingMaster = dfs_LotMakingMaster;
        }
        public async Task<JsonResult> DDLLot(string Predict = null,bool IsShowDefault=false)
        {
           var data = _dropdownService.RenderDDL(await _dfs_LotMakingMaster.DDLLot(DateTime.Now.AddMonths(-12), DateTime.Now, Predict), IsShowDefault);
            return Json(data);
        }

        public async Task<JsonResult> DDLLotRequisition(string Predict = null,long OrderID = 0, bool IsShowDefault = false)
        {
            var data = _dropdownService.RenderDDL(await _dfs_LotMakingMaster.DDLLotRequisition(DateTime.Now.AddMonths(-12), DateTime.Now, Predict,OrderID), IsShowDefault);
            return Json(data);
        }
    }
}
