using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class ChequeSignatoryMasterService: IChequeSignatoryMasterService
    {
        private readonly IChequeSignatoryMasterRepository chequeSignatoryMasterRepository;

        public ChequeSignatoryMasterService(IChequeSignatoryMasterRepository chequeSignatoryMasterRepository)
        {
            this.chequeSignatoryMasterRepository = chequeSignatoryMasterRepository;
        }
        public async Task<List<SelectListItem>> DDLChequeSignatoryMasterList(int companyId)
        {
            return await chequeSignatoryMasterRepository.DDLChequeSignatoryMasterList(companyId);
        }
    }
}
