using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.DBEntities.dbo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.dbo
{
   public interface IModuleMenuService
    {
        Task<ModuleMenu> GetModuleMenuById(int id);
        Task<IList<ModuleMenu>> GetModuleMenuAsync();
        List<LogedUserAccessViewModel> ParrentModuleMenu(int? CompanyId);
        Task<List<ModuleWiseMenuViewModel>> GenerateModuleWiseMenuTree(int roleId=0);

    }
}
