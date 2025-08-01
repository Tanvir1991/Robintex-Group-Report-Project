using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class PackingAssortmentMasterDetail
    {
        public long Id { get; set; }
        public int? PackingAssortmentId { get; set; }
        public int? NoOfMasterPoly { get; set; }
        public long? BlisterId { get; set; }
    }
}
