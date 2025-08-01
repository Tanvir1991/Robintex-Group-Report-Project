using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement.DB_View
{
   public class vw_CMBL_ItemALLAttribute
    {
       
        public int CompanyID { get; set; }
        [Key]
        public long L_1_AttributeID { get; set; }
        public string L_1_AttributeName { get; set; }
        public long L_2_AttributeID { get; set; }
        public string L_2_AttributeName { get; set; }
        public long L_3_AttributeID { get; set; }
        public string L_3_AttributeName { get; set; }
        public long L_4_AttributeID { get; set; }
        public string L_4_AttributeName { get; set; }
        public long L_5_AttributeID { get; set; }
        public string L_5_AttributeName { get; set; }
        public long L_6_AttributeID { get; set; }
        public string L_6_AttributeName { get; set; }
        public long ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public int SKU { get; set; }
        public long SafetyStock { get; set; }
    }
}
