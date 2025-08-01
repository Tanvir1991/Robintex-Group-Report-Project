using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMBRO
{
    public interface Itbl_Currency_SetupService
    {
        Task<List<SelectListItem>> DDLCurrencyList();
        
    }
}
