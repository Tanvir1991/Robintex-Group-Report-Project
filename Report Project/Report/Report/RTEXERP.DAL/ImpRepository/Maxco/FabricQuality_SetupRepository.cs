using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class FabricQuality_SetupRepository : GenericRepository<FabricQuality_Setup>, IFabricQuality_SetupRepository
    {
        private MaxcoDBContext dbCon;

        public FabricQuality_SetupRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<SelectListItem>> DDLFabricQuality(int TypeID)
        {
            var data =await dbCon.FabricQuality_Setup.Where(b => b.TypeID == TypeID)
               .Select(c => new SelectListItem
               {
                   Text = c.Description.Trim(),
                   Value = c.ID.ToString()
               }).ToListAsync();
            return data;
        }
    }
}
