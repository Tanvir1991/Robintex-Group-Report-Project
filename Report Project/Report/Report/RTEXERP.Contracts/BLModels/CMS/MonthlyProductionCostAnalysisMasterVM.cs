using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.CMS
{
   public class MonthlyProductionCostAnalysisMasterVM
    {
        public int ID { get; set; }
        public int MonthID { get; set; }
        public int YearID { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreateDate { get; set; }
        public List<SelectListItem> DDLMonthList { get; set; }
        public List<SelectListItem> DDLYearList { get; set; }
        public List<MonthlyProductionCostAnalysisDetailsVM> MonthlyProductionCostAnalysisDetails { get; set; }
        public List<MDReportItem> MDReportItem { get; set; }
    }
}
