using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.EMBRO
{
    public class ExportInvoiceAdjustMaster
    {
        public ExportInvoiceAdjustMaster()
        {
            ExportInvoiceAdjustDetails = new HashSet<ExportInvoiceAdjustDetails>();
        }
        public int ID { get; set; }
        public decimal VoucherID { get; set; }
        public string AdjustmentNo { get; set; }
        public int? AdjustmentSerial { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public int? CreateBY { get; set; }

        public ICollection<ExportInvoiceAdjustDetails> ExportInvoiceAdjustDetails { get; set; }
    }
}
