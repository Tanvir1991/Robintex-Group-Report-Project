using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
    public class PurchaseOrderReport
    {

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Business")]
        public int BusinessID { get; set; }
        [Display(Name ="MRP Item")]
        public int MRPItemCode { get; set; }
        [Display(Name ="Buyer")]
        public int BuyerID { get; set; }
        [Display(Name ="Order No")]
        public int OrderID { get; set; }
 
        [Display(Name = "Report Type")]
        public int ReportType { get; set; }
        public int WithAllTransaction { get; set; }
        public string DateFromSTR { get { return DateFrom.ToString("dd-MMM-yyyy"); } }
        public string DateToSTR { get { return DateFrom.ToString("dd-MMM-yyyy"); } }

        public IEnumerable<SelectListItem> DDLCompany {get;set;}
        public IEnumerable<SelectListItem> DDLBusiness {get;set;}
        public IEnumerable<SelectListItem> DDLMRPItem { get; set; }
        public IEnumerable<SelectListItem> DDLReportType { get; set; }
        public IEnumerable<SelectListItem> DDLBuyer { get; set; }
        public IEnumerable<SelectListItem> DDLOrder { get; set; }





    }
}
