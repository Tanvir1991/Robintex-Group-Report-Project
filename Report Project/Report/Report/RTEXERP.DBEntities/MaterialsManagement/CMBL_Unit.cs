using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class CMBL_Unit
    {
        [Key]
        public int UnitID { get; set; }
        public string UnitDescription { get; set; }
        public string UnitAbbreviation { get; set; }
        public long CompanyID { get; set; }

    }
}
