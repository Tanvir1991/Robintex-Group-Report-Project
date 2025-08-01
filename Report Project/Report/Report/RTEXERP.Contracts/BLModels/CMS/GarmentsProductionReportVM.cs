using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.CMS
{
  public  class GarmentsProductionReportVM
    {
        public GarmentsProductionReportVM()
        {
            DDLReportFor = new List<SelectListItem>();

            DDLReportFor.Add(new SelectListItem() { Text = "Please Select", Value="" });
            DDLReportFor.Add(new SelectListItem() { Text = "Sewing Production", Value = "2" ,Selected=true });
            DDLReportFor.Add(new SelectListItem() { Text = "Finishing Production", Value = "1" });
        }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

        public string ReportFor { get; set; }
        public int MonthID { get; set; }
        public List<SelectListItem> DDLMonthList { get; set; }
        public int Year { get; set; }
        public List<SelectListItem> DDLYearList { get; set; }
        public List<SelectListItem> DDLReportFor { get; set; }

    }
}
