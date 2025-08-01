using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Component
{
    
    public class FinishFabricStockViewComponent : ViewComponent
    {
        private readonly IALLFiniteSchedulerReportService aLLFiniteSchedulerReportService;
        public FinishFabricStockViewComponent(IALLFiniteSchedulerReportService _aLLFiniteSchedulerReportService)
        {
            aLLFiniteSchedulerReportService=_aLLFiniteSchedulerReportService;            
        }
        public async Task<IViewComponentResult> InvokeAsync(FabricStockReport entity)
        {
           List<FabricStockReportSPModel> rResult = new List<FabricStockReportSPModel>();
            rResult = await aLLFiniteSchedulerReportService.GetFinishFabricStockList(entity.DateTo);
            rResult.ForEach(x => { x.DateTo = entity.DateTo; });
            return View("FinishFabricStockVC", rResult);

        }
    }
}
