using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
   public class MAC_AccessoriesCostingInfoVM
    {
        public int ID { get; set; }
        public int OrderCostingID { get; set; }
        public int? TrimID { get; set; }
        public int? CostingItemID { get; set; }
        public int CostingTypeID { get; set; }
        public string CostingFor { get; set; }
        public decimal CostRate { get; set; }
    }
}
