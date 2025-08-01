using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
    public class MonthlyKnittingProductionReportPageViewModel
    {
        public MonthlyKnittingProductionReportPageViewModel()
        {
            ReportDataList = new List<MonthlyKnittingProductionReportData>();
        }
        public string CompanyName { get; set; }
        public string DateDuration { get; set; }

        public double Salary { get; set; }
        public List<MonthlyKnittingProductionReportData> ReportDataList { get; set; }
    }

    public  class MonthlyKnittingProductionReportData
    {
        public DateTime ReportDate { get; set; }
        public string ReportDateSTR { get; set; }
        public string CompanyName { get; set; }
        public long CompanyID { get; set; }
        public double ShiftAProduction { get; set; }
        public double ShiftBProduction { get; set; }
        public double ShiftCProduction { get; set; }
        public double TotalProduction { get; set; }
        public double TotalEarning { get; set; }
        public double DailySalary { get; set; }
        public double Rate { get; set; }
        public double ProfitLoss { get { return TotalEarning - DailySalary; } }

    }
}
