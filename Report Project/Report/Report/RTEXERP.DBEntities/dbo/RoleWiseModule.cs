using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.dbo
{
    public partial class RoleWiseModule
    {
        public int RoleWiseModuleId { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int SecurityLevelId { get; set; }
        public int CompanyId { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
