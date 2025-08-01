using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
   public interface ICBM_BranchRepository :IGenericRepository<CbmBranch>
    {
        Task<List<SelectListItem>> DDL_CBMBankBranch(decimal CompanyID,int BankID);
    }
}
