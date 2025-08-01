using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using RTEXERP.Common.Constants;
using RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo;
using RTEXERP.Extension.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RTEXERP.WEB.Helper
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        //IHttpContextAccessor _httpContext;
        //public SessionExpireFilter(IHttpContextAccessor httpContext)
        //{
        //    _httpContext = httpContext;
        //}

        public override void OnActionExecuted(ActionExecutedContext context)
        {
         //   base.OnActionExecuted(context);
        }

        public override  void OnActionExecuting(ActionExecutingContext context)
        {

            string ajaxRequestalue = "XMLHttpRequest";
            string requestedWith = context.HttpContext.Request.Headers["X-Requested-With"];
            try
            {

            }catch(Exception e)
            {
                var dd = e.Message;
            }
            var ctx = HttpContextHelper.Current;
            if (ctx.Session != null)
            {
                if (ctx.Session.Id != context.HttpContext.Session.Id)
                {
                    string sessionCookie = ctx.Request.Headers["Cookie"];
                    if(null != sessionCookie)
                    {
                        ctx.Response.Redirect($"/Identity/Account/Login");
                    }
                }
                else if(ajaxRequestalue!= requestedWith)
                {
                    EnsureRequestIsAuthorized(context);
                }
            }
            base.OnActionExecuting(context);

        }

        private void EnsureRequestIsAuthorized(ActionExecutingContext context)
        {
            string _currentController = "";
            string _area = "";
            string _currentAction = "";
            if (HttpContextHelper.Current.User.Identity.IsAuthenticated)
            {
                var userModules = HttpContextHelper.Current.Session.Get<List<LogedUserAccessViewModel>>(SessionKey.USER_SECURITY_MODULES);
                if (userModules != null)
                {
                    var areaname = context.RouteData.Values["area"]; //context.RouteData.Values["controller"].ToString();
                    var currentController = context.RouteData.Values["controller"];
                    var currentAction = context.RouteData.Values["action"];
                   
                    

                    if (areaname != null)
                    {
                        _area = areaname.ToString();
                    }
                    if (currentController != null)
                    {
                        _currentController = currentController.ToString();
                    }
                    if (currentAction != null)
                    {
                        _currentAction = currentAction.ToString();
                    }
                    var isAuthorized = userModules.Where(w => w.ControllerName == _currentController).FirstOrDefault();

                    if (string.IsNullOrEmpty(_currentAction))
                        currentAction = "Index";
                    var currentModule = userModules.Where(w => w.ControllerName.ToLower() == _currentController.ToLower()
                                               && (w.ActionName.ToLower() == _currentAction.ToLower()
                                               //|| w.ActionName.ToLower() == "index"
                                               )).FirstOrDefault();
                    
                    if (currentModule != null)
                    {
                        var id1 = currentModule.ModuleMenuId.ToString();
                        var id2 = "-1";
                        var id3 = "-1";
                        if (currentModule.ParentModuleId.HasValue)
                        {
                            var level2Parent = currentModule.ParentModuleId.Value;
                            id2 = level2Parent.ToString();
                            var level2Module = userModules.Where(u => u.ModuleMenuId == level2Parent).FirstOrDefault();
                            if (level2Module != null && level2Module.ParentModuleId.HasValue)
                                id3 = level2Module.ParentModuleId.Value.ToString();
                        }
                        var ids = string.Format("{0}_{1}_{2}", id3, id2, id1);
                        HttpContextHelper.Current.Session.Set<string>(SessionKey.Current_Module_Keys, ids);
                       
                    }
                    else
                    {
                        var AllModules = HttpContextHelper.Current.Session.Get<List<LogedUserAccessViewModel>>(SessionKey.All_Modules); // SessionHelper.AllModules;
                        var AllcurrentModule = AllModules.Where(w => w.ControllerName.ToLower() == _currentController.ToLower() && (w.ActionName.ToLower() == _currentAction.ToLower() || w.ActionName == "Index")).FirstOrDefault();
                        //if (AllcurrentModule != null && !ExcludeScurity(currentController, currentAction))
                        //{
                        //    HttpContext.Current.Session["UNAUTHORIZED_ACCES"] = "You are not authorized to access the specific action.";
                        //    throw new UnauthorizedAccessException("You are not authorized to access the specific action.");
                        //}

                    }
                    
                   
                }
            }
        }
    }
}
