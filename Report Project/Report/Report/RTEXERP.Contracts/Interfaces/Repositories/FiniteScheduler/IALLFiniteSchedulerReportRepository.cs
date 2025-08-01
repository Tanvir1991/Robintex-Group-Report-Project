using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface IALLFiniteSchedulerReportRepository:IGenericRepository<FabricStockReportSPModel>
    {
        Task<List<FabricStockReportSPModel>> GetFinishFabricStockList(DateTime DateTo);
        Task<List<FabricStockReportSPModel>> GetFabricLotStockList(int LotID, int AttributeInstanceID, DateTime DateTo);
        Task<List<FabricStockReportSPModel>> GetGreigeFabricStockList(DateTime DateTo);
    }
}
