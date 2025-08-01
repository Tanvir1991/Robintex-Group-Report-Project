using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
    public interface Itbl_Currency_SetupRepository:IGenericRepository<tbl_Currency_Setup>
    {
        Task<List<SelectListItem>> DDLCurrencyList();
        
    }
}
