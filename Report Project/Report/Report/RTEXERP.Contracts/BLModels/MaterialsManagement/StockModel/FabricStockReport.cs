using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
    public class FabricStockReport
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        public string ReportType { get; set; }
        public bool WithAllTransaction { get; set; }
        public List<SelectListItem> CompanyList { get; set; }
        public List<SelectListItem> ReportTypeList { get; set; }
    }
}
