using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.Contracts.Interfaces.Services.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Component
{
    public class ModuleWiseMenuTreeViewComponent : ViewComponent
    {
        private readonly IModuleMenuService moduleMenuService;
        public ModuleWiseMenuTreeViewComponent(IModuleMenuService moduleMenuService)
        {
            this.moduleMenuService = moduleMenuService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int roleId = 0)
        {
            var moduleWiseMenuTree = await moduleMenuService.GenerateModuleWiseMenuTree(roleId);
            var htmlData = GenerateModuleWiseMenuHTML(moduleWiseMenuTree);
            ViewBag.HtmlData = htmlData;
            return View("ModuleWiseMenuTreeVC");

        }
        private string GenerateModuleWiseMenuHTML(List<ModuleWiseMenuViewModel> moduleWiseMenuTree)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var menuItem in moduleWiseMenuTree)
            {
                if (menuItem.ControllerName == "#" && menuItem.ActionName == null)
                {
                    //var isAssigned = menuItem.ChildMenu.Where(x=>x.IsAssigned==false).Count()>0 ? "" : "checked";
                    sb.Append($"<div id=\"accordionModuleMenu-{menuItem.ModuleMenuId }\">");
                    sb.Append("<div class=\"card\">");
                    sb.Append($"<div class=\"card-header\" id=\"headingModuleMenu-{ menuItem.ModuleMenuId}\">");
                    sb.Append("<h5 class=\"mb-0\">");
                    sb.Append("<div class=\"row\">");
                    sb.Append("<div class=\"chkDiv\" style=\" width:5%;text-align:center;\">");
                    sb.Append($"<input type=\"checkbox\" class=\"chk-{menuItem.ModuleMenuId} chkParent-{(menuItem.ParentModuleId == null ? 0 : menuItem.ParentModuleId)}\" data-id=\"{menuItem.ModuleMenuId}\"/>");
                    sb.Append($"<input type=\"hidden\" class=\"hdnParentModuleId\" value=\"{(menuItem.ParentModuleId == null ? 0 : menuItem.ParentModuleId)}\"/>");
                    sb.Append("</div>");
                    sb.Append($"<div class=\"headerDiv\" style=\" width:95%;padding-right:10px;\">");
                    sb.Append($"<a class=\"collapsed\" role=\"button\" data-toggle=\"collapse\" href=\"#collapse-{menuItem.ModuleMenuId}\" aria-expanded=\"false\" aria-controls=\"collapse-{ menuItem.ModuleMenuId }\">{menuItem.LinkText}</a>");
                    sb.Append("<div>");
                    sb.Append("</div>");
                    sb.Append("</h5>");
                    sb.Append("</div>");
                    sb.Append($"<div id=\"collapse-{menuItem.ModuleMenuId}\" class=\"collapse\" data-parent=\"#accordionModuleMenu-{menuItem.ModuleMenuId}\" aria-labelledby=\"headingModuleMenu-{menuItem.ModuleMenuId}\">");
                    if (menuItem.ChildMenu.Count > 0 && menuItem.ChildMenu.First().ControllerName == "#")
                        sb.Append("<div class=\"card-body\">");

                    sb.Append(GenerateModuleWiseMenuHTML(menuItem.ChildMenu));

                    if (menuItem.ChildMenu.Count > 0 && menuItem.ChildMenu.First().ControllerName == "#")
                        sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
                else
                {
                    var isAssigned = menuItem.IsAssigned == true ? "checked" : "";
                    sb.Append("<div class=\"card-body\" style=\"padding-bottom:0rem;\">");
                    sb.Append("<div class=\"row\">");
                    sb.Append("<div class=\"chkDiv\" style=\" width:5%;text-align:center;\">");
                    sb.Append($"<input type=\"checkbox\" {isAssigned} class=\"chkMenu chk-{menuItem.ModuleMenuId} chkParent-{(menuItem.ParentModuleId == null ? 0 : menuItem.ParentModuleId)}\" data-id=\"{menuItem.ModuleMenuId}\" />");
                    sb.Append($"<input type=\"hidden\" class=\"hdnModuleMenuId\" value=\"{menuItem.ModuleMenuId }\"/>");
                    sb.Append($"<input type=\"hidden\" class=\"hdnParentModuleId\" value=\"{(menuItem.ParentModuleId == null ? 0 : menuItem.ParentModuleId)}\"/>");
                    sb.Append($"<input type=\"hidden\" class=\"hdnRoleWiseModuleId\" value=\"{menuItem.RoleWiseModuleId }\"/>");
                    sb.Append($"</div>");
                    sb.Append($"<div class=\"headerDiv\" style=\" width:95%;padding-right:10px;\"> {menuItem.LinkText}</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }

            };
            return sb.ToString();

        }
    }
}
