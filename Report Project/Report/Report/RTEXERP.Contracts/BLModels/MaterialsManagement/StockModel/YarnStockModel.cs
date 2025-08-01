using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
   public class YarnStockModel
    {
        [Display(Name= "Composition")]
        public string YarnComposition { get; set; }
        [Display(Name = "Composition")]
        public string YarnCompositionID { get; set; }
        [Display(Name = "Count")]
        public string YarnCount { get; set; }
        [Display(Name = "Count")]
        public string YarnCountID { get; set; }
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; }
        [Display(Name = "Date")]
        public string TransactionDateST { get { return TransactionDate.ToString("dd-MMM-yyyy"); } }

        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLYarnComposition { get; set; }
        public List<SelectListItem> DDLYarnCount { get; set; }

    }
}
