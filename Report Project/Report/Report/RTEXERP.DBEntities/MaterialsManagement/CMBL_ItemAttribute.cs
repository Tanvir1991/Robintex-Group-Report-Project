using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class CMBL_ItemAttribute
    {
        public CMBL_ItemAttribute()
        {
            CMBL_ItemAttributeSet = new HashSet<CMBL_ItemAttributeSet>();
        }
        [Key]
        public long AttributeID { get; set; }
        public string AttributeName { get; set; }
        public int ParentAttributeID { get; set; }
        public int AttributeLevel { get; set; }
        public string AttributeCode { get; set; }
        public int CompanyID { get; set; }

        public virtual ICollection<CMBL_ItemAttributeSet> CMBL_ItemAttributeSet { get; set; }
    }
}
