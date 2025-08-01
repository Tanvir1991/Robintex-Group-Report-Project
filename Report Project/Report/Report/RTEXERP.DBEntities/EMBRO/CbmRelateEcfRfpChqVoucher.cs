using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmRelateEcfRfpChqVoucher
    {
        public decimal VoucherId { get; set; }
        public decimal? Ecfid { get; set; }
        public decimal? Rfpid { get; set; }
        public decimal? Lrpid { get; set; }
        public decimal? ChqId { get; set; }
        public DateTime? AdjustmentDate { get; set; }
        public long Vid { get; set; }

        public virtual CbmEcf Ecf { get; set; }
        public virtual CbmLrp Lrp { get; set; }
        public virtual CbmRfp Rfp { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
