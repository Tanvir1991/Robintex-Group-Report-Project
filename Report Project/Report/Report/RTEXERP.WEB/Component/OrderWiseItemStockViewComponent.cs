using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Component
{
    //public class OrderWiseItemStockViewComponent
    //{
    //}
    public class OrderWiseItemStockViewComponent : ViewComponent
    {
        private readonly IALLMMReportService aLLMMReportService;
        public OrderWiseItemStockViewComponent(IALLMMReportService aLLMMReportService)
        {
            this.aLLMMReportService = aLLMMReportService;            
        }
        public async Task<IViewComponentResult> InvokeAsync(PurchaseOrderReport entity)
        {
           List<PurchaseOrderStockSPModel> rResult = new List<PurchaseOrderStockSPModel>();
           // var co = await basicCOAService.ChartOfAccounts(1, 1);
            var list =await aLLMMReportService.GetPurchaseOrderWiseStock(entity.DateFrom,entity.DateTo,entity.MRPItemCode,entity.CompanyID,entity.BusinessID,entity.WithAllTransaction);
            rResult = list;
          
            return View("OrderWiseItemStockVC", rResult);

        }
    }
}
