using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
    public interface IYarnBalanceService
    {
        Task<List<YarnLotBalanceViewModel>> YarnLotBalanceSummaryByCountComposition(string LotNo, DateTime? DateFrom, DateTime? DateTo, string YarnCountId, int? YarnCompositionId, int IsDetails = 0);

        DataTable YarnSummaryCompositionWise(DateTime StockDate, int CompanyID = 0);
        Task<List<YarnStockDetailsSPModel>> YarnStockDetails(string YarnComposition, string YarnCount, DateTime TransactionDate, long CompanyID);
        Task<List<YarnStockDetailsSPModel>> YarnLotDetails(string LotNo);
    }
}
