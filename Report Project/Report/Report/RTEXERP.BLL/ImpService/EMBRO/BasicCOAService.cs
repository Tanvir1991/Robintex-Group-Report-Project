using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.DBEntities.Embro;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class BasicCOAService : IBasicCOAService
    {
        private readonly IBasicCOARepository basicCOARepository;
        public BasicCOAService(IBasicCOARepository basicCOARepository)
        {
            this.basicCOARepository = basicCOARepository;
        }
        public async Task<List<SelectListItem>> DDLChartOfAccounts(int? parentId, int levelId)
        {
            return await basicCOARepository.DDLChartOfAccounts( parentId, levelId);
        }
        //usp_GetCompanyWiseSupplierDDL
        public async Task<List<SelectListItem>> DDLChartOfAccountsCompanyWiseSupplier( int companyId)
        {
            return await basicCOARepository.DDLChartOfAccountsCompanyWiseSupplier(companyId);
        }
        public async Task<IEnumerable<SelectListItem>> DDLAccCategory(int Selected)
        {
            return await basicCOARepository.DDLAccCategory(Selected);
        }

        public async Task<BasicCoa> AccInfo(int Id)
        {
            return await basicCOARepository.AccInfo(Id);
        }

        public async Task<IEnumerable<SelectListItem>> DDLCategoryChartOfAccounts(int CompanyID, int? CategoryID = 0)
        {
            return await basicCOARepository.DDLCategoryChartOfAccounts(CompanyID, CategoryID);
        }

        public async Task<List<BasicCOAViewModel>> ChartOfAccountsSupplierGroup(int companyId, int? CategoryID = 0)
        {
            return await basicCOARepository.ChartOfAccountsSupplierGroup(companyId, CategoryID);
        }
     
 
        public async Task<List<BasicCOAViewModel>> ChartOfAccountsGroup(int companyId, int? CategoryID = 0)
        {
            return await basicCOARepository.ChartOfAccountsGroup(companyId, CategoryID);
        }

        public async Task<List<BasicCOAViewModel>> ChartOfAccounts(int? parentId, int levelId)
        {
            return await basicCOARepository.ChartOfAccounts(parentId, levelId);
        }

        public async Task<List<BasicCOAViewModel>> GetsSupplierListAutocomplete(string itemName, int companyId)
        {
            return await basicCOARepository.GetsSupplierListAutocomplete(itemName,companyId);
        }
        public async Task<List<BasicCOAViewModel>> GetAutoCompleteChartOfAccounts(string itemName, int companyId)
        {
            return await basicCOARepository.GetAutoCompleteChartOfAccounts(itemName, companyId);
        }
        public async Task<List<BasicCOAViewModel>> GetBankAccountAutocomplete(string itemName, int companyId)
        {
            return await basicCOARepository.GetBankAccountAutocomplete(itemName, companyId);
        }

        public async Task<List<SelectListItem>> DDLCompanyVatPayableAccount(int companyId)
        {
            return await basicCOARepository.DDLCompanyVatPayableAccount(companyId);
        }

        public async Task<List<SelectListItem>> DDLCompanyAdvanceIncomeTaxAccount(int companyId)
        {
            return await basicCOARepository.DDLCompanyAdvanceIncomeTaxAccount(companyId);
        }

        public async Task<UserInfoModel> GetACCUserCompany(string UserName)
        {
            return await basicCOARepository.GetACCUserCompany(UserName);
        }
    }
}
