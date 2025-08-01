using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class JournalVoucherInfo
    {
        public int Id { get; set; }
        public decimal? VoucherId { get; set; }
        public int? ItemId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public int? Vindex { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
