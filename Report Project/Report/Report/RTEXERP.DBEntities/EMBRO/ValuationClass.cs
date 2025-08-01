using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ValuationClass
    {
        public decimal ClassId { get; set; }
        public string ClassName { get; set; }
        public int ParentId { get; set; }
        public int CompanyId { get; set; }
        public int BusinessId { get; set; }
        public int? LocationId { get; set; }
        public int? SalesTaxAccount { get; set; }
        public int? IncomeTaxAccount { get; set; }
        public int? ExciseDutyAccount { get; set; }

        public virtual BasicCoa Class { get; set; }
    }
}
