using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using RTEXERP.Contracts.BLModels.dbo;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.AppSecurity;
using RTEXERP.Contracts.Interfaces.Services.dbo;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;

namespace RTEXERP.WEB.Controllers
{
    public class RoleWiseMenuAssignController : BaseController
    {
        private readonly IModuleMenuService moduleMenuService;
        private readonly IAspNetRolesService aspNetRolesService;
        private readonly IDropdownService dropdownService;
        private readonly IRoleWiseModuleService roleWiseModuleService;
        public RoleWiseMenuAssignController(IModuleMenuService moduleMenuService, IAspNetRolesService aspNetRolesService, IDropdownService dropdownService
            , IRoleWiseModuleService roleWiseModuleService)
        {
            this.moduleMenuService = moduleMenuService;
            this.aspNetRolesService = aspNetRolesService;
            this.dropdownService = dropdownService;
            this.roleWiseModuleService = roleWiseModuleService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = new ModuleWiseMenuTreeViewModel();
            model.RoleList = dropdownService.RenderDDL(aspNetRolesService.DDLGetRoleList(),true);
            return View(model);
        }
        public ActionResult GetModuleMenuViewComponent(string viewName, int roleId=0)
        {

            if (viewName == "ModuleWiseMenuTree")
            {                
                return ViewComponent(viewName, roleId);
            }            
            return View("No Content Found");
        }

        [HttpPost]
        public async Task<JsonResult> RoleWiseMenuAssignSave(List<RoleWiseModuleViewModel> roleWiseMenuList)
        {            
            var result = await roleWiseModuleService.AddRoleWiseModule(roleWiseMenuList, Session_EMPLOYEE_ID, Session_COMPANY_ID);
            return Json(result);
        }
    }
}