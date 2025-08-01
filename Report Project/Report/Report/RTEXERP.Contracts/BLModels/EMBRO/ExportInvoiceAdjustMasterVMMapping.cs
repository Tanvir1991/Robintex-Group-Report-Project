using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
   public class ExportInvoiceAdjustMasterVMMapping
    {
        [Display(Name = "Company")]
        public long CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int BusinessID { get; set; }
        public string BusinessName { get; set; }
        public int ID { get; set; }
        [Display(Name = "Voucher No.")]
        public decimal VoucherID { get; set; }
        [Display(Name = "Voucher Amount")]
        public decimal VoucherAmount { get; set; }
        public string AdjustmentNo { get; set; }
        [Display(Name ="Export Service Type")]
        public int ExportServiceTypeID { get; set; }
        [Display(Name ="Invoice")]
        public int InvoiceID { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [Display(Name = "Excel Data")]
        public string ExcelData { get; set; }
        public List<SelectListItem> DDLVoucher { get; set; }
        public List<SelectListItem> DDLInvoice { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLExportService { get; set; }
        public string UserName { get; set; }
    }
}
