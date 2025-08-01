using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class InterOrderFabricTransfer
    {
        [Key]
        public int TransferID { get; set; }
        public DateTime TransferDate { get; set; }
        public int TransferedFromOrderID { get; set; }
        public string TransferedFromOrderNo { get; set; }
        public long TransferedFromOrderFabricAttributeInstanceID { get; set; }
        public int TransferedToOrderID { get; set; }
        public string TransferedToOrderNo { get; set; }
        public long TransferedToOrderFabricAttributeInstanceID { get; set; }
        public bool IsFromOSGenerated { get; set; }
        public bool? IsToOSGenerated { get; set; }
        public decimal TransferedQuantity { get; set; }
        public int TransferTypeID { get; set; }
        public string Remarks { get; set; }
        public bool IsRemoved { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
