using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.DBEntities.dbo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.dbo
{
   public interface IModuleMenuRepository:IGenericRepository<ModuleMenu>
    {
        Task<ModuleMenu> GetModuleMenuById(int companyId);
        Task<IList<ModuleMenu>> GetModuleMenuAsync();
        List<LogedUserAccessViewModel> ParrentModuleMenu(int? CompanyId);
        Task<IList<ModuleMenu>> GetAllModuleMenuAsync();
    }
}
