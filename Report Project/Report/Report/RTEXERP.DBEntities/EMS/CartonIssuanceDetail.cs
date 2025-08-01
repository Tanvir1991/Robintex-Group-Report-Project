using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class CartonIssuanceDetail
    {
        public int Id { get; set; }
        public int? Isid { get; set; }
        public int? CartonId { get; set; }
        public int? Poid { get; set; }
    }
}
