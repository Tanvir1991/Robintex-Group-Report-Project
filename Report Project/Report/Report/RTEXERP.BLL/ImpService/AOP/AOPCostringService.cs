using RTEXERP.Contracts.BLModels.AOP.DigitalPrintReportModel;
using RTEXERP.Contracts.BLModels.AOP.ReportModel;
using RTEXERP.Contracts.Interfaces.Repositories.AOP;
using RTEXERP.Contracts.Interfaces.Services.AOP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.AOP
{
    public class AOPCostringService : IAOPCostringService
    {
        private readonly IAOPCostingRepository iAOPCostingRepository;
        public AOPCostringService(IAOPCostingRepository iAOPCostingRepository)
        {
            this.iAOPCostingRepository = iAOPCostingRepository;
        }

        public async Task<List<AOPCostingReportModel>> Aop_Cost_Summary_Issue(DateTime stdate, DateTime enddate)
        {
            return await iAOPCostingRepository.Aop_Cost_Summary_Issue(stdate, enddate);
        }

        public async Task<DigitalPrintCostingReportModel> DigitalPrint_Cost_Summary_Issue(DateTime stdate, DateTime enddate)
        {
            return await iAOPCostingRepository.DigitalPrint_Cost_Summary_Issue(stdate, enddate);
        }
    }
}
