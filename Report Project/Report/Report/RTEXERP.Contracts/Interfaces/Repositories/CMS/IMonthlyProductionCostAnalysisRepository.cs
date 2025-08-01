using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.CMS
{
   public interface IMonthlyProductionCostAnalysisRepository:IGenericRepository<MonthlyProductionCostAnalysisMaster>
    {
        Task<RResult> SaveMonthWiseProduction(MonthlyProductionCostAnalysisMaster model);
        Task<List<MonthlyProductionCostAnalysisDetailsVM>> GetMonthlyProductionCostAnalysisList(int month, int yearID);
        Task<List<MonthlyProductionCostAnalysisDetailsVM>> GetYearlyWiseProductionCostAnalysisList(int yearID);
    }
}
