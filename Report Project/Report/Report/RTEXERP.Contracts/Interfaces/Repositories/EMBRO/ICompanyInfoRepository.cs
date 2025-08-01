using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
   public interface ICompanyInfoRepository:IGenericRepository<CompanyInfo>
    {
        Task<List<SelectListItem>> GetDDLCompanyInfo();
    }
}
