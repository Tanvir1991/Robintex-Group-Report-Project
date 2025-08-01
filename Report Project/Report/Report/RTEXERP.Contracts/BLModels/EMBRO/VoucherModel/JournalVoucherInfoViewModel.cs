using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO.VoucherModel
{
    public class JournalVoucherInfoViewModel
    {
        public decimal VoucherId { get; set; }
        public int? AccountId { get; set; }
        public int? ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public int? StoreId { get; set; }
        public string RequisitionNumber { get; set; }
        public decimal? ConversionCost { get; set; }
        public string MaterialName { get; set; }
        public string QuantityUnit { get; set; }
        public int? Vindex { get; set; }
        public long Vid { get; set; }
    }
}
