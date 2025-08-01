using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class tbl_marker_short_cuttingRepository : ITbl_marker_short_cuttingRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public tbl_marker_short_cuttingRepository(FiniteSchedulerDBContext context)
            //: base(context)
        {
            dbCon = context;
        }

        public async Task<List<CompanyWiseCuttingQtyViewModel>> GetCompanyWiseCuttingQty(DateTime dateFrom, DateTime dateTo)
        {
            var cuttingList = new List<CompanyWiseCuttingQtyViewModel>();
            try
            {
                await dbCon.LoadStoredProc("sp_Cutting_Summary_Report")
                             .WithSqlParam("DtFrom", dateFrom)
                             .WithSqlParam("DtTo", dateTo)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 cuttingList = handler.ReadToList<CompanyWiseCuttingQtyViewModel>() as List<CompanyWiseCuttingQtyViewModel>;
                             });                
                return cuttingList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<CuttingProductionReportPageDetailViewModel>> GetCuttingProductionReportDetailData(DateTime dateFrom, DateTime dateTo)
        {
            var cuttingList = new List<CuttingProductionReportPageDetailViewModel>();
            try
            {
                await dbCon.LoadStoredProc("sp_Cutting_Summary_Report_details")
                             .WithSqlParam("DtFrom", dateFrom)
                             .WithSqlParam("DtTo", dateTo)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 cuttingList = handler.ReadToList<CuttingProductionReportPageDetailViewModel>() as List<CuttingProductionReportPageDetailViewModel>;
                             });
                return cuttingList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<CompanyWiseCuttingQtyViewModel>> GetDailyCompanyWiseCuttingQty(DateTime dateFrom, DateTime dateTo)
        {
            var cuttingList = new List<CompanyWiseCuttingQtyViewModel>();
            try
            {
                await dbCon.LoadStoredProc("USP_Daily_Cutting_Summary_Report")
                             .WithSqlParam("DtFrom", dateFrom)
                             .WithSqlParam("DtTo", dateTo)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 cuttingList = handler.ReadToList<CompanyWiseCuttingQtyViewModel>() as List<CompanyWiseCuttingQtyViewModel>;
                             });
                return cuttingList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
