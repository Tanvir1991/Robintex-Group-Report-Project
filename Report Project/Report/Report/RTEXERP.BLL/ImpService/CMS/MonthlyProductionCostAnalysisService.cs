using AutoMapper;
using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.Contracts.Interfaces.Services.CMS;
using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.CMS
{
    public class MonthlyProductionCostAnalysisService : IMonthlyProductionCostAnalysisService
    {
        private readonly IMonthlyProductionCostAnalysisRepository monthlyProductionCostAnalysisRepository;
        private readonly IMapper mapper;

        public MonthlyProductionCostAnalysisService(IMonthlyProductionCostAnalysisRepository _monthlyProductionCostAnalysisRepository,IMapper _mapper)
        {
            monthlyProductionCostAnalysisRepository = _monthlyProductionCostAnalysisRepository;
            mapper = _mapper;
        }

        public async Task<List<MonthlyProductionCostAnalysisDetailsVM>> GetMonthlyProductionCostAnalysisList(int month, int yearID)
        {
            return await monthlyProductionCostAnalysisRepository.GetMonthlyProductionCostAnalysisList(month, yearID);
        }

        public async Task<List<MonthlyProductionCostAnalysisDetailsVM>> GetYearlyWiseProductionCostAnalysisList(int yearID)
        {
            return await monthlyProductionCostAnalysisRepository.GetYearlyWiseProductionCostAnalysisList( yearID);
        }

        public async Task<RResult> SaveMonthWiseProduction(MonthlyProductionCostAnalysisMasterVM model)
        {
            var rResult = new RResult();
            model.IsRemoved = false;
            model.CreateDate = DateTime.Now;
            model.MonthlyProductionCostAnalysisDetails.ForEach(c => { c.IsRemoved = false;c.CreateDate = DateTime.Now; });
            var mainObj = mapper.Map<MonthlyProductionCostAnalysisMasterVM, MonthlyProductionCostAnalysisMaster>(model);
            rResult = await monthlyProductionCostAnalysisRepository.SaveMonthWiseProduction(mainObj);
            return rResult;
        }
    }
}
