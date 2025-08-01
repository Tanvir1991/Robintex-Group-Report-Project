using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using RTEXERP.BLL.CommonService.EmailSetup;
using RTEXERP.BLL.ImpService.AppSecurity;
using RTEXERP.Common.MapperHelper;
using RTEXERP.Contracts;
using RTEXERP.Contracts.Interfaces.Services.AppSecurity;
using RTEXERP.DAL;
using RTEXERP.DAL.ImpRepository.AppSecurity;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RTEXERP.Extension.Extensions
{
    public static class ServiceExtension
    {
        public static void RTEXERPDependency(this IServiceCollection services, IConfiguration configuration)
        {

            #region Assembly Repository
            //This registers the service layer: I only register the classes who name ends with "Service" (at the moment)
            services.RegisterAssemblyPublicNonGenericClasses(
                Assembly.GetExecutingAssembly())
                .Where(s => s.Name.EndsWith("Repository")
                         || s.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();

            //Now I register the  assembly used by DevModService
            services.RegisterAssemblyPublicNonGenericClasses(
                     Assembly.GetAssembly(typeof(AspNetRolesService)))
                .AsPublicImplementedInterfaces();
            services.RegisterAssemblyPublicNonGenericClasses(
                Assembly.GetAssembly(typeof(AspNetRolesRepository)))
           .AsPublicImplementedInterfaces();

            //Put any code here to initialise values from the configuration parameter
            #endregion Assembly Repository


            /*
            services.Scan(scan => scan
      .FromCallingAssembly() // 1. Find the concrete classes
        .AddClasses()        //    to register
          .UsingRegistrationStrategy(RegistrationStrategy.Skip) // 2. Define how to handle duplicates
          .AsSelf()    // 2. Specify which services they are registered as
          .WithScopedLifetime()); // 3. Set the lifetime for the services
          */

            //services.AddScoped<IBlogRepository, BlogRepository>();
            //services.AddScoped<IBlogService, BlogService>();
        }

        public static void GenericRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAutoMapConverter<,>), typeof(AutoMapConverter<,>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IExtendedGenericRepository<>), typeof(ExtendedGenericRepository<>));
            services.AddSingleton<IEmailSenderCS, EmailSenderCS>();
           
            
        }

        public static void CookiePolicyService(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        public static void SessionService(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
           // services.AddHttpContextAccessor();
        }


    }
}
