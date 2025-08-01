using Microsoft.EntityFrameworkCore;
using RTEXERP.DBEntities;
using RTEXERP.DBEntities.MaterialsManagement;
using RTEXERP.DBEntities.MaterialsManagement.DB_View;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.DataContext
{
    public class MaterialsManagementDBContext : DbContext
    {
        public MaterialsManagementDBContext(DbContextOptions<MaterialsManagementDBContext> options) : base(options) { }

        #region dbo
        public virtual DbSet<CMBL_Sample> CMBL_Sample { get; set; }
        public virtual DbSet<CMBL_SampleItem> CMBL_SampleItem { get; set; }
        public virtual DbSet<CMBL_SampleGateReceiving> CMBL_SampleGateReceiving { get; set; }
        public virtual DbSet<CMBL_Unit> CMBL_Unit { get; set; }
        public virtual DbSet<CMBL_SampleItemGateReceiving> CMBL_SampleItemGateReceiving { get; set; }
        public virtual DbSet<CMBL_StockTransaction> CMBL_StockTransaction { get; set; }
        public virtual DbSet<CMBL_DocumentType_Setup> CMBL_DocumentType_Setup { get; set; }
        public virtual DbSet<CMBL_Item> CMBL_Item { get; set; }
        public virtual DbSet<CMBL_ItemAttribute> CMBL_ItemAttribute { get; set; }
        public virtual DbSet<CMBL_ItemAttributeSet> CMBL_ItemAttributeSet { get; set; }
        public virtual DbSet<CMBL_ItemUnit> CMBL_ItemUnit { get; set; }

        public virtual DbSet<MM_MRPItem> MM_MRPItem { get; set; }
        public virtual DbSet<DD_PurchaseOrder> DD_PurchaseOrder { get; set; }
        public virtual DbSet<DD_POItemMaster> DD_POItemMaster { get; set; }
        public virtual DbSet<DD_POItemDetails> DD_POItemDetails { get; set; }
        public virtual DbSet<DD_POStatus_Setup> DD_POStatus_Setup { get; set; }
        public virtual DbSet<CMBL_StoreBroadGroup> CMBL_StoreBroadGroup { get; set; }
        public virtual DbSet<CMBL_UserStore> CMBL_UserStore { get; set; }
        public virtual DbSet<KnittingNeedleConsumptionMaster> KnittingNeedleConsumptionMaster { get; set; }
        public virtual DbSet<KnittingNeedleConsumptionDetails> KnittingNeedleConsumptionDetails { get; set; }
        public virtual DbSet<KnittingRepairItemCategory> KnittingRepairItemCategory { get; set; }
        //
        #endregion
        #region Db View
        public virtual DbSet<vw_CMBL_ItemALLAttribute> vw_CMBL_ItemALLAttribute { get; set; }
        
        #endregion Db View
        public DbSet<AuditTrace> AuditTrace { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region dbo
            modelBuilder.Entity<CMBL_Sample>(entity =>
            {
                entity.ToTable("CMBL_Sample", "dbo");
            });
            modelBuilder.Entity<CMBL_SampleItem>(entity =>
            {
                entity.ToTable("CMBL_SampleItem", "dbo");
            });
            modelBuilder.Entity<CMBL_SampleGateReceiving>(entity =>
            {
                entity.ToTable("CMBL_SampleGateReceiving", "dbo");
            });
            modelBuilder.Entity<CMBL_Unit>(entity =>
            {
                entity.ToTable("CMBL_Unit", "dbo");
            });
            modelBuilder.Entity<CMBL_SampleItemGateReceiving>(entity =>
            {
                entity.ToTable("CMBL_SampleItemGateReceiving", "dbo");
            });
            modelBuilder.Entity<CMBL_StockTransaction>(entity =>
            {
                entity.ToTable("CMBL_StockTransaction", "dbo");
            });
            modelBuilder.Entity<CMBL_StoreBroadGroup>(entity =>
            {
                entity.ToTable("CMBL_StoreBroadGroup", "dbo");
            });
            modelBuilder.Entity<CMBL_UserStore>(entity =>
            {
                entity.ToTable("CMBL_UserStore", "dbo");
            });
            #endregion
            
            #region Table Property 

            //modelBuilder.Entity<CMBL_StockTransaction>().Property(p => p.Quantity).HasMaxLength(7);
            #endregion

            modelBuilder.Entity<AuditTrace>(entity =>
            {
                entity.ToTable("AuditTrace", "AJT");
            });
            modelBuilder.Entity<KnittingNeedleConsumptionMaster>(entity =>
            {
                entity.ToTable("KnittingNeedleConsumptionMaster", "AJT");
            });
            modelBuilder.Entity<KnittingNeedleConsumptionDetails>(entity =>
            {
                entity.ToTable("KnittingNeedleConsumptionDetails", "AJT");
            });
            modelBuilder.Entity<KnittingRepairItemCategory>(entity =>
            {
                entity.ToTable("KnittingRepairItemCategory", "AJT");
            });


            #region DB View
            modelBuilder.Entity<vw_CMBL_ItemALLAttribute>(entity =>
            {
                entity.ToTable("vw_CMBL_ItemALLAttribute", "AJT");
            });
            #endregion DB View

        }
    }
}