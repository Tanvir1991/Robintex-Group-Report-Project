using RTEXERP.Contracts.BLModels.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.CMS
{
  public  interface IDepartmentSalaryForProductionService
    {
        Task<List<ProductionReportSalaryViewModel>> GetSalary(string ReportName,DateTime SalaryDateFrom,DateTime SalaryDateTo);
        Task<List<ProductionReportSalaryViewModel>> GetSalary(string ReportName, int Month,int Year);
    }
}
