using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.CMS
{
 public   class MonthlyProductionCostAnalysisDetails
    {
        public int ID { get; set; }
        [ForeignKey("MonthlyProductionCostAnalysisMaster")]
        public int MasterID { get; set; }
        public string ReportName { get; set; }
        public decimal Earning { get; set; }
        public decimal SalaryCost { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual MonthlyProductionCostAnalysisMaster MonthlyProductionCostAnalysisMaster { get; set; }
    }
}
