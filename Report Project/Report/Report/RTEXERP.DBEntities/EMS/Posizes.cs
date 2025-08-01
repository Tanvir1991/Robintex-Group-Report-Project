using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class Posizes
    {
        public long Id { get; set; }
        public long? Poid { get; set; }
        public long? SizeId { get; set; }
        public string SizeName { get; set; }
        public DateTime? PrepareDate { get; set; }
        public double? PosizePrice { get; set; }
    }
}
