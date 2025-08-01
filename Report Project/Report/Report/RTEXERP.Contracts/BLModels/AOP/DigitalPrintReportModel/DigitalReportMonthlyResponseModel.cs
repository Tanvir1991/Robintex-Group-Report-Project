using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.AOP.DigitalPrintReportModel
{
   public  class DigitalReportMonthlyResponseModel
    {
        public string DateDuration { get; set; }
        public string CurrentDateSTR { get; set; }
        public DateTime CurrentDate { get; set; }

        public decimal InHouseProduction { get; set; }
        public decimal SubContractProduction { get; set; }

        public string InhouseProductionUnit { get; set; }
        public string SubContractProductionUnit { get; set; }

        public decimal InHouseEarning { get; set; }
        public decimal SubContractEarning { get; set; }
       public decimal DailyTotalEarning { get { return InHouseEarning + SubContractEarning; } }

        public decimal InHouseCost { get; set; }
        public decimal SubContractCost { get; set; }
        
        public decimal TotalProductionCost { get { return InHouseCost + SubContractCost; } }
        public decimal DailySalary { get; set; }

        public decimal DailyTotalCostWithSalary { get { return TotalProductionCost + DailySalary; } }

        public decimal Profit { get {return DailyTotalEarning - DailyTotalCostWithSalary; } }
    }
}
