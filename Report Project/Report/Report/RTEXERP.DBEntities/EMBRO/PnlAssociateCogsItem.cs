using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class PnlAssociateCogsItem
    {
        public int Id { get; set; }
        public long? AccountId { get; set; }
        public int? CogsLineId { get; set; }
    }
}
