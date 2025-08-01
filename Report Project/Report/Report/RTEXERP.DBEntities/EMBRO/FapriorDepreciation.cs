using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class FapriorDepreciation
    {
        public decimal AssetId { get; set; }
        public float? PriorDepriciationValue { get; set; }
        public string PriorDepriciationNarration { get; set; }
        public int YearNumber { get; set; }
        public int? NoOfMonths { get; set; }
        public double? Rate { get; set; }
    }
}
