using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class YarnBalanceService : IYarnBalanceService
    {
        public readonly IYarnBalanceRepository yarnBalanceRepository;
        public YarnBalanceService(IYarnBalanceRepository yarnBalanceRepository)
        {
            this.yarnBalanceRepository = yarnBalanceRepository;
        }
        public async Task<List<YarnLotBalanceViewModel>> YarnLotBalanceSummaryByCountComposition(string LotNo, DateTime? DateFrom, DateTime? DateTo, string YarnCountId, int? YarnCompositionId, int IsDetails = 0)
        {
            return await yarnBalanceRepository.YarnLotBalanceSummaryByCountComposition(LotNo,DateFrom,DateTo,YarnCountId,YarnCompositionId,IsDetails);
        }

        public async Task<List<YarnStockDetailsSPModel>> YarnLotDetails(string LotNo)
        {
            return await yarnBalanceRepository.YarnLotDetails(LotNo);
        }

        public async Task<List<YarnStockDetailsSPModel>> YarnStockDetails(string YarnComposition, string YarnCount, DateTime TransactionDate, long CompanyID)
        {
            return await yarnBalanceRepository.YarnStockDetails(YarnComposition,YarnCount,TransactionDate, CompanyID);
        }

        public DataTable YarnSummaryCompositionWise(DateTime StockDate, int CompanyID = 0)
        {
            return  yarnBalanceRepository.YarnSummaryCompositionWise(StockDate, CompanyID);
        }
    }
}
