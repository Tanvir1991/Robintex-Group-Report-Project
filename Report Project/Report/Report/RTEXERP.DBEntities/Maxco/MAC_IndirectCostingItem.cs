using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class MAC_IndirectCostingItem
    {
        public MAC_IndirectCostingItem()
        {
            MAC_AccessoriesCostingInfo = new List<MAC_AccessoriesCostingInfo>();
        }
        public int ID { get; set; }
        public int? CostingTypeID { get; set; }
        public string CostingItem { get; set; }
        public string CssClass { get; set; }
        public int? ShowSerial { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemvoed { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBY { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public MAC_CostingType MAC_CostingType { get; set; }
        public List<MAC_AccessoriesCostingInfo> MAC_AccessoriesCostingInfo { get; set; }
    }
}
