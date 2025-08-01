using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface IOrderColorWiseRejectionBreakdown_ReportRepository:IGenericRepository<OrderColorWiseRejectionBreakdown_Report>
    {
        Task<RResult> OrderColorWiseRejectionBreakdown_ReportSave(List<OrderColorWiseRejectionBreakdown_Report> entity);
    }
}
