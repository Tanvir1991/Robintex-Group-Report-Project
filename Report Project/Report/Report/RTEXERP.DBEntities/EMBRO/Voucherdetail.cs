using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Voucherdetail
    {
        [Key]
        public long Vid { get; set; }
        [ForeignKey("Voucher")]
        public decimal VoucherId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public int? LocationId { get; set; }
        public string Status { get; set; }
        public long? Costcenter { get; set; }
        public long? Activity { get; set; }
        public int? Vindex { get; set; }

        public long? EntryType { get; set; }

        public Voucher Voucher { get; set; }
    }
}
