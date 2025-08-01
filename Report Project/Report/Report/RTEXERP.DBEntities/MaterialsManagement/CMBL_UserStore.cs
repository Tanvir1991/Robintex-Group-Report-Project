using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
  public  class CMBL_UserStore
    {
        [Key]
        public int StoreID { get; set; }
        public int UserID { get; set; }
    }
}
