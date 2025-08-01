using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
   
    public  class CMBL_StoreBroadGroup
    {
        [Key]
        public int StoreID { get; set; }
        public long AttributeID { get; set; }
    }
}
