using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel.BatchCosting;
using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
   public class ALLMMReportService : IALLMMReportService
    {
        private readonly IALLMMReportRepository iALLMMReportRepository;
        private readonly IGarmentsProductionReportRepository garmentsProductionReportRepository;
        public ALLMMReportService(IALLMMReportRepository iALLMMReportRepository, IGarmentsProductionReportRepository garmentsProductionReportRepository)
        {
            this.iALLMMReportRepository = iALLMMReportRepository;
            this.garmentsProductionReportRepository = garmentsProductionReportRepository;
        }

        public async Task<BatchCostingMap> FULLBatchCosting(DateTime FromDate, DateTime ToDate, int CompanyID, int? BuyerID = 0, long? OrderID = 0)
        {
            return await iALLMMReportRepository.FULLBatchCosting(FromDate, ToDate, CompanyID, BuyerID, OrderID);
        }

        public async Task<List<GarmentsProductionReportSPModel>> GetGarmentsProductionsReportData(DateTime StartDate, DateTime DateTo, long OrderID,int ReportFor, int IsLastOS = 0)
        {
            return await this.garmentsProductionReportRepository.GetGarmentsProductionsReportData(StartDate, DateTo, OrderID,ReportFor,IsLastOS);
        }

        public async Task<List<PurchaseOrderStockSPModel>> GetPurchaseOrderWiseStock(DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction)
        {
            return await iALLMMReportRepository.GetPurchaseOrderWiseStock(DateFrom, DateTo, MrpItemCode, CompanyID, BusinessID, WithAllTransaction);
        }

        public async Task<List<PurchaseOrderStockSPModel>> Get_Individual_PO_ItemStock(DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction)
        {
            return await iALLMMReportRepository.Get_Individual_PO_ItemStock(DateFrom, DateTo, MrpItemCode, CompanyID, BusinessID, WithAllTransaction);
        }

        public async Task<List<PurchaseOrderStockSPModel>> Get_Individual_PO_ItemStockDetail(int BuyerID, DateTime DateFrom, DateTime DateTo, int MrpItemCode, int CompanyID, int BusinessID, int WithAllTransaction, long AttributeInstanceID)
        {
            return await iALLMMReportRepository.Get_Individual_PO_ItemStockDetail(BuyerID, DateFrom, DateTo, MrpItemCode, CompanyID, BusinessID, WithAllTransaction, AttributeInstanceID);
        }
    }
}
