using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
   public class VoucherCreditInformation
    {
        public string CreditAccount { get; set; }
        public int CreditAccountID { get; set; }

        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public string CostCenter { get; set; }
        public int CostCenterId { get; set; }
        public string Activity { get; set; }
        public int ActivityId { get; set; }
    }
}
