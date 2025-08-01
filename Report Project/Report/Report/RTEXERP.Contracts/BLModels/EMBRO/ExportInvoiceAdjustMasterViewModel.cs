using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
   public class ExportInvoiceAdjustMasterViewModel
    {
      public  ExportInvoiceAdjustMasterViewModel()
        {
            ExportInvoiceAdjustDetails = new List<ExportInvoiceAdjustDetailsViewModel>();
        }
        public int ID { get; set; }
        public int ExportServiceTypeID { get; set; }
        public decimal VoucherID { get; set; }
        public string AdjustmentNo { get; set; }
        public int? AdjustmentSerial { get; set; }
        public long CompanyID { get; set; }
        public int? CreateBy { get; set; }

        public List<SelectListItem> DDLVoucher { get; set; }
        public List<ExportInvoiceAdjustDetailsViewModel> ExportInvoiceAdjustDetails { get; set; }
 
    }
}
