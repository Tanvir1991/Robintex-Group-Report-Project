using OfficeOpenXml;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
    public interface IOvalPrintingReportMasterService
    {
        Task<RResult> OvalPrintingReportMasterSave(ExcelPackage package);
        Task<OvalPrintingReportMasterViewModel> GetOvalPrintingInformation(DateTime ReportDate, int ID = 0,DateTime? ReportDateTo=null);
    }
}
