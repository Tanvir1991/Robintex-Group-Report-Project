using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.AppSecurity;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.dbo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.AppSecurity
{
  public  interface IAspNetRolesService
    {

        Task<IList<AspNetRoles>> GetAspNetRolesAsync();
        Task<AspNetRoles> GetAspNetRolesById(int id);
        Task<RResult> AddAspNetRoles(AspNetRoles model, bool saveChanges = true);
        Task UpdateAspNetRoles(AspNetRoles entity, bool saveChanges = true);
        Task<RResult> UpdateAspNetRolesWithReturn(AspNetRoles entity, bool saveChanges = true);
        Task<bool> IsDuplicateAspNetRoles(string name, int companyId, int? id);
        List<AspNetRolesViewModel> GetAspNetRolesList();
        List<SelectListItem> DDLGetRoleList();

    }
}
