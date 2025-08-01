using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class OrderKRSBatchInfoViewModel
    {
        public string FabricQuality { get; set; }
        public int YarnInKRS { get; set; }
        public decimal YarnInKRSPercentage { get; set; }
        public decimal BatchDelivery { get; set; }

        public decimal DyeingPrintQty { get; set; }
        public decimal FinishQty { get; set; }

        public int KRSID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyShortName { get; set; }
        public string BuyerName { get; set; }
    }
}
