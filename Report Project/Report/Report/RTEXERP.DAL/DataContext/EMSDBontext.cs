using Microsoft.EntityFrameworkCore;
using RTEXERP.DBEntities.EMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DAL.DataContext
{
    public partial class EMSDBContext : DbContext
    {

      
        public EMSDBContext(DbContextOptions<EMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BarcodeStatus> BarcodeStatus { get; set; }
        public virtual DbSet<BlisterAssortmentMain> BlisterAssortmentMain { get; set; }
        public virtual DbSet<BlisterPacked> BlisterPacked { get; set; }
        public virtual DbSet<CartonDimensionSetup> CartonDimensionSetup { get; set; }
        public virtual DbSet<CartonIssuanceDetail> CartonIssuanceDetail { get; set; }
        public virtual DbSet<CartonPacked> CartonPacked { get; set; }
        public virtual DbSet<CartonReceivingDetail> CartonReceivingDetail { get; set; }
        public virtual DbSet<CountryInformation> CountryInformation { get; set; }
        public virtual DbSet<CountrySetup> CountrySetup { get; set; }
        public virtual DbSet<EmPcdPackingCartonDetail> EmPcdPackingCartonDetail { get; set; }
        public virtual DbSet<EmPcdPackingCartonDetailCustom> EmPcdPackingCartonDetailCustom { get; set; }
        public virtual DbSet<EmPdPackingDetail> EmPdPackingDetail { get; set; }
        public virtual DbSet<EmPdPackingDetailCustom> EmPdPackingDetailCustom { get; set; }
        public virtual DbSet<EmPidComercialinvoiceDetail> EmPidComercialinvoiceDetail { get; set; }
        public virtual DbSet<EmPidComercialinvoiceDetailCustom> EmPidComercialinvoiceDetailCustom { get; set; }
        public virtual DbSet<EmPidPackinginvoiceDetail> EmPidPackinginvoiceDetail { get; set; }
        public virtual DbSet<EmPidPackinginvoiceDetailCustom> EmPidPackinginvoiceDetailCustom { get; set; }
        public virtual DbSet<EmPimPackinginvoiceClosure> EmPimPackinginvoiceClosure { get; set; }
        public virtual DbSet<EmPimPackinginvoiceMaster> EmPimPackinginvoiceMaster { get; set; }
        public virtual DbSet<EmPimPackinginvoiceMasterCustom> EmPimPackinginvoiceMasterCustom { get; set; }
        public virtual DbSet<EmPimcComercialinvoiceMaster> EmPimcComercialinvoiceMaster { get; set; }
        public virtual DbSet<EmPimcComercialinvoiceMasterCustom> EmPimcComercialinvoiceMasterCustom { get; set; }
        public virtual DbSet<EmPmPackingMaster> EmPmPackingMaster { get; set; }
        public virtual DbSet<EmPmPackingMasterCustom> EmPmPackingMasterCustom { get; set; }
        public virtual DbSet<GarmentReceivingDetail> GarmentReceivingDetail { get; set; }
        public virtual DbSet<GarmentReceivingMain> GarmentReceivingMain { get; set; }
        public virtual DbSet<GenerateBarcode> GenerateBarcode { get; set; }
        public virtual DbSet<GrLpLinkPages> GrLpLinkPages { get; set; }
        public virtual DbSet<GrMlModuleLinks> GrMlModuleLinks { get; set; }
        public virtual DbSet<GrMsModuleSetup> GrMsModuleSetup { get; set; }
        public virtual DbSet<GrPsPageSetup> GrPsPageSetup { get; set; }
        public virtual DbSet<GrRlRelatedLinks> GrRlRelatedLinks { get; set; }
        public virtual DbSet<GrUsUserSetup> GrUsUserSetup { get; set; }
        public virtual DbSet<MasterPolyBagDimension> MasterPolyBagDimension { get; set; }
        public virtual DbSet<OrderShipment> OrderShipment { get; set; }
        public virtual DbSet<OrderSpecification> OrderSpecification { get; set; }
        public virtual DbSet<PackingAssortmentDetail> PackingAssortmentDetail { get; set; }
        public virtual DbSet<PackingAssortmentMain> PackingAssortmentMain { get; set; }
        public virtual DbSet<PackingAssortmentMasterDetail> PackingAssortmentMasterDetail { get; set; }
        public virtual DbSet<PkSizeWeights> PkSizeWeights { get; set; }
        public virtual DbSet<PkSizeWeightsCustom> PkSizeWeightsCustom { get; set; }
        public virtual DbSet<PoassortmentDetail> PoassortmentDetail { get; set; }
        public virtual DbSet<Porefrence> Porefrence { get; set; }
        public virtual DbSet<Posizes> Posizes { get; set; }
        public virtual DbSet<ScGsGroupSetup> ScGsGroupSetup { get; set; }
        public virtual DbSet<ScPtPermissionTypes> ScPtPermissionTypes { get; set; }
        public virtual DbSet<ScUgUserGroup> ScUgUserGroup { get; set; }
        public virtual DbSet<ScUgmUsergroupLinks> ScUgmUsergroupLinks { get; set; }
        public virtual DbSet<ScUgmUsergroupModules> ScUgmUsergroupModules { get; set; }
        public virtual DbSet<TblFdbpPeriodAssociation> TblFdbpPeriodAssociation { get; set; }
        public virtual DbSet<TblFdbpRealizationDetail1> TblFdbpRealizationDetail1 { get; set; }
        public virtual DbSet<TblFdbpRealizationMaster> TblFdbpRealizationMaster { get; set; }
        public virtual DbSet<TblFdbpRealized> TblFdbpRealized { get; set; }
        public virtual DbSet<TblOrdershipmentstatusOfs> TblOrdershipmentstatusOfs { get; set; }
        public virtual DbSet<TblPeriod> TblPeriod { get; set; }
        public virtual DbSet<FCR_InvoiceOrderMapping> FCR_InvoiceOrderMapping { get; set; }

        // Unable to generate entity type for table 'dbo.TBL_ORDERSTATUS'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EM_PCD_Shipdate'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ShippingInspectionAgency'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ShippingMark'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ShippingPaymentTerm'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_FDBP_Realization_Detail_'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_FDBP_Item_setup'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_ExportCache'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TBL_ORDERCLOSURESTATUS_OFS'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_FDBP_InvoiceMAP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CartonIssuanceMain'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_FDBP_Document_Main'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TBL_FDBP_Document_Detail'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CartonReceivingMain'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_FDBP_Document_Purchase'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_Invoice_Entry'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.FDBP_Log'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.InvoiceOutstanding_Log'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ordershipment_bk'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.OrderShipment_BK28thSep2013'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.POAssortmentDetail_BK9thSep2013'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.OrderShippingCity'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.OrderShippingCountry'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PayrollAnalysis'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tbl_HNMInvoices'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PayrollAnalysis_Bk1stMay2016'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.BlisterAssortmentDetail'. Please see the warning messages.



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<BarcodeStatus>(entity =>
            {
                entity.ToTable("Barcode_Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BlisterAssortmentMain>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssortmentDate).HasColumnType("datetime");

                entity.Property(e => e.MasterPolyId).HasColumnName("MasterPolyID");

                entity.Property(e => e.Poid).HasColumnName("POID");

                entity.Property(e => e.StyleId).HasColumnName("StyleID");
            });

            modelBuilder.Entity<BlisterPacked>(entity =>
            {
                entity.ToTable("Blister_Packed");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BlisterId).HasColumnName("BlisterID");

                entity.Property(e => e.CartonId).HasColumnName("CartonID");

                entity.Property(e => e.PackingDate).HasColumnType("datetime");

                entity.Property(e => e.Poid).HasColumnName("POID");
            });

            modelBuilder.Entity<CartonDimensionSetup>(entity =>
            {
                entity.ToTable("CartonDimension_Setup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CartonIssuanceDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CartonId).HasColumnName("CartonID");

                entity.Property(e => e.Isid).HasColumnName("ISID");

                entity.Property(e => e.Poid).HasColumnName("POID");
            });

            modelBuilder.Entity<CartonPacked>(entity =>
            {
                entity.ToTable("Carton_Packed");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CartonId).HasColumnName("CartonID");

                entity.Property(e => e.PackingDate).HasColumnType("datetime");

                entity.Property(e => e.Poid).HasColumnName("POID");
            });

            modelBuilder.Entity<CartonReceivingDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CartonId).HasColumnName("CartonID");

                entity.Property(e => e.Poid).HasColumnName("POID");

                entity.Property(e => e.Rid).HasColumnName("RID");
            });

            modelBuilder.Entity<CountryInformation>(entity =>
            {
                entity.ToTable("Country_Information");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bid).HasColumnName("BID");

                entity.Property(e => e.BuyerAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BuyerName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.Consignee)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ConsigneeBank)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryPort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryTerms)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Deliveryto)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DischargePort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DistPort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoadingPort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingMark)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CountrySetup>(entity =>
            {
                entity.ToTable("Country_Setup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmPcdPackingCartonDetail>(entity =>
            {
                entity.HasKey(e => e.EpcdId)
                    .HasName("PK_EM_PCD_PACKINGCARTONDETAIL");

                entity.ToTable("EM_PCD_PACKING_CARTON_DETAIL");

                entity.HasIndex(e => new { e.EpcdEpmId, e.EpcdEpdId, e.EpcdCartonId, e.EpcdColorId, e.EpcdSizeId })
                    .HasName("IND_EM_PCD_PACKING_CARTON_DETAIL1");

                entity.Property(e => e.EpcdId).HasColumnName("EPCD_ID");

                entity.Property(e => e.EpcdCartonId).HasColumnName("EPCD_CARTON_ID");

                entity.Property(e => e.EpcdColorId).HasColumnName("EPCD_COLOR_ID");

                entity.Property(e => e.EpcdEpdId).HasColumnName("EPCD_EPD_ID");

                entity.Property(e => e.EpcdEpmId).HasColumnName("EPCD_EPM_ID");

                entity.Property(e => e.EpcdGarments).HasColumnName("EPCD_GARMENTS");

                entity.Property(e => e.EpcdSizeId).HasColumnName("EPCD_SIZE_ID");
            });

            modelBuilder.Entity<EmPcdPackingCartonDetailCustom>(entity =>
            {
                entity.HasKey(e => e.EpcdId)
                    .HasName("PK_EM_PCD_PACKINGCARTONDETAIL_CUSTOM");

                entity.ToTable("EM_PCD_PACKING_CARTON_DETAIL_CUSTOM");

                entity.HasIndex(e => new { e.EpcdEpmId, e.EpcdEpdId, e.EpcdColorId, e.EpcdSizeId })
                    .HasName("Ind_EM_PCD_PACKING_CARTON_DETAIL_CUSTOM_1");

                entity.Property(e => e.EpcdId).HasColumnName("EPCD_ID");

                entity.Property(e => e.EpcdCartonId).HasColumnName("EPCD_CARTON_ID");

                entity.Property(e => e.EpcdColorId).HasColumnName("EPCD_COLOR_ID");

                entity.Property(e => e.EpcdEpdId).HasColumnName("EPCD_EPD_ID");

                entity.Property(e => e.EpcdEpmId).HasColumnName("EPCD_EPM_ID");

                entity.Property(e => e.EpcdGarments).HasColumnName("EPCD_GARMENTS");

                entity.Property(e => e.EpcdSizeId).HasColumnName("EPCD_SIZE_ID");
            });

            modelBuilder.Entity<EmPdPackingDetail>(entity =>
            {
                entity.HasKey(e => e.EpdId);

                entity.ToTable("EM_PD_PACKING_DETAIL");

                entity.HasIndex(e => new { e.EpdEpmId, e.EpdCartonId })
                    .HasName("Ind_EM_PD_PACKING_DETAIL_1");

                entity.Property(e => e.EpdId).HasColumnName("EPD_ID");

                entity.Property(e => e.EpdCartonId).HasColumnName("EPD_CARTON_ID");

                entity.Property(e => e.EpdCartonNo)
                    .HasColumnName("EPD_CARTON_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EpdEpmId).HasColumnName("EPD_EPM_ID");
            });

            modelBuilder.Entity<EmPdPackingDetailCustom>(entity =>
            {
                entity.HasKey(e => e.EpdId);

                entity.ToTable("EM_PD_PACKING_DETAIL_CUSTOM");

                entity.Property(e => e.EpdId).HasColumnName("EPD_ID");

                entity.Property(e => e.EpdCartonId).HasColumnName("EPD_CARTON_ID");

                entity.Property(e => e.EpdCartonNo)
                    .HasColumnName("EPD_CARTON_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EpdEpmId).HasColumnName("EPD_EPM_ID");
            });

            modelBuilder.Entity<EmPidComercialinvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.EpidId);

                entity.ToTable("EM_PID_COMERCIALINVOICE_DETAIL");

                entity.Property(e => e.EpidId).HasColumnName("EPID_ID");

                entity.Property(e => e.EpidEpmId).HasColumnName("EPID_EPM_ID");

                entity.Property(e => e.EpidInvId).HasColumnName("EPID_INV_ID");
            });

            modelBuilder.Entity<EmPidComercialinvoiceDetailCustom>(entity =>
            {
                entity.HasKey(e => e.EpidId);

                entity.ToTable("EM_PID_COMERCIALINVOICE_DETAIL_CUSTOM");

                entity.Property(e => e.EpidId).HasColumnName("EPID_ID");

                entity.Property(e => e.EpidEpmId).HasColumnName("EPID_EPM_ID");

                entity.Property(e => e.EpidInvId).HasColumnName("EPID_INV_ID");
            });

            modelBuilder.Entity<EmPidPackinginvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.EpidId);

                entity.ToTable("EM_PID_PACKINGINVOICE_DETAIL");

                entity.HasIndex(e => new { e.EpidEpmId, e.EpidPklId })
                    .HasName("IND_EM_PID_PACKINGINVOICE_DETAIL_1");

                entity.Property(e => e.EpidId).HasColumnName("EPID_ID");

                entity.Property(e => e.EpidEpmId).HasColumnName("EPID_EPM_ID");

                entity.Property(e => e.EpidPklId).HasColumnName("EPID_PKL_ID");
            });

            modelBuilder.Entity<EmPidPackinginvoiceDetailCustom>(entity =>
            {
                entity.HasKey(e => e.EpidId);

                entity.ToTable("EM_PID_PACKINGINVOICE_DETAIL_CUSTOM");

                entity.Property(e => e.EpidId).HasColumnName("EPID_ID");

                entity.Property(e => e.EpidEpmId).HasColumnName("EPID_EPM_ID");

                entity.Property(e => e.EpidPklId).HasColumnName("EPID_PKL_ID");
            });

            modelBuilder.Entity<EmPimPackinginvoiceClosure>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.ToTable("EM_PIM_PACKINGINVOICE_CLOSURE");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClosureBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClosureDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<EmPimPackinginvoiceMaster>(entity =>
            {
                entity.HasKey(e => e.EpimId);

                entity.ToTable("EM_PIM_PACKINGINVOICE_MASTER");

                entity.HasIndex(e => new { e.EpimCompanyid, e.EpimBuyerid, e.EpimLcno, e.EpimInvoiceno })
                    .HasName("IND_EM_PIM_PACKAGINGINVOICE_MASTE_1");

                entity.Property(e => e.EpimId)
                    .HasColumnName("EPIM_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmPimBuyersubmissiondate)
                    .HasColumnName("EM_PIM_BUYERSUBMISSIONDATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EpimAmount)
                    .HasColumnName("EPIM_AMOUNT")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpimAvgPrice)
                    .HasColumnName("EPIM_AVG_PRICE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpimBaccountid).HasColumnName("EPIM_BACCOUNTID");

                entity.Property(e => e.EpimBankname).HasColumnName("EPIM_BANKNAME");

                entity.Property(e => e.EpimBuyerid).HasColumnName("EPIM_BUYERID");

                entity.Property(e => e.EpimCompanyid).HasColumnName("EPIM_COMPANYID");

                entity.Property(e => e.EpimContainerNo)
                    .HasColumnName("EPIM_ContainerNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EpimDate)
                    .HasColumnName("EPIM_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimExfactorydate)
                    .HasColumnName("EPIM_EXFACTORYDATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EpimExportdate)
                    .HasColumnName("EPIM_EXPORTDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimExportno)
                    .HasColumnName("EPIM_EXPORTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimFcrdate)
                    .HasColumnName("EPIM_FCRDate")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(CONVERT([varchar](10),getdate(),(101)))");

                entity.Property(e => e.EpimFcrnumber)
                    .HasColumnName("EPIM_FCRNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EpimFlightno)
                    .HasColumnName("EPIM_FLIGHTNO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EpimInvoicedate)
                    .HasColumnName("EPIM_INVOICEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimInvoiceno)
                    .HasColumnName("EPIM_INVOICENO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimInvoiceunit)
                    .HasColumnName("EPIM_INVOICEUNIT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('PC(s)')");

                entity.Property(e => e.EpimIsdeleted).HasColumnName("EPIM_ISDELETED");

                entity.Property(e => e.EpimIsedited).HasColumnName("EPIM_ISEDITED");

                entity.Property(e => e.EpimLcdate)
                    .HasColumnName("EPIM_LCDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimLcno).HasColumnName("EPIM_LCNO");

                entity.Property(e => e.EpimNo)
                    .HasColumnName("EPIM_NO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimQuantity)
                    .HasColumnName("EPIM_Quantity")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EpimSailingdate)
                    .HasColumnName("EPIM_SAILINGDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimShipedfrom)
                    .HasColumnName("EPIM_SHIPEDFROM")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimShipedto)
                    .HasColumnName("EPIM_SHIPEDTO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimShippingBillDate)
                    .HasColumnName("EPIM_ShippingBillDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EpimShippingBillNo)
                    .HasColumnName("EPIM_ShippingBillNo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EpimStatus).HasColumnName("EPIM_STATUS");
            });

            modelBuilder.Entity<EmPimPackinginvoiceMasterCustom>(entity =>
            {
                entity.HasKey(e => e.EpimId);

                entity.ToTable("EM_PIM_PACKINGINVOICE_MASTER_CUSTOM");

                entity.Property(e => e.EpimId)
                    .HasColumnName("EPIM_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EpimAmount)
                    .HasColumnName("EPIM_AMOUNT")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpimAvgPrice)
                    .HasColumnName("EPIM_AVG_PRICE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpimBaccountid).HasColumnName("EPIM_BACCOUNTID");

                entity.Property(e => e.EpimBankname).HasColumnName("EPIM_BANKNAME");

                entity.Property(e => e.EpimBuyerid).HasColumnName("EPIM_BUYERID");

                entity.Property(e => e.EpimCompanyid).HasColumnName("EPIM_COMPANYID");

                entity.Property(e => e.EpimContainerNo)
                    .HasColumnName("EPIM_ContainerNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EpimDate)
                    .HasColumnName("EPIM_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimExportdate)
                    .HasColumnName("EPIM_EXPORTDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimExportno)
                    .HasColumnName("EPIM_EXPORTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimFlightno)
                    .HasColumnName("EPIM_FLIGHTNO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EpimInvoicedate)
                    .HasColumnName("EPIM_INVOICEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimInvoiceno)
                    .HasColumnName("EPIM_INVOICENO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimIsdeleted).HasColumnName("EPIM_ISDELETED");

                entity.Property(e => e.EpimIsedited).HasColumnName("EPIM_ISEDITED");

                entity.Property(e => e.EpimLcdate)
                    .HasColumnName("EPIM_LCDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimLcno).HasColumnName("EPIM_LCNO");

                entity.Property(e => e.EpimNo)
                    .HasColumnName("EPIM_NO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimSailingdate)
                    .HasColumnName("EPIM_SAILINGDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimShipedfrom)
                    .HasColumnName("EPIM_SHIPEDFROM")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimShipedto)
                    .HasColumnName("EPIM_SHIPEDTO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimStatus).HasColumnName("EPIM_STATUS");
            });

            modelBuilder.Entity<EmPimcComercialinvoiceMaster>(entity =>
            {
                entity.HasKey(e => e.EpimId);

                entity.ToTable("EM_PIMC_COMERCIALINVOICE_MASTER");

                entity.Property(e => e.EpimId)
                    .HasColumnName("EPIM_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EpimAmount)
                    .HasColumnName("EPIM_AMOUNT")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpimAvgPrice)
                    .HasColumnName("EPIM_AVG_PRICE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpimBaccountid).HasColumnName("EPIM_BACCOUNTID");

                entity.Property(e => e.EpimBankname).HasColumnName("EPIM_BANKNAME");

                entity.Property(e => e.EpimBuyerid).HasColumnName("EPIM_BUYERID");

                entity.Property(e => e.EpimCompanyid).HasColumnName("EPIM_COMPANYID");

                entity.Property(e => e.EpimContainerNo)
                    .HasColumnName("EPIM_ContainerNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EpimDate)
                    .HasColumnName("EPIM_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimExportdate)
                    .HasColumnName("EPIM_EXPORTDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimExportno)
                    .HasColumnName("EPIM_EXPORTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimFlightno)
                    .HasColumnName("EPIM_FLIGHTNO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EpimInvoicedate)
                    .HasColumnName("EPIM_INVOICEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimInvoiceno)
                    .HasColumnName("EPIM_INVOICENO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimLcdate)
                    .HasColumnName("EPIM_LCDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimLcno).HasColumnName("EPIM_LCNO");

                entity.Property(e => e.EpimNo)
                    .HasColumnName("EPIM_NO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimSailingdate)
                    .HasColumnName("EPIM_SAILINGDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimShipedfrom)
                    .HasColumnName("EPIM_SHIPEDFROM")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimShipedto)
                    .HasColumnName("EPIM_SHIPEDTO")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmPimcComercialinvoiceMasterCustom>(entity =>
            {
                entity.HasKey(e => e.EpimId);

                entity.ToTable("EM_PIMC_COMERCIALINVOICE_MASTER_CUSTOM");

                entity.Property(e => e.EpimId)
                    .HasColumnName("EPIM_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EpimAmount)
                    .HasColumnName("EPIM_AMOUNT")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpimAvgPrice)
                    .HasColumnName("EPIM_AVG_PRICE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpimBaccountid).HasColumnName("EPIM_BACCOUNTID");

                entity.Property(e => e.EpimBankname).HasColumnName("EPIM_BANKNAME");

                entity.Property(e => e.EpimBuyerid).HasColumnName("EPIM_BUYERID");

                entity.Property(e => e.EpimCompanyid).HasColumnName("EPIM_COMPANYID");

                entity.Property(e => e.EpimContainerNo)
                    .HasColumnName("EPIM_ContainerNo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EpimDate)
                    .HasColumnName("EPIM_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimExportdate)
                    .HasColumnName("EPIM_EXPORTDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimExportno)
                    .HasColumnName("EPIM_EXPORTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimFlightno)
                    .HasColumnName("EPIM_FLIGHTNO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EpimInvoicedate)
                    .HasColumnName("EPIM_INVOICEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimInvoiceno)
                    .HasColumnName("EPIM_INVOICENO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimLcdate)
                    .HasColumnName("EPIM_LCDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimLcno).HasColumnName("EPIM_LCNO");

                entity.Property(e => e.EpimNo)
                    .HasColumnName("EPIM_NO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimSailingdate)
                    .HasColumnName("EPIM_SAILINGDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpimShipedfrom)
                    .HasColumnName("EPIM_SHIPEDFROM")
                    .HasMaxLength(50);

                entity.Property(e => e.EpimShipedto)
                    .HasColumnName("EPIM_SHIPEDTO")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmPmPackingMaster>(entity =>
            {
                entity.HasKey(e => e.EpmId)
                    .HasName("PK_EM_PM_PACKING_MASTER_1");

                entity.ToTable("EM_PM_PACKING_MASTER");

                entity.Property(e => e.EpmId)
                    .HasColumnName("EPM_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EpmBankname).HasColumnName("EPM_BANKNAME");

                entity.Property(e => e.EpmBuyerid).HasColumnName("EPM_BUYERID");

                entity.Property(e => e.EpmCompanyid).HasColumnName("EPM_COMPANYID");

                entity.Property(e => e.EpmCountryorigin)
                    .HasColumnName("EPM_COUNTRYORIGIN")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmDate)
                    .HasColumnName("EPM_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpmDestination)
                    .HasColumnName("EPM_DESTINATION")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmInvoicedate)
                    .HasColumnName("EPM_INVOICEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpmInvoiceno)
                    .HasColumnName("EPM_INVOICENO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmLcdate)
                    .HasColumnName("EPM_LCDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpmLcno).HasColumnName("EPM_LCNO");

                entity.Property(e => e.EpmNetcartonweight)
                    .HasColumnName("EPM_NETCARTONWEIGHT")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpmNetweight)
                    .HasColumnName("EPM_NETWEIGHT")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpmNo)
                    .HasColumnName("EPM_NO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmShipmentmode)
                    .HasColumnName("EPM_SHIPMENTMODE")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmShippedfrom)
                    .HasColumnName("EPM_SHIPPEDFROM")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmShippedto)
                    .HasColumnName("EPM_SHIPPEDTO")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmPmPackingMasterCustom>(entity =>
            {
                entity.HasKey(e => e.EpmId)
                    .HasName("PK_EM_PM_PACKING_MASTER_CUSTOM_1");

                entity.ToTable("EM_PM_PACKING_MASTER_CUSTOM");

                entity.Property(e => e.EpmId)
                    .HasColumnName("EPM_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EpmBankname).HasColumnName("EPM_BANKNAME");

                entity.Property(e => e.EpmBuyerid).HasColumnName("EPM_BUYERID");

                entity.Property(e => e.EpmCompanyid).HasColumnName("EPM_COMPANYID");

                entity.Property(e => e.EpmCountryorigin)
                    .HasColumnName("EPM_COUNTRYORIGIN")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmDate)
                    .HasColumnName("EPM_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpmDestination)
                    .HasColumnName("EPM_DESTINATION")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmInvoicedate)
                    .HasColumnName("EPM_INVOICEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpmInvoiceno)
                    .HasColumnName("EPM_INVOICENO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmLcdate)
                    .HasColumnName("EPM_LCDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EpmLcno).HasColumnName("EPM_LCNO");

                entity.Property(e => e.EpmNetcartonweight)
                    .HasColumnName("EPM_NETCARTONWEIGHT")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpmNetweight)
                    .HasColumnName("EPM_NETWEIGHT")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EpmNo)
                    .HasColumnName("EPM_NO")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmShipmentmode)
                    .HasColumnName("EPM_SHIPMENTMODE")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmShippedfrom)
                    .HasColumnName("EPM_SHIPPEDFROM")
                    .HasMaxLength(50);

                entity.Property(e => e.EpmShippedto)
                    .HasColumnName("EPM_SHIPPEDTO")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GarmentReceivingDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.RecId).HasColumnName("RecID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");
            });

            modelBuilder.Entity<GarmentReceivingMain>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PackingAreaId).HasColumnName("PackingAreaID");

                entity.Property(e => e.Poid).HasColumnName("POID");

                entity.Property(e => e.RecChallan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecDate).HasColumnType("datetime");

                entity.Property(e => e.RecNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GenerateBarcode>(entity =>
            {
                entity.ToTable("Generate_Barcode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BlisterId).HasColumnName("BlisterID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.ColorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Poid).HasColumnName("POID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GrLpLinkPages>(entity =>
            {
                entity.HasKey(e => e.GlpId)
                    .HasName("PK_GR_LP_LINK_PAGES_1");

                entity.ToTable("GR_LP_LINK_PAGES");

                entity.Property(e => e.GlpId).HasColumnName("GLP_ID");

                entity.Property(e => e.GlpHome)
                    .HasColumnName("GLP_HOME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GmlId).HasColumnName("GML_ID");

                entity.Property(e => e.SpsId).HasColumnName("SPS_ID");

                entity.HasOne(d => d.Gml)
                    .WithMany(p => p.GrLpLinkPages)
                    .HasForeignKey(d => d.GmlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GR_LP_LINK_PAGES_GR_ML_MODULE_LINKS");

                entity.HasOne(d => d.Sps)
                    .WithMany(p => p.GrLpLinkPages)
                    .HasForeignKey(d => d.SpsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GR_LP_LINK_PAGES_GR_PS_PAGE_SETUP");
            });

            modelBuilder.Entity<GrMlModuleLinks>(entity =>
            {
                entity.HasKey(e => e.GmlId);

                entity.ToTable("GR_ML_MODULE_LINKS");

                entity.Property(e => e.GmlId).HasColumnName("GML_ID");

                entity.Property(e => e.GmlActive).HasColumnName("GML_ACTIVE");

                entity.Property(e => e.GmlDasParenttable)
                    .HasColumnName("GML_DAS_PARENTTABLE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GmlDesc)
                    .IsRequired()
                    .HasColumnName("GML_DESC")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GmlDocreportlink)
                    .HasColumnName("GML_DOCREPORTLINK")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GmlIsapprovaldoc).HasColumnName("GML_ISAPPROVALDOC");

                entity.Property(e => e.GmlIsworkflow).HasColumnName("GML_ISWORKFLOW");

                entity.Property(e => e.GmlLevel).HasColumnName("GML_LEVEL");

                entity.Property(e => e.GmlName)
                    .IsRequired()
                    .HasColumnName("GML_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GmlParentid).HasColumnName("GML_PARENTID");

                entity.Property(e => e.GmsId).HasColumnName("GMS_ID");

                entity.HasOne(d => d.Gms)
                    .WithMany(p => p.GrMlModuleLinks)
                    .HasForeignKey(d => d.GmsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GR_ML_MODULE_LINKS_GR_MS_MODULE_SETUP");
            });

            modelBuilder.Entity<GrMsModuleSetup>(entity =>
            {
                entity.HasKey(e => e.GmsId);

                entity.ToTable("GR_MS_MODULE_SETUP");

                entity.Property(e => e.GmsId).HasColumnName("GMS_ID");

                entity.Property(e => e.GmsActive).HasColumnName("GMS_ACTIVE");

                entity.Property(e => e.GmsDesc)
                    .HasColumnName("GMS_DESC")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GmsName)
                    .HasColumnName("GMS_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GmsPath)
                    .HasColumnName("GMS_PATH")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GrPsPageSetup>(entity =>
            {
                entity.HasKey(e => e.SpsId);

                entity.ToTable("GR_PS_PAGE_SETUP");

                entity.Property(e => e.SpsId).HasColumnName("SPS_ID");

                entity.Property(e => e.SpsDesc)
                    .IsRequired()
                    .HasColumnName("SPS_DESC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpsIsactive).HasColumnName("SPS_ISACTIVE");

                entity.Property(e => e.SpsName)
                    .IsRequired()
                    .HasColumnName("SPS_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpsPath)
                    .IsRequired()
                    .HasColumnName("SPS_PATH")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GrRlRelatedLinks>(entity =>
            {
                entity.HasKey(e => e.GrlId);

                entity.ToTable("GR_RL_RELATED_LINKS");

                entity.Property(e => e.GrlId)
                    .HasColumnName("GRL_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GrlParentGmlid).HasColumnName("GRL_PARENT_GMLID");

                entity.Property(e => e.GrlRelatedGmlid).HasColumnName("GRL_RELATED_GMLID");

                entity.Property(e => e.GrlRelationlevel).HasColumnName("GRL_RELATIONLEVEL");

                entity.Property(e => e.GrlSequence).HasColumnName("GRL_SEQUENCE");

                entity.HasOne(d => d.GrlParentGml)
                    .WithMany(p => p.GrRlRelatedLinksGrlParentGml)
                    .HasForeignKey(d => d.GrlParentGmlid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GR_RL_RELATED_LINKS_GR_ML_MODULE_LINKS");

                entity.HasOne(d => d.GrlRelatedGml)
                    .WithMany(p => p.GrRlRelatedLinksGrlRelatedGml)
                    .HasForeignKey(d => d.GrlRelatedGmlid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GR_RL_RELATED_LINKS_GR_ML_MODULE_LINKS1");
            });

            modelBuilder.Entity<GrUsUserSetup>(entity =>
            {
                entity.HasKey(e => e.GusId);

                entity.ToTable("GR_US_USER_SETUP");

                entity.Property(e => e.GusId).HasColumnName("GUS_ID");

                entity.Property(e => e.GusDesc)
                    .IsRequired()
                    .HasColumnName("GUS_DESC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GusName)
                    .IsRequired()
                    .HasColumnName("GUS_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GusPass)
                    .IsRequired()
                    .HasColumnName("GUS_PASS")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasterPolyBagDimension>(entity =>
            {
                entity.ToTable("MasterPolyBag_Dimension");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dimension)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderShipment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

                entity.Property(e => e.Catagory)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Consignee)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ConsigneeBank)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryPort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryTo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InspectionDate).HasColumnType("datetime");

                entity.Property(e => e.LoadingPort)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Poid).HasColumnName("POID");

                entity.Property(e => e.ShipmentDate).HasColumnType("datetime");

                entity.Property(e => e.ShippingMark)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeriffCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Warehouse)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderSpecification>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BuyerRef)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConstructionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OptionNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Season)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SuppCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SuppName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PackingAssortmentDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.PackingAssortmentId).HasColumnName("PackingAssortmentID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");
            });

            modelBuilder.Entity<PackingAssortmentMain>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CartonNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CartoonId).HasColumnName("CartoonID");

                entity.Property(e => e.PackingDate).HasColumnType("datetime");

                entity.Property(e => e.Poid).HasColumnName("POID");
            });

            modelBuilder.Entity<PackingAssortmentMasterDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BlisterId).HasColumnName("BlisterID");

                entity.Property(e => e.PackingAssortmentId).HasColumnName("PackingAssortmentID");
            });

            modelBuilder.Entity<PkSizeWeights>(entity =>
            {
                entity.ToTable("PK_SIZE_WEIGHTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EpmId).HasColumnName("EPM_ID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StyleId).HasColumnName("StyleID");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<PkSizeWeightsCustom>(entity =>
            {
                entity.ToTable("PK_SIZE_WEIGHTS_CUSTOM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EpmId).HasColumnName("EPM_ID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StyleId).HasColumnName("StyleID");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<PoassortmentDetail>(entity =>
            {
                entity.ToTable("POAssortmentDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColorSetId).HasColumnName("ColorSetID");

                entity.Property(e => e.PackingTypeId).HasColumnName("PackingTypeID");

                entity.Property(e => e.Poid).HasColumnName("POID");

                entity.Property(e => e.SizeSetId).HasColumnName("SizeSetID");
            });

            modelBuilder.Entity<Porefrence>(entity =>
            {
                entity.HasKey(e => e.Poid)
                    .HasName("PK_OrderPORefrence");

                entity.ToTable("PORefrence");

                entity.Property(e => e.Poid).HasColumnName("POID");

                entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EditPodate)
                    .HasColumnName("EditPODate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Podate)
                    .HasColumnName("PODate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pono)
                    .HasColumnName("PONo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StyleId).HasColumnName("StyleID");
            });

            modelBuilder.Entity<Posizes>(entity =>
            {
                entity.ToTable("POSizes");

                entity.HasIndex(e => new { e.Poid, e.SizeId })
                    .HasName("NonClusteredIndex-20180131-201756");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Poid).HasColumnName("POID");

                entity.Property(e => e.PosizePrice).HasColumnName("POSizePrice");

                entity.Property(e => e.PrepareDate).HasColumnType("datetime");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScGsGroupSetup>(entity =>
            {
                entity.HasKey(e => e.SgsId)
                    .HasName("PK_SC_UG_USER_GROUP");

                entity.ToTable("SC_GS_GROUP_SETUP");

                entity.Property(e => e.SgsId).HasColumnName("SGS_ID");

                entity.Property(e => e.SugName)
                    .IsRequired()
                    .HasColumnName("SUG_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScPtPermissionTypes>(entity =>
            {
                entity.HasKey(e => e.PtId);

                entity.ToTable("SC_PT_PERMISSION_TYPES");

                entity.Property(e => e.PtId).HasColumnName("PT_ID");

                entity.Property(e => e.PtName)
                    .IsRequired()
                    .HasColumnName("PT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScUgUserGroup>(entity =>
            {
                entity.HasKey(e => e.SugId)
                    .HasName("PK_SC_UG_USER_GROUP_1");

                entity.ToTable("SC_UG_USER_GROUP");

                entity.Property(e => e.SugId).HasColumnName("SUG_ID");

                entity.Property(e => e.GusId).HasColumnName("GUS_ID");

                entity.Property(e => e.SgsId).HasColumnName("SGS_ID");

                entity.HasOne(d => d.Gus)
                    .WithMany(p => p.ScUgUserGroup)
                    .HasForeignKey(d => d.GusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SC_UG_USER_GROUP_GR_US_USER_SETUP");

                entity.HasOne(d => d.Sgs)
                    .WithMany(p => p.ScUgUserGroup)
                    .HasForeignKey(d => d.SgsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SC_UG_USER_GROUP_SC_GS_GROUP_SETUP");
            });

            modelBuilder.Entity<ScUgmUsergroupLinks>(entity =>
            {
                entity.HasKey(e => e.SugmId);

                entity.ToTable("SC_UGM_USERGROUP_LINKS");

                entity.Property(e => e.SugmId).HasColumnName("SUGM_ID");

                entity.Property(e => e.GmlId).HasColumnName("GML_ID");

                entity.Property(e => e.PtId).HasColumnName("PT_ID");

                entity.Property(e => e.SgsId).HasColumnName("SGS_ID");

                entity.HasOne(d => d.Gml)
                    .WithMany(p => p.ScUgmUsergroupLinks)
                    .HasForeignKey(d => d.GmlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SC_UGM_USERGROUP_LINKS_GR_ML_MODULE_LINKS");

                entity.HasOne(d => d.Sgs)
                    .WithMany(p => p.ScUgmUsergroupLinks)
                    .HasForeignKey(d => d.SgsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SC_UGM_USERGROUP_LINKS_SC_UG_USER_GROUP");
            });

            modelBuilder.Entity<ScUgmUsergroupModules>(entity =>
            {
                entity.HasKey(e => e.SugmId);

                entity.ToTable("SC_UGM_USERGROUP_MODULES");

                entity.Property(e => e.SugmId).HasColumnName("SUGM_ID");

                entity.Property(e => e.GmsId).HasColumnName("GMS_ID");

                entity.Property(e => e.PtId).HasColumnName("PT_ID");

                entity.Property(e => e.SgsId).HasColumnName("SGS_ID");

                entity.HasOne(d => d.Gms)
                    .WithMany(p => p.ScUgmUsergroupModules)
                    .HasForeignKey(d => d.GmsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SC_UGM_USERGROUP_MODULES_GR_MS_MODULE_SETUP");

                entity.HasOne(d => d.Pt)
                    .WithMany(p => p.ScUgmUsergroupModules)
                    .HasForeignKey(d => d.PtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SC_UGM_USERGROUP_MODULES_SC_PT_PERMISSION_TYPES");

                entity.HasOne(d => d.Sgs)
                    .WithMany(p => p.ScUgmUsergroupModules)
                    .HasForeignKey(d => d.SgsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SC_UGM_USERGROUP_MODULES_SC_UG_USER_GROUP");
            });

            modelBuilder.Entity<TblFdbpPeriodAssociation>(entity =>
            {
                entity.HasKey(e => e.AssociationId);

                entity.ToTable("Tbl_FDBP_PeriodAssociation");

                entity.HasIndex(e => e.AssociationDocumentId)
                    .HasName("Ind_Tbl_FEBP_PeriodAssocition_1")
                    .IsUnique();

                entity.Property(e => e.AssociationId).HasColumnName("Association_ID");

                entity.Property(e => e.AssociationDate)
                    .HasColumnName("Association_Date")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AssociationDocumentId).HasColumnName("Association_DocumentID");

                entity.Property(e => e.AssociationPeriodId).HasColumnName("Association_PeriodID");
            });

            modelBuilder.Entity<TblFdbpRealizationDetail1>(entity =>
            {
                entity.HasKey(e => e.FdbpDetailId);

                entity.ToTable("Tbl_FDBP_Realization_Detail");

                entity.HasIndex(e => e.FdbpDetailInvoiceNo)
                    .HasName("IND_Tbl_FDBP_Realization_Detail_1");

                entity.Property(e => e.FdbpDetailId).HasColumnName("FDBP_Detail_ID");

                entity.Property(e => e.FdbpDetailAmount).HasColumnName("FDBP_Detail_Amount");

                entity.Property(e => e.FdbpDetailDiscount).HasColumnName("FDBP_Detail_Discount");

                entity.Property(e => e.FdbpDetailDocRef)
                    .HasColumnName("FDBP_Detail_DocRef")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FdbpDetailInvoiceId).HasColumnName("FDBP_Detail_InvoiceID");

                entity.Property(e => e.FdbpDetailInvoiceNo)
                    .HasColumnName("FDBP_detail_InvoiceNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FdbpDetailMasterId).HasColumnName("FDBP_Detail_MasterID");

                entity.Property(e => e.FdbpDetailStatus)
                    .HasColumnName("FDBP_Detail_Status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FdbpDetailStatusDate)
                    .HasColumnName("FDBP_Detail_StatusDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.FdbpDetailTransRef)
                    .HasColumnName("FDBP_Detail_TransRef")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFdbpRealizationMaster>(entity =>
            {
                entity.HasKey(e => e.FdbpDocId);

                entity.ToTable("Tbl_FDBP_Realization_Master");

                entity.Property(e => e.FdbpDocId).HasColumnName("FDBP_DocID");

                entity.Property(e => e.FdbpCommission)
                    .HasColumnName("FDBP_Commission")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FdbpCreated)
                    .HasColumnName("FDBP_Created")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdbpDocDate)
                    .HasColumnName("FDBP_DocDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.FdbpDocNo)
                    .HasColumnName("FDBP_DocNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FdbpTotal)
                    .HasColumnName("FDBP_Total")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblFdbpRealized>(entity =>
            {
                entity.ToTable("TBL_FDBP_Realized");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConversionRate).HasColumnName("Conversion Rate");

                entity.Property(e => e.Created)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");
            });

            modelBuilder.Entity<TblOrdershipmentstatusOfs>(entity =>
            {
                entity.ToTable("TBL_ORDERSHIPMENTSTATUS_OFS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Buyerid).HasColumnName("BUYERID");

                entity.Property(e => e.Buyername)
                    .HasColumnName("BUYERNAME")
                    .HasMaxLength(379)
                    .IsUnicode(false);

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FavgCostingPrice).HasColumnName("FAvgCostingPrice");

                entity.Property(e => e.FavgNegotiatedPrice).HasColumnName("FAvgNegotiatedPrice");

                entity.Property(e => e.Fcm).HasColumnName("FCM");

                entity.Property(e => e.Fcommission).HasColumnName("FCommission");

                entity.Property(e => e.Fconsumption).HasColumnName("FConsumption");

                entity.Property(e => e.FembroPrintCost).HasColumnName("FEmbroPrintCost");

                entity.Property(e => e.FfinishFabric).HasColumnName("FFinishFabric");

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.ForderId).HasColumnName("FOrderID");

                entity.Property(e => e.ForderQty).HasColumnName("FOrderQty");

                entity.Property(e => e.ForderSheetId).HasColumnName("FOrderSheetID");

                entity.Property(e => e.FotherAllowanceCost).HasColumnName("FOtherAllowanceCost");

                entity.Property(e => e.Fsmvcost).HasColumnName("FSMVCost");

                entity.Property(e => e.FtotalTrimCost).HasColumnName("FTotalTrimCost");

                entity.Property(e => e.LavgCostingPrice).HasColumnName("LAvgCostingPrice");

                entity.Property(e => e.LavgNegotiatedPrice).HasColumnName("LAvgNegotiatedPrice");

                entity.Property(e => e.Lcm).HasColumnName("LCM");

                entity.Property(e => e.Lcommission).HasColumnName("LCommission");

                entity.Property(e => e.Lconsumption).HasColumnName("LConsumption");

                entity.Property(e => e.LembroPrintCost).HasColumnName("LEmbroPrintCost");

                entity.Property(e => e.LfinishFabric).HasColumnName("LFinishFabric");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.LorderId).HasColumnName("LOrderID");

                entity.Property(e => e.LorderQty).HasColumnName("LOrderQty");

                entity.Property(e => e.LorderSheetId).HasColumnName("LOrderSheetID");

                entity.Property(e => e.LotherAllowanceCost).HasColumnName("LOtherAllowanceCost");

                entity.Property(e => e.Lsmvcost).HasColumnName("LSMVCost");

                entity.Property(e => e.LtotalTrimCost).HasColumnName("LTotalTrimCost");

                entity.Property(e => e.MonthNo).HasColumnName("MonthNO");

                entity.Property(e => e.StyleOrderId).HasColumnName("StyleOrderID");

                entity.Property(e => e.StyleOrderNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Yarnissuerate).HasColumnName("YARNISSUERATE");

                entity.Property(e => e.Yarnorderid).HasColumnName("YARNORDERID");

                entity.Property(e => e.Year).HasColumnName("YEAR");
            });

            modelBuilder.Entity<TblPeriod>(entity =>
            {
                entity.HasKey(e => e.PeriodId);

                entity.ToTable("Tbl_Period");

                entity.Property(e => e.PeriodId).HasColumnName("Period_ID");

                entity.Property(e => e.PeriodCreated)
                    .HasColumnName("Period_Created")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PeriodEnd)
                    .HasColumnName("Period_End")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PeriodName)
                    .HasColumnName("Period_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodStart)
                    .HasColumnName("Period_Start")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PeriodStatus).HasColumnName("Period_Status");

                entity.Property(e => e.PeriodYear).HasColumnName("Period_Year");
            });
        }
    }
}
