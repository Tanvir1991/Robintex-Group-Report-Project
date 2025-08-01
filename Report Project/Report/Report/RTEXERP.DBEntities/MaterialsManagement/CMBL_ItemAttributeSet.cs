using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class CMBL_ItemAttributeSet
    {
        [Key]
        public long ItemAttributeID { get; set; }
        public long ItemID { get; set; }
        public long AttributeID { get; set; }
        public int AttributeLevel { get; set; }
        public virtual CMBL_ItemAttribute CMBL_ItemAttribute { get; set; }
        public virtual CMBL_Item CMBL_Item { get; set; }
    }
}
