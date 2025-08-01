using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmEcf
    {
        public CbmEcf()
        {
            CbmEcfdetail = new HashSet<CbmEcfdetail>();
            CbmRelateEcfRfpChqVoucher = new HashSet<CbmRelateEcfRfpChqVoucher>();
        }

        public decimal Ecfid { get; set; }
        public string Ecfnum { get; set; }
        public DateTime? Ecfdate { get; set; }
        public string Ecfdescription { get; set; }
        public string Ecftype { get; set; }
        public decimal? Claimant { get; set; }
        public decimal? Total { get; set; }
        public string PaymentMode { get; set; }
        public decimal? CompId { get; set; }
        public decimal? BusinessId { get; set; }
        public decimal? CreationBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal? VerificationBy { get; set; }
        public DateTime? VerificationDate { get; set; }
        public decimal? ApprovalBy { get; set; }
        public DateTime? ApprovalDate { get; set; }

        public virtual ICollection<CbmEcfdetail> CbmEcfdetail { get; set; }
        public virtual ICollection<CbmRelateEcfRfpChqVoucher> CbmRelateEcfRfpChqVoucher { get; set; }
    }
}
