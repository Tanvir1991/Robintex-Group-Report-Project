using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class AdvancePayment
    {
        public long Id { get; set; }
        public string Poid { get; set; }
        public decimal? Deduction { get; set; }
        public long? Voucherid { get; set; }
        public long? SupplierId { get; set; }
        public string PoNumber { get; set; }
        public int? StoreId { get; set; }
    }
}
