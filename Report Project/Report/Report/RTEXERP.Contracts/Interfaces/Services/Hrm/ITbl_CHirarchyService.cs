using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Hrm
{
   public interface ITbl_CHirarchyService
    {
        Task<decimal> GetOvalPrintDailySalary(int DivisionID, DateTime SalaryMonth);
        Task<decimal> GetAOPDailySalary(int DivisionID, DateTime SalaryMonth);
        Task<decimal> GetComptexDyeingDailySalary(int DivisionID, List<int> IgnoreDepartment, List<int> IgnoreSection, DateTime SalaryMonth);
        int TotalMonthDayes(DateTime SalaryMonth);
        int GetNumberOfSpecificeDaysInMonth(DateTime dateFrom, DateTime dateTo, DayOfWeek dayName);
    }
}
