using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO.VoucherModel
{
   public class VoucherGeneralInfoViewModel
    {
        public int Id { get; set; }
        
        public decimal VoucherId { get; set; }

        public int AccountId { get; set; }
        public string Description { get; set; }
        public string Billno { get; set; }
        public DateTime? Billdate { get; set; }
        public string RefNo { get; set; }
        public decimal? Discount { get; set; }
        public decimal? InTax { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Net { get; set; }
        public string Comments { get; set; }
        public string Currency { get; set; }
        public decimal? ConversionRate { get; set; }
        public string SupplierDonumber { get; set; }
        public DateTime? Podate { get; set; }
        public DateTime? Grndate { get; set; }
        public DateTime? Dcdate { get; set; }
        public decimal? InvoiceEffect { get; set; }
        public int? Vindex { get; set; }
        public decimal? ExciseDuty { get; set; }
        public string Lcnumber { get; set; }
        public long? Lcid { get; set; }
        public long? BankAccId { get; set; }
    }
}
