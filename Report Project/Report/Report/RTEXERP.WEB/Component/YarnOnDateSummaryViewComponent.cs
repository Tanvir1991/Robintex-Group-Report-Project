using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Component
{
    public class YarnOnDateSummaryViewComponent : ViewComponent
    {
        public readonly IYarnBalanceService yarnBalanceService;
        public readonly IBasicCOAService basicCOAService;
        public YarnOnDateSummaryViewComponent(IYarnBalanceService yarnBalanceService, IBasicCOAService basicCOAService)
        {
            this.yarnBalanceService = yarnBalanceService;
            this.basicCOAService = basicCOAService;
        }
        public async Task<IViewComponentResult> InvokeAsync(YarnStockModel entity)
        {
            RResult<DataTable> rResult = new RResult<DataTable>();
            var co = await basicCOAService.ChartOfAccounts(1, 1);
            var yarnBalance =yarnBalanceService.YarnSummaryCompositionWise(entity.TransactionDate, entity.CompanyID);
            rResult.modelObject = yarnBalance;
            rResult.statusCode = entity.CompanyID;
            rResult.statusMsg = entity.TransactionDate.ToString("dd-MMM-yyyy");
            return View("YarnOnDateSummaryVC", rResult);

        }
        }
}
