using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface IOvalPrintingReportMasterRepository : IGenericRepository<OvalPrintingReportMaster>
    {
        Task<RResult> OvalPrintingReportMasterSave(OvalPrintingReportMasterViewModel OvalPrintingReportMaster);
        Task<OvalPrintingReportMasterViewModel> GetOvalPrintingInformation(DateTime ReportDate, int ID = 0,DateTime? ReportDateTo=null);
    }
}
