using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco.DB_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class vw_OrderGarmentAssortmentOrder_PantoneRepository : GenericRepository<vw_OrderGarmentAssortmentOrder_Pantone>, Ivw_OrderGarmentAssortmentOrder_PantoneRepository
    {
        private MaxcoDBContext dbCon;
        public vw_OrderGarmentAssortmentOrder_PantoneRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLGetOrderStyleColor(int styleID)
        {
            try
            {
                var list = await dbCon.vw_OrderGarmentAssortmentOrder_Pantone.Where(b => b.StyleID == styleID)
                  .Select(b => new SelectListItem()
                  {
                      Text = b.PantoneNo,
                      Value = b.PantoneNo
                  }).Distinct().ToListAsync();
                return list;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
    }
}
