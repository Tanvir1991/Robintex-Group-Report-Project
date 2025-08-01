using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class TblFdbpRealizationDetail1
    {
        public long FdbpDetailId { get; set; }
        public long? FdbpDetailMasterId { get; set; }
        public long? FdbpDetailInvoiceId { get; set; }
        public string FdbpDetailTransRef { get; set; }
        public double? FdbpDetailDiscount { get; set; }
        public double? FdbpDetailAmount { get; set; }
        public string FdbpDetailInvoiceNo { get; set; }
        public string FdbpDetailDocRef { get; set; }
        public int? FdbpDetailStatus { get; set; }
        public DateTime? FdbpDetailStatusDate { get; set; }
    }
}
