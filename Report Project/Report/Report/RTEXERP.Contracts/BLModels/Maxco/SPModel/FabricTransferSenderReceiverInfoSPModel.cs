using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel
{
    public class FabricTransferSenderReceiverInfoSPModel
    {
        public int VersionID { get; set; }
        public int OrderID { get; set; }
        public long AttributeInstanceID { get; set; }
        public string OrderNo { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public string FabricComposition { get; set; }
        public string FinishedWidth { get; set; }
        public int GSM { get; set; }
        public string PantoneNo { get; set; }
        public decimal OSQuantity { get; set; }
        public decimal TransferedQuantity { get; set; }
        public decimal RemainingQuantity { get { return OSQuantity - TransferedQuantity; } }
    }
}
