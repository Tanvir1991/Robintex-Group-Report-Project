using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class SFS_ProductionResourceSpecificationService : ISFS_ProductionResourceSpecificationService
    {
        private readonly ISFS_ProductionResourceSpecificationRepository sFS_ProductionResourceSpecificationRepository;

        public SFS_ProductionResourceSpecificationService(ISFS_ProductionResourceSpecificationRepository _sFS_ProductionResourceSpecificationRepository)
        {
            sFS_ProductionResourceSpecificationRepository = _sFS_ProductionResourceSpecificationRepository;
        }
        public async Task<List<SelectListItem>> DDLGetProductionLineNo(int pRTypeID)
        {
            return await sFS_ProductionResourceSpecificationRepository.DDLGetProductionLineNo(pRTypeID);
        }

        public async Task<SFS_ProductionResourceSpecificationViewModel> GetProductionResourceSpecifications(int SFS_prsid)
        {
            return await sFS_ProductionResourceSpecificationRepository.GetProductionResourceSpecifications(SFS_prsid);
        }

        public async Task<List<SFS_ProductionResourceSpecificationViewModel>> GetProductionResourceSpecificationsList(int pRTypeID)
        {
            return await sFS_ProductionResourceSpecificationRepository.GetProductionResourceSpecificationsList(pRTypeID);
        }
    }
}
