using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel
{
    public class MerOrderShipmentSPModel
    {
        public int StyleMasterID { get; set; }
        public string Program { get; set; }
        public string StyleNo { get; set; }
        public string PONumber { get; set; }
        public string OrderNo { get; set; }
        public DateTime ExFactoryDate { get; set; }
        public string ExFactoryDateMsg { get { return ExFactoryDate.ToString("dd-MMM-yyyy"); } }
        public int OrderQuantity { get; set; }
        public string ExportMonth { get; set; }

    }
}
