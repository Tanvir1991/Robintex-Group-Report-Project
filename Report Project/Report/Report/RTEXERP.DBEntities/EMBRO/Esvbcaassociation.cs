using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Esvbcaassociation
    {
        public int Id { get; set; }
        public int? Bcavid { get; set; }
        public string Bank { get; set; }
        public string Invoice { get; set; }
        public decimal? NewGrossPks { get; set; }
        public decimal? OldGrossPks { get; set; }
        public decimal? GrossFc { get; set; }
        public int? Esvid { get; set; }
        public decimal? Conversionrate { get; set; }
        public DateTime? Edate { get; set; }
    }
}
