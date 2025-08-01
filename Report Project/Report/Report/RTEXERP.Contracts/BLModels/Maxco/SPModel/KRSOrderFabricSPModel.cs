using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel
{
  public  class KRSOrderFabricSPModel
    {
        public long OrderID { get; set; }
        public int KRS_MID { get; set; }
        public string KRS_MIDSTR { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string OrderNo { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public string FAB_COMPOSITION { get; set; }
        public int GSM { get; set; }
        public double FINISHED_WIDTH { get; set; }
        public string MachineType { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public decimal Quantity { get; set; }
    }
}
