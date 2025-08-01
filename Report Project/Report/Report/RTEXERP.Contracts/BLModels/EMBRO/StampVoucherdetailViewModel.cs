using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
   public class StampVoucherdetailViewModel
    {
        public decimal VoucherId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public int? LocationId { get; set; }
        public string Status { get; set; }
        public long? Costcenter { get; set; }
        public long? Activity { get; set; }
        public int? Vindex { get; set; }
        public long Vid { get; set; }
        public long? EntryType { get; set; }

        public IEnumerable<SelectListItem> DDLCostCentr { get; set; }
        public IEnumerable<SelectListItem> DDLActivity { get; set; }



    }
}
