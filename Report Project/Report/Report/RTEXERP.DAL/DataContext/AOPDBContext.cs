using Microsoft.EntityFrameworkCore;
using RTEXERP.DBEntities.AOP;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.DataContext
{
    public class AOPDBContext : DbContext
    {
        public AOPDBContext(DbContextOptions<AOPDBContext> options) : base(options) { }

        public virtual DbSet<User_Setup> User_Setup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}