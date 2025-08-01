using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
   public  class TrialBalanceViewModel: AccCommonModel
    {
        public int AccCategoryId { get; set; }
        [Display(Name = "Select By Cost Center")]
        public string SelectByCostCenter { get; set; }
        [Display(Name ="Select With Detail")]
        public string SelectWithDetail { get; set; }
        [Display(Name ="Expanded/Summarize")]
        public string  ReportSummarizeType { get; set; }
        [Display(Name = "Posted/UnPosted")]
        public string PostedType { get; set; }
        [Display(Name = "Exclude Zero Balance in Current Activity Duration.")]
        public int IsExcludeZeroBalance { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        


        public string DateFromStr { get; set; } = DateTime.Now.ToString("dd-MMM-yyyy");
        public string DateToStr { get; set; } = DateTime.Now.ToString("dd-MMM-yyyy");

        public IEnumerable<SelectListItem> DDLPostedType { get; set; }
        public IEnumerable<SelectListItem> DDLReportSummarizeType { get; set; }
        public IEnumerable<SelectListItem> DDLAccCategory { get; set; }
    }
}
