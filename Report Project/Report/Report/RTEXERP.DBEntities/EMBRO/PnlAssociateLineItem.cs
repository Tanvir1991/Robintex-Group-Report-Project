using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class PnlAssociateLineItem
    {
        public int Id { get; set; }
        public int? LineId { get; set; }
        public long? CoaId { get; set; }
    }
}
