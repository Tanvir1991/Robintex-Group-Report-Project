using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.EMBRO
{
    public interface ICBM_ChequeService
    {
        Task<List<SelectListItem>> DDLIssuedCheque( int BankAccID);
    }
}
