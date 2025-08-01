using RTEXERP.Contracts.BLModels.AOP.DigitalPrintReportModel;
using RTEXERP.Contracts.BLModels.AOP.ReportModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.AOP
{
   public interface IAOPCostringService
    {
        Task<List<AOPCostingReportModel>> Aop_Cost_Summary_Issue(DateTime stdate, DateTime enddate);
        Task<DigitalPrintCostingReportModel> DigitalPrint_Cost_Summary_Issue(DateTime stdate, DateTime enddate);
    }
}
