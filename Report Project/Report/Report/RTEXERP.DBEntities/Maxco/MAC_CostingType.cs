using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class MAC_CostingType
    {
        public MAC_CostingType()
        {
            MAC_IndirectCostingItem = new List<MAC_IndirectCostingItem>();
            MAC_AccessoriesCostingInfo = new List<MAC_AccessoriesCostingInfo>();
        }
        public int ID { get; set; }
        public string CostingType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemvoed { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBY { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<MAC_IndirectCostingItem> MAC_IndirectCostingItem { get; set; }
        public List<MAC_AccessoriesCostingInfo> MAC_AccessoriesCostingInfo { get; set; }
    }
}
