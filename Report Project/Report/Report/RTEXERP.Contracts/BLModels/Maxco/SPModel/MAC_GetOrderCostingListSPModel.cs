using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel
{
    public class MAC_GetOrderCostingListSPModel
    {
        public int ID { get; set; }
        public DateTime CostingDate { get; set; }

        public string Code { get; set; }
        public string BuyerName { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal OfferPrice { get; set; }
        public string FabricInfo { get; set; }
        
        public decimal? Efficiency { get; set; }
        public decimal? SMV { get; set; }
        public decimal? CPM { get; set; }

        public int IsInsertedAlgo { get; set; }

        public string CostingDateSTR { get { return this.CostingDate.ToString("dd-MMM-yyyy"); } }
    }
}
