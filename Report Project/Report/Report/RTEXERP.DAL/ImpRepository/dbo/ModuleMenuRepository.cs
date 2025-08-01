using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Contracts.Interfaces.Repositories.dbo;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.dbo
{
    public class ModuleMenuRepository : GenericRepository<ModuleMenu>, IModuleMenuRepository
    {
        private ReportDBContext dbCon;
        public ModuleMenuRepository(ReportDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<IList<ModuleMenu>> GetAllModuleMenuAsync()
        {
            return await FindAllAsync(c => c.IsMenuItem == true);
        }

        public async Task<IList<ModuleMenu>> GetModuleMenuAsync()
        {
            return await FindAllAsync(c => c.IsRemoved == false);
        }

        public async Task<ModuleMenu> GetModuleMenuById(int companyId)
        {
            return await FindAsync(c => c.IsRemoved == false && c.CompanyId == companyId);
        }

        public List<LogedUserAccessViewModel> ParrentModuleMenu(int? CompanyId)
        {
          var firstList = dbCon.ModuleMenu.Where(b => b.IsRemoved == false && b.IsActive == true && b.ControllerName=="#"  //!b.ParentModuleId.HasValue
             );
            if(CompanyId!=null && CompanyId > 0)
            {
                firstList = firstList.Where(b => b.CompanyId == CompanyId);
            }
            var rList = firstList.Select(b => new LogedUserAccessViewModel()
            {
                ModuleMenuId =b.ModuleMenuId,
                ModuleCode = b.ModuleCode,
                ParentModuleId = b.ParentModuleId,
                ActionName = b.ActionName,
                AreaName = b.AreaName,
                ControllerName = b.ControllerName,
                UserType = b.UserType,
                LinkText = b.LinkText,
                LinkTextUn = b.LinkTextUn,
                DisplayOrder = b.DisplayOrder.Value,
                IsMenuItem = b.IsMenuItem,
                MenuLevel = b.MenuLevel,
                MenuSymbol = b.MenuSymbol,
                ModuleMenueCode = b.ModuleMenueCode,
                
            });
            return rList.ToList();
        }
    }
     

       

      
    

       
    



}
