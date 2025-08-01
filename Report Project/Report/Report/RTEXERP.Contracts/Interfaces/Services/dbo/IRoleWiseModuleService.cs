using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.dbo;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.dbo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.dbo
{
   public interface IRoleWiseModuleService
    {
        Task<IList<RoleWiseModule>> GetRoleWiseModuleAsync();
        Task<RoleWiseModule> GetRoleWiseModuleById(int id);
        Task<RResult> AddRoleWiseModule(RoleWiseModule model, bool saveChanges = true);
        Task<RResult> AddRoleWiseModule(List<RoleWiseModuleViewModel> modelList, int createdBy,int companyId, bool saveChanges = true);
        Task UpdateRoleWiseModule(RoleWiseModule entity, bool saveChanges = true);
        Task<RResult> UpdateRoleWiseModuleWithReturn(RoleWiseModule entity, bool saveChanges = true);
        Task<bool> IsDuplicateTrimInfo(int roleId, int companyId, int? id);
      //  List<SelectListItem> DDLGetRoleWiseModuleList(int companyId);
        List<RoleWiseModuleViewModel> GetRoleWiseModuleList(int companyId);

    }
}
