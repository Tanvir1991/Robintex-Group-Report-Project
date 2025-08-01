using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class CBM_BranchService : ICBM_BranchService
    {
        private readonly ICBM_BranchRepository iCBM_BranchRepository;
        public CBM_BranchService(ICBM_BranchRepository iCBM_BranchRepository)
        {
            this.iCBM_BranchRepository = iCBM_BranchRepository;
        }
        public async Task<List<SelectListItem>> DDL_CBMBankBranch(decimal CompanyID, int BankID)
        {
            return await this.iCBM_BranchRepository.DDL_CBMBankBranch(CompanyID, BankID);
        }
    }
}
