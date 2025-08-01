using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmEcfdetail
    {
        public decimal? Ecfid { get; set; }
        public string Particulars { get; set; }
        public decimal? AccountId { get; set; }
        public decimal? RefId { get; set; }
        public string RefNo { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? LocationId { get; set; }
        public decimal? CostCenterId { get; set; }
        public decimal? ActivityId { get; set; }
        public DateTime? ExpenseDate { get; set; }

        public virtual CbmEcf Ecf { get; set; }
    }
}
