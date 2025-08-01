using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
    public interface ICMBL_UnitService
    {
        Task<List<SelectListItem>> DDLUnitListByCompany(long CompanyId);
    }
}
