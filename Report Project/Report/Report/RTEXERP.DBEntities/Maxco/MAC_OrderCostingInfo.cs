using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class MAC_OrderCostingInfo
    {
        public MAC_OrderCostingInfo()
        {
            MAC_AccessoriesCostingInfo = new List<MAC_AccessoriesCostingInfo>();
            MAC_FabricCostingInfo = new List<MAC_FabricCostingInfo>();
        }
        public int ID { get; set; }
        public DateTime CostingDate { get; set; }
        public string Code { get; set; }
        public int? BuyerID { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        
        public int? OrderQuantity { get; set; }
        public decimal? Efficiency { get; set; }
        public decimal? SMV { get; set; }
        public decimal? CPM { get; set; }
        public decimal? CBL { get; set; }

        public string Remarks { get; set; }

        public decimal? BackCalculationPercent { get; set; }
        public decimal? FabricConsumptionPerDzn { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemvoed { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBY { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<MAC_FabricCostingInfo> MAC_FabricCostingInfo { get; set; }
        public List<MAC_AccessoriesCostingInfo> MAC_AccessoriesCostingInfo { get; set; }

    }
}
