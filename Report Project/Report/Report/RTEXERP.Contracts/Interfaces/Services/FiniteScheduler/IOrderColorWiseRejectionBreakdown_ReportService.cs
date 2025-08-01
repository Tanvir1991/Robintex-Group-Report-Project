using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
    public interface IOrderColorWiseRejectionBreakdown_ReportService
    {
        Task<RResult> OrderColorWiseRejectionBreakdown_ReportSave(List<OrderColorWiseRejectionBreakdown_Report> entity);
    }
}
