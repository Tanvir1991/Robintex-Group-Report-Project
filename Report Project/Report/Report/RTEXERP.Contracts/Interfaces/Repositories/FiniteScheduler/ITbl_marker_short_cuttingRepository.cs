using RTEXERP.Contracts.BLModels.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface ITbl_marker_short_cuttingRepository
    {
        Task<List<CompanyWiseCuttingQtyViewModel>> GetCompanyWiseCuttingQty(DateTime dateFrom, DateTime dateTo);
        Task<List<CompanyWiseCuttingQtyViewModel>> GetDailyCompanyWiseCuttingQty(DateTime dateFrom, DateTime dateTo);
        Task<List<CuttingProductionReportPageDetailViewModel>> GetCuttingProductionReportDetailData(DateTime dateFrom, DateTime dateTo);
    }
}
