using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.dbo;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.dbo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.dbo
{
   public interface IRoleWiseModuleRepository:IGenericRepository<RoleWiseModule>
    {
        Task<IList<RoleWiseModule>> GetRoleWiseModuleAsync();
        Task<RoleWiseModule> GetRoleWiseModuleById(int id);
        Task<RResult> AddRoleWiseModule(RoleWiseModule model, bool saveChanges = true);
        Task<RResult> AddRoleWiseModule(List<RoleWiseModule> modelList, bool saveChanges = true);
        Task UpdateRoleWiseModule(RoleWiseModule entity, bool saveChanges = true);
        Task<RResult> UpdateRoleWiseModuleWithReturn(RoleWiseModule entity, bool saveChanges = true);
        Task<bool> IsDuplicateRoleWiseModule(int roleId, int companyId, int? id);

      //  List<SelectListItem> DDLGetRoleWiseModuleList(int companyId);
        List<RoleWiseModuleViewModel> GetRoleWiseModuleList(int companyId);
        Task<List<RoleWiseModule>> GetRoleWiseModuleByRoleId(int roleId);
    }
}
