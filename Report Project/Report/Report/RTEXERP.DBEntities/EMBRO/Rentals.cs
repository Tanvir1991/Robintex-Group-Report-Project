using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Rentals
    {
        public Rentals()
        {
            CbmLrpDetail = new HashSet<CbmLrpDetail>();
        }

        public int Id { get; set; }
        public int LeaseId { get; set; }
        public string LeaseLoanCode { get; set; }
        public int VersionNo { get; set; }
        public DateTime? Startdate { get; set; }
        public int? LeaseRentalNo { get; set; }
        public decimal? TotalPrincipalOutstanding { get; set; }
        public decimal? TotalFinancialChargesOutstanding { get; set; }
        public decimal? TotalRentalOutstanding { get; set; }
        public decimal? Rentals1 { get; set; }
        public decimal? Interest { get; set; }
        public decimal? Principal { get; set; }
        public int? Paid { get; set; }
        public decimal Insurance { get; set; }
        public bool? Status { get; set; }

        public virtual LeaseLoanPayment Lease { get; set; }
        public virtual ICollection<CbmLrpDetail> CbmLrpDetail { get; set; }
    }
}
