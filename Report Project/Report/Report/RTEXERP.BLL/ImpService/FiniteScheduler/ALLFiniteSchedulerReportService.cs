using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class ALLFiniteSchedulerReportService : IALLFiniteSchedulerReportService
    {
        private readonly IALLFiniteSchedulerReportRepository allFiniteSchedulerReportRepository;
        public ALLFiniteSchedulerReportService(IALLFiniteSchedulerReportRepository _allFiniteSchedulerReportRepository)
        {
            allFiniteSchedulerReportRepository = _allFiniteSchedulerReportRepository;
        }

        public async Task<List<FabricStockReportSPModel>> GetFabricLotStockList(int LotID, int AttributeInstanceID, DateTime DateTo)
        {
            return await allFiniteSchedulerReportRepository.GetFabricLotStockList(LotID, AttributeInstanceID,DateTo);
        }

        public async Task<List<FabricStockReportSPModel>> GetFinishFabricStockList(DateTime DateTo)
        {
            return await allFiniteSchedulerReportRepository.GetFinishFabricStockList(DateTo);
        }

        public async Task<List<FabricStockReportSPModel>> GetGreigeFabricStockList(DateTime DateTo)
        {
            return await allFiniteSchedulerReportRepository.GetGreigeFabricStockList(DateTo);
        }
    }
}
