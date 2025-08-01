using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class MAC_FabricCostingInfo
    {
        public int ID { get; set; }
        public int OrderCostingID { get; set; }
        public string FabricCompisition { get; set; }
        public int? GSM { get; set; }
        public int? FabricQualityID { get; set; }
        public string YarnCount { get; set; }
        public string FabricColor { get; set; }
        public decimal? YarnPrice { get; set; }
        public decimal? LycraCostPercent { get; set; }
        public decimal? LycraCost { get; set; }
        public decimal? KnittingCost { get; set; }
        public decimal? KnittingWastagePer { get; set; }
        public decimal? DeyingCostSolid { get; set; }
        public decimal? DeyingCostAOP { get; set; }
        public decimal? DeyingWastagePer { get; set; }
        public decimal? LeveragePercent { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemvoed { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBY { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public MAC_OrderCostingInfo MAC_OrderCostingInfo { get; set; }
    }
}
