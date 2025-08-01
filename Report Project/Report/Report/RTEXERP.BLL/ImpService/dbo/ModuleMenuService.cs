using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Contracts.Interfaces.Repositories.dbo;
using RTEXERP.Contracts.Interfaces.Services.dbo;
using RTEXERP.DBEntities.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.dbo
{
    public class ModuleMenuService : IModuleMenuService
    {
        private readonly IModuleMenuRepository moduleMenuRepository;
        private readonly IRoleWiseModuleRepository roleWiseModuleRepository;
        public ModuleMenuService(IModuleMenuRepository moduleMenuRepository, IRoleWiseModuleRepository roleWiseModuleRepository)
        {
            this.moduleMenuRepository = moduleMenuRepository;
            this.roleWiseModuleRepository = roleWiseModuleRepository;
        }
        public async Task<IList<ModuleMenu>> GetModuleMenuAsync()
        {
            return await moduleMenuRepository.GetModuleMenuAsync();
        }
        public async Task<ModuleMenu> GetModuleMenuById(int companyId)
        {
            return await moduleMenuRepository.GetModuleMenuById(companyId);
        }
        public List<LogedUserAccessViewModel> ParrentModuleMenu(int? CompanyId)
        {
            return moduleMenuRepository.ParrentModuleMenu(CompanyId);
        }
        public async Task<List<ModuleWiseMenuViewModel>> GenerateModuleWiseMenuTree(int roleId=0)
        {
            List<ModuleWiseMenuViewModel> ModuleWiseMenuTree = new List<ModuleWiseMenuViewModel>();

            var menuList = (await moduleMenuRepository.GetAllModuleMenuAsync()).OrderBy(x => x.MenuLevel).ToList();
            var roleWiseMenu = await roleWiseModuleRepository.GetRoleWiseModuleByRoleId(roleId);
            var menuListWithRole = (from m in menuList
                                   join rm in roleWiseMenu.Where(x=>x.IsRemoved==false) on m.ModuleMenuId equals rm.ModuleId into r
                                   from rr in r.DefaultIfEmpty()
                                   select new ModuleMenuViewModel
                                   {
                                       ModuleMenuId = m.ModuleMenuId,
                                       ParentModuleId = m.ParentModuleId,
                                       LinkText = m.LinkText?.Trim(),
                                       AreaName = m.AreaName?.Trim(),
                                       ControllerName = m.ControllerName?.Trim(),
                                       ActionName = m.ActionName?.Trim(),
                                       RoleWiseModuleId= rr != null?rr.RoleWiseModuleId:0,
                                       IsAssigned = rr!= null 
                                   }).ToList();



            var parentMenuList = menuListWithRole.Where(x => x.ParentModuleId == null);
            foreach (var parentMenu in parentMenuList)
            {
                ModuleWiseMenuViewModel moduleWiseMenu = new ModuleWiseMenuViewModel
                {
                    ModuleMenuId = parentMenu.ModuleMenuId,
                    ParentModuleId = parentMenu.ParentModuleId,                   
                    LinkText = parentMenu.LinkText,
                    AreaName = parentMenu.AreaName,
                    ControllerName = parentMenu.ControllerName,
                    ActionName =parentMenu.ActionName,
                    IsAssigned=parentMenu.IsAssigned,
                    RoleWiseModuleId=parentMenu.RoleWiseModuleId,
                    ChildMenu = await GenerateModuleWiseMenuChild(menuListWithRole, parentMenu.ModuleMenuId)
                    
                };
                ModuleWiseMenuTree.Add(moduleWiseMenu);
            }
            return ModuleWiseMenuTree;
        }
        private async Task<List<ModuleWiseMenuViewModel>> GenerateModuleWiseMenuChild(List<ModuleMenuViewModel> menuList, int moduleMenuId)
        {
            List<ModuleWiseMenuViewModel> ModuleWiseChildMenuTree = new List<ModuleWiseMenuViewModel>();
            var childMenuList = menuList.Where(x => x.ParentModuleId == moduleMenuId);
            foreach (var childMenuItem in childMenuList)
            {
                ModuleWiseMenuViewModel moduleWiseMenu = new ModuleWiseMenuViewModel
                {
                    ModuleMenuId = childMenuItem.ModuleMenuId,
                    ParentModuleId = childMenuItem.ParentModuleId,
                    LinkText = childMenuItem.LinkText,
                    AreaName = childMenuItem.AreaName,
                    ControllerName = childMenuItem.ControllerName,
                    ActionName = childMenuItem.ActionName,
                    IsAssigned = childMenuItem.IsAssigned,
                    RoleWiseModuleId=childMenuItem.RoleWiseModuleId,    
                    ChildMenu = await GenerateModuleWiseMenuChild(menuList, childMenuItem.ModuleMenuId)
                };
                ModuleWiseChildMenuTree.Add(moduleWiseMenu);
            }
            return ModuleWiseChildMenuTree;
        }
    }
}
