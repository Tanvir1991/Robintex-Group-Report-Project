using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.CMS
{
    public interface IDepartmentSalaryForProductionRepository :IGenericRepository<DepartmentSalaryForProduction>
    {
        Task<List<ProductionReportSalaryViewModel>> GetSalary(string ReportName, DateTime SalaryDateFrom, DateTime SalaryDateTo);
        Task<List<ProductionReportSalaryViewModel>> GetSalary(string ReportName, int Month,int Year);
    }
}
