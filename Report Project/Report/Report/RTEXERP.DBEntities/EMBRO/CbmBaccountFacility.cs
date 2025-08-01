using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmBaccountFacility
    {
        public decimal? BaccountId { get; set; }
        public string FinFacilityId { get; set; }
        public decimal? Limit { get; set; }
        public decimal? Rate { get; set; }
        public string Collateral { get; set; }
        public string Remarks { get; set; }
        public DateTime? RepaymentDate { get; set; }
        public DateTime? RenewalDate { get; set; }

        public virtual BasicCoa Baccount { get; set; }
    }
}
