using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{

    public class MAC_AccessoriesCostingInfo
    {
        public int ID { get; set; }
        public int OrderCostingID { get; set; }
        public int? TrimID { get; set; }
        [ForeignKey("MAC_IndirectCostingItem")]
        public int ? CostingItemID { get; set; }
        [ForeignKey("MAC_CostingType")]
        public int CostingTypeID { get; set; }
        public string CostingFor { get; set; }
        public decimal CostRate { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemvoed { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBY { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public MAC_OrderCostingInfo MAC_OrderCostingInfo { get; set; }
        public MAC_IndirectCostingItem MAC_IndirectCostingItem { get; set; }
        public MAC_CostingType MAC_CostingType { get; set; }





    }
}
