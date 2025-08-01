using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RTEXERP.DAL.DataContext;
using RTEXERP.DAL.IdentityEntities;
using RTEXERP.Extension.Extensions;
using Microsoft.Extensions.Logging;
using System.IO;
using Serilog;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Diagnostics;
using RTEXERP.Contracts.Configurations;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using RTEXERP.SResources.Resources;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RTEXERP.WEB.Helper;
using AutoMapper;
using FluentScheduler;
using RTEXERP.WEB.Scheduler.SchedulerProcess;
using RTEXERP.BLL.CommonService.EmailSetup;
using RTEXERP.WEB.Scheduler.SchedulerProcess.SchedulerJobs;
using Microsoft.AspNetCore.Http.Features;
using RTEXERP.Contracts.Interfaces.Services.AppSecurity;

namespace RTEXERP.WEB
{
    public class Startup
    {
        readonly IHostingEnvironment HostingEnvironment;
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            HostingEnvironment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.CookiePolicyService();

            // Also make top level configuration available(for EF configuration and access to connection string)
            services.AddSingleton(Configuration); //IConfigurationRoot
            services.AddSingleton<IConfiguration>(Configuration);
           

            services.AddSingleton<LocService>();
            //Add Support for strongly typed Configuration and map to class
            services.AddOptions();
            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));
            //services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddDbContext<ApplicationDBContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("ReportERPConnection")));

            services.AddDbContext<ReportDBContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ReportERPConnection")));

            services.AddDbContext<AOPDBContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("AOPConnectionString")));

            services.AddDbContext<CMSDBContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("CMSConnectionString")));

            services.AddDbContext<EmbroDBContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("EmbroConnectionString")));

            services.AddDbContext<EMSDBContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("EMSConnectionString")));

            services.AddDbContext<FiniteSchedulerDBContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("FiniteSchedulerConnectionString")));

            services.AddDbContext<MaterialsManagementDBContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("MaterialsManagementConnectionString")));

            services.AddDbContext<MaxcoDBContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("MaxcoConnectionString")));
            services.AddDbContext<HRTESTContext>(options =>
options.UseSqlServer(
Configuration.GetConnectionString("HRMSConnectionString")));

            #region Identity Password Configuration
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;



            })
                //.AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();
            #endregion Identity Password Configuration

            services.SessionService();
            #region ConfigureApplicationCookie

            #endregion ConfigureApplicationCookie

            services.GenericRepository();
            services.RTEXERPDependency(Configuration);
            services.AddSingleton<AOPCostSummeryJob>();
            services.AddSingleton<IUserIPAddressService, UserIPAddressService>();
            //  services.AddSingleton<IE_mailSender, Email_Sender>();
            #region localization
            services.Configure<RequestLocalizationOptions>(
            opts =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("bn-BD")
                };
                opts.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
            });
            #endregion

            /* new Add Scheduler*/
          
            /*End scheduler*/
            services.AddLocalization(opts => opts.ResourcesPath = "Resources");

            services.AddAutoMapper();

            //
            services.Configure<FormOptions>(x => x.ValueCountLimit = 2048);
            //JobManager.UseUtcTime();
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization()
                            .AddMvcOptions(options =>
                            {
                                // options.Filters.Add(new SessionExpireFilter());

                            })
                            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                             .AddJsonOptions(options => {
                                 options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                                 options.SerializerSettings.MaxDepth = 64;
                             })
            .AddRazorPagesOptions(options =>
            {
                options.AllowAreas = true;
                options.Conventions.AuthorizeAreaFolder("Identity", "/Account/");
                options.Conventions.AllowAnonymousToAreaPage("Identity", "/Account/Login");

            });
            
            //services.AddHttpContextAccessor();
            services.TryAddSingleton<IHttpContextAccessor, IHttpContextAccessor>();
            services.AddTransient<UserMenuAccessServices>();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            JobManager.Initialize(new JobRegistry(services.BuildServiceProvider().GetRequiredService<IEmailSenderCS>()));
            //  JobManager.Initialize(new JobRegistry(app.ApplicationServices));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            // Serilog config

            Log.Logger = new LoggerConfiguration()
                    .WriteTo.RollingFile(pathFormat: "logs\\log-{Date}.log")
                    .CreateLogger();

            if (env.IsDevelopment())
            {
                loggerFactory.AddSerilog();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                #region Error Log
                loggerFactory
                    .AddSerilog();
                app.UseExceptionHandler(errorApp =>

                    //Application level exception handler here - this is just a place holder
                    errorApp.Run(async (context) =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";
                        await context.Response.WriteAsync("<html><body>\r\n");
                        await context.Response.WriteAsync(
                                "We're sorry, we encountered an un-expected issue with your application.<br>\r\n");

                        //Capture the exception
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            //This error would not normally be exposed to the client
                            await context.Response.WriteAsync("<br>Error: " +
                                    HtmlEncoder.Default.Encode(error.Error.Message) + "<br>\r\n");
                        }
                        await context.Response.WriteAsync("<br><a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512)); // Padding for IE
                    }));
                #endregion Error Log
            }
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            

            app.UseHttpsRedirection();
            //app.UseCookiePolicy();
            app.UseStaticFiles();


            //N-2
            app.UseAuthentication();
            app.UseCookiePolicy();
            // N-1
            app.UseSession();
            HttpContextHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            //Last N
            #region Area Route
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
   

            #endregion Area Route
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            /*Scheduler */
            //JobManager.JobFactory = new JobFactory(new StandardKernel(new EmailInject()));
            //JobManager.Initialize(new JobRegistry());
         
            /*End Scheduler */
        }
    }


}
