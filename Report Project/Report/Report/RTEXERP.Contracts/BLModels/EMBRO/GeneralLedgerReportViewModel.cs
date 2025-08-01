using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
   public class GeneralLedgerReportViewModel : AccCommonModel
    {
        [Display(Name="Ledger Name")]
        public int AccID { get; set; }
        [Display(Name = "Category")]
        public int AccCategoryID { get; set; }
        [Display(Name = "Cost Center")]
        public int CostCenterID { get; set; }
        [Display(Name = "Activity")]
        public int ActivityID { get; set; }
        [Display(Name = "Fiscal Start Date")]
        public string DateFrom { get; set; }
        [Display(Name = "Fiscal End Date")]
        public string DateTo { get; set; }

        public IEnumerable<SelectListItem> DDLAccList { get; set; }
        public IEnumerable<SelectListItem> DDLCategoryList { get; set; }
        public IEnumerable<SelectListItem> DDLActivityList { get; set; }
        public IEnumerable<SelectListItem> DDLCostCenterList { get; set; }
    }
}
