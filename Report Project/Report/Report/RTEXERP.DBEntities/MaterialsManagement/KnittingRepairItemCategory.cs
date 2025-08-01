using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
  public  class KnittingRepairItemCategory
    {
        [Key]
        public int ItemCategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsActive { get; set; }
    }
}
