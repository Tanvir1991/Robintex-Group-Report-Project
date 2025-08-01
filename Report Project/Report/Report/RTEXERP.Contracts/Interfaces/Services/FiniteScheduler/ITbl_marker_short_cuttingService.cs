using RTEXERP.Contracts.BLModels.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
   public interface ITbl_marker_short_cuttingService
    {
        Task<CuttingProductionReportPageMasterViewModel> GetCuttingProductionReportData(DateTime dateFrom, DateTime dateTo);
        Task<List<CompanyWiseCuttingQtyViewModel>> GetDailyCompanyWiseCuttingQty(DateTime dateFrom, DateTime dateTo);
    }
}
