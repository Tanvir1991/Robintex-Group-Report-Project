using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class Porefrence
    {
        public long Poid { get; set; }
        public string Pono { get; set; }
        public long? OrderId { get; set; }
        public DateTime? Podate { get; set; }
        public bool? Status { get; set; }
        public long? StyleId { get; set; }
        public int? IsEdited { get; set; }
        public DateTime? EditPodate { get; set; }
        public decimal? AvgPrice { get; set; }
    }
}
