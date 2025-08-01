using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Valuation
    {
        public int Id { get; set; }
        public string ValuationDate { get; set; }
        public int? ValuatorId { get; set; }
        public decimal? RevisedValue { get; set; }
        public int? AssetId { get; set; }
        public int? ItemId { get; set; }
        public int? ReasonId { get; set; }
        public int? Status { get; set; }
        public decimal? OriginalCost { get; set; }
        public decimal? Wdv { get; set; }
        public int? AssetCoaid { get; set; }
        public string ItemType { get; set; }
        public int? Daccountid { get; set; }
        public int? Caccountid { get; set; }
        public string ValuatorName { get; set; }
    }
}
