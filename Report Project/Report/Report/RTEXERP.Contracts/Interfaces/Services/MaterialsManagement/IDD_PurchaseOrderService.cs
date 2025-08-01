using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
   public interface IDD_PurchaseOrderService
    {
        Task<List<SelectListItem>> DDLPurchaseOrder(int OrderID, DateTime? PODateFrom = null, DateTime? PODateTo = null);
        Task<List<SelectListItem>> DDLPurchaseOrderStatus();
        Task<List<GetOrderPOListSPModel>> GetOrderPOList(int OrderID = 0, int POID = 0, DateTime? PODateFrom = null, DateTime? PODateTo = null, int StatusID = 0);
        Task<List<DD_PO_PurchaseOrderDetailsInfoSPModel>> GetDD_PO_PurchaseOrderDetailsInfo(int POID);
        Task<DD_PO_PurchaseOrderInfoSPModel> GetDD_PO_PurchaseOrderInfo(int POID);

        Task<PurchaseOrderReportViewModel> GetPOReport(int POID, int IsShowStyleSizeWiseQuantity);
    }
}
