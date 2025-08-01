using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class CMBL_UnitRepository : GenericRepository<CMBL_Unit>, ICMBL_UnitRepository
    {
        private MaterialsManagementDBContext dbCon;
       
        public CMBL_UnitRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;            
        }
        public async Task<List<SelectListItem>> DDLUnitListByCompany(long CompanyId)
        {
            try
            {
                var list =await dbCon.CMBL_Unit
                           .Where(x=>x.CompanyID==CompanyId)
                           .Select(row => new SelectListItem
                            {
                                Text = row.UnitDescription,
                                Value = row.UnitID.ToString()
                            }).ToListAsync();

                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
