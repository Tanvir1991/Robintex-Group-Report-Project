using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.DataTransferModel
{
    public class InterOrderFabricTransferDTM
    {
        public int TransferedFromVersionID { get; set; }
        public int TransferedToVersionID { get; set; }
        public int TransferID { get; set; }
        public DateTime TransferDate { get; set; }
        public int TransferedFromOrderID { get; set; }
        public string TransferedFromOrderNo { get; set; }
        public long TransferedFromOrderFabricAttributeInstanceID { get; set; }
        public int TransferedToOrderID { get; set; }
        public string TransferedToOrderNo { get; set; }
        public long TransferedToOrderFabricAttributeInstanceID { get; set; }
        public decimal TransferedQuantity { get; set; }
        public int TransferTypeID { get; set; }
    }
}
