using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMS
{
    public class FCR_InvoiceOrderMappingViewModel
    {
        public int Sl { get; set; }
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public string FCRNo { get; set; }
        public DateTime FCRDate { get; set; }
        public string FCRDateMSG { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Excel Data")]
        public string ExcelData { get; set; }
        public IEnumerable<SelectListItem> InvoiceList { get; set; }
        public IEnumerable<SelectListItem> DDLCompany { get; set; }

    }
}
