using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Voucheracb
    {
        public decimal Id { get; set; }
        public string VoucherNumber { get; set; }
        public int? VoucherType { get; set; }
        public DateTime? Vdate { get; set; }
        public int CompanyId { get; set; }
        public int BusinessId { get; set; }
        public decimal? PreparedBy { get; set; }
        public decimal? CheckedBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? IndividualVoucherId { get; set; }
        public string VoucherDescription { get; set; }
        public decimal? AuthorizedBy { get; set; }
        public DateTime? AuthorizeDate { get; set; }
        public DateTime? PrepareDate { get; set; }
        public int? SystemVoucher { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? ExpiredBy { get; set; }
        public string EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public int? NoOfDays { get; set; }
        public string PaymentTerm { get; set; }
        public int SubVoucherType { get; set; }
        public DateTime Rdate { get; set; }
        public int? StoreId { get; set; }
        public decimal? Crate { get; set; }
        public decimal? AmtInDoller { get; set; }
    }
}
