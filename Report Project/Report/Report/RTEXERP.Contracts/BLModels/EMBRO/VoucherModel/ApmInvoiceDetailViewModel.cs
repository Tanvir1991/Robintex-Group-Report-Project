using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO.VoucherModel
{
  public  class ApmInvoiceDetailViewModel
    {
        public decimal InvoiceId { get; set; }
        public decimal VoucherId { get; set; }
        public decimal? InvoiceEffect { get; set; }
    }
}
