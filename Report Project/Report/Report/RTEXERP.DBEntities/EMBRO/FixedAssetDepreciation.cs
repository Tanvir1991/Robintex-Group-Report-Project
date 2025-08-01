using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class FixedAssetDepreciation
    {
        public int DepreciationId { get; set; }
        public int AssetId { get; set; }
        public DateTime DepreciationDate { get; set; }
        public decimal AmountDepreciated { get; set; }
        public decimal WrittenDownValue { get; set; }
        public string VoucherNumber { get; set; }
    }
}
