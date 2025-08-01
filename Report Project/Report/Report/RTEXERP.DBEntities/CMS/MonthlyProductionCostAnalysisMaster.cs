using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.CMS
{
  public  class MonthlyProductionCostAnalysisMaster
    {
        public int ID { get; set; }
        public int MonthID { get; set; }
        public int YearID { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual List<MonthlyProductionCostAnalysisDetails> MonthlyProductionCostAnalysisDetails { get; set; }
    }
}
