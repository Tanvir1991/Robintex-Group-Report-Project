using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.CMS
{
    public class ProductionReportSalaryViewModel
    {
         public string ReportName { get; set; }
        public DateTime SalaryDate { get; set; }
        public decimal Salary { get; set; }
        public decimal OtherSalary { get; set; }
        public decimal OT { get; set; }
        public decimal OtherOT { get; set; }
        public decimal OverHeadCost { get; set; }
        public decimal TotalSalary { get { return Salary + OtherSalary + OT + OtherOT+OverHeadCost; } }
    }
}
