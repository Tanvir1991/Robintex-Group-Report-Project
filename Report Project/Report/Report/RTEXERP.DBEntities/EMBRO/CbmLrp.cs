using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmLrp
    {
        public CbmLrp()
        {
            CbmLrpDetail = new HashSet<CbmLrpDetail>();
            CbmRelateEcfRfpChqVoucher = new HashSet<CbmRelateEcfRfpChqVoucher>();
        }

        public decimal Lrpid { get; set; }
        public string Lrpnum { get; set; }
        public DateTime? Lrpdate { get; set; }
        public decimal? LocationId { get; set; }
        public string Lrpdescription { get; set; }
        public string PaymentMode { get; set; }
        public decimal? NetAmount { get; set; }
        public int LeasorId { get; set; }
        public decimal? CompId { get; set; }
        public decimal? BusinessId { get; set; }
        public decimal? CreationBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? VerificationBy { get; set; }
        public DateTime? Verificationdate { get; set; }
        public decimal? CheckBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public decimal? Voucherid { get; set; }

        public virtual ICollection<CbmLrpDetail> CbmLrpDetail { get; set; }
        public virtual ICollection<CbmRelateEcfRfpChqVoucher> CbmRelateEcfRfpChqVoucher { get; set; }
    }
}
