using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
    public interface ICBM_BankAccountSetupRepository:IGenericRepository<CbmBankAccountSetup>
    {
        Task<List<SelectListItem>> DDLBankAccount(int BranchID);
    }
}
