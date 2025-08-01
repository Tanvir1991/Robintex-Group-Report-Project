using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Hrm
{
    public class ModuleWiseMenuViewModel
    {
        //public ModuleWiseMenuViewModel()
        //{
        //    ChildMenu = new List<ModuleWiseMenuViewModel>();
        //}
        public int ModuleMenuId { get; set; }       
        public string LinkText { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int? ParentModuleId { get; set; }
        public bool IsAssigned { get; set; }
        public int RoleWiseModuleId { get; set; }
        public List<ModuleWiseMenuViewModel> ChildMenu { get; set; }
    }
}
