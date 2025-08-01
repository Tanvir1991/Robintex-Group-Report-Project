using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.CMS
{
   public interface IMonthlyProductionCostAnalysisService
    {
        Task<RResult> SaveMonthWiseProduction(MonthlyProductionCostAnalysisMasterVM model);
        Task<List<MonthlyProductionCostAnalysisDetailsVM>> GetMonthlyProductionCostAnalysisList(int month, int yearID);
        Task<List<MonthlyProductionCostAnalysisDetailsVM>> GetYearlyWiseProductionCostAnalysisList(int yearID);
    }
}
