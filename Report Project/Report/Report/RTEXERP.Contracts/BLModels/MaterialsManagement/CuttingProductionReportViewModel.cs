using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
    public class CuttingProductionReportViewModel
    {
        [Display(Name="Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        public int CompanyID { get; set; }       
        public List<SelectListItem> DDLCompany { get; set; }
      
    }
}
