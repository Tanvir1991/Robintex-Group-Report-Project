using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
   public interface IKnittingRepairItemCategoryService
    {
        Task<List<SelectListItem>> GetDDLKnittingRepairItemCategory();
    }
}
