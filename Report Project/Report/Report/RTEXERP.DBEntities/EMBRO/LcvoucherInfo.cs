using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class LcvoucherInfo
    {
        public long LcdetailId { get; set; }
        public decimal VoucherId { get; set; }
        public DateTime BankAcceptanceDate { get; set; }
        public DateTime BankMaturityDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LcvoucherCreationDate { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
