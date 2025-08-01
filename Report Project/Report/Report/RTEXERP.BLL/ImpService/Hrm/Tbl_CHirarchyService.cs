using RTEXERP.Contracts.Interfaces.Repositories.Hrm;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Hrm
{
    public class Tbl_CHirarchyService : ITbl_CHirarchyService
    {
        private readonly ITbl_CHirarchyRepository _EmployeeSalaryInfo;

        public Tbl_CHirarchyService(ITbl_CHirarchyRepository tbl_CHirarchyRepository)
        {
            _EmployeeSalaryInfo = tbl_CHirarchyRepository;
        }

        public async Task<decimal> GetAOPDailySalary(int DivisionID, DateTime SalaryMonth)
        {
            return await _EmployeeSalaryInfo.GetAOPDailySalary(DivisionID,SalaryMonth);
        }

        public async Task<decimal> GetComptexDyeingDailySalary(int DivisionID, List<int> IgnoreDepartment, List<int> IgnoreSection, DateTime SalaryMonth)
        {
            return await _EmployeeSalaryInfo.GetComptexDyeingDailySalary(DivisionID, IgnoreDepartment, IgnoreSection, SalaryMonth);
        }

        public int GetNumberOfSpecificeDaysInMonth(DateTime dateFrom, DateTime dateTo, DayOfWeek dayName)
        {
            return _EmployeeSalaryInfo.GetNumberOfSpecificeDaysInMonth(dateFrom, dateTo, dayName);
        }

        public async Task<decimal> GetOvalPrintDailySalary(int DivisionID, DateTime SalaryMonth)
        {
            return await _EmployeeSalaryInfo.GetOvalPrintDailySalary(DivisionID, SalaryMonth);
        }

        public int TotalMonthDayes(DateTime SalaryMonth)
        {
            return _EmployeeSalaryInfo.TotalMonthDayes(SalaryMonth);
        }
    }
}
