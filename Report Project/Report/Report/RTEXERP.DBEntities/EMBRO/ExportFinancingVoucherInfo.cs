using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ExportFinancingVoucherInfo
    {
        public long Id { get; set; }
        public long? VoucherId { get; set; }
        public int? VoucherTypeMainId { get; set; }
        public string VoucherTypeText { get; set; }
        public int? BuyerId { get; set; }
        public string BuyerName { get; set; }
        public int? Lcid { get; set; }
        public string Lcnum { get; set; }
    }
}
