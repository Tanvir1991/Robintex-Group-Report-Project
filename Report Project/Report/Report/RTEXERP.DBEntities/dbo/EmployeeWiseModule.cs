using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.dbo
{
    public partial class EmployeeWiseModule
    {
        public int EmpModuleId { get; set; }
        public int EmployeeId { get; set; }
        public int ModuleId { get; set; }
        public int SecurityLevelId { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
