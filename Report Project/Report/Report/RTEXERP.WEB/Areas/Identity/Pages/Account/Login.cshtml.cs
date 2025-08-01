using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RTEXERP.DAL.IdentityEntities;
using RTEXERP.Common.Constants;
using RTEXERP.Extension.Extensions;
using RTEXERP.BLL.ImpService.Hrm;
using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using Microsoft.EntityFrameworkCore;
using RTEXERP.WEB.Helper;
using RTEXERP.Contracts.Interfaces.Services.dbo;
using Microsoft.AspNetCore.Http;

namespace RTEXERP.WEB.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IUserAccessInfoService userAccessInfoService;
        private IModuleMenuService moduleMenuService;
        //private SessionData storeSessionData;
        public LoginModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, IUserAccessInfoService userAccessInfoService
            , IModuleMenuService moduleMenuService)
        {
            _signInManager = signInManager;
            _logger = logger;
            this.userAccessInfoService = userAccessInfoService;
            this.moduleMenuService = moduleMenuService;
            //storeSessionData = new SessionData();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            //[Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [Display(Name = "User Name")]
            [MaxLength(50, ErrorMessage = "Maximam Length 50.")]
            [MinLength(3, ErrorMessage = "Minimum 3 .")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
      
        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            ViewData["Title"] = "RTEX Login";
                returnUrl = returnUrl ?? Url.Content("~/");

                // Clear the existing external cookie to ensure a clean login process
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (User.Identity.IsAuthenticated)
            {
                returnUrl = "~/Home/Index";
            }

                ReturnUrl = returnUrl;
            
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var userInfo = userAccessInfoService.GetLoggedUserInfo(Input.UserName);
                    if (userInfo != null && userInfo.EmployeeId > 0) {
                        var AllaccessList = userAccessInfoService.GETAllMenuItem(userInfo.CompanyId);
                        var UserAccessList = userAccessInfoService.GetLogedUserAccessItem(userInfo.RoleId,userInfo.EmployeeId);
                        var ParrentList = UserAccessList.Where(b=> !b.ParentModuleId.HasValue).ToList();
                     //   HttpContext.Session.Set<LoggedUserInfoViewModel>(SessionKey.LOGGEDIN_EMPLOYEE_INFO_Model, userInfo);
                        SessionData.SETSessionInfo(AllaccessList, UserAccessList, ParrentList, userInfo);
                        SessionData.Session_COMPANY_ID = userInfo.CompanyId;
                        SessionData.Session_EMPLOYEE_ID = userInfo.EmployeeId;
                        SessionData.Session_User_IsSuperAdmin = userInfo.IsSuperAdminRole;
                        SessionData.Session_Role_ID = userInfo.RoleId;
                        SessionData.Session_USER_ID = userInfo.UserId;
                        HttpContext.Session.SetInt32("OfficeType_Id", userInfo.RoleId);
                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        await _signInManager.SignOutAsync();
                        return Page();
                    }
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
