using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo
{
    public class LogedUserAccessViewModel
    {
        public int ModuleMenuId { get; set; }
        public string ModuleCode { get; set; }
        public int? MenuLevel { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string LinkText { get; set; }
        public string LinkTextUn { get; set; }
        public int RoleId { get; set; }
        public bool? IsMenuItem { get; set; }
        public string MenuSymbol { get; set; }
        public int? ParentModuleId { get; set; }
        public int? DisplayOrder { get; set; }
        public string UserType { get; set; }
        public int? SecurityLevelId { get; set; }
        public string ModuleMenueCode { get; set; }
    }
}
