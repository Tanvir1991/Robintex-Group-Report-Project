using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class CompanyInfoService : ICompanyInfoService
    {
        private readonly ICompanyInfoRepository companyInfoRepository;

        public CompanyInfoService(ICompanyInfoRepository _companyInfoRepository)
        {
            companyInfoRepository = _companyInfoRepository;
        }
        public async Task<List<SelectListItem>> GetDDLCompanyInfo()
        {
            return await companyInfoRepository.GetDDLCompanyInfo();
        }
    }
}
