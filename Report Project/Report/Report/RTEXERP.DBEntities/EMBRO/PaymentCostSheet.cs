using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class PaymentCostSheet
    {
        public int Id { get; set; }
        public string Lcno { get; set; }
        public int? Coaid { get; set; }
        public decimal? Amount { get; set; }
    }
}
