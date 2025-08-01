using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RTEXERP.DAL.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.DataContext
{

    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    }

}