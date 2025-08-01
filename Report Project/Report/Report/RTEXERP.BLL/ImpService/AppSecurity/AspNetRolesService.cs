using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.AppSecurity;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.AppSecurity;
using RTEXERP.Contracts.Interfaces.Services.AppSecurity;
using RTEXERP.DBEntities.dbo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.AppSecurity
{
    public class AspNetRolesService : IAspNetRolesService
    {
       private readonly IAspNetRolesRepository aspNetRolesRepository;
        public AspNetRolesService(IAspNetRolesRepository aspNetRolesRepository)
        {
            this.aspNetRolesRepository = aspNetRolesRepository;
        }
        public async Task<RResult> AddAspNetRoles(AspNetRoles model, bool saveChanges = true)
        {
            return await aspNetRolesRepository.AddAspNetRoles(model, saveChanges);
        }

        public List<SelectListItem> DDLGetRoleList()
        {
            return  aspNetRolesRepository.DDLGetRoleList();
        }

        //public List<SelectListItem> DDLGetCompanyList()
        //{
        //    return aspNetRolesRepository.DDLGetCompanyList();

        //}

        public async Task<IList<AspNetRoles>> GetAspNetRolesAsync()
        {
            return await aspNetRolesRepository.GetAspNetRolesAsync();
        }

        public async Task<AspNetRoles> GetAspNetRolesById(int id)
        {
            return await aspNetRolesRepository.GetAspNetRolesById(id);
        }

        public List<AspNetRolesViewModel> GetAspNetRolesList()
        {
            return aspNetRolesRepository.GetAspNetRolesList();
        }

        public async Task<bool> IsDuplicateAspNetRoles(string name, int companyId, int? id)
        {
            return await aspNetRolesRepository.IsDuplicateAspNetRoles(name, companyId, id);
        }

        public async Task UpdateAspNetRoles(AspNetRoles entity, bool saveChanges = true)
        {
            await aspNetRolesRepository.UpdateAspNetRoles(entity, saveChanges);
        }

        public async Task<RResult> UpdateAspNetRolesWithReturn(AspNetRoles entity, bool saveChanges = true)
        {
            return await aspNetRolesRepository.UpdateAspNetRolesWithReturn(entity, saveChanges);
        }
    }
}
