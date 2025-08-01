﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace RTEXERP.WEB
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        CreateWebHostBuilder(args).Build().Run();
    //    }

    //    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //        WebHost.CreateDefaultBuilder(args)
    //            .UseStartup<Startup>();
    //}

    public class Program
    {
        public static void Main(string[] args)
        {
            //Old code to directly return host.
            //var host = CreateWebHostBuilder(args);

            //New code to return builder.
            var hostBuilder = CreateWebHostBuilder(args);
            var host = hostBuilder.Build();

            //Initialize data if not done.
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            //    //try
            //    //{
            //    //    var storeDataContext = services.GetRequiredService<StoreDataContext>();
            //    //    StoreDataInitializer.Initialize(storeDataContext);

            //    //}
            //    //catch (Exception ex)
            //    //{
            //    //    var logger = loggerFactory.CreateLogger<Program>();
            //    //    logger.LogError(ex, "An error occurred seeding the DB.");
            //    //}
            //}
       
          
            host.Run();
        }

        
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                })
                //.UseUrls("http://localhost:8603")
                //.UseIISIntegration() 
                .UseStartup<Startup>();
    }


}
