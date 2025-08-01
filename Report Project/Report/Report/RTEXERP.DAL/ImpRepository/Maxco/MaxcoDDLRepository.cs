
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Maxco;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.Maxco
{
    public class MaxcoDDLRepository : GenericRepository<FabricYarnComposition_Setup>, IMaxcoDDLRepository
    {
        private MaxcoDBContext dbCon;

        public MaxcoDDLRepository(MaxcoDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<SelectListItem>> DDLLCNoList()
        {
            var list = await dbCon.LC_CM_CASH_MASTER.Where(b=>b.LCM_DATEOFISSUANCE>=DateTime.Now.AddDays(-200)).Select(b =>
           new SelectListItem()
           {
               Text = b.LCM_CODE,
               Value = b.LCM_CODE
           }).ToListAsync();
            return list;
        }

        public async Task<List<SelectListItem>> DDLTrims()
        {
            var data =await dbCon.Trim_Setup
                 .Where(b => b.IsDisplay == true && b.TrimCategoryID == 1)
                 .Select(b => new SelectListItem
                 {
                     Text = b.Description.Trim(),
                     Value = b.ID.ToString()
                 }).ToListAsync();

            return data;
        }

        public async Task<List<SelectListItem>> DDLYarnComposition()
        {
            var list =await dbCon.FabricYarnComposition_Setup.Select(b =>            
            new SelectListItem()
            {
                Text = b.Description,
                Value = b.ID.ToString()
            }).ToListAsync();
            return list;
        }

        public async Task<List<SelectListItem>> DDLYarnCompositionSTR()
        {
            var list = await dbCon.FabricYarnComposition_Setup.Select(b =>
             new SelectListItem()
             {
                 Text = b.Description.Trim(),
                 Value = b.Description.Trim()
             }).ToListAsync();
            return list;
        }

        public async Task<List<SelectListItem>> DDLYarnCount(int CompositionId)
        {
            var list = await dbCon.FabricYarnCount_Setup.Where(b=>(CompositionId==0 || b.FabricYarnCompositionID==CompositionId)).Distinct().Select(b =>
            new SelectListItem()
            {
                Text = b.Description,
                Value = b.ID.ToString()
            }).ToListAsync();
            return list;
        }

        public async Task<List<SelectListItem>> DDLYarnCountALLSTR()
        {
            var list = await dbCon.FabricYarnCount_Setup
                .Where(b=>b.Description.Length>0)
                .Select(b=> new SelectListItem
                {
                    Text = b.Description.Trim().Replace("/1","/S").Replace("20/D", "20 DE").Replace("75/72", "75/72 DE"),
                })
                .Distinct().Select(b =>
                 new SelectListItem()
                 {
                     Text = b.Text,
                     Value = b.Text
                 }).ToListAsync();
            return list;
        }

        public async Task<List<SelectListItem>> DDLYarnCountValue(int CompositionId)
        {
            var list = await (from c in dbCon.FabricYarnCount_Setup
                              where (CompositionId == 0 || c.FabricYarnCompositionID == CompositionId)
                                 group c by c.Description into _YarnCount
                              select new SelectListItem
                              {
                                  Text = _YarnCount.Key,
                                  Value = _YarnCount.Key
                              }).ToListAsync();
            return list;
        }

        public async Task<List<BasicModel>> GETFabricComposition(string Composition)
        {
            var itemList = new List<BasicModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.USP_GETFabricComposition")
                             .WithSqlParam("Composition", Composition)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<BasicModel>() as List<BasicModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
    }
}
