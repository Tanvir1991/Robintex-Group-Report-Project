using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Hrm
{
    public class ModuleWiseMenuTreeViewModel
    {
        //public ModuleWiseMenuViewModel ParentMenu { get; set; }
        //public List<ModuleWiseMenuViewModel> ChildMenu { get; set; }
        public int RoleId { get; set; }
        public List<SelectListItem> RoleList { get; set; }
    }
}
