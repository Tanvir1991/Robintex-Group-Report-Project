using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel.BatchCosting;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{

    public class ALLMMReportRepository : GenericRepository<CMBL_SampleGateReceiving>, IALLMMReportRepository
    {
        private MaterialsManagementDBContext dbCon;

        public ALLMMReportRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<BatchCostingMap> FULLBatchCosting(DateTime FromDate, DateTime ToDate, int CompanyID, int? BuyerID = 0, long? OrderID = 0)
        {

            BatchCostingMap batchInfo = new BatchCostingMap();
            batchInfo.DateFrom = FromDate.ToString("dd-MMM-yyyy");
            batchInfo.DateTo = ToDate.ToString("dd-MMM-yyyy");

            try
            {
                await dbCon.LoadStoredProc("rpt.USP_FULLBatchCosting", commandTimeout: 20000)
                        .WithSqlParam("FromDate", FromDate)
                        .WithSqlParam("ToDate", ToDate)
                        .WithSqlParam("CompanyID", CompanyID)
                        .WithSqlParam("BuyerID", BuyerID)
                        .WithSqlParam("OrderID", OrderID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    batchInfo.BatchProduction = handler.ReadToList<BatchOrderCost>() as List<BatchOrderCost>;
                    handler.NextResult();
                    batchInfo.ShadeProductionCost = handler.ReadToList<BatchOrderCost>() as List<BatchOrderCost>;
                    handler.NextResult();
                    batchInfo.SampleProductionCost = handler.ReadToList<BatchOrderCost>() as List<BatchOrderCost>;
                    handler.NextResult();
                    batchInfo.MachineWashCost = handler.ReadToList<BatchOrderCost>() as List<BatchOrderCost>;
                    handler.NextResult();
                });
            }
            catch (Exception e)
            {
                throw;
            }
            return batchInfo;

        }

        public async Task<List<PurchaseOrderStockSPModel>> GetPurchaseOrderWiseStock(DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction)
        {
            var itemList = new List<PurchaseOrderStockSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.PurchaseOrderWiseStockStatus")
                   .WithSqlParam("DateFrom", DateFrom)
                             .WithSqlParam("DateTo", DateTo)
                             .WithSqlParam("CompanyID", CompanyID)
                             .WithSqlParam("BusinessID", BusinessID)
                             .WithSqlParam("MrpItemCode", MrpItemCode) 
                             .WithSqlParam("WithAllTransaction", WithAllTransaction)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<PurchaseOrderStockSPModel>() as List<PurchaseOrderStockSPModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<PurchaseOrderStockSPModel>> Get_Individual_PO_ItemStock(DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction)
        {
            var itemList = new List<PurchaseOrderStockSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.Get_Individual_PO_ItemStock")
                             .WithSqlParam("DateFrom", DateFrom)
                             .WithSqlParam("DateTo", DateTo)
                             .WithSqlParam("MrpItemCode", MrpItemCode)
                             .WithSqlParam("CompanyID", CompanyID)
                             .WithSqlParam("BusinessID", BusinessID)
                             .WithSqlParam("WithAllTransaction", WithAllTransaction)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<PurchaseOrderStockSPModel>() as List<PurchaseOrderStockSPModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<PurchaseOrderStockSPModel>> Get_Individual_PO_ItemStockDetail(int BuyerID, DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction, long AttributeInstanceID)
        {
            
            var itemList = new List<PurchaseOrderStockSPModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.usp_GetIndividualPurchaseOrderItemDetail")
                   .WithSqlParam("BuyerID", BuyerID)
                    .WithSqlParam("DateFrom", DateFrom)
                             .WithSqlParam("DateTo", DateTo)
                             .WithSqlParam("MrpItemCode", MrpItemCode)
                             .WithSqlParam("CompanyID", CompanyID)
                             .WithSqlParam("BusinessID", BusinessID)
                             .WithSqlParam("AttributeInstanceID", AttributeInstanceID)                             
                             .WithSqlParam("WithAllTransaction", WithAllTransaction)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<PurchaseOrderStockSPModel>() as List<PurchaseOrderStockSPModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
