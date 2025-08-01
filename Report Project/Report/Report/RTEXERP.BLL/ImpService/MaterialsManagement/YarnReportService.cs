using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class YarnReportService : IYarnReportService
    {
        private readonly IYarnReportRepository yarnReportRepository;
        public YarnReportService(IYarnReportRepository yarnReportRepository)
        {
            this.yarnReportRepository = yarnReportRepository;
        }
        public async Task<List<YarnStockSPModel>> GetYarnStock(DateTime DateFrom, DateTime DateTo, int WithAllTransaction)
        {
            return await yarnReportRepository.GetYarnStock(DateFrom, DateTo, WithAllTransaction);
        }
    }
}
