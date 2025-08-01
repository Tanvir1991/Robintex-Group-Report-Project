using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class PackingAssortmentMain
    {
        public int Id { get; set; }
        public long? Poid { get; set; }
        public int? CartoonId { get; set; }
        public int? NoOfCartons { get; set; }
        public int? TotalCartonsDispatched { get; set; }
        public bool? IsMasterPoly { get; set; }
        public DateTime? PackingDate { get; set; }
        public int? TotalGarments { get; set; }
        public int? Status { get; set; }
        public string CartonNo { get; set; }
    }
}
