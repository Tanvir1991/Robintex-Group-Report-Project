using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.Contracts.Interfaces.Services.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.MaterialsManagement
{
    public class KnittingRepairItemCategoryService : IKnittingRepairItemCategoryService
    {
        private readonly IKnittingRepairItemCategoryRepository knittingRepairItemCategoryRepository;

        public KnittingRepairItemCategoryService(IKnittingRepairItemCategoryRepository _knittingRepairItemCategoryRepository)
        {
            knittingRepairItemCategoryRepository = _knittingRepairItemCategoryRepository;
        }
        public async Task<List<SelectListItem>> GetDDLKnittingRepairItemCategory()
        {
            return await knittingRepairItemCategoryRepository.GetDDLKnittingRepairItemCategory();
        }
    }
}
