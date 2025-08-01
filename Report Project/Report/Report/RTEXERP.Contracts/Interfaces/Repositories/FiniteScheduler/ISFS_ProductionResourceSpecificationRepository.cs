using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
   public interface ISFS_ProductionResourceSpecificationRepository:IGenericRepository<SFS_ProductionResourceSpecification>
    {
        Task<List<SelectListItem>> DDLGetProductionLineNo(int pRTypeID);
        Task<SFS_ProductionResourceSpecificationViewModel> GetProductionResourceSpecifications(int SFS_prsid);
        Task<List<SFS_ProductionResourceSpecificationViewModel>> GetProductionResourceSpecificationsList(int pRTypeID);
    }
}
