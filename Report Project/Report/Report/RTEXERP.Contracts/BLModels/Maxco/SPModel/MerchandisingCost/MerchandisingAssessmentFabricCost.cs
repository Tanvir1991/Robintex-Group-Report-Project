using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel.MerchandisingCost
{
    public class MerchandisingAssessmentFabricCost
    {
        public int ID { get; set; }
        public DateTime? CostingDate { get; set; }
        public string Buyername { get; set; }
        public int OrderQuantity { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        public decimal? SMV { get; set; }
        public decimal? Efficiency { get; set; }
        public decimal? CPM { get; set; }
        public decimal? CBL { get; set; }
        public decimal? BackCalculationPercent { get; set; }
        public decimal? FabricConsumptionPerDzn { get; set; }
        public string FabricCompisition { get; set; }
        public int GSM { get; set; }
        public string FabricQuality { get; set; }
        public string YarnCount { get; set; }
        public string FabricColor { get; set; }
        public decimal? YarnPrice { get; set; }
        public decimal? LycraCostPercent { get; set; }
        public decimal? LycraCost { get; set; }
        public decimal? KnittingCost { get; set; }
        public decimal? KnittingWastagePer { get; set; }
        public decimal? DeyingCostSolid { get; set; }
        public decimal? DeyingWastagePer { get; set; }
        public decimal? Totalcost { get; set; }
        public decimal? Contribution { get; set; }
        public decimal? LeveragePercent { get; set; }
        public int FabricCount { get; set; }


    }

    public class MerchandisingAssessmentIndirectCost
    {
        public int ID { get; set; }
        public int CostingTypeID { get; set; }
        public string CostingFor { get; set; }
        public decimal? CostingRate { get; set; }
        public string CalculationType { get; set; }
        public string CssClass { get; set; }
    }
}
