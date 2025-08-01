using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class FixedAssetClass
    {
        public FixedAssetClass()
        {
            FixedAsset = new HashSet<FixedAsset>();
        }

        public int ClassId { get; set; }
        public string ClassGroupId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AccountDepriciationMethodId { get; set; }
        public int? TaxDepriciationMethodId { get; set; }
        public decimal? AccountDepriciationRate { get; set; }
        public decimal? TaxDepriciationRate1 { get; set; }
        public decimal? TaxDepriciationRate2 { get; set; }
        public decimal? TaxDepriciationRate3 { get; set; }
        public decimal? TaxDepriciationRateN { get; set; }
        public int? DepriciationPolicyId { get; set; }

        public virtual ICollection<FixedAsset> FixedAsset { get; set; }
    }
}
