using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ItemMap
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? AccountingDepPolicy { get; set; }
        public int? AccountingDepMethod { get; set; }
        public decimal? AccountingDepRate { get; set; }
        public int? TaxDepMethod { get; set; }
        public decimal? TaxDepRate1 { get; set; }
        public decimal? TaxDepRate2 { get; set; }
        public decimal? TaxDepRate3 { get; set; }
        public decimal? TaxDepRateN { get; set; }
        public string Initials { get; set; }
    }
}
