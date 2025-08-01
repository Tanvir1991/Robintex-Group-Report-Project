using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Areas.FiniteScheduler.Controllers
{
    [Area("FiniteScheduler")]
    public class DFS_LotDyeingDeliveryController : BaseController
    {
        private readonly IDFS_LotMakingMasterService _dfs_LotMakingMaster;
        private readonly IDropdownService _dropdownService;
        private IDFS_LotDyeingDeliveryService _dFS_LotDyeingDeliveryService;

        public DFS_LotDyeingDeliveryController(IDFS_LotMakingMasterService dfs_LotMakingMaster, IDropdownService dropdownService
            ,IDFS_LotDyeingDeliveryService dFS_LotDyeingDeliveryService)
        {
            _dfs_LotMakingMaster = dfs_LotMakingMaster;
            _dropdownService = dropdownService;
            _dFS_LotDyeingDeliveryService = dFS_LotDyeingDeliveryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            DFS_LotDyeingDeliveryVM model = new DFS_LotDyeingDeliveryVM();
            
            model.DDLLot = _dropdownService.RenderDDL(await _dfs_LotMakingMaster.DDLLot(DateTime.Now.AddMonths(-3),DateTime.Now), true);
            return View(model);
        }
        public async Task<JsonResult> SaveLotDyeing(DFS_LotDyeingDeliveryVM model)
        {
            RResult oResult = new RResult();
            if (ModelState.IsValid == false)
            {
                oResult.result = 0;
                oResult.message = "Data is not valid";
                return Json(oResult);
            }
            if (model.ID == 0)
            {
                model.UserID = Session_USER_ID;
                oResult = await _dFS_LotDyeingDeliveryService.Insert(model);
            }
            else if (model.ID > 0 && model.UIDeleted==false)
            {
                model.UserID = Session_USER_ID;
                oResult =await _dFS_LotDyeingDeliveryService.Update(model);
            }
            else if (model.ID > 0 && model.UIDeleted==true)
            {
                model.UserID = Session_USER_ID;
                oResult = await _dFS_LotDyeingDeliveryService.Remove(model);
            } 

            return Json(oResult);
            
        }

        public async Task<JsonResult> GetDeliveryLot(DateTime DateFrom,DateTime DateTo)
        {
            var getLotDeliveryDetails =await _dFS_LotDyeingDeliveryService.GetLotDyeingDelivery(DateFrom, DateTo);
            return Json(getLotDeliveryDetails);

        }
    }
}
