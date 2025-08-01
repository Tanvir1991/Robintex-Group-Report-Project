using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.dbo
{
  public  class RoleWiseModuleViewModel
    {
        public int RoleWiseModuleId { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int SecurityLevelId { get; set; }
        public int CompanyId { get; set; }


    }
}
