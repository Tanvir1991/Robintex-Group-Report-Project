using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using RTEXERP.DBEntities.Maxco.SPModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class MaxcoReportService : IMaxcoReportService
    {
        private readonly IMaxcoReportRepository maxcoReportRepository;
        public MaxcoReportService(IMaxcoReportRepository maxcoReportRepository)
        {
            this.maxcoReportRepository = maxcoReportRepository;
        }

        public async Task<List<OrderSheetVersionSPModel>> GetOrderVersion(string OrderNo)
        {
            return await this.maxcoReportRepository.GetOrderVersion(OrderNo);
        }

        public async Task<OrderSheetFirstAndLastVersionSPModel> GetOSVersionDifferenceInfo(int OrderID, int BuyerID)
        {
            return await maxcoReportRepository.GetOSVersionDifferenceInfo(OrderID, BuyerID);
        }

        public async Task<OrderSheetReport> OrderSheetReportData(int CurrentVersionID)
        {
            return await this.maxcoReportRepository.OrderSheetReportData(CurrentVersionID);
        }

    }
}
