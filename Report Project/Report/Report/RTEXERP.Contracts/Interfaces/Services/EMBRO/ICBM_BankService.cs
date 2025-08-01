using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMBRO
{
   public interface ICBM_BankService
    {
        Task<List<SelectListItem>> DDLBank(decimal CompanyID);
    }
}
