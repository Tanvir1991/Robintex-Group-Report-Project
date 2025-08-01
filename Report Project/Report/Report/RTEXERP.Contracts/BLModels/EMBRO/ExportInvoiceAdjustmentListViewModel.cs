using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
  public  class ExportInvoiceAdjustmentListViewModel
    {
        public int AdjustmentID { get; set; }
        public long CompanyID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string DateFromSTR { get { return DateFrom.ToString("dd-MMM-yyyy"); } }
        public string DateToSTR { get { return DateTo.ToString("dd-MMM-yyyy"); } }

        public string VoucherNumber { get; set; }
        public string VoucherDate { get; set; }
        public string AdjustmentNo { get; set; }
        public string AdjustmentDate { get; set; }
        public decimal Amount { get; set; }
        public string ChequeNumber { get; set; }
        public int ExportInvoiceTypeID { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLExportInvoiceType { get; set; }
    }
}
