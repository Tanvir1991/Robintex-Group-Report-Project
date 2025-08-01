using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class MM_MRPItemService : IMM_MRPItemService
    {
        private readonly IMM_MRPItemRepository mM_MRPItemRepository;
        public MM_MRPItemService(IMM_MRPItemRepository mM_MRPItemRepository)
        {
            this.mM_MRPItemRepository = mM_MRPItemRepository;
        }
        public List<SelectListItem> GetTrimMRPItem()
        {
            return mM_MRPItemRepository.GetTrimMRPItem();
        }
    }
}
