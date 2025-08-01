using RTEXERP.Contracts.BLModels.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.CMS
{
  public  interface IGarmentsProductionReportRepository :IGenericRepository<GarmentsProductionReportSPModel>
    {
        Task<List<GarmentsProductionReportSPModel>> GetGarmentsProductionsReportData(DateTime StartDate,DateTime DateTo,long OrderID,int ReportFor, int IsLastOS=0);
    }
}
