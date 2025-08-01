using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class SFS_ProductionResourceSpecificationRepository : GenericRepository<SFS_ProductionResourceSpecification>, ISFS_ProductionResourceSpecificationRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public SFS_ProductionResourceSpecificationRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<SelectListItem>> DDLGetProductionLineNo(int pRTypeID)
        {
            /*
            var rtnList = await dbCon.SFS_ProductionResourceSpecification.Where(b => b.SFS_PRTypeID == pRTypeID)
                  .Select(x => new SelectListItem()
                  {
                      Text = x.Name,
                      Value = x.SFS_PRSID.ToString()
                  }).ToListAsync();
            */
            var rtnList = await dbCon.vw_SFS_Productionline.Select(s => new SelectListItem
            {
                Text = s.LineName,
                Value=s.LineID.ToString()
            }).ToListAsync();
               



            return rtnList;
        }

        public async Task<SFS_ProductionResourceSpecificationViewModel> GetProductionResourceSpecifications(int SFS_prsid)
        {
            var dataquery =await dbCon.SFS_ProductionResourceSpecification.Where(b => b.SFS_PRSID == SFS_prsid)
                .Select(b=> new SFS_ProductionResourceSpecificationViewModel
                {SFS_PRSID=b.SFS_PRSID,
                FabricCategoryID=b.FabricCategoryID,
                HeadUserID = b.HeadUserID,
                HRM_SectionID =b.HRM_SectionID,
                HRM_SectionName=b.HRM_SectionName,
                IsAllBuyer=b.IsAllBuyer,
                IsAllFabricType=b.IsAllFabricType,
                IsAllGarmentCategory=b.IsAllGarmentCategory,
                IsAllGarmentType=b.IsAllGarmentType,
                Name =b.Name,
                SFS_PRTypeID=b.SFS_PRTypeID,
                UserID=b.UserID
                })
                .FirstAsync();
            return dataquery;
        }

        public async Task<List<SFS_ProductionResourceSpecificationViewModel>> GetProductionResourceSpecificationsList(int pRTypeID)
        {
            var data = await dbCon.SFS_ProductionResourceSpecification.Where(b => b.SFS_PRTypeID == pRTypeID)
               .Select(b => new SFS_ProductionResourceSpecificationViewModel
               {
                   SFS_PRSID = b.SFS_PRSID,
                   FabricCategoryID = b.FabricCategoryID,
                   HeadUserID = b.HeadUserID,
                   HRM_SectionID = b.HRM_SectionID,
                   HRM_SectionName = b.HRM_SectionName,
                   IsAllBuyer = b.IsAllBuyer,
                   IsAllFabricType = b.IsAllFabricType,
                   IsAllGarmentCategory = b.IsAllGarmentCategory,
                   IsAllGarmentType = b.IsAllGarmentType,
                   Name = b.Name,
                   SFS_PRTypeID = b.SFS_PRTypeID,
                   UserID = b.UserID
               })
               .ToListAsync();
            return data;
        }
    }
}
