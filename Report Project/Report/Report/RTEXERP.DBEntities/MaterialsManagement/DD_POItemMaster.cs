using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class DD_POItemMaster
    {
        public DD_POItemMaster()
        {
            DD_POItemDetails = new List<DD_POItemDetails>();
        }
        public int ID { get; set; }
        [ForeignKey("DD_PurchaseOrder")]
        public long PurchaseOrderID { get; set; }
        public long AttributeInstanceID { get; set; }
        public int? UnitID { get; set; }
        public int? OrderID { get; set; }
        public int? ObjectID { get; set; }
        public int? RequisitionID { get; set; }
        public int? MRPItemCode { get; set; }
        public int? IsMRPBased { get; set; }
        public int? ModelID { get; set; }
        public long? NewAttributeInstance { get; set; }
        public bool? IsNewAttributeInstance { get; set; }


        public DD_PurchaseOrder DD_PurchaseOrder { get; set; }
        public List<DD_POItemDetails> DD_POItemDetails { get; set; }
    }
}
