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
    public class KnittingRepairItemCategoryRepository : GenericRepository<KnittingRepairItemCategory>, IKnittingRepairItemCategoryRepository
    {
        private MaterialsManagementDBContext dbCon;

        public KnittingRepairItemCategoryRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<SelectListItem>> GetDDLKnittingRepairItemCategory()
        {
            var list = await dbCon.KnittingRepairItemCategory.Where(b => b.IsActive && b.IsRemoved == false)
                 .Select(b => new SelectListItem()
                 {
                     Text = b.CategoryName,
                     Value = b.ItemCategoryID.ToString()
                 }).ToListAsync();
            return list;
        }
    }
}
