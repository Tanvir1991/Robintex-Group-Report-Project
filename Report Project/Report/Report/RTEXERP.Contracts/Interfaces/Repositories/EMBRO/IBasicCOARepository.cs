using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.BLModels.Shared.ChartOFACC;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Embro;

using System.Collections.Generic;
 
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
    public interface IBasicCOARepository:IGenericRepository<BasicCoa>
    {
        /// <summary>
        ///   Company=1
        ///   Business=2
        ///   Location=3
        ///   Category=4
        ///   SubCategory=5
        ///   BroadGroup=6
        ///   NarrowGroup=7
        ///   Identification=8
        ///   SubIdentification1=9
        ///   SubIdentification2=10
        ///   CostCenter=11
        ///   Activity=12
        ///   SubActivity=13
        ///   Item=14
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="levelId"></param>
        /// <returns></returns>
        Task<List<SelectListItem>> DDLChartOfAccounts(int? parentId, int levelId);
        Task<List<SelectListItem>> DDLChartOfAccountsCompanyWiseSupplier(int companyId);
        Task<IEnumerable<SelectListItem>> DDLAccCategory(int Selected);
        Task<IEnumerable<SelectListItem>> DDLCategoryChartOfAccounts(int CompanyID, int? CategoryID = 0);
        Task<BasicCoa> AccInfo(int Id);
        Task<List<BasicCOAViewModel>> ChartOfAccountsSupplierGroup(int companyId, int? CategoryID = 0);
        Task<List<BasicCOAViewModel>> GetAutoCompleteChartOfAccounts(string itemName, int companyId);
        Task<List<BasicCOAViewModel>> ChartOfAccountsGroup(int companyId, int? CategoryID = 0);
        Task<List<BasicCOAViewModel>> ChartOfAccounts(int? parentId, int levelId);
        Task<List<BasicCOAViewModel>> GetsSupplierListAutocomplete(string itemName, int companyId);
        Task<List<BasicCOAViewModel>> GetBankAccountAutocomplete(string itemName, int companyId);
        Task<List<SelectListItem>> DDLCompanyVatPayableAccount(int companyId);
        Task<List<SelectListItem>> DDLCompanyAdvanceIncomeTaxAccount(int companyId);

        Task<UserInfoModel> GetACCUserCompany(string UserName);
    }
}
