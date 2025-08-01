using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ViwVoucher
    {
        public decimal VoucherId { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime? Vdate { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string VoucherDescription { get; set; }
        public long? Costcenter { get; set; }
        public int? LocationId { get; set; }
        public long? Activity { get; set; }
        public DateTime Rdate { get; set; }
        public int CompanyId { get; set; }
        public int BusinessId { get; set; }
        public int? Vindex { get; set; }
        public long Vid { get; set; }
        public decimal? PreparedBy { get; set; }
        public decimal? CheckedBy { get; set; }
        public decimal? AuthorizedBy { get; set; }
        public int? IndividualVoucherId { get; set; }
        public int? VoucherType { get; set; }
        public int? ParentId { get; set; }
        public int? NoOfDays { get; set; }
        public long? EntryType { get; set; }
        public decimal? Crate { get; set; }
    }
}
