using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.dbo
{
    public partial class ModuleMenu
    {
        public int ModuleMenuId { get; set; }
        public string ModuleMenueCode { get; set; }
        public string LinkText { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int? ParentModuleId { get; set; }
        public int? CompanyId { get; set; }
        public bool? IsMenuItem { get; set; }
        public int? DisplayOrder { get; set; }
        public string LinkTextUn { get; set; }
        public string UserType { get; set; }
        public string ModuleCode { get; set; }
        public string MenuSymbol { get; set; }
        public int? MenuLevel { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsActive { get; set; }
    }
}
