using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Contracts.BLModels.Shared.ChartOFACC;
using RTEXERP.Contracts.Interfaces.Repositories.Hrm;
using RTEXERP.DAL.DataContext;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RTEXERP.DAL.ImpRepository.Hrm
{
    public class UserAccessInfoRepository : GenericRepository<LogedUserAccessViewModel>, IUserAccessInfoRepository
    {

        private ReportDBContext dbCon;
        public UserAccessInfoRepository(ReportDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public List<LogedUserAccessViewModel> GetLogedUserAccessItem(int RoleId, int? EmployeeId)
        {
            List<LogedUserAccessViewModel> modelList = new List<LogedUserAccessViewModel>();
            try
            {
                dbCon.LoadStoredProc("hrm.usp_UserMenuList")
                              .AddParam("RoleId", RoleId)
                              .AddParam("EmployeeId", EmployeeId)
                              .Exec(r => modelList = r.ToList<LogedUserAccessViewModel>());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return modelList;

        }
        public LoggedUserInfoViewModel GetLoggedUserInfo(string UserName)
        {
            List<LoggedUserInfoViewModel> model = new List<LoggedUserInfoViewModel>();

            try
            {
                dbCon.LoadStoredProc("hrm.usp_GetLoggedUserInfo")
                               .AddParam("UserName", UserName)

                               .Exec(r => model = r.ToList<LoggedUserInfoViewModel>());

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return model.FirstOrDefault();
        }

        public List<LogedUserAccessViewModel> GETAllMenuItem(int CompanyId)
        {
            //List<LogedUserAccessViewModel> modelList = new List<LogedUserAccessViewModel>();
            var list = dbCon.ModuleMenu.Where(b => b.IsRemoved == false && b.IsActive == true && b.CompanyId == CompanyId)
                .Select(b => new LogedUserAccessViewModel()
                {
                    ActionName = b.ActionName,
                    AreaName = b.AreaName,
                    ControllerName = b.ControllerName,
                    DisplayOrder = b.DisplayOrder,
                    IsMenuItem = b.IsMenuItem,
                    LinkText = b.LinkText,
                    LinkTextUn = b.LinkTextUn,
                    MenuLevel = b.MenuLevel,
                    MenuSymbol = b.MenuSymbol,
                    ModuleCode = b.ModuleCode,
                    ModuleMenueCode = b.ModuleMenueCode,
                    ModuleMenuId = b.ModuleMenuId,
                    ParentModuleId =b.ParentModuleId,
                    RoleId = 0,
                    SecurityLevelId = 99,
                    UserType = b.UserType
                });

            return list.ToList();

        }

        public List<ChartOfAccounts> GetChantOfAccounts(int ParentID = 0, int LevelId = 1)
        {
            List<ChartOfAccounts> list = new List<ChartOfAccounts>();

            try
            {
                dbCon.LoadStoredProc("usp_GETBasicChartOfAccount")
                               .AddParam("ParentID", ParentID)
                                  .AddParam("LevelId", LevelId)
                               .Exec(r => list = r.ToList<ChartOfAccounts>());

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

     
    }
}
