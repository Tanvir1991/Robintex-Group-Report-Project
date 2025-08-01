using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
   public  class FabricType_SetupRepository :GenericRepository<FabricType_Setup>, IFabricType_SetupRepository
    {
        private MaxcoDBContext dbCon;

        public FabricType_SetupRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        } 

        public async Task<List<SelectListItem>> DDLFabricType()
        {
            var data = await dbCon.FabricType_Setup.Where(b => b.FabricCategoryID == 1)
                 .Select(b => new SelectListItem
                 {
                     Text = b.Description.Trim(),
                     Value = b.ID.ToString()
                 }).ToListAsync();
            return data;
        }
    }
}
