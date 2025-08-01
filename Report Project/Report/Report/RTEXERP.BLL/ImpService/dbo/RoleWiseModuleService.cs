using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.dbo;
using RTEXERP.Contracts.Common;
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
   
    public class RoleWiseModuleService : IRoleWiseModuleService
    {
        private readonly IRoleWiseModuleRepository roleWiseModuleRepository;
        private readonly IMapper mapper;
        public RoleWiseModuleService(IRoleWiseModuleRepository roleWiseModuleRepository,IMapper mapper)
        {
            this.roleWiseModuleRepository = roleWiseModuleRepository;
            this.mapper = mapper;
        }
        public async Task<RResult> AddRoleWiseModule(RoleWiseModule model, bool saveChanges = true)
        {
            return await roleWiseModuleRepository.AddRoleWiseModule(model, saveChanges);
        }

        public async Task<RResult> AddRoleWiseModule(List<RoleWiseModuleViewModel> modelList,int createdBy, int companyId, bool saveChanges = true)
        {
            var entityList = mapper.Map<List<RoleWiseModuleViewModel>, List<RoleWiseModule>>(modelList);
            entityList.Where(x=>x.RoleWiseModuleId==0).ToList()
                .ForEach(x => { x.CompanyId = companyId;x.SecurityLevelId = 5;x.IsActive = true; x.CreatedBy = createdBy; x.CreateDate = DateTime.Now; });
            return await roleWiseModuleRepository.AddRoleWiseModule(entityList, saveChanges);
        }

        //public List<SelectListItem> DDLGetRoleWiseModuleList(int companyId)
        //{
        //    return roleWiseModuleRepository.DDLGetRoleWiseModuleList(companyId);
        //}

        public async Task<IList<RoleWiseModule>> GetRoleWiseModuleAsync()
        {
            return await roleWiseModuleRepository.GetRoleWiseModuleAsync();
        }

        public async Task<RoleWiseModule> GetRoleWiseModuleById(int id)
        {
            return await roleWiseModuleRepository.GetRoleWiseModuleById(id);
        }

        public List<RoleWiseModuleViewModel> GetRoleWiseModuleList(int companyId)
        {
            return roleWiseModuleRepository.GetRoleWiseModuleList(companyId);
        }

        //public async Task<bool> IsDuplicateRoleWiseModule(int roleId, int companyId, int? id)
        //{
        //    return await roleWiseModuleRepository.IsDuplicateRoleWiseModule(roleId, companyId, id);
        //}

        public async Task<bool> IsDuplicateTrimInfo(int roleId, int companyId, int? id)
        {
            return await roleWiseModuleRepository.IsDuplicateRoleWiseModule(roleId, companyId, id);
        }

        public async Task UpdateRoleWiseModule(RoleWiseModule entity, bool saveChanges = true)
        {
            await roleWiseModuleRepository.UpdateRoleWiseModule(entity, saveChanges);
        }

        public async Task<RResult> UpdateRoleWiseModuleWithReturn(RoleWiseModule entity, bool saveChanges = true)
        {
            return await roleWiseModuleRepository.UpdateRoleWiseModuleWithReturn(entity, saveChanges);
        }
    }

}
