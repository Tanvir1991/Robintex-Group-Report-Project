using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class ConsumptionSheetCMViewModel
    {
        public decimal CPM { get; set; }
        public decimal SMV { get; set; }
        public decimal Efficiency { get; set; }
        public decimal QuotationCM { get; set; }
        public decimal SMVCM { get; set; }
        public decimal ALGOCM { get; set; }
        public decimal AdditionalFabricValue { get; set; }
        public int TotalOrderQty { get; set; }
        public decimal ReviseCM { get; set; }
        public decimal FabricCostPerKG { get; set; }
        public decimal FabricConsumptionKGPerDzn { get; set; }
        public int AdditionalFabricQty { get; set; }
    }
}
