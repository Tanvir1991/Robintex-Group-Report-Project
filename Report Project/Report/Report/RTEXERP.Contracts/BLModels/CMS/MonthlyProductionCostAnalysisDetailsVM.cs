using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.CMS
{
   public class MonthlyProductionCostAnalysisDetailsVM
    {
        public int ID { get; set; }
        public int MasterID { get; set; }
        public string ReportName { get; set; }
        public decimal Earning { get; set; }
        public decimal SalaryCost { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreateDate { get; set; }
        public int YearID { get; set; }
        public  MonthlyProductionCostAnalysisMasterVM MonthlyProductionCostAnalysisMaster { get; set; }
    }
}
