using Microsoft.EntityFrameworkCore;
using RTEXERP.DBEntities.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.DataContext
{
    public class FiniteSchedulerDBContext : DbContext
    {
        public FiniteSchedulerDBContext(DbContextOptions<FiniteSchedulerDBContext> options) : base(options) { }
        public virtual DbSet<OvalPrintingReportMaster> OvalPrintingReportMaster { get; set; }
        public virtual DbSet<OvalPrintingReportDetails> OvalPrintingReportDetails { get; set; }
        public virtual DbSet<MarkerCuttingPlanMaster_Excel> MarkerCuttingPlanMaster_Excel { get; set; }
        public virtual DbSet<MarkerCuttingInfo_Excel> MarkerCuttingInfo_Excel { get; set; }
        public virtual DbSet<MarkerCuttingFabricDetail_Excel> MarkerCuttingFabricDetail_Excel { get; set; }
        public virtual DbSet<MarkerCuttingSizes_Excel> MarkerCuttingSizes_Excel { get; set; }
        public virtual DbSet<MarkerCuttingConsumption_Excel> MarkerCuttingConsumption_Excel { get; set; }
        public virtual DbSet<LotWiseCuttingInfo> LotWiseCuttingInfo { get; set; }
        public virtual DbSet<LotWiseCuttingInfoMarkers> LotWiseCuttingInfoMarkers { get; set; }
        public virtual DbSet<LotWiseCuttingInfoMarkersSizes> LotWiseCuttingInfoMarkersSizes { get; set; }
        public virtual DbSet<LotWiseShortCuttingInfo> LotWiseShortCuttingInfo { get; set; }
        public virtual DbSet<vw_OrderLotFinishQuantity> vw_OrderLotFinishQuantity { get; set; }
        public virtual DbSet<ConsumptionSheetUserInputs> ConsumptionSheetUserInputs { get; set; }
        public virtual DbSet<OrderColorWiseRejectionBreakdown_Report> OrderColorWiseRejectionBreakdown_Report { get; set; }
        public virtual DbSet<DFS_LotDyeingDelivery> DFS_LotDyeingDelivery { get; set; }

        public virtual DbSet<DFS_LotMakingMaster> DFS_LotMakingMaster { get; set; }

        public virtual DbSet<Tbl_KnittingMachines> Tbl_KnittingMachines { get; set; }
        public virtual DbSet<vw_OrderLotConfirmQuantity> vw_OrderLotConfirmQuantity { get; set; }
        public virtual DbSet<Tbl_cutting_part_ok> Tbl_cutting_part_ok { get; set; }
        public virtual DbSet<Tbl_Cutting_Defect_Lot> Tbl_Cutting_Defect_Lot { get; set; }
        public virtual DbSet<SFS_ProductionResourceSpecification> SFS_ProductionResourceSpecification { get; set; }
        public virtual DbSet<SFS_ProductionResourceRelations> SFS_ProductionResourceRelations { get; set; }
        public virtual DbSet<vw_SFS_Productionline> vw_SFS_Productionline { get; set; }
        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OvalPrintingReportMaster>(entity =>
            {
                entity.ToTable("OvalPrintingReportMaster", "rpt");
            });
            modelBuilder.Entity<OvalPrintingReportMaster>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<OvalPrintingReportDetails>(entity =>
            {
                entity.ToTable("OvalPrintingReportDetails", "rpt");
            });
            modelBuilder.Entity<OvalPrintingReportDetails>().HasQueryFilter(p => !p.IsRemoved);

            modelBuilder.Entity<MarkerCuttingPlanMaster_Excel>(entity =>
            {
                entity.ToTable("MarkerCuttingPlanMaster_Excel", "ajt");
            });
            modelBuilder.Entity<MarkerCuttingInfo_Excel>(entity =>
            {
                entity.ToTable("MarkerCuttingInfo_Excel", "ajt");
            });
            modelBuilder.Entity<MarkerCuttingFabricDetail_Excel>(entity =>
            {
                entity.ToTable("MarkerCuttingFabricDetail_Excel", "ajt");
            });
            modelBuilder.Entity<MarkerCuttingSizes_Excel>(entity =>
            {
                entity.ToTable("MarkerCuttingSizes_Excel", "ajt");
            });
            modelBuilder.Entity<MarkerCuttingConsumption_Excel>(entity =>
            {
                entity.ToTable("MarkerCuttingConsumption_Excel", "ajt");
            });
            modelBuilder.Entity<LotWiseCuttingInfo>(entity =>
            {               
                entity.ToTable("LotWiseCuttingInfo", "ajt");
                entity.HasQueryFilter(x => x.IsRemoved == false);
            });
            //modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<LotWiseCuttingInfoMarkers>(entity =>
            {
                entity.ToTable("LotWiseCuttingInfoMarkers", "ajt");
                entity.HasQueryFilter(x => x.IsRemoved == false);
            });
            modelBuilder.Entity<LotWiseCuttingInfoMarkersSizes>(entity =>
            {
                entity.ToTable("LotWiseCuttingInfoMarkersSizes", "ajt");
                entity.HasQueryFilter(x => x.IsRemoved == false);
            });

            modelBuilder.Entity<LotWiseShortCuttingInfo>(entity =>
            {
                entity.ToTable("LotWiseShortCuttingInfo", "ajt");
                entity.HasQueryFilter(x => x.IsRemoved == false);
            });
            modelBuilder.Entity<vw_OrderLotFinishQuantity>(entity =>
            { 
                entity.ToTable("vw_OrderLotFinishQuantity", "ajt");
            }); 
            modelBuilder.Entity<ConsumptionSheetUserInputs>(entity =>
            {
                entity.ToTable("ConsumptionSheetUserInputs", "ajt");
            });
            modelBuilder.Entity<OrderColorWiseRejectionBreakdown_Report>(entity =>
            {
                entity.ToTable("OrderColorWiseRejectionBreakdown_Report", "ajt");
            });
            modelBuilder.Entity<vw_OrderLotConfirmQuantity>(entity =>
            {
                entity.ToTable("vw_OrderLotConfirmQuantity", "ajt");
            });
            modelBuilder.Entity<DFS_LotDyeingDelivery>(entity =>
            {
                entity.ToTable("DFS_LotDyeingDelivery", "ajt");
            });
            modelBuilder.Entity<Tbl_Cutting_Defect_Lot>(entity =>
            {
                entity.ToTable("Tbl_Cutting_Defect_Lot", "ajt");
            });
            modelBuilder.Entity<vw_SFS_Productionline>(entity =>
            {
                entity.ToTable("vw_SFS_Productionline", "ajt");
            });
            


        }
    }
}