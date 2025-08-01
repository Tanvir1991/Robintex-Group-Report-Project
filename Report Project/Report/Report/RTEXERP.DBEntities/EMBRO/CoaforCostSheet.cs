using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CoaforCostSheet
    {
        public int Id { get; set; }
        public int? Coaid { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
    }
}
