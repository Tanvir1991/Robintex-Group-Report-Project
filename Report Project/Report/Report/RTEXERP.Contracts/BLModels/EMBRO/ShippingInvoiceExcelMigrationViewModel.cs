using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
    public class ShippingInvoiceExcelMigrationViewModel
    {        
        public int? ExcelSerial { get; set; }
        public string InvoiceNo { get; set; }
        public string ShippingBillNo { get; set; }
        public DateTime ShippingDate { get; set; }        
        public string ModifiedDescription { get; set; }
    }
}
