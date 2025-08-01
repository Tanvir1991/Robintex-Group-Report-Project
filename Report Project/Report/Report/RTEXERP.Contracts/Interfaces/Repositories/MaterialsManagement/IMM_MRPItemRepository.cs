using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement
{
    public interface IMM_MRPItemRepository :IGenericRepository<MM_MRPItem>
    {
        List<SelectListItem> GetTrimMRPItem();
    }
}
