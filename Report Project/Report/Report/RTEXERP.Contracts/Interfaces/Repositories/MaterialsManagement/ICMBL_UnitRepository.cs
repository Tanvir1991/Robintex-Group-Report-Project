using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement
{
    public interface ICMBL_UnitRepository:IGenericRepository<CMBL_Unit>
    {
        Task<List<SelectListItem>> DDLUnitListByCompany(long CompanyId);
    }
}
