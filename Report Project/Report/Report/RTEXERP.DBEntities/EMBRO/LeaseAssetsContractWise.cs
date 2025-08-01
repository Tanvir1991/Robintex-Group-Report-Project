using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class LeaseAssetsContractWise
    {
        public int Assetid { get; set; }
        public int LeaseId { get; set; }
        public int? AssetCoaid { get; set; }
        public bool? Status { get; set; }
        public int? VersionNo { get; set; }

        public virtual FixedAsset Asset { get; set; }
        public virtual LeaseLoanPayment Lease { get; set; }
    }
}
