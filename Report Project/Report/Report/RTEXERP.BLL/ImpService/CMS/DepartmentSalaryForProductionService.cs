using RTEXERP.Contracts.BLModels.CMS;
using RTEXERP.Contracts.Interfaces.Repositories.CMS;
using RTEXERP.Contracts.Interfaces.Services.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace RTEXERP.BLL.ImpService.CMS
{
    public class DepartmentSalaryForProductionService : IDepartmentSalaryForProductionService
    {
        private readonly IDepartmentSalaryForProductionRepository _departmentSalaryForProductionRepository;

        public DepartmentSalaryForProductionService(IDepartmentSalaryForProductionRepository     departmentSalaryForProductionRepository)
        {
            _departmentSalaryForProductionRepository = departmentSalaryForProductionRepository;
        }
        public async Task<List<ProductionReportSalaryViewModel>> GetSalary(string ReportName, DateTime SalaryDateFrom, DateTime SalaryDateTo)
        {
            var list = await _departmentSalaryForProductionRepository.GetSalary(ReportName, SalaryDateFrom, SalaryDateTo);
            return list;

        }

        public async Task<List<ProductionReportSalaryViewModel>> GetSalary(string ReportName, int Month,int Year)
        {
            var list = await _departmentSalaryForProductionRepository.GetSalary(ReportName, Month,Year);
            return list;
        }
    }
}
