using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.DBEntities;
using RTEXERP.DBEntities.Maxco;
using RTEXERP.DBEntities.Maxco.DB_Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RTEXERP.DAL.DataContext
{
    public class MaxcoDBContext : DbContext
    {
        public MaxcoDBContext(DbContextOptions<MaxcoDBContext> options) : base(options) { }

        public DbSet<FabricYarnCount_Setup> FabricYarnCount_Setup { get; set; }
        public DbSet<FabricYarnComposition_Setup> FabricYarnComposition_Setup { get; set; }
        public DbSet<LC_CM_CASH_MASTER> LC_CM_CASH_MASTER { get; set; }
        public DbSet<Style> Style { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<Buyer_Setup> Buyer_Setup { get; set; }

        public DbSet<MAC_CostingType> MAC_CostingType { get; set; }
        public DbSet<MAC_OrderCostingInfo> MAC_OrderCostingInfo { get; set; }
        public DbSet<MAC_AccessoriesCostingInfo> MAC_AccessoriesCostingInfo { get; set; }
        public DbSet<MAC_FabricCostingInfo> MAC_FabricCostingInfo { get; set; }
        public DbSet<MAC_IndirectCostingItem> MAC_OtherCostingItem { get; set; }

        public DbSet<FabricQuality_Setup> FabricQuality_Setup { get; set; }
        public DbSet<FabricType_Setup> FabricType_Setup { get; set; }
        public DbSet<Pantone> Pantone { get; set; }
        public DbSet<Trim_Setup> Trim_Setup { get; set; }
        public DbSet<Vw_MAC_IndirectCostingItem> Vw_MAC_IndirectCostingItem { get; set; }
        public DbSet<AuditTrace> AuditTrace { get; set; }

        public DbSet<Mer_StyleMaster> Mer_StyleMaster { get; set; }
        public DbSet<Mer_StylePODetail> Mer_StylePODetail { get; set; }
        public DbSet<Mer_StylePOColorSizeQuantityDetail> Mer_StylePOColorSizeQuantityDetail { get; set; }
        public DbSet<Season_Setup> Season_Setup { get; set; }
        public DbSet<MER_Zone> MER_Zone { get; set; }
        public DbSet<FS_RequirementSheet_Master> FS_RequirementSheet_Master { get; set; }
        public DbSet<FS_RequirementSheet_Fabrics> FS_RequirementSheet_Fabrics { get; set; }
        public DbSet<FS_Fabric_Details> FS_Fabric_Details { get; set; }
        public DbSet<FS_SizeSet> FS_SizeSet { get; set; }
        public DbSet<FS_ColorSet> FS_ColorSet { get; set; }
        public DbSet<FabricTrims_Setup> FabricTrims_Setup { get; set; }
        public DbSet<FabricBooking> FabricBooking { get; set; }
        public DbSet<FabricBookingMaster> FabricBookingMaster { get; set; }
        public DbSet<FabricBookingDetail> FabricBookingDetail { get; set; }
        public DbSet<FabricBookingSizeDetail> FabricBookingSizeDetail { get; set; }
        public DbSet<KRS_MASTER> KRS_MASTER { get; set; }
        public DbSet<KRS_DETAIL> KRS_DETAIL { get; set; }
        public DbSet<KRS_Sizes> KRS_Sizes { get; set; }
        public DbSet<User_Setup> User_Setup { get; set; }
        public DbSet<IE_OrderEfficiency> IE_OrderEfficiency { get; set; }
        public DbSet<QRM_OrderSheetFabrics> QRM_OrderSheetFabrics { get; set; }
        public DbSet<InterOrderFabricTransfer> InterOrderFabricTransfer { get; set; }
        public DbSet<FabricAdjustmentTransferType> FabricAdjustmentTransferType { get; set; }
        //

        #region DB Views
        public DbSet<vw_OrderGarmentAssortmentOrder_Pantone> vw_OrderGarmentAssortmentOrder_Pantone { get; set; }
        #endregion DB Views

        #region DB Function
        //  public DbSet<fn_OrderSheetFirstAndLastVersion> fn_OrderSheetFirstAndLastVersion { get; set; }
        #endregion

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var auditEntries = OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await OnAfterSaveChanges(auditEntries);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MAC_CostingType>(entity =>
            {
                entity.ToTable("MAC_CostingType", "AJT");
            });
            modelBuilder.Entity<Vw_MAC_IndirectCostingItem>(entity =>
            {
                entity.ToTable("Vw_MAC_IndirectCostingItem", "AJT");
            });
            modelBuilder.Entity<MAC_OrderCostingInfo>(entity =>
            {
                entity.ToTable("MAC_OrderCostingInfo", "AJT");
            });
            modelBuilder.Entity<IE_OrderEfficiency>(entity =>
            {
                entity.ToTable("IE_OrderEfficiency", "AJT");
            });
            modelBuilder.Entity<FabricAdjustmentTransferType>(entity =>
            {
                entity.ToTable("FabricAdjustmentTransferType", "AJT");
            });
            
            modelBuilder.Entity<vw_OrderGarmentAssortmentOrder_Pantone>(entity =>
            {
                entity.ToTable("vw_OrderGarmentAssortmentOrder_Pantone", "AJT");
            });

            modelBuilder.Entity<MAC_OrderCostingInfo>()
                .HasQueryFilter(t => t.IsRemvoed == false);


            modelBuilder.Entity<MAC_AccessoriesCostingInfo>(entity =>
            {
                entity.ToTable("MAC_AccessoriesCostingInfo", "AJT");
                entity.HasOne(d => d.MAC_OrderCostingInfo)
                 .WithMany(p => p.MAC_AccessoriesCostingInfo)
                 .HasForeignKey(d => d.OrderCostingID)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK__MAC_Acces__Updat__2B7B9FD0");
            });
            modelBuilder.Entity<MAC_FabricCostingInfo>(entity =>
            {
                entity.ToTable("MAC_FabricCostingInfo", "AJT");

                entity.HasOne(d => d.MAC_OrderCostingInfo)
                 .WithMany(p => p.MAC_FabricCostingInfo)
                 .HasForeignKey(d => d.OrderCostingID)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK__MAC_Fabri__Updat__289F3325");
            });

            modelBuilder.Entity<MAC_FabricCostingInfo>()
             .HasQueryFilter(t => t.IsRemvoed == false);


            modelBuilder.Entity<MAC_IndirectCostingItem>(entity =>
            {
                entity.ToTable("MAC_OtherCostingItem", "AJT");
            });
            modelBuilder.Entity<MAC_IndirectCostingItem>()
                .HasQueryFilter(t => t.IsRemvoed == false);

            modelBuilder.Entity<AuditTrace>(entity =>
            {
                entity.ToTable("AuditTrace", "AJT");
            });
            modelBuilder.Entity<Mer_StyleMaster>(entity =>
            {
                entity.ToTable("Mer_StyleMaster", "ajt");
            });
            modelBuilder.Entity<Mer_StylePODetail>(entity =>
            {
                entity.ToTable("Mer_StylePODetail", "ajt");
            });
            modelBuilder.Entity<Mer_StylePOColorSizeQuantityDetail>(entity =>
            {
                entity.ToTable("Mer_StylePOColorSizeQuantityDetail", "ajt");
            });

            modelBuilder.Entity<MER_Zone>(entity =>
            {
                entity.ToTable("MER_Zone", "ajt");
            });

            modelBuilder.Entity<FabricBooking>(entity =>
            {
                entity.ToTable("FabricBooking", "ajt");
            });
            modelBuilder.Entity<FabricBookingMaster>(entity =>
            {
                entity.ToTable("FabricBookingMaster", "ajt");
            });
            modelBuilder.Entity<FabricBookingDetail>(entity =>
            {
                entity.ToTable("FabricBookingDetail", "ajt");
            });
            modelBuilder.Entity<FabricBookingSizeDetail>(entity =>
            {
                entity.ToTable("FabricBookingSizeDetail", "ajt");
            });
            modelBuilder.Entity<InterOrderFabricTransfer>(entity =>
            {
                entity.ToTable("InterOrderFabricTransfer", "ajt");
            });
            
            #region DB Function

            //modelBuilder.HasDbFunction(typeof(MaxcoDBContext).GetMethod(nameof(OrderSheetFirstAndLastVersion_fn), new[] { typeof(int), typeof(int) }))
            //    .HasName("fn_OrderSheetFirstAndLastVersion")
            //    .HasSchema("ajt");

            //modelBuilder.HasDbFunction(typeof(MaxcoDBContext).GetMethod(nameof(OrderSheetFirstAndLastVersion_fn), new[] { typeof(int), typeof(int) }))
            //    .HasName("fn_OrderSheetFirstAndLastVersion")
            //    .HasSchema("ajt");
            #endregion DB Function
        }




        #region Save Change
        private List<AuditTraceEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditTraceEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditTrace || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditTraceEntry(entry);
                auditEntry.TableName = entry.Metadata.Relational().TableName; // EF Core 3.1: entry.Metadata.GetTableName();
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    // The following condition is ok with EF Core 2.2 onwards.
                    // If you are using EF Core 2.1, you may need to change the following condition to support navigation properties: https://github.com/dotnet/efcore/issues/17700
                    // if (property.IsTemporary || (entry.State == EntityState.Added && property.Metadata.IsForeignKey()))
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            //  auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                AuditTrace.Add(auditEntry.ToAudit());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        private Task OnAfterSaveChanges(List<AuditTraceEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                // Save the Audit entry
                AuditTrace.Add(auditEntry.ToAudit());
            }

            return SaveChangesAsync();
        }

        #endregion


        #region sql function
        //public fn_OrderSheetFirstAndLastVersion OrderSheetFirstAndLastVersion_fn(int OrderID, int BuyerID)
        // => throw new NotSupportedException();

        #endregion 
    }



}