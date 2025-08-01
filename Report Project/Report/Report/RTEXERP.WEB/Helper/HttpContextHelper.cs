using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.WEB.Helper
{
    public static class HttpContextHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
         
        public static HttpContext Current => _httpContextAccessor.HttpContext;
        //public static void dd()
        //{
        //    var username = _httpContextAccessor.HttpContext.User.Identity.Name;
        //}
        
    }
}
