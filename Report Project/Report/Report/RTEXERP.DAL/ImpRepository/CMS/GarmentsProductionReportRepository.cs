using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.DAL.DataContext;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.CMS
{
    public class GarmentsProductionReportRepository : GenericRepository<GarmentsProductionReportSPModel>,IGarmentsProductionReportRepository
    {
        private CMSDBContext dbCon;

        public GarmentsProductionReportRepository(CMSDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<GarmentsProductionReportSPModel>> GetGarmentsProductionsReportData(DateTime StartDate, DateTime DateTo, long OrderID,int ReportFor, int IsLastOS = 0)
        {
            List<GarmentsProductionReportSPModel> spData = new List<GarmentsProductionReportSPModel>();
            try
            {
                /*rpt.sp_Production_Summary_WithCM*/
                
                await dbCon.LoadStoredProc("rpt.sp_Production_Summary_WithCM_N")
                .WithSqlParam("DtFrom", StartDate)
                .WithSqlParam("DtTo", DateTo)
                .WithSqlParam("orderid", OrderID)
                .WithSqlParam("ReportFor", ReportFor)
                .WithSqlParam("IsLastOS", IsLastOS)
                
                .ExecuteStoredProcAsync((handler) =>
                {
                    spData = handler.ReadToList<GarmentsProductionReportSPModel>() as List<GarmentsProductionReportSPModel>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return spData;

        }
    }
}
