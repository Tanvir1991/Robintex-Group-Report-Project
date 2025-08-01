using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RTEXERP.Contracts.BLModels.AppSecurity;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Services.AppSecurity;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.DAL.IdentityEntities;
using RTEXERP.WEB.Controllers;

namespace RTEXERP.WEB.Areas.AppSecurity.Controllers
{
    [Area("AppSecurity")]
    public class UserRegisterController : BaseController
    {
        private readonly IDropdownService dropdownService;
    
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<RegisterModel> logger;

        private readonly IAspNetRolesService aspNetRolesService;

        public UserRegisterController(IDropdownService dropdownService,
  
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ILogger<RegisterModel> logger,
            IAspNetRolesService aspNetRolesService)
        {
           
            this.dropdownService = dropdownService;
            this.signInManager = signInManager;
            this.userManager = userManager;

            this.logger = logger;
            this.aspNetRolesService = aspNetRolesService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new UserRegisterViewModel();
            //model.CompanyList = dropdownService.RenderDDL(companyInfoService.DDLGetCompanyList());
            model.EmployeeList = dropdownService.DefaultDDL();
            model.RoleList = dropdownService.RenderDDL(aspNetRolesService.DDLGetRoleList());
            model.ActiveList = dropdownService.BooleanDDL();
            return View(model);
        }
        [HttpPost]
        public  async Task<IActionResult> Register(UserRegisterViewModel userRegisterVM)
        {
           RResult result = new RResult();
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser()
                    {
                        UserName = userRegisterVM.UserName,
                        Email = userRegisterVM.Email,
                        CompanyId = userRegisterVM.CompanyId,
                        CreateBy = 1,
                        CreateDate = DateTime.Now,
                        IsActive = true,
                        IsRemoved = false,
                        EmployeeId = userRegisterVM.EmployeeId
                    };
                    var insertUser = await userManager.CreateAsync(user, userRegisterVM.Password);

                    var roleName = await aspNetRolesService.GetAspNetRolesById(userRegisterVM.RoleId);
                    if (insertUser.Succeeded)
                    {
                        var roleInsert = await userManager.AddToRoleAsync(user, roleName.Name);
                        result.result = 1;
                        result.message = ReturnMessage.InsertMessage;
                    }
                    else
                    {
                        result.result = 0;
                        result.message = "Duplicate User.";
                    }


                }
                else
                {
                    result.result = 0;
                    result.message = "Register information is not valid.";
                }
            }
            catch(Exception e)
            {
                result.result = 0;
                result.message = e.Message;
            }

            return Json(result);
        }

        public JsonResult GetEmployeeListByCompany(int companyId)
        {
            List<SelectListItem> empList = new List<SelectListItem>();
            try
            {
                //empList = dropdownService.RenderDDL(employeeService.DDLEmployeeList(companyId));
            }
            catch (Exception)
            {

                throw;
            }
            return Json(empList);
        }



    }
}