using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.EMBRO
{
    public class ExportInvoiceVoucherMapping
    {
        public int ID { get; set; }
        public long VoucherID { get; set; }
        public DateTime VoucherDate { get; set; }
        public int ExportInvoiceTypeID { get; set; }
        public string MappingNo { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
