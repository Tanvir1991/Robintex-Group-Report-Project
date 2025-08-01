using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.CMS
{
  public  class SalaryAnalysisDataPageViewModel
    {
        [Display(Name = "Month")]
        public int MonthID { get; set; }
        public List<SelectListItem> DDLMonthList { get; set; }
        public int Year { get; set; }
        public string DateDuration { get; set; }
        public List<SelectListItem> DDLYearList { get; set; }
        [Display(Name = " Select Duration")]
        public int PeriodID { get; set; }
        public List<SelectListItem> PeriodList { get; set; }
        public List<MonthlyProductionCostAnalysisDetailsVM> MonthlyProductionCostAnalysisDetails { get; set; }

    }
}
