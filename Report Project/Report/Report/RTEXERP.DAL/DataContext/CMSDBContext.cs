using Microsoft.EntityFrameworkCore;
using RTEXERP.DBEntities.CMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.DataContext
{
    public class CMSDBContext : DbContext
    {
        public CMSDBContext(DbContextOptions<CMSDBContext> options) : base(options) { }

        public virtual DbSet<SubcontractStyleCharge> SubcontractStyleCharge { get; set; }
        public virtual DbSet<Pro_Master> Pro_Master { get; set; }
        public virtual DbSet<DepartmentSalaryForProduction> DepartmentSalaryForProduction { get; set; }
        public virtual DbSet<MonthlyProductionCostAnalysisMaster> MonthlyProductionCostAnalysisMaster { get; set; }
        public virtual DbSet<MonthlyProductionCostAnalysisDetails> MonthlyProductionCostAnalysisDetails { get; set; }
        public virtual DbSet<ProductionLineEmployee> ProductionLineEmployee { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SubcontractStyleCharge>(entity =>
            {
                entity.ToTable("SubcontractStyleCharge", "AJT");
            });
           
            modelBuilder.Entity<DepartmentSalaryForProduction>(entity =>
            {
                entity.ToTable("DepartmentSalaryForProduction", "AJT");
            });
            modelBuilder.Entity<MonthlyProductionCostAnalysisMaster>(entity =>
            {
                entity.ToTable("MonthlyProductionCostAnalysisMaster", "AJT");
            });
            modelBuilder.Entity<MonthlyProductionCostAnalysisDetails>(entity =>
            {
                entity.ToTable("MonthlyProductionCostAnalysisDetails", "AJT");
            });
            modelBuilder.Entity<ProductionLineEmployee>(entity =>
            {
                entity.ToTable("ProductionLineEmployee", "AJT");
            });
        }
    }
}