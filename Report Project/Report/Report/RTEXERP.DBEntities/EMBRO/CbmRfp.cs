using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmRfp
    {
        public CbmRfp()
        {
            CbmRelateEcfRfpChqVoucher = new HashSet<CbmRelateEcfRfpChqVoucher>();
            CbmRfpDetail = new HashSet<CbmRfpDetail>();
        }

        public decimal Rfpid { get; set; }
        public string Rfpnum { get; set; }
        public DateTime? Rfpdate { get; set; }
        public decimal? LocationId { get; set; }
        public string Rfpdescription { get; set; }
        public string PaymentMode { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? SupplierId { get; set; }
        public decimal? CompId { get; set; }
        public decimal? BusinessId { get; set; }
        public decimal? CreationBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? VerificationBy { get; set; }
        public DateTime? Verificationdate { get; set; }
        public decimal? CheckBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public bool? IsAdvanceAdjusted { get; set; }
        public int? RfpaddedStatus { get; set; }
        public decimal? RelatedOldRfpid { get; set; }

        public virtual ICollection<CbmRelateEcfRfpChqVoucher> CbmRelateEcfRfpChqVoucher { get; set; }
        public virtual ICollection<CbmRfpDetail> CbmRfpDetail { get; set; }
    }
}
