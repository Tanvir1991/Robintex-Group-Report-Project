using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.AppSecurity;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.AppSecurity;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.AppSecurity
{
   public class AspNetRolesRepository:GenericRepository<AspNetRoles>,IAspNetRolesRepository
    {
      
        private ReportDBContext dbCon;
        public AspNetRolesRepository(ReportDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<RResult> AddAspNetRoles(AspNetRoles model, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                if (await IsDuplicateAspNetRoles(model.Name,model.CompanyId,model.Id))
                {
                    rResult.result = 0;
                    rResult.message = "Duplicate Role Name";
                    return rResult;
                }
                model.NormalizedName = model.Name.ToUpper();
                model.IsActive = true;
                model.IsRemoved = false;
                model.CreateDate = DateTime.Now;

                await InsertAsync(model, saveChanges);
                rResult.result = 1;
                rResult.message = "Saved Successfully";
                return rResult;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;
            }
            return rResult;
        }

        public List<SelectListItem> DDLGetCompanyList()
        {
            //var aspNetRolesList = dbCon.CompanyInfo.Where(c => c.IsActive == true && c.IsRemoved == false)
            //      .Select(row => new SelectListItem
            //      {
            //          Text = row.CompanyName,
            //          Value = row.Id.ToString()

            //      }).ToList();
            //  return aspNetRolesList;
            return new List<SelectListItem>();
        }

        public async Task<IList<AspNetRoles>> GetAspNetRolesAsync()
        {
            return await FindAllAsync(c => c.IsRemoved == false);
        }

        public async Task<AspNetRoles> GetAspNetRolesById(int id)
        {
            return await FindAsync(c => c.Id == id && c.IsRemoved == false);
        }

        public List<AspNetRolesViewModel> GetAspNetRolesList()
        {
            //    var aspNerRolesList = dbCon.AspNetRoles.Where(b => b.IsRemoved == false);
            //    var companyList = dbCon.CompanyInfo.Where(b => b.IsRemoved == false);
            //    var qry = (from nr in aspNerRolesList
            //               join co in companyList on nr.CompanyId equals co.Id
            //               select new AspNetRolesViewModel
            //               {

            //                   Id=nr.Id,
            //                   Name=nr.Name,
            //                   NormalizedName=nr.NormalizedName,
            //                   ConcurrencyStamp=nr.ConcurrencyStamp,
            //                   Description=nr.Description,
            //                   CompanyName=co.CompanyName,
            //                   CompanyId=nr.CompanyId,
            //                   IsSuperAdminRole=nr.IsSuperAdminRole

            //               }).ToList();
            //    return qry;
            return new List<AspNetRolesViewModel>();
        }

        public async Task<bool> IsDuplicateAspNetRoles(string name, int companyId, int? id)
        {
            var aspnetRoles = new AspNetRoles();
            if (id.HasValue && id > 0)
            {
                aspnetRoles = await FindAsync(c => c.Name == name && c.CompanyId == companyId && c.Id != id);
            }
            else
            {
                aspnetRoles = await FindAsync(c => c.Name == name && c.CompanyId == companyId);
            }
            if (aspnetRoles !=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task UpdateAspNetRoles(AspNetRoles entity, bool saveChanges = true)
        {
            await UpdateAsync(entity, saveChanges);
        }

        public async Task<RResult> UpdateAspNetRolesWithReturn(AspNetRoles entity, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                if (await IsDuplicateAspNetRoles(entity.Name,entity.CompanyId,entity.Id))
                {

                    rResult.result = 0;
                    rResult.message = "Duplicate Role name";
                    return rResult;
                }
                entity.NormalizedName = entity.Name.ToUpper();
                await UpdateAsync(entity, saveChanges);

                rResult.result = 1;
                if (entity.IsRemoved)
                {
                    rResult.message = "Delete Successfully";
                }
                else
                {
                    rResult.message = "Update Successfully";
                }
            }
            catch (Exception e)
            {

                rResult.result = 0;
                rResult.message = e.Message;
          }
            return rResult;
        }

        public List<SelectListItem> DDLGetRoleList()
        {
            var companyList = dbCon.AspNetRoles.Where(c => c.IsRemoved == false
                                            && c.IsActive == true)
                               .Select(row => new SelectListItem
                               {
                                   Text = row.Name,
                                   Value = row.Id.ToString()
                               }).ToList();
            return companyList;
        }
    }
}
