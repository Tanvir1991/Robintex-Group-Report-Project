using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Materials
{
    public class YarnLotNo
    {
        public string LotNo { get; set; }
        public int CompanyID { get; set; }
        public decimal BlanceQty { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
      
        public int YarnCountId { get; set; }
        public int YarnCompositionId { get; set; }
        [Display(Name ="Report Type")]
         public int ReportType { get; set; }

        public IEnumerable<SelectListItem> DDLReportType { get; set; }
        public IEnumerable<SelectListItem> DDLCompany { get; set; }
        public IEnumerable<SelectListItem> DDlLotNo { get; set; }
        public IEnumerable<SelectListItem>DDLYarnCountList { get; set; }
        public IEnumerable<SelectListItem> DDLYarnCompositionList { get; set; }

        public string DateFromSt { get { return DateTime.Now.ToString("dd-MMM-yyyy"); } }
        public string DateToST { get { return DateTime.Now.ToString("dd-MMM-yyyy"); } }
    }
}
