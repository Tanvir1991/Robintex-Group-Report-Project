using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel.BatchCosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
 
    public interface IALLMMReportService  
    {
        Task<BatchCostingMap> FULLBatchCosting(DateTime FromDate, DateTime ToDate, int CompanyID, int? BuyerID = 0, long? OrderID=0);
        Task<List<PurchaseOrderStockSPModel>> GetPurchaseOrderWiseStock(DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction);
        Task<List<PurchaseOrderStockSPModel>> Get_Individual_PO_ItemStock(DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction);
        Task<List<PurchaseOrderStockSPModel>> Get_Individual_PO_ItemStockDetail(int BuyerID, DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction, long AttributeInstanceID);
        Task<List<GarmentsProductionReportSPModel>> GetGarmentsProductionsReportData(DateTime StartDate, DateTime DateTo, long OrderID,int ReportFor, int IsLastOS = 0);
    }

}
