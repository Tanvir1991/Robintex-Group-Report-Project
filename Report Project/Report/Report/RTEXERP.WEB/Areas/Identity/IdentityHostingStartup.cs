using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RTEXERP.DAL.DataContext;
using RTEXERP.DAL.IdentityEntities;

[assembly: HostingStartup(typeof(RTEXERP.WEB.Areas.Identity.IdentityHostingStartup))]
namespace RTEXERP.WEB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}