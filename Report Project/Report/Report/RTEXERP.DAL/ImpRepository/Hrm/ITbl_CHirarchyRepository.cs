using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.Hrm;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Hrm.DbViews;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Hrm
{
   public class Tbl_CHirarchyRepository :GenericRepository<Tbl_CHirarchy>, ITbl_CHirarchyRepository
    {
        private HRTESTContext _hrmDB;
     
        public Tbl_CHirarchyRepository(HRTESTContext hrmDB):base(hrmDB)
        {
            _hrmDB = hrmDB;
        }

        public async Task<decimal> GetAOPDailySalary(int DivisionID, DateTime SalaryMonth)
        {
            var totalDayes = this.TotalMonthDayes(SalaryMonth);
            var data = await _hrmDB.Tbl_CHirarchy
                .Where(b => b.Emp_Active == true && b.Division_ID == DivisionID && b.Emp_Gross.HasValue == true)
                .Select(b => new { b.EmpCd, b.Emp_ID, b.Emp_Gross,MonthDayes= totalDayes })
                .ToListAsync();
            decimal? perDaySalary = data.Sum(b =>(decimal?)b.Emp_Gross.Value / b.MonthDayes);
            if (perDaySalary == null)
            {
                return 0;
            }
            return perDaySalary.Value;
        }

        public async Task<decimal> GetComptexDyeingDailySalary(int DivisionID, List<int> IgnoreDepartment, List<int> IgnoreSection, DateTime SalaryMonth)
        {
            var totalDayes = this.TotalMonthDayes(SalaryMonth);
            var data = await _hrmDB.Tbl_CHirarchy
                .Where(b => b.Emp_Active == true && b.Division_ID == DivisionID 
                     && b.Emp_Gross.HasValue == true
                     && !IgnoreDepartment.Contains(b.Dept_ID)
                     && !IgnoreSection.Contains(b.Section_Id))
                .Select(b => new { b.EmpCd, b.Emp_ID, b.Emp_Gross, MonthDayes = totalDayes })
                .ToListAsync();

            decimal? perDaySalary = data.Sum(b => (decimal?)b.Emp_Gross.Value / b.MonthDayes);
            if (perDaySalary == null)
            {
                return 0;
            }
            return perDaySalary.Value;
        }

        public async Task<decimal> GetOvalPrintDailySalary(int DivisionID, DateTime SalaryMonth)
        {
            var totalDayes = this.TotalMonthDayes(SalaryMonth);
            var escapeDays = this.GetNumberOfSpecificeDaysInMonth(SalaryMonth.Year, SalaryMonth.Month, DayOfWeek.Friday);
            totalDayes -= escapeDays;
            var data = await _hrmDB.Tbl_CHirarchy
                .Where(b => b.Emp_Active == true && b.Division_ID == DivisionID && b.Emp_Gross.HasValue == true)
                .Select(b => new { b.EmpCd, b.Emp_ID, b.Emp_Gross, MonthDayes = totalDayes })
                .ToListAsync();
            decimal? perDaySalary = data.Sum(b => (decimal?)b.Emp_Gross.Value / b.MonthDayes);
            if (perDaySalary == null)
            {
                return 0;
            }
            return perDaySalary.Value;
        }


        public int TotalMonthDayes(DateTime SalaryMonth)
        {
            int dayes = DateTime.DaysInMonth(SalaryMonth.Year,SalaryMonth.Month);
            return dayes;
        }

        public int GetNumberOfSpecificeDaysInMonth(int year, int month, DayOfWeek dayName)
        {
            CultureInfo ci = new CultureInfo("en-US");
            int NumuberDays = 0;
            for (int i = 1; i <= ci.Calendar.GetDaysInMonth(year, month); i++)
            {
                if (new DateTime(year, month, i).DayOfWeek == dayName)
                {
                    NumuberDays += 1;
                }
                    
            }
            return NumuberDays;
        }
        public int GetNumberOfSpecificeDaysInMonth(DateTime dateFrom, DateTime dateTo, DayOfWeek dayName)
        {
            CultureInfo ci = new CultureInfo("en-US");
            int NumuberDays = 0;
            for (DateTime i = dateFrom; dateTo.CompareTo(i)>=0; i = i.AddDays(1))
            {
                if (i.DayOfWeek == dayName)
                {
                    NumuberDays += 1;
                }

            }
            return NumuberDays;
        }
    }
}
