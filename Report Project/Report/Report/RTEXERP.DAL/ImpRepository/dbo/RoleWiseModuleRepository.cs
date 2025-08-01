using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.dbo;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.dbo;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.dbo
{
    public class RoleWiseModuleRepository : GenericRepository<RoleWiseModule>, IRoleWiseModuleRepository
    {
        private readonly ReportDBContext DbCon;
        public RoleWiseModuleRepository(ReportDBContext context) : base(context)
        {
            DbCon = context;
        }
        public async Task<RResult> AddRoleWiseModule(RoleWiseModule model, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                if (await IsDuplicateRoleWiseModule(model.RoleId, model.CompanyId, 0))
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.DuplicateMessage;
                    return rResult;
                }
                else
                {
                    model.IsActive = true;
                    model.IsRemoved = false;
                   // model.CreatedDate = DateTime.Now;
                    await InsertAsync(model, saveChanges);
                    rResult.result = 1;
                    rResult.message = ReturnMessage.InsertMessage;
                }
            }
            catch (Exception e)
            {

                rResult.result = 0;
                rResult.message = e.Message;
            }
            return rResult;
        }

        public async Task<RResult> AddRoleWiseModule(List<RoleWiseModule> modelList, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var menuToAdd = modelList.Where(x => x.RoleWiseModuleId == 0).ToList();
                var menuToRemove = modelList.Where(x => x.RoleWiseModuleId > 0).ToList();
                if (menuToAdd.Count > 0)
                {
                    DbCon.RoleWiseModule.AddRange(menuToAdd);
                }
                if (menuToRemove.Count > 0)
                {
                    foreach (var item in menuToRemove)
                    {
                        var entity = await DbCon.RoleWiseModule.FindAsync(item.RoleWiseModuleId);
                        entity.IsRemoved = true;
                    }
                }
                await DbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
            }
            return rResult;
        }

        //public List<SelectListItem> DDLGetRoleWiseModuleList(int companyId)
        //{
        //    var qry = DbCon.RoleWiseModule.Where(b => b.IsActive == true && b.IsRemoved == false && b.CompanyId == companyId)
        //         .Select(row => new SelectListItem
        //         {
        //             Text = row.TrimName,
        //             Value = row.Id.ToString()
        //         }).ToList();
        //    return qry;
        //}

        public async Task<IList<RoleWiseModule>> GetRoleWiseModuleAsync()
        {
            return await FindAllAsync(c => c.IsRemoved == false);
        }

        public async Task<RoleWiseModule> GetRoleWiseModuleById(int id)
        {
            return await FindAsync(c => c.IsRemoved == false && c.RoleWiseModuleId == id);
        }

        public async Task<List<RoleWiseModule>> GetRoleWiseModuleByRoleId(int roleId)
        {
            return (await FindAllAsync(c => c.IsRemoved == false && c.RoleId == roleId)).ToList();
        }

        public List<RoleWiseModuleViewModel> GetRoleWiseModuleList(int companyId)
        {

            var roleWiseModule = DbCon.RoleWiseModule.Where(c => c.IsActive == true && c.IsRemoved == false && c.CompanyId == companyId)
                 .Select(row => new RoleWiseModuleViewModel
                 {
                     RoleId=row.RoleId,
                     RoleWiseModuleId=row.RoleWiseModuleId,
                     SecurityLevelId=row.SecurityLevelId,
                     CompanyId=row.CompanyId
                 }).ToList();
            return roleWiseModule;





        }



        public async Task<bool> IsDuplicateRoleWiseModule(int roleId, int companyId, int? id)
        {
            var RoleWiseModule = new RoleWiseModule();

            if (id.HasValue && id > 0)
            {
                RoleWiseModule = await FindAsync(c => c.RoleId == roleId && c.CompanyId == companyId && c.RoleWiseModuleId != id);

            }
            else
            {
                RoleWiseModule = await FindAsync(c => c.RoleId == roleId && c.CompanyId == companyId);
            }
            if (RoleWiseModule != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task UpdateRoleWiseModule(RoleWiseModule entity, bool saveChanges = true)
        {
            await UpdateAsync(entity, saveChanges);
        }

        public async Task<RResult> UpdateRoleWiseModuleWithReturn(RoleWiseModule entity, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                if (await IsDuplicateRoleWiseModule(entity.RoleId, entity.CompanyId, entity.RoleWiseModuleId))
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.DuplicateMessage;
                    return rResult;
                }
                else
                {
                    await UpdateAsync(entity, entity.RoleWiseModuleId, saveChanges);
                    rResult.result = 1;
                }
                if (entity.IsRemoved)
                {
                    rResult.message = ReturnMessage.DeleteMessage;
                }
                else
                {
                    rResult.message = ReturnMessage.UpdateMessage;
                }
            }
            catch (Exception e)
            {

                rResult.result = 0;
                rResult.message = e.Message;
            }
            return rResult;
        }
    }

}
