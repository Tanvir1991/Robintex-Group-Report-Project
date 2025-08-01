using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmFinFacility
    {
        public decimal FinFacilityId { get; set; }
        public string FinFacilityName { get; set; }
        public string FinFacilityDesc { get; set; }
        public string Type { get; set; }

        public virtual BasicCoa FinFacility { get; set; }
    }
}
