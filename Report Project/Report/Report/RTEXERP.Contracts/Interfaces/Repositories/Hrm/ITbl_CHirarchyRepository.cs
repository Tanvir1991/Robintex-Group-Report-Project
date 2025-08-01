using RTEXERP.DBEntities.Hrm.DbViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Hrm
{
   public interface ITbl_CHirarchyRepository:IGenericRepository<Tbl_CHirarchy>
    {
        Task<decimal> GetOvalPrintDailySalary(int DivisionID, DateTime SalaryMonth);
        Task<decimal> GetAOPDailySalary(int DivisionID, DateTime SalaryMonth);
        Task<decimal> GetComptexDyeingDailySalary(int DivisionID, List<int> IgnoreDepartment, List<int> IgnoreSection, DateTime SalaryMonth);
        int TotalMonthDayes(DateTime SalaryMonth);
        int GetNumberOfSpecificeDaysInMonth(DateTime dateFrom, DateTime dateTo, DayOfWeek dayName);
    }
}
