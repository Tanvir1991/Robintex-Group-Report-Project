using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblBpvreport
    {
        public string VoucherName { get; set; }
        public string Item { get; set; }
        public string Identification { get; set; }
        public string Prefix { get; set; }
        public string ChqNum { get; set; }
        public DateTime? ChqDate { get; set; }
        public DateTime? PrepareDate { get; set; }
        public decimal? Net { get; set; }
        public DateTime? DateToBePaid { get; set; }
        public string CompId { get; set; }
        public string UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
