using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class CMBL_Item
    {
        public CMBL_Item()
        {
            CMBL_ItemAttributeSet = new HashSet<CMBL_ItemAttributeSet>();
            CMBL_ItemUnit = new HashSet<CMBL_ItemUnit>();
            CMBL_StockTransaction = new HashSet<CMBL_StockTransaction>();
        }
        [Key]
        public long ItemID { get; set; }
        public string ItemName { get; set; }
        public int SKU { get; set; }
        public string ItemCode { get; set; }
        public long SafetyStock { get; set; }
        public long LowestAttributeID { get; set; }
        public long CompanyID { get; set; }
        public int ItemType { get; set; }
        public long? ItemMasterID { get; set; }
        public bool? Block_Status { get; set; }

        public virtual ICollection<CMBL_ItemAttributeSet> CMBL_ItemAttributeSet { get; set; }
        public virtual ICollection<CMBL_ItemUnit> CMBL_ItemUnit { get; set; }
        public virtual ICollection<CMBL_StockTransaction> CMBL_StockTransaction { get; set; }
    }
}
