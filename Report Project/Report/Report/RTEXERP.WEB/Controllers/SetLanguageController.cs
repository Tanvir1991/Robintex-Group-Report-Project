using System;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace RTEXERP.WEB.Controllers
{
    public class SetLanguageController : Controller
    {
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            //CultureInfo cc = Thread.CurrentThread.CurrentCulture;
            //var ca = System.Globalization.CultureInfo.CurrentCulture;
            //Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);
            //CultureInfo ddd = Thread.CurrentThread.CurrentCulture;
            //var ab = System.Globalization.CultureInfo.CurrentCulture;
            //var cul = new RequestCulture(culture);
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
               //CookieRequestCultureProvider.MakeCookieValue(cul),
               /* new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1)*/
               new CookieOptions
               {
                   Expires = DateTimeOffset.UtcNow.AddYears(1),
                   IsEssential = true,  //critical settings to apply new culture
                   Path = "/",
                   HttpOnly = false,
               }
                
            );

            //CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            //var c = System.Globalization.CultureInfo.CurrentCulture;
            return LocalRedirect(returnUrl);
            
        }
    }
}