using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CostCenterLocation
    {
        public decimal CostCenterId { get; set; }
        public decimal LocationId { get; set; }

        public virtual BasicCoa CostCenter { get; set; }
        public virtual Location Location { get; set; }
    }
}
