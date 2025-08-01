
using Microsoft.EntityFrameworkCore;
using RTEXERP.DBEntities.Embro;
using RTEXERP.DBEntities.EMBRO;

namespace RTEXERP.DAL.DataContext
{
   public  class EmbroDBContext : DbContext
    {


        public EmbroDBContext(DbContextOptions<EmbroDBContext> options) : base(options) { }

        #region Domain Model
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<AccumulationAccounts> AccumulationAccounts { get; set; }
        public virtual DbSet<AdvancePayment> AdvancePayment { get; set; }
        public virtual DbSet<ApmCasCompanyAccountAssociation> ApmCasCompanyAccountAssociation { get; set; }
        public virtual DbSet<ApmInvoiceAdjustment> ApmInvoiceAdjustment { get; set; }
        public virtual DbSet<ApmInvoiceDetail> ApmInvoiceDetail { get; set; }
        public virtual DbSet<ApmInvoiceDetailRobust> ApmInvoiceDetailRobust { get; set; }
        public virtual DbSet<ApmInvoiceMain> ApmInvoiceMain { get; set; }
        public virtual DbSet<ApmInvoiceStatus> ApmInvoiceStatus { get; set; }
        public virtual DbSet<ApmLcDetail> ApmLcDetail { get; set; }
        public virtual DbSet<ApmPaymentModes> ApmPaymentModes { get; set; }
        public virtual DbSet<ApmPaymentModesDetail> ApmPaymentModesDetail { get; set; }
        public virtual DbSet<ApmPayrollDetail> ApmPayrollDetail { get; set; }
        public virtual DbSet<ApmPayrollMain> ApmPayrollMain { get; set; }
        public virtual DbSet<ApmSupplierPaymentTerms> ApmSupplierPaymentTerms { get; set; }
        public virtual DbSet<ApmSupplierStatusMain> ApmSupplierStatusMain { get; set; }
        public virtual DbSet<ApmTaxationSetup> ApmTaxationSetup { get; set; }
        public virtual DbSet<BackupCbmBillToBillPayment> BackupCbmBillToBillPayment { get; set; }
        public virtual DbSet<BankAccountSetup> BankAccountSetup { get; set; }
        public virtual DbSet<BankContactInfo> BankContactInfo { get; set; }
        public virtual DbSet<BankRecGeneralInfo> BankRecGeneralInfo { get; set; }
        public virtual DbSet<BankVoucherInfo> BankVoucherInfo { get; set; }
        public virtual DbSet<BasicCoa> BasicCoa { get; set; }
        public virtual DbSet<ExportInvoiceType> ExportInvoiceType { get; set; }
        public virtual DbSet<ExportInvoiceVoucherMapping> ExportInvoiceVoucherMapping { get; set; }
        public virtual DbSet<CbmActype> CbmActype { get; set; }
        public virtual DbSet<CbmBaccountFacility> CbmBaccountFacility { get; set; }
        public virtual DbSet<CbmBank> CbmBank { get; set; }
        public virtual DbSet<CbmBankAccountSetup> CbmBankAccountSetup { get; set; }
        public virtual DbSet<CbmBankFacility> CbmBankFacility { get; set; }
        public virtual DbSet<CbmBankStatement> CbmBankStatement { get; set; }
        public virtual DbSet<CbmBillToBillPayment> CbmBillToBillPayment { get; set; }
        public virtual DbSet<CbmBillToBillPayment2> CbmBillToBillPayment2 { get; set; }
        public virtual DbSet<CbmBilltobillpayment1> CbmBilltobillpayment1 { get; set; }
        public virtual DbSet<CbmBranch> CbmBranch { get; set; }
        public virtual DbSet<CbmCheque> CbmCheque { get; set; }
        public virtual DbSet<CbmChequeBook> CbmChequeBook { get; set; }
        public virtual DbSet<CbmChequeStatus> CbmChequeStatus { get; set; }
        public virtual DbSet<CbmCurrency> CbmCurrency { get; set; }
        public virtual DbSet<CbmEcf> CbmEcf { get; set; }
        public virtual DbSet<CbmEcfdetail> CbmEcfdetail { get; set; }
        public virtual DbSet<CbmEmployee> CbmEmployee { get; set; }
        public virtual DbSet<CbmFinFacility> CbmFinFacility { get; set; }
        public virtual DbSet<CBM_Instrument_Type> CBM_Instrument_Type { get; set; }
        public virtual DbSet<CbmLrp> CbmLrp { get; set; }
        public virtual DbSet<CbmLrpDetail> CbmLrpDetail { get; set; }
        public virtual DbSet<CbmParameters> CbmParameters { get; set; }
        public virtual DbSet<CbmPayrollBillToBill> CbmPayrollBillToBill { get; set; }
        public virtual DbSet<CbmPrintedCheque> CbmPrintedCheque { get; set; }
        public virtual DbSet<CbmPrintedChequeStatus> CbmPrintedChequeStatus { get; set; }
        public virtual DbSet<CbmRelateEcfRfpChqVoucher> CbmRelateEcfRfpChqVoucher { get; set; }
        public virtual DbSet<CbmRfp> CbmRfp { get; set; }
        public virtual DbSet<CbmRfpDetail> CbmRfpDetail { get; set; }
        public virtual DbSet<CbmVoucherBillToBillPayment> CbmVoucherBillToBillPayment { get; set; }
        public virtual DbSet<CheckIfVoucherBelongsToDiffCompanyForMaxco> CheckIfVoucherBelongsToDiffCompanyForMaxco { get; set; }
        public virtual DbSet<CheckVoucherSum> CheckVoucherSum { get; set; }
        public virtual DbSet<ChequeSignatoryDetail> ChequeSignatoryDetail { get; set; }
        public virtual DbSet<ChequeSignatoryMaster> ChequeSignatoryMaster { get; set; }
        public virtual DbSet<ClosingDates> ClosingDates { get; set; }
        public virtual DbSet<ClosingTypes> ClosingTypes { get; set; }
        public virtual DbSet<CoaforCostSheet> CoaforCostSheet { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        public virtual DbSet<CostCenterLocation> CostCenterLocation { get; set; }
        public virtual DbSet<CustomerBankInfo> CustomerBankInfo { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetail { get; set; }
        public virtual DbSet<CustomerSetup> CustomerSetup { get; set; }
        public virtual DbSet<DateProblemsInVouchers> DateProblemsInVouchers { get; set; }
        public virtual DbSet<DepriciationMethod> DepriciationMethod { get; set; }
        public virtual DbSet<DepriciationPolicy> DepriciationPolicy { get; set; }
        public virtual DbSet<EfvinvoiceInfo> EfvinvoiceInfo { get; set; }
        public virtual DbSet<EntryTypeSetup> EntryTypeSetup { get; set; }
        public virtual DbSet<ErpClearingAgentDetail> ErpClearingAgentDetail { get; set; }
        public virtual DbSet<ErpClearingAgentMaster> ErpClearingAgentMaster { get; set; }
        public virtual DbSet<ErpPaymentModes> ErpPaymentModes { get; set; }
        public virtual DbSet<ErpPaymentTerms> ErpPaymentTerms { get; set; }
        public virtual DbSet<ErpSro> ErpSro { get; set; }
        public virtual DbSet<EsvagentInfo> EsvagentInfo { get; set; }
        public virtual DbSet<Esvbcaassociation> Esvbcaassociation { get; set; }
        public virtual DbSet<Esvstatus> Esvstatus { get; set; }
        public virtual DbSet<ExportFinancingVoucherInfo> ExportFinancingVoucherInfo { get; set; }
        public virtual DbSet<ExportSalesVoucherInfo> ExportSalesVoucherInfo { get; set; }
        public virtual DbSet<FaitemDepreciationMap> FaitemDepreciationMap { get; set; }
        public virtual DbSet<Fapayment> Fapayment { get; set; }
        public virtual DbSet<FapriorDepreciation> FapriorDepreciation { get; set; }
        public virtual DbSet<FcrDetails> FcrDetails { get; set; }
        public virtual DbSet<FcrMaster> FcrMaster { get; set; }
        public virtual DbSet<FinishedGoodsCb> FinishedGoodsCb { get; set; }
        public virtual DbSet<FiscalYearSetup> FiscalYearSetup { get; set; }
        public virtual DbSet<FixedAsset> FixedAsset { get; set; }
        public virtual DbSet<FixedAssetClass> FixedAssetClass { get; set; }
        public virtual DbSet<FixedAssetDepreciation> FixedAssetDepreciation { get; set; }
        public virtual DbSet<FixedAssetTransfer> FixedAssetTransfer { get; set; }
        public virtual DbSet<FixedAssetWarranty> FixedAssetWarranty { get; set; }
        public virtual DbSet<FsgSetupDetail> FsgSetupDetail { get; set; }
        public virtual DbSet<FsgSetupMaster> FsgSetupMaster { get; set; }
        public virtual DbSet<GeneralConfigurationSetup> GeneralConfigurationSetup { get; set; }
        public virtual DbSet<GeneralParameters> GeneralParameters { get; set; }
        public virtual DbSet<GeneralSetupDetail> GeneralSetupDetail { get; set; }
        public virtual DbSet<GeneralSetupMaster> GeneralSetupMaster { get; set; }
        public virtual DbSet<GspDetails> GspDetails { get; set; }
        public virtual DbSet<GspMaster> GspMaster { get; set; }
        public virtual DbSet<Insurer> Insurer { get; set; }
        public virtual DbSet<InventoryInformation> InventoryInformation { get; set; }
        public virtual DbSet<InventorySupplies> InventorySupplies { get; set; }
        public virtual DbSet<ItemMap> ItemMap { get; set; }
        public virtual DbSet<Itemsaccount> Itemsaccount { get; set; }
        public virtual DbSet<JournalVoucherInfo> JournalVoucherInfo { get; set; }
        public virtual DbSet<LcDetail> LcDetail { get; set; }
        public virtual DbSet<LcsAssociation> LcsAssociation { get; set; }
        public virtual DbSet<LcsAssociationMain> LcsAssociationMain { get; set; }
        public virtual DbSet<Lcsmain> Lcsmain { get; set; }

        public virtual DbSet<LcvoucherInfo> LcvoucherInfo { get; set; }

        public virtual DbSet<LeaseAssetsContractWise> LeaseAssetsContractWise { get; set; }
        public virtual DbSet<LeaseLoanPayment> LeaseLoanPayment { get; set; }
        public virtual DbSet<LeaseLoanPaymentHistory> LeaseLoanPaymentHistory { get; set; }
        public virtual DbSet<LetterType> LetterType { get; set; }
        public virtual DbSet<LettersGenerated> LettersGenerated { get; set; }
        public virtual DbSet<Levels> Levels { get; set; }
        public virtual DbSet<LocalSalesCustomerInfo> LocalSalesCustomerInfo { get; set; }
        public virtual DbSet<LocalSalesVoucherInfo> LocalSalesVoucherInfo { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MmImportSupplierAssociation> MmImportSupplierAssociation { get; set; }
        public virtual DbSet<ModeOfPayment> ModeOfPayment { get; set; }
        public virtual DbSet<MuMenu> MuMenu { get; set; }
        public virtual DbSet<MuMenuItem> MuMenuItem { get; set; }
        public virtual DbSet<MuModule> MuModule { get; set; }
        public virtual DbSet<MuPage> MuPage { get; set; }
        public virtual DbSet<MuPageType> MuPageType { get; set; }
        public virtual DbSet<MuServer> MuServer { get; set; }
        public virtual DbSet<MuUser> MuUser { get; set; }
        public virtual DbSet<MuUserGroup> MuUserGroup { get; set; }
        public virtual DbSet<MuUserPages> MuUserPages { get; set; }
        public virtual DbSet<Opb2014> Opb2014 { get; set; }
        public virtual DbSet<OpeningBalances> OpeningBalances { get; set; }

        public virtual DbSet<OpeningBalancesOld> OpeningBalancesOld { get; set; }
        public virtual DbSet<OrderPayment> OrderPayment { get; set; }
        public virtual DbSet<PaymentCostSheet> PaymentCostSheet { get; set; }
        public virtual DbSet<PaymentMode> PaymentMode { get; set; }
        public virtual DbSet<PaymentPeriod> PaymentPeriod { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<PnlAddCogsItem> PnlAddCogsItem { get; set; }
        public virtual DbSet<PnlAddLineItem> PnlAddLineItem { get; set; }
        public virtual DbSet<PnlAssociateCogsItem> PnlAssociateCogsItem { get; set; }
        public virtual DbSet<PnlAssociateLineItem> PnlAssociateLineItem { get; set; }
        public virtual DbSet<PurchaseVoucherInfo> PurchaseVoucherInfo { get; set; }
        public virtual DbSet<RecurringEntries> RecurringEntries { get; set; }
        public virtual DbSet<Rentals> Rentals { get; set; }
        public virtual DbSet<Revaluation> Revaluation { get; set; }
        public virtual DbSet<Sheet> Sheet { get; set; }
        public virtual DbSet<ShippingInvoiceExcelMigration> ShippingInvoiceExcelMigration { get; set; }
        public virtual DbSet<Signatory> Signatory { get; set; }
        public virtual DbSet<StoresInformation> StoresInformation { get; set; }
        public virtual DbSet<SubVoucherTypeSetup> SubVoucherTypeSetup { get; set; }
        public virtual DbSet<SupplierAttributeExDty> SupplierAttributeExDty { get; set; }
        public virtual DbSet<SupplierAttributeGst> SupplierAttributeGst { get; set; }
        public virtual DbSet<SupplierBankInfo> SupplierBankInfo { get; set; }
        public virtual DbSet<SupplierDetail> SupplierDetail { get; set; }
        public virtual DbSet<SupplierSetup> SupplierSetup { get; set; }
        public virtual DbSet<SystemDomain> SystemDomain { get; set; }
        public virtual DbSet<TaxAssociationSetup> TaxAssociationSetup { get; set; }
        public virtual DbSet<TaxType> TaxType { get; set; }
        public virtual DbSet<TblAssociation> TblAssociation { get; set; }
        public virtual DbSet<TblBpvreport> TblBpvreport { get; set; }
        public virtual DbSet<TblCbmAdvancePayment> TblCbmAdvancePayment { get; set; }
        public virtual DbSet<TblCbmAdvancePaymentRfpRelate> TblCbmAdvancePaymentRfpRelate { get; set; }
        public virtual DbSet<TblCurrencyDetail> TblCurrencyDetail { get; set; }
        public virtual DbSet<TblCurrencySetup> TblCurrencySetup { get; set; }
        public virtual DbSet<TblDepRate> TblDepRate { get; set; }
        public virtual DbSet<TblImportSupplier> TblImportSupplier { get; set; }
        public virtual DbSet<TblInvoiceCurrency> TblInvoiceCurrency { get; set; }
        public virtual DbSet<TblPaymentReport> TblPaymentReport { get; set; }
        public virtual DbSet<TblPayrollMaster> TblPayrollMaster { get; set; }
        public virtual DbSet<TblPurchaseReport> TblPurchaseReport { get; set; }
        public virtual DbSet<TblRfpCurrency> TblRfpCurrency { get; set; }
        public virtual DbSet<TblSupplierCurrency> TblSupplierCurrency { get; set; }
        public virtual DbSet<TblVoucherCurrency> TblVoucherCurrency { get; set; }
        public virtual DbSet<TempDate> TempDate { get; set; }
        public virtual DbSet<TempErvinvoices> TempErvinvoices { get; set; }
        public virtual DbSet<TempErvinvoicesMaster> TempErvinvoicesMaster { get; set; }
        public virtual DbSet<TermsOfPayment> TermsOfPayment { get; set; }
        public virtual DbSet<TrimTaxationSetup> TrimTaxationSetup { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UtilityInformation> UtilityInformation { get; set; }
        public virtual DbSet<UtitlityExpenditureVoucherInfo> UtitlityExpenditureVoucherInfo { get; set; }
        public virtual DbSet<Valuation> Valuation { get; set; }
        public virtual DbSet<ValuationClass> ValuationClass { get; set; }
        public virtual DbSet<Valuators> Valuators { get; set; }
        public virtual DbSet<ValutorTypes> ValutorTypes { get; set; }
        public virtual DbSet<Valutorperson> Valutorperson { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<View1> View1 { get; set; }
        public virtual DbSet<View2> View2 { get; set; }
        public virtual DbSet<ViwAccounts> ViwAccounts { get; set; }
        public virtual DbSet<ViwAgeingDetailReport> ViwAgeingDetailReport { get; set; }
        public virtual DbSet<ViwFixedAssetAddition> ViwFixedAssetAddition { get; set; }
        public virtual DbSet<ViwInvoice> ViwInvoice { get; set; }
        public virtual DbSet<ViwLedger> ViwLedger { get; set; }
        public virtual DbSet<ViwMigInfectedInvoices> ViwMigInfectedInvoices { get; set; }
        public virtual DbSet<ViwMigInfectedPayments> ViwMigInfectedPayments { get; set; }
        public virtual DbSet<ViwMigInfectedRfps> ViwMigInfectedRfps { get; set; }
        public virtual DbSet<ViwMigrationInfectedCreditors> ViwMigrationInfectedCreditors { get; set; }
        public virtual DbSet<ViwRfp> ViwRfp { get; set; }
        public virtual DbSet<ViwVoucher> ViwVoucher { get; set; }
        public virtual DbSet<ViwVoucherFiscalYear> ViwVoucherFiscalYear { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }
        public virtual DbSet<VoucherCheck> VoucherCheck { get; set; }
        public virtual DbSet<VoucherConfigurationSetup> VoucherConfigurationSetup { get; set; }
        public virtual DbSet<VoucherGeneralInfo> VoucherGeneralInfo { get; set; }
        public virtual DbSet<VoucherGeneralInfoBk21> VoucherGeneralInfoBk21 { get; set; }
        public virtual DbSet<VoucherLog> VoucherLog { get; set; }
        public virtual DbSet<VoucherParameters> VoucherParameters { get; set; }
        public virtual DbSet<VoucherReversalVoucherAssociation> VoucherReversalVoucherAssociation { get; set; }
        public virtual DbSet<VoucherSumforTb> VoucherSumforTb { get; set; }
        public virtual DbSet<VoucherTempXml> VoucherTempXml { get; set; }
        public virtual DbSet<VoucherTypeSetup> VoucherTypeSetup { get; set; }
        public virtual DbSet<Voucheracb> Voucheracb { get; set; }
        public virtual DbSet<Voucherdetail> Voucherdetail { get; set; }

        public virtual DbSet<WorkCenters> WorkCenters { get; set; }
        public virtual DbSet<WorkInProgressCb> WorkInProgressCb { get; set; }
        #endregion Domain Model

        #region New
        public virtual DbSet<ExportInvoiceAdjustMaster> ExportInvoiceAdjustMaster { get; set; }
        public virtual DbSet<ExportInvoiceAdjustDetails> ExportInvoiceAdjustDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(b=>b.ItemId);

                entity.ToTable("accounts");

                entity.Property(e => e.Bgid)
                    .HasColumnName("BGID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Bgname)
                    .HasColumnName("BGName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CatId)
                    .HasColumnName("CatID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CatName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Iid)
                    .HasColumnName("IID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Iname)
                    .HasColumnName("IName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ngid)
                    .HasColumnName("NGID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Ngname)
                    .HasColumnName("NGName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubcatId)
                    .HasColumnName("SubcatID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SubcatName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AccumulationAccounts>(entity =>
            {
                entity.HasKey(b=>b.AccumulationId);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccumulationId).HasColumnName("AccumulationID");
            });

            modelBuilder.Entity<AdvancePayment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Deduction).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PoNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Poid)
                    .HasColumnName("POID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            });

            modelBuilder.Entity<ApmCasCompanyAccountAssociation>(entity =>
            {
                entity.HasKey(b=>b.CasId);

                entity.ToTable("APM_CAS_COMPANY_ACCOUNT_ASSOCIATION");

                entity.Property(e => e.CasCompany1Accountid).HasColumnName("CAS_COMPANY_1_ACCOUNTID");

                entity.Property(e => e.CasCompany1Id).HasColumnName("CAS_COMPANY_1_ID");

                entity.Property(e => e.CasCompany2Accountid).HasColumnName("CAS_COMPANY_2_ACCOUNTID");

                entity.Property(e => e.CasCompany2Id).HasColumnName("CAS_COMPANY_2_ID");

                entity.Property(e => e.CasId)
                    .HasColumnName("CAS_ID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ApmInvoiceAdjustment>(entity =>
            {
                entity.HasKey(b=>b.VoucherId);

                entity.ToTable("apm_InvoiceAdjustment");

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            });

            modelBuilder.Entity<ApmInvoiceDetail>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceId, e.VoucherId });
                    //'.ForSqlServerIsClustered(false);

                entity.ToTable("APM_Invoice_Detail");

                entity.HasIndex(e => e.VoucherId)
                    .HasName("IX_APM_Invoice_Detail_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.InvoiceId, e.VoucherId })
                    .HasName("IX_APM_Invoice_Detail");
                    //.ForSqlServerIsClustered();

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceEffect).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.ApmInvoiceDetail)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APM_Invoice_Detail_APM_Invoice_Main");

                entity.HasOne(d => d.Voucher)
                    .WithOne(p => p.ApmInvoiceDetail)
                    .HasForeignKey<ApmInvoiceDetail>(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APM_Invoice_Detail_Voucher");
            });

            modelBuilder.Entity<ApmInvoiceDetailRobust>(entity =>
            {
                entity.HasKey(b=>b.VoucherId);

                entity.ToTable("APM_Invoice_Detail_robust");

                entity.Property(e => e.InvoiceEffect).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ApmInvoiceMain>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.ToTable("APM_Invoice_Main");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("IX_APM_Invoice_Main_NC");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdvAdjusted).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.AmtInDoller).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CurrencyRate).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ExDtyRate).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.GrossAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceSystemId)
                    .IsRequired()
                    .HasColumnName("InvoiceSystemID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LcAcceptenceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Ponum)
                    .IsRequired()
                    .HasColumnName("PONum")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrepareDate).HasColumnType("datetime");

                entity.Property(e => e.PreparedBy).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxRate).HasColumnType("decimal(24, 2)");
            });

            modelBuilder.Entity<ApmInvoiceStatus>(entity =>
            {
                entity.ToTable("APM_Invoice_Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApmLcDetail>(entity =>
            {
                entity.HasKey(b=>b.Acpno);

                entity.ToTable("APM_LC_Detail");

                entity.Property(e => e.Acpno)
                    .HasColumnName("ACPNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lcid).HasColumnName("LCID");

                entity.Property(e => e.Lcno)
                    .HasColumnName("LCNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApmPaymentModes>(entity =>
            {
                entity.HasKey(e => e.Mopid);

                entity.ToTable("APM_Payment_Modes");

                entity.Property(e => e.Mopid)
                    .HasColumnName("MOPID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Mopdescription)
                    .HasColumnName("MOPDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Mopname)
                    .IsRequired()
                    .HasColumnName("MOPName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApmPaymentModesDetail>(entity =>
            {
                entity.HasKey(b=>b.Mopid);

                entity.ToTable("APM_Payment_Modes_Detail");

                entity.Property(e => e.Mopid)
                    .HasColumnName("MOPID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Mop)
                    .WithMany(p => p.ApmPaymentModesDetail)
                    .HasForeignKey(d => d.Mopid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APM_Payment_Modes_Detail_APM_Payment_Modes");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ApmPaymentModesDetail)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APM_Payment_Modes_Detail_SupplierSetup");
            });

            modelBuilder.Entity<ApmPayrollDetail>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceId, e.PayrollId });
                    //.ForSqlServerIsClustered(false);

                entity.ToTable("APM_Payroll_Detail");

                entity.HasIndex(e => e.PayrollId)
                    .HasName("IX_APM_Payroll_Detail_1")
                    .IsUnique();

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PayrollId)
                    .HasColumnName("PayrollID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceEffect).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ApmPayrollMain>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.ToTable("APM_Payroll_Main");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdvAdjusted).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.AmtInDoller).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CurrencyRate).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ExDtyRate).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.GrossAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceSystemId)
                    .IsRequired()
                    .HasColumnName("InvoiceSystemID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LcAcceptenceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Ponum)
                    .IsRequired()
                    .HasColumnName("PONum")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrepareDate).HasColumnType("datetime");

                entity.Property(e => e.PreparedBy).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxRate).HasColumnType("decimal(24, 2)");
            });

            modelBuilder.Entity<ApmSupplierPaymentTerms>(entity =>
            {
                entity.HasKey(e => e.Topid);

                entity.ToTable("APM_Supplier_PaymentTerms");

                entity.Property(e => e.Topid)
                    .HasColumnName("TOPID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Topdescription)
                    .IsRequired()
                    .HasColumnName("TOPDescription")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Topdiscount)
                    .HasColumnName("TOPDiscount")
                    .HasColumnType("decimal(24, 4)");

                entity.Property(e => e.TopitemAccountId)
                    .HasColumnName("TOPItemAccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TopsupplierId)
                    .HasColumnName("TOPSupplierID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Topterms)
                    .HasColumnName("TOPTerms")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.TopitemAccount)
                    .WithMany(p => p.ApmSupplierPaymentTerms)
                    .HasForeignKey(d => d.TopitemAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APM_Supplier_PaymentTerms_BasicCOA");

                entity.HasOne(d => d.Topsupplier)
                    .WithMany(p => p.ApmSupplierPaymentTerms)
                    .HasForeignKey(d => d.TopsupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APM_Supplier_PaymentTerms_SupplierSetup");
            });

            modelBuilder.Entity<ApmSupplierStatusMain>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("APM_Supplier_Status_Main");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApmTaxationSetup>(entity =>
            {
                entity.HasKey(b=>b.TaxId);

                entity.ToTable("APM_TaxationSetup");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Concession).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.NatureOfPayment)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SectionNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TaxId)
                    .HasColumnName("TaxID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxRate).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TimeOfDeduction)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.ApmTaxationSetup)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APM_TaxationSetup_BasicCOA");
            });

            modelBuilder.Entity<BackupCbmBillToBillPayment>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.ToTable("backup_CBM_BillToBillPayment");

                entity.Property(e => e.AdjustedAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.AdjustmentVoucherId).HasColumnName("AdjustmentVoucherID");

                entity.Property(e => e.EntryTime).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            });

            modelBuilder.Entity<BankAccountSetup>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountTypeId).HasColumnName("AccountTypeID");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BankContactInfo>(entity =>
            {
                entity.HasKey(b => b.AccountID);

                entity.Property(e => e.AccountID)
                    .HasColumnName("AccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BankRecGeneralInfo>(entity =>
            {
                entity.HasKey(e => e.Vid);

                entity.Property(e => e.Vid).HasColumnName("VID");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BankCharges).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.BankRefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Billdate).HasColumnType("smalldatetime");

                entity.Property(e => e.Billno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.Comments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyUnit)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Dhl)
                    .HasColumnName("DHL")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Eds)
                    .HasColumnName("EDS")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Esc)
                    .HasColumnName("ESC")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Fdd)
                    .HasColumnName("FDD")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Gross)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.InTax)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Net)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RecAmnt).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.Vindex).HasColumnName("VIndex");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BankRecGeneralInfo)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_BankRecGeneralInfo_BasicCOA");
            });

            modelBuilder.Entity<BankVoucherInfo>(entity =>
            {
                entity.HasKey(e => new { e.VoucherId, e.AccountId });

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BorCa)
                    .HasColumnName("BorCA")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DepositDate).HasColumnType("datetime");

                entity.Property(e => e.InstrumentId)
                    .HasColumnName("InstrumentID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentTypeId)
                    .HasColumnName("InstrumentTypeID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PayeeResident)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfessionalFees).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.ProfitonDebt).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.PropertyAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RefNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TreasuryChallanNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vindex).HasColumnName("VIndex");

                entity.Property(e => e.VoucherDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.BankVoucherInfo)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankVoucherInfo_Voucher");
            });

            modelBuilder.Entity<BasicCoa>(entity =>
            {
                entity.ToTable("BasicCOA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.NaturalAccountId).HasColumnName("NaturalAccountID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

         

            modelBuilder.Entity<CbmActype>(entity =>
            {
                entity.HasKey(b => b.ActypeId);

                entity.ToTable("CBM_ACTYPE");

                entity.Property(e => e.ActypeComments)
                    .HasColumnName("ACTypeComments")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ActypeId)
                    .HasColumnName("ACTypeID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ActypeName)
                    .HasColumnName("ACTypeName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Actype)
                    .WithMany(p => p.CbmActype)
                    .HasForeignKey(d => d.ActypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CBM_ACTYPE_BasicCOA");
            });

            modelBuilder.Entity<CbmBaccountFacility>(entity =>
            {
                entity.HasKey(b => b.BaccountId);

                entity.ToTable("CBM_BAccountFacility");

                entity.Property(e => e.BaccountId)
                    .HasColumnName("BAccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Collateral)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.FinFacilityId)
                    .HasColumnName("FinFacilityID")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Limit).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Rate).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RenewalDate).HasColumnType("datetime");

                entity.Property(e => e.RepaymentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Baccount)
                    .WithMany(p => p.CbmBaccountFacility)
                    .HasForeignKey(d => d.BaccountId)
                    .HasConstraintName("FK_CBM_BAccountFacility_BasicCOA");
            });

            modelBuilder.Entity<CbmBank>(entity =>
            {
                entity.HasKey(e => e.BankId);

                entity.ToTable("CBM_Bank");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.Abbr)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CbmBank)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CBM_Bank_BasicCOA");
            });

            modelBuilder.Entity<CbmBankAccountSetup>(entity =>
            {
                entity.HasKey(b => b.BaccountId);

                entity.ToTable("CBM_BankAccountSetup");

                entity.Property(e => e.BaccountId)
                    .HasColumnName("BAccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BaccountName)
                    .HasColumnName("BAccountName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CurrId).HasColumnName("CurrID");

                entity.Property(e => e.Limit).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Lremarks)
                    .HasColumnName("LRemarks")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Baccount)
                    .WithMany(p => p.CbmBankAccountSetupBaccount)
                    .HasForeignKey(d => d.BaccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CBM_BankAccountSetup_BasicCOA");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.CbmBankAccountSetup)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_CBM_BankAccountSetup_CBM_Branch");

                entity.HasOne(d => d.Curr)
                    .WithMany(p => p.CbmBankAccountSetup)
                    .HasForeignKey(d => d.CurrId)
                    .HasConstraintName("FK_CBM_BankAccountSetup_CBM_Currency");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.CbmBankAccountSetupType)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_CBM_BankAccountSetup_BasicCOA1");
            });

            modelBuilder.Entity<CbmBankFacility>(entity =>
            {
                entity.HasKey(b => b.FinFacilityId);

                entity.ToTable("CBM_BankFacility");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.Coaid).HasColumnName("COAID");

                entity.Property(e => e.Collateral)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FinFacilityId)
                    .HasColumnName("FinFacilityID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Limit).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Rate).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RenewalDate).HasColumnType("datetime");

                entity.Property(e => e.RepaymentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.CbmBankFacility)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_CBM_BankFacility_CBM_Bank");
            });

            modelBuilder.Entity<CbmBankStatement>(entity =>
            {
                entity.HasKey(e => e.Bsid);

                entity.ToTable("CBM_Bank_Statement");

                entity.Property(e => e.Bsid)
                    .HasColumnName("BSID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.BaccountId)
                    .HasColumnName("BAccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BankRefNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bsdate)
                    .HasColumnName("BSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InstrumentNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentTypeId)
                    .HasColumnName("InstrumentTypeID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Particulars)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CbmBillToBillPayment>(entity =>
            {
                entity.ToTable("CBM_BillToBillPayment");

                entity.HasIndex(e => e.VoucherId)
                    .HasName("Ind_CBM_BillToBillPayment_1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdjustedAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.AdjustmentVoucherId).HasColumnName("AdjustmentVoucherID");

                entity.Property(e => e.EntryTime).HasColumnType("datetime");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            });

            modelBuilder.Entity<CbmBillToBillPayment2>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.ToTable("CBM_BillToBillPayment_2");

                entity.Property(e => e.AdjustedAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.AdjustmentVoucherId).HasColumnName("AdjustmentVoucherID");

                entity.Property(e => e.EntryTime).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            });

            modelBuilder.Entity<CbmBilltobillpayment1>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.ToTable("cbm_billtobillpayment1");

                entity.Property(e => e.AdjustedAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.AdjustmentVoucherId).HasColumnName("AdjustmentVoucherID");

                entity.Property(e => e.EntryTime).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            });

            modelBuilder.Entity<CbmBranch>(entity =>
            {
                entity.HasKey(e => e.BranchId);

                entity.ToTable("CBM_Branch");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.BranchAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.CbmBranch)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_CBM_Branch_CBM_Bank");
            });

            modelBuilder.Entity<CbmCheque>(entity =>
            {
                entity.HasKey(e => e.ChqId);

                entity.ToTable("CBM_Cheque");

                entity.HasIndex(e => e.SignStatus)
                    .HasName("IX_CBM_Cheque_NC");

                entity.Property(e => e.ChqId)
                    .HasColumnName("ChqID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ChequeSignatoryId).HasColumnName("ChequeSignatoryID");

                entity.Property(e => e.ChqAccountId)
                    .HasColumnName("ChqAccountID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ChqAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.ChqBkId)
                    .HasColumnName("ChqBkID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ChqComments)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.ChqDate).HasColumnType("datetime");

                entity.Property(e => e.ChqDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ChqNum)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SignStatus)
                    .HasColumnType("numeric(10, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.ChqBk)
                    .WithMany(p => p.CbmCheque)
                    .HasForeignKey(d => d.ChqBkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CBM_Cheque_CBM_ChequeBook");
            });

            modelBuilder.Entity<CbmChequeBook>(entity =>
            {
                entity.ToTable("CBM_ChequeBook");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeriesEnd)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SeriesStart)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(1)");
            });

            modelBuilder.Entity<CbmChequeStatus>(entity =>
            {
                entity.HasKey(b => b.StatusId);

                entity.ToTable("CBM_ChequeStatus");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CbmCurrency>(entity =>
            {
                entity.HasKey(e => e.CurId);

                entity.ToTable("CBM_Currency");

                entity.Property(e => e.CurId).HasColumnName("CurID");

                entity.Property(e => e.CurAbbreviation)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CurName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CurSign)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CbmEcf>(entity =>
            {
                entity.HasKey(e => e.Ecfid);

                entity.ToTable("CBM_ECF");

                entity.Property(e => e.Ecfid)
                    .HasColumnName("ECFID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApprovalBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.BusinessId)
                    .HasColumnName("BusinessID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Claimant).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CompId)
                    .HasColumnName("CompID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreationBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Ecfdate)
                    .HasColumnName("ECFDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ecfdescription)
                    .HasColumnName("ECFDescription")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ecfnum)
                    .HasColumnName("ECFNum")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ecftype)
                    .HasColumnName("ECFType")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Total).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VerificationBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.VerificationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CbmEcfdetail>(entity =>
            {
                entity.HasKey(b => b.Ecfid);

                entity.ToTable("CBM_ECFDetail");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ActivityId)
                    .HasColumnName("ActivityID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Amount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.CostCenterId)
                    .HasColumnName("CostCenterID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Ecfid)
                    .HasColumnName("ECFID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExpenseDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Particulars)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Rate).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.RefId)
                    .HasColumnName("RefID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ecf)
                    .WithMany(p => p.CbmEcfdetail)
                    .HasForeignKey(d => d.Ecfid)
                    .HasConstraintName("FK_CBM_ECFDetail_CBM_ECF");
            });

            modelBuilder.Entity<CbmEmployee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("CBM_Employee");

                entity.Property(e => e.EmpId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompId)
                    .HasColumnName("CompID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmpCategory)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmpDept)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmpDesig)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNum)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmpSection)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CbmFinFacility>(entity =>
            {
                entity.HasKey(b => b.FinFacilityId);

                entity.ToTable("CBM_FinFacility");

                entity.Property(e => e.FinFacilityDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FinFacilityId)
                    .HasColumnName("FinFacilityID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FinFacilityName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FinFacility)
                    .WithMany(p => p.CbmFinFacility)
                    .HasForeignKey(d => d.FinFacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CBM_FinFacility_BasicCOA");
            });

            modelBuilder.Entity<CBM_Instrument_Type>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("CBM_Instrument_Type");

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CbmLrp>(entity =>
            {
                entity.HasKey(e => e.Lrpid);

                entity.ToTable("CBM_LRP");

                entity.Property(e => e.Lrpid)
                    .HasColumnName("LRPID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BusinessId)
                    .HasColumnName("BusinessID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CheckBy).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.CompId)
                    .HasColumnName("CompID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreationBy).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LeasorId).HasColumnName("LeasorID");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Lrpdate)
                    .HasColumnName("LRPDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lrpdescription)
                    .HasColumnName("LRPDescription")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lrpnum)
                    .IsRequired()
                    .HasColumnName("LRPNum")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VerificationBy).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Verificationdate).HasColumnType("datetime");

                entity.Property(e => e.Voucherid)
                    .HasColumnName("VOUCHERID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<CbmLrpDetail>(entity =>
            {
                entity.HasKey(e => new { e.Lrpid, e.RentalId });

                entity.ToTable("CBM_LRP_Detail");

                entity.Property(e => e.Lrpid)
                    .HasColumnName("LRPID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RentalId).HasColumnName("RentalID");

                entity.HasOne(d => d.Lrp)
                    .WithMany(p => p.CbmLrpDetail)
                    .HasForeignKey(d => d.Lrpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CBM_LRP_Detail_CBM_LRP");

                entity.HasOne(d => d.Rental)
                    .WithMany(p => p.CbmLrpDetail)
                    .HasForeignKey(d => d.RentalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CBM_LRP_Detail_Rentals");
            });

            modelBuilder.Entity<CbmParameters>(entity =>
            {
                entity.ToTable("CBM_Parameters");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CbmPayrollBillToBill>(entity =>
            {
                entity.HasKey(b => b.PayrollVoucherId);

                entity.ToTable("CBM_PayrollBillToBill");

                entity.Property(e => e.Payment).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PayrollVoucherId).HasColumnName("PayrollVoucherID");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            });

            modelBuilder.Entity<CbmPrintedCheque>(entity =>
            {
                entity.HasKey(e => e.ChqId)
                    .HasName("PK_CBM_ChequesInHand");

                entity.ToTable("CBM_PrintedCheque");

                entity.Property(e => e.ChqId)
                    .HasColumnName("ChqID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Identification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivingPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CbmPrintedChequeStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("CBM_PrintedChequeStatus");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusDescription).IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CbmRelateEcfRfpChqVoucher>(entity =>
            {
                entity.HasKey(e => e.Vid);
                //    .ForSqlServerIsClustered(false);

                entity.ToTable("CBM_Relate_ECF_RFP_CHQ_VOUCHER");

                entity.HasIndex(e => e.VoucherId)
                    .HasName("IX_CBM_Relate_ECF_RFP_CHQ_Voucher_NC");
                   // .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.Rfpid, e.Ecfid, e.Lrpid, e.ChqId })
                    .HasName("IX_CBM_RFP_CHQ_Voucher_NC");

                entity.Property(e => e.Vid).HasColumnName("VID");

                entity.Property(e => e.AdjustmentDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ChqId)
                    .HasColumnName("ChqID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Ecfid)
                    .HasColumnName("ECFID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Lrpid)
                    .HasColumnName("LRPID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rfpid)
                    .HasColumnName("RFPID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Ecf)
                    .WithMany(p => p.CbmRelateEcfRfpChqVoucher)
                    .HasForeignKey(d => d.Ecfid)
                    .HasConstraintName("FK_CBM_Relate_ECF_RFP_CHQ_VOUCHER_CBM_ECF");

                entity.HasOne(d => d.Lrp)
                    .WithMany(p => p.CbmRelateEcfRfpChqVoucher)
                    .HasForeignKey(d => d.Lrpid)
                    .HasConstraintName("FK_CBM_Relate_ECF_RFP_CHQ_VOUCHER_CBM_LRP");

                entity.HasOne(d => d.Rfp)
                    .WithMany(p => p.CbmRelateEcfRfpChqVoucher)
                    .HasForeignKey(d => d.Rfpid)
                    .HasConstraintName("FK_CBM_Relate_ECF_RFP_CHQ_VOUCHER_CBM_RFP");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.CbmRelateEcfRfpChqVoucher)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CBM_Relate_ECF_RFP_CHQ_VOUCHER_Voucher");
            });

            modelBuilder.Entity<CbmRfp>(entity =>
            {
                entity.HasKey(e => e.Rfpid)
                    .HasName("PK_CBM_RFP_MIGRATION");

                entity.ToTable("CBM_RFP");

                entity.Property(e => e.Rfpid)
                    .HasColumnName("RFPID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BusinessId)
                    .HasColumnName("BusinessID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CheckBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.CompId)
                    .HasColumnName("CompID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreationBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.IsAdvanceAdjusted)
                    .IsRequired()
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RelatedOldRfpid)
                    .HasColumnName("RelatedOldRFPID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RfpaddedStatus)
                    .HasColumnName("RFPAddedStatus")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Rfpdate)
                    .HasColumnName("RFPDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rfpdescription)
                    .HasColumnName("RFPDescription")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rfpnum)
                    .HasColumnName("RFPNum")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VerificationBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Verificationdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CbmRfpDetail>(entity =>
            {
                entity.HasKey(e => new { e.Rfpid, e.InvoiceId })
                    .HasName("PK_CBM_RFP_Detail_MIGRATION");

                entity.ToTable("CBM_RFP_Detail");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("IX_CBM_RFP_Detail_MIGRATION")
                    .IsUnique();

                entity.Property(e => e.Rfpid)
                    .HasColumnName("RFPID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Rfp)
                    .WithMany(p => p.CbmRfpDetail)
                    .HasForeignKey(d => d.Rfpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CBM_RFP_Detail_MIGRATION_CBM_RFP");
            });

            modelBuilder.Entity<CbmVoucherBillToBillPayment>(entity =>
            {
                entity.ToTable("cbm_VoucherBillToBillPayment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdjustmentVoucherId).HasColumnName("AdjustmentVoucherID");

                entity.Property(e => e.EntryTime).HasColumnType("datetime");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.CbmVoucherBillToBillPayment)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("fk_voucher_id");
            });

            modelBuilder.Entity<CheckIfVoucherBelongsToDiffCompanyForMaxco>(entity =>
            {
                entity.HasKey(b => b.AccountId);

                entity.ToTable("CheckIfVoucherBelongsToDiffCompany_forMaxco");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AmountSum).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.VoucherDate).HasColumnType("smalldatetime");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<CheckVoucherSum>(entity =>
            {
                entity.HasKey(b => b.VoucherId);

                entity.ToTable("CheckVoucherSum");

                entity.Property(e => e.Amount).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ChequeSignatoryDetail>(entity =>
            {
                entity.HasKey(e => new { e.ChequeSignatoryId, e.SignatoryId });

                entity.Property(e => e.ChequeSignatoryId).HasColumnName("ChequeSignatoryID");

                entity.Property(e => e.SignatoryId).HasColumnName("SignatoryID");

                entity.HasOne(d => d.ChequeSignatory)
                    .WithMany(p => p.ChequeSignatoryDetail)
                    .HasForeignKey(d => d.ChequeSignatoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChequeSignatoryDetail_ChequeSignatoryMaster");

                entity.HasOne(d => d.Signatory)
                    .WithMany(p => p.ChequeSignatoryDetail)
                    .HasForeignKey(d => d.SignatoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChequeSignatoryDetail_Signatory");
            });

            modelBuilder.Entity<ChequeSignatoryMaster>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovalLimit).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClosingDates>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompId).HasColumnName("CompID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FiscalYear).HasColumnName("fiscalYear");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ClosingDates)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClosingDates_ClosingTypes");
            });

            modelBuilder.Entity<ClosingTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Current')");
            });

            modelBuilder.Entity<CoaforCostSheet>(entity =>
            {
                entity.ToTable("COAforCostSheet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Coaid).HasColumnName("COAID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyInfo>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.HasIndex(e => e.CompanyId)
                    .HasName("IX_CompanyInfo")
                    .IsUnique();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ntn)
                    .HasColumnName("NTN")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Stn)
                    .HasColumnName("STN")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithOne(p => p.CompanyInfo)
                    .HasForeignKey<CompanyInfo>(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyInfo_BasicCOA");
            });

            modelBuilder.Entity<CostCenterLocation>(entity =>
            {
                entity.HasKey(b => b.CostCenterId);

                entity.Property(e => e.CostCenterId)
                    .HasColumnName("CostCenterID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.CostCenter)
                    .WithMany(p => p.CostCenterLocation)
                    .HasForeignKey(d => d.CostCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostCenterLocation_BasicCOA");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.CostCenterLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostCenterLocation_Location");
            });

            modelBuilder.Entity<CustomerBankInfo>(entity =>
            {
                entity.HasKey(b => b.CustomerId);

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(59)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            });

            modelBuilder.Entity<CustomerDetail>(entity =>
            {
                entity.HasKey(b => b.CustomerId);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerSetup>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalTaxNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesTaxNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DateProblemsInVouchers>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.ToTable("DateProblemsInVouchers");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PrepareDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DepriciationMethod>(entity =>
            {
                entity.HasKey(b => b.MethodId);

                entity.Property(e => e.MethodId).HasColumnName("MethodID");

                entity.Property(e => e.MethodName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DepriciationPolicy>(entity =>
            {
                entity.HasKey(e => e.PolicyId)
                    .HasName("PK_Depriciation_Policy");

                entity.Property(e => e.PolicyId)
                    .HasColumnName("PolicyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EfvinvoiceInfo>(entity =>
            {
                entity.ToTable("EFVInvoiceInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Payment).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            });

            modelBuilder.Entity<EntryTypeSetup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ErpClearingAgentDetail>(entity =>
            {
                entity.HasKey(b => b.AgentDetailId);

                entity.ToTable("ERP_ClearingAgent_Detail");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AgentDetailId)
                    .HasColumnName("AgentDetailID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AgentId).HasColumnName("AgentID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ErpClearingAgentMaster>(entity =>
            {
                entity.HasKey(b => b.AgentId);

                entity.ToTable("ERP_ClearingAgent_Master");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AgentId)
                    .HasColumnName("AgentID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ErpPaymentModes>(entity =>
            {
                entity.HasKey(b => b.Pmid);

                entity.ToTable("ERP_PaymentModes");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Pmdescription)
                    .IsRequired()
                    .HasColumnName("PMDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pmid)
                    .HasColumnName("PMID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ErpPaymentTerms>(entity =>
            {
                entity.HasKey(e => e.Ptid);

                entity.ToTable("ERP_PaymentTerms");

                entity.Property(e => e.Ptid).HasColumnName("PTID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.IsDisplay).HasDefaultValueSql("(1)");

                entity.Property(e => e.PaymentModeId).HasColumnName("PaymentModeID");

                entity.Property(e => e.Ptdescription)
                    .IsRequired()
                    .HasColumnName("PTDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ErpSro>(entity =>
            {
                entity.HasKey(b => b.Sroid);

                entity.ToTable("ERP_SRO");

                entity.Property(e => e.Detail1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Detail2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sroid)
                    .HasColumnName("SROID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Sronumber)
                    .HasColumnName("SRONumber")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EsvagentInfo>(entity =>
            {
                entity.HasKey(e => new { e.VoucherId, e.CommissionAgentId });

                entity.ToTable("ESVAgentInfo");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CommissionAgentId).HasColumnName("CommissionAgentID");

                entity.Property(e => e.ConvRate).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TamountinRs).HasColumnName("TAmountinRs");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.EsvagentInfo)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESVAgentInfo_Voucher");
            });

            modelBuilder.Entity<Esvbcaassociation>(entity =>
            {
                entity.ToTable("ESVBCAAssociation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bank)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bcavid).HasColumnName("BCAVID");

                entity.Property(e => e.Conversionrate).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Edate)
                    .HasColumnName("EDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Esvid).HasColumnName("ESVID");

                entity.Property(e => e.GrossFc)
                    .HasColumnName("GrossFC")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Invoice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewGrossPks).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OldGrossPks).HasColumnType("decimal(24, 3)");
            });

            modelBuilder.Entity<Esvstatus>(entity =>
            {
                entity.HasKey(e => e.Esvid);

                entity.ToTable("ESVStatus");

                entity.Property(e => e.Esvid)
                    .HasColumnName("ESVID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActualAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Remaining).HasColumnType("decimal(24, 2)");
            });

            modelBuilder.Entity<ExportFinancingVoucherInfo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.BuyerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lcid).HasColumnName("LCID");

                entity.Property(e => e.Lcnum)
                    .HasColumnName("LCNum")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

                entity.Property(e => e.VoucherTypeMainId).HasColumnName("VoucherTypeMainID");

                entity.Property(e => e.VoucherTypeText)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExportSalesVoucherInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                //  .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.VoucherId)
                    .HasName("IX_ExportSalesVoucherInfo");
                    //.ForSqlServerIsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.CavoucherId).HasColumnName("CAVoucherID");

                entity.Property(e => e.ConvRate).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Freight).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.GrossAmount).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Rate).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.Vindex).HasColumnName("VIndex");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.ExportSalesVoucherInfo)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExportSalesVoucherInfo_Voucher");
            });

            modelBuilder.Entity<FaitemDepreciationMap>(entity =>
            {
                entity.HasKey(b=>b.RelationId);

                entity.ToTable("FAItemDepreciationMap");

                entity.Property(e => e.DepreciationType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.RelationId)
                    .HasColumnName("RelationID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Fapayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("FAPayment");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("paymentID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Identifier).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PaymentType).HasColumnName("paymentType");
            });

            modelBuilder.Entity<FapriorDepreciation>(entity =>
            {
                entity.HasKey(e => new { e.AssetId, e.YearNumber });

                entity.ToTable("FAPriorDepreciation");

                entity.Property(e => e.AssetId).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PriorDepriciationNarration)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FcrDetails>(entity =>
            {
                entity.ToTable("FCR_Details");

                entity.Property(e => e.FcrdetailsId).HasColumnName("FCRDetailsId");

                entity.Property(e => e.Fcrdate)
                    .HasColumnName("FCRDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FcrmasterId).HasColumnName("FCRMasterId");

                entity.Property(e => e.Fcrno)
                    .IsRequired()
                    .HasColumnName("FCRNo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FcrMaster>(entity =>
            {
                entity.ToTable("FCR_Master");

                entity.Property(e => e.FcrmasterId).HasColumnName("FCRMasterId");

                entity.Property(e => e.ChequeId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FcrmasterDate)
                    .HasColumnName("FCRMasterDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FcrmasterNo)
                    .HasColumnName("FCRMasterNo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FinishedGoodsCb>(entity =>
            {
                entity.HasKey(b=>b.Id);

                entity.ToTable("FinishedGoods_CB");

                entity.Property(e => e.DateOfCb)
                    .HasColumnName("DateOfCB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<FiscalYearSetup>(entity =>
            {
                entity.HasKey(b=>b.StartDay);

                entity.Property(e => e.StartDay).HasColumnName("startDay");

                entity.Property(e => e.StartMonth).HasColumnName("startMonth");
            });

            modelBuilder.Entity<FixedAsset>(entity =>
            {
                entity.HasKey(e => e.AssetId);

                entity.HasIndex(e => e.AssetId)
                    .HasName("IX_FixedAsset")
                    .IsUnique();

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.AccumulatedDepriciation)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AcquisitionTransferDate).HasColumnType("datetime");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.AllocationDate).HasColumnType("datetime");

                entity.Property(e => e.AssetCoaid).HasColumnName("AssetCOAID");

                entity.Property(e => e.AssetCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.BarCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bcoccurence)
                    .HasColumnName("BCOccurence")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BillOfEntryDate).HasColumnType("datetime");

                entity.Property(e => e.BookValue)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

                entity.Property(e => e.CostOfAcquisition)
                    .HasColumnType("decimal(32, 2)")
                    .HasComputedColumnSql("([PurchasePrice] + [ImportDuties] + [DismantlingCost] + [ProfessionalFees] + [InstallationCost] + [InitialDeliveryCost] + [SitePreparationCost] - [TradeDiscount] - [Rebates])");

                entity.Property(e => e.DateofAcquisition).HasColumnType("datetime");

                entity.Property(e => e.DepreciationType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.DirectlyAttributedCost)
                    .HasColumnType("decimal(28, 2)")
                    .HasComputedColumnSql("([DismantlingCost] + [ProfessionalFees] + [InstallationCost] + [InitialDeliveryCost] + [SitePreparationCost])");

                entity.Property(e => e.DismantlingCost)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DisposalAdditionalSalesTaxRate).HasColumnType("decimal(24, 0)");

                entity.Property(e => e.DisposalAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.DisposalBillNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerNic)
                    .HasColumnName("DisposalBuyerNIC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerStaxNum)
                    .HasColumnName("DisposalBuyerSTaxNum")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalDate).HasColumnType("datetime");

                entity.Property(e => e.DisposalMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalRecieptMode)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalRefNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalSalesTaxRate).HasColumnType("decimal(24, 0)");

                entity.Property(e => e.FixedAssetClassId).HasColumnName("FixedAssetClassID");

                entity.Property(e => e.ImpairmentAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ImpairmentDate).HasColumnType("datetime");

                entity.Property(e => e.ImportAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.ImportCurrency)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ImportDuties)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.InitialDeliveryCost)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.InstallationCost)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IntendedUse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.OriginalCost)
                    .HasColumnType("decimal(30, 2)")
                    .HasComputedColumnSql("([PurchasePrice] + [ImportDuties] + [DismantlingCost] + [ProfessionalFees] + [InstallationCost] + [InitialDeliveryCost] + [SitePreparationCost])");

                entity.Property(e => e.OverhaulPeriod).HasColumnType("decimal(24, 7)");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PorefNumber)
                    .HasColumnName("PORefNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrimarySpecs)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProfessionalFees)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PurchasePrice)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rebates)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RelatedAssetId).HasColumnName("RelatedAssetID");

                entity.Property(e => e.ResidualValue).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.SecondarySpecs)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SitePreparationCost)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.SubActivityId).HasColumnName("SubActivityID");

                entity.Property(e => e.ThirdPartyAsset)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TradeDiscount)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferStatus).HasDefaultValueSql("(0)");

                entity.Property(e => e.TransferVoucherId).HasColumnName("TransferVoucherID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.Property(e => e.WrittenDownValue)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.YearofManufacturing)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.FixedAssetClass)
                    .WithMany(p => p.FixedAsset)
                    .HasForeignKey(d => d.FixedAssetClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FixedAsset_FixedAssetClass");
            });

            modelBuilder.Entity<FixedAssetClass>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.AccountDepriciationMethodId).HasColumnName("AccountDepriciationMethod_ID");

                entity.Property(e => e.AccountDepriciationRate).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.ClassGroupId)
                    .HasColumnName("ClassGroupID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DepriciationPolicyId).HasColumnName("DepriciationPolicyID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDepriciationMethodId).HasColumnName("TaxDepriciationMethod_ID");

                entity.Property(e => e.TaxDepriciationRate1).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TaxDepriciationRate2).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TaxDepriciationRate3).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TaxDepriciationRateN).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FixedAssetDepreciation>(entity =>
            {
                entity.HasKey(e=>e.DepreciationId);

                entity.Property(e => e.AmountDepreciated).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.DepreciationDate).HasColumnType("datetime");

                entity.Property(e => e.DepreciationId)
                    .HasColumnName("DepreciationID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.VoucherNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WrittenDownValue).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<FixedAssetTransfer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetCoaid).HasColumnName("AssetCOAID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.FixedAssetClassId).HasColumnName("FixedAssetClassID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<FixedAssetWarranty>(entity =>
            {
                entity.HasKey(e => e.AssetId);

                entity.Property(e => e.AssetId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.WarrantyDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WarrantyEndDate).HasColumnType("datetime");

                entity.Property(e => e.WarrantyStartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FsgSetupDetail>(entity =>
            {
                entity.HasKey(e => new { e.Fsgid, e.Id });

                entity.ToTable("FSG_Setup_Detail");

                entity.Property(e => e.Fsgid).HasColumnName("FSGID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Coaid).HasColumnName("COAID");

                entity.Property(e => e.Coasign).HasColumnName("COASign");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fid)
                    .IsRequired()
                    .HasColumnName("FID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormulaName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Indent).HasDefaultValueSql("(0)");

                entity.Property(e => e.IsBold)
                    .HasColumnName("isBold")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IsBox).HasColumnName("isBox");

                entity.Property(e => e.IsCaps)
                    .HasColumnName("isCaps")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IsFormula).HasColumnName("isFormula");

                entity.Property(e => e.IsHline).HasColumnName("isHLine");

                entity.Property(e => e.IsPrintDesc)
                    .HasColumnName("isPrintDesc")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IsPrintValue)
                    .HasColumnName("isPrintValue")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IsVline)
                    .HasColumnName("isVLine")
                    .HasDefaultValueSql("(183)");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.LineFeed).HasDefaultValueSql("(0)");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FsgSetupMaster>(entity =>
            {
                entity.HasKey(e => new { e.Fsgid, e.Fsgname });

                entity.ToTable("FSG_Setup_Master");

                entity.Property(e => e.Fsgid)
                    .HasColumnName("FSGID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Fsgname)
                    .HasColumnName("FSGName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Fsgheading)
                    .IsRequired()
                    .HasColumnName("FSGHeading")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneralConfigurationSetup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.Parameter)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneralParameters>(entity =>
            {
                entity.HasKey(e => e.ParamId);

                entity.Property(e => e.ParamId).HasColumnName("ParamID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.GeneralDecription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneralSetupDetail>(entity =>
            {
                entity.HasKey(e => new { e.SetupId, e.InstanceId, e.CompanyId });

                entity.Property(e => e.SetupId)
                    .HasColumnName("SetupID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstanceId)
                    .HasColumnName("InstanceID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstanceValue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<GeneralSetupMaster>(entity =>
            {
                entity.HasKey(e => e.SetupId);

                entity.Property(e => e.SetupId)
                    .HasColumnName("SetupID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<GspDetails>(entity =>
            {
                entity.ToTable("GSP_Details");

                entity.Property(e => e.GspdetailsId).HasColumnName("GSPDetailsId");

                entity.Property(e => e.Gspdate)
                    .HasColumnName("GSPDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GspmasterId).HasColumnName("GSPMasterId");

                entity.Property(e => e.Gspno)
                    .IsRequired()
                    .HasColumnName("GSPNo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GspMaster>(entity =>
            {
                entity.ToTable("GSP_Master");

                entity.Property(e => e.GspmasterId).HasColumnName("GSPMasterId");

                entity.Property(e => e.ChequeId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GspmasterDate)
                    .HasColumnName("GSPMasterDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GspmasterNo)
                    .HasColumnName("GSPMasterNo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Insurer>(entity =>
            {
                entity.Property(e => e.InsurerId).HasColumnName("InsurerID");

                entity.Property(e => e.CoaaccountId).HasColumnName("COAAccountID");

                entity.Property(e => e.Companyid).HasColumnName("COMPANYID");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HeadOfficeAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceAcid)
                    .HasColumnName("InsuranceACID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InsurerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InterestAcid).HasColumnName("InterestACID");

                entity.Property(e => e.LongTermLacid).HasColumnName("LongTermLACID");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RelationsManager)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InventoryInformation>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpeningInventory).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Units)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InventoryInformation)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryInformation_BasicCOA");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.InventoryInformation)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_InventoryInformation_StoresInformation");
            });

            modelBuilder.Entity<InventorySupplies>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemMap>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountingDepRate).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Initials)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.TaxDepRate1).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TaxDepRate2).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TaxDepRate3).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TaxDepRateN).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Itemsaccount>(entity =>
            {
                entity.HasKey(e=>e.Itemid);

                entity.Property(e => e.Itemid)
                    .HasColumnName("itemid")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.Itemname)
                    .HasColumnName("itemname")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JournalVoucherInfo>(entity =>
            {
                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Quantity).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.Rate).HasColumnType("decimal(24, 8)");

                entity.Property(e => e.Vindex).HasDefaultValueSql("((0))");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.JournalVoucherInfo)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("FK_JournalVoucherInfo_Voucher");
            });

            modelBuilder.Entity<LcDetail>(entity =>
            {
                entity.HasKey(e=>e.VoucherId);

                entity.ToTable("LC_Detail");

                entity.HasIndex(e => e.Lcnumber)
                    .HasName("Ind_Lc_Detail_1");

                entity.HasIndex(e => e.VoucherId)
                    .HasName("Ind_Lc_Detail");

                entity.Property(e => e.Lcnumber)
                    .IsRequired()
                    .HasColumnName("LCNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pinumber)
                    .IsRequired()
                    .HasColumnName("PINumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LcsAssociation>(entity =>
            {
                entity.HasKey(e=>e.IdentificationId);

                entity.ToTable("LCS_Association");

                entity.Property(e => e.IdentificationId).HasColumnName("IdentificationID");

                entity.Property(e => e.Lcsmid).HasColumnName("LCSMID");
            });

            modelBuilder.Entity<LcsAssociationMain>(entity =>
            {
                entity.ToTable("LCS_Association_Main");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lcsmain>(entity =>
            {
                entity.HasKey(e => e.Lcnumber);

                entity.ToTable("LCSMain");

                entity.Property(e => e.Lcnumber).HasColumnName("LCNumber");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Hscode)
                    .HasColumnName("HSCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImportedUnderSro)
                    .IsRequired()
                    .HasColumnName("ImportedUnderSRO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LccontractNumber)
                    .IsRequired()
                    .HasColumnName("LCContractNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lcdate)
                    .HasColumnName("LCDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mplaccount).HasColumnName("MPLAccount");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentNature)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivingDate).HasColumnType("datetime");

                entity.Property(e => e.SuppInvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TransportId).HasColumnName("TransportID");

                entity.Property(e => e.TransportNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

          

            modelBuilder.Entity<LcvoucherInfo>(entity =>
            {
                entity.HasKey(e => e.LcdetailId);

                entity.ToTable("LCVoucherInfo");

                entity.Property(e => e.LcdetailId).HasColumnName("LCDetailID");

                entity.Property(e => e.BankAcceptanceDate).HasColumnType("datetime");

                entity.Property(e => e.BankMaturityDate).HasColumnType("datetime");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LcvoucherCreationDate)
                    .HasColumnName("LCVoucherCreationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.LcvoucherInfo)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LCVoucherInfo_LCVoucherInfo");
            });

         

            modelBuilder.Entity<LeaseAssetsContractWise>(entity =>
            {
                entity.HasKey(e => new { e.Assetid, e.LeaseId });

                entity.Property(e => e.LeaseId).HasColumnName("LeaseID");

                entity.Property(e => e.AssetCoaid).HasColumnName("AssetCOAID");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.LeaseAssetsContractWise)
                    .HasForeignKey(d => d.Assetid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeaseAssetsContractWise_FixedAsset");

                entity.HasOne(d => d.Lease)
                    .WithMany(p => p.LeaseAssetsContractWise)
                    .HasForeignKey(d => d.LeaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeaseAssetsContractWise_LeaseLoanPayment");
            });

            modelBuilder.Entity<LeaseLoanPayment>(entity =>
            {
                entity.HasKey(e => e.LeaseLoanId);

                entity.HasIndex(e => new { e.LeaseLoanCode, e.Companyid })
                    .HasName("IX_LeaseLoanPayment")
                    .IsUnique();

                entity.Property(e => e.LeaseLoanId).HasColumnName("LeaseLoanID");

                entity.Property(e => e.AssetCoaid).HasColumnName("AssetCOAID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.Companyid).HasColumnName("COMPANYID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstInstallmentDate)
                    .HasColumnName("firstInstallmentDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InstallmentPeriodType)
                    .HasColumnName("installmentPeriodType")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IsLeaseOwnershipTransferable)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Isinsurance)
                    .IsRequired()
                    .HasColumnName("ISINSURANCE")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LeaseLoanCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LeasorLenderId).HasColumnName("LeasorLenderID");

                entity.Property(e => e.Ltype)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RevisionDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("(0)");

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.Versionno).HasColumnName("VERSIONNO");
            });

            modelBuilder.Entity<LeaseLoanPaymentHistory>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.LeaseLoanId, e.LeaseLoanCode });

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LeaseLoanId).HasColumnName("LeaseLoanID");

                entity.Property(e => e.LeaseLoanCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssetCoaid).HasColumnName("AssetCOAID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.Companyid).HasColumnName("COMPANYID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstInstallmentDate)
                    .HasColumnName("firstInstallmentDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InstallmentPeriodType)
                    .HasColumnName("installmentPeriodType")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IsLeaseOwnershipTransferable)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Isinsurance)
                    .IsRequired()
                    .HasColumnName("ISINSURANCE")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.LeasorLenderId).HasColumnName("LeasorLenderID");

                entity.Property(e => e.Ltype)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RevisionDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("(0)");

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.Versionno).HasColumnName("VERSIONNO");
            });

            modelBuilder.Entity<LetterType>(entity =>
            {
                entity.HasKey(e=>e.LetterTypeId);

                entity.Property(e => e.LetterTypeDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LettersGenerated>(entity =>
            {
                entity.HasKey(e=>e.LetterGeneratedId);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.BankRepresentative)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CheqDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cheqno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateGenerated).HasColumnType("datetime");

                entity.Property(e => e.Favouring)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromAccountId).HasColumnName("FromAccountID");

                entity.Property(e => e.FromAccountNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromBankId).HasColumnName("FromBankID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.LetterGeneratedId).ValueGeneratedOnAdd();

                entity.Property(e => e.Refno)
                    .HasColumnName("Refno.")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToAccountAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ToAccountId)
                    .HasColumnName("ToAccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToAccountNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToAccountTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToBankId).HasColumnName("ToBankID");

                entity.Property(e => e.ToDate)
                    .HasColumnName("To Date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Levels>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocalSalesCustomerInfo>(entity =>
            {
                entity.HasKey(e => new { e.VoucherId, e.CustomerId });

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesTaxNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.LocalSalesCustomerInfo)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalSalesCustomerInfo_Voucher");
            });

            modelBuilder.Entity<LocalSalesVoucherInfo>(entity =>
            {
                entity.HasKey(e => e.Vid);

                entity.Property(e => e.Vid).HasColumnName("VID");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Discount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Dodate)
                    .HasColumnName("DODate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Donumber)
                    .HasColumnName("DONumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.SalesTax).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Vindex).HasColumnName("VIndex");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.LocalSalesVoucherInfo)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("FK_LocalSalesVoucherInfo_Voucher");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.SrNum);

                entity.Property(e => e.SrNum).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Area)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LocationDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationInitials)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LocationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlotNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tel1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tel2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.SrNumNavigation)
                    .WithOne(p => p.Location)
                    .HasForeignKey<Location>(d => d.SrNum)
                    .HasConstraintName("FK_Location_BasicCOA");
            });

            modelBuilder.Entity<MmImportSupplierAssociation>(entity =>
            {
                entity.HasKey(e=>e.AccountId);

                entity.ToTable("MM_ImportSupplierAssociation");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("IX_tbl_ImportSupplier_AccAssociation")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            });

            modelBuilder.Entity<ModeOfPayment>(entity =>
            {
                entity.HasKey(e => e.ModeId);

                entity.Property(e => e.ModeId).HasColumnName("ModeID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfDays).HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<MuMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("MU_Menu");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MuMenuItem>(entity =>
            {
                entity.HasKey(e=>e.MenuItemId);

                entity.ToTable("MU_MenuItem");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.Property(e => e.MenuItemName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.ParentMenuItemId).HasColumnName("ParentMenuItemID");
            });

            modelBuilder.Entity<MuModule>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.ToTable("MU_Module");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ServerId).HasColumnName("ServerID");

                entity.Property(e => e.WebDirectoryName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MuPage>(entity =>
            {
                entity.HasKey(e=>e.PageId);

                entity.ToTable("MU_Page");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.PageLink)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PageName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PageTypeId).HasColumnName("PageTypeID");
            });

            modelBuilder.Entity<MuPageType>(entity =>
            {
                entity.HasKey(e => e.PageTypeId);

                entity.ToTable("MU_PageType");

                entity.Property(e => e.PageTypeId).HasColumnName("PageTypeID");

                entity.Property(e => e.PageTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MuServer>(entity =>
            {
                entity.HasKey(e => e.MuServer1);

                entity.ToTable("MU_Server");

                entity.Property(e => e.MuServer1).HasColumnName("MU_Server");

                entity.Property(e => e.MuServerName)
                    .IsRequired()
                    .HasColumnName("MU_ServerName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MuUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("MU_User");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemId)
                    .HasColumnName("SystemID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MuUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId);

                entity.ToTable("MU_UserGroup");

                entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MuUserPages>(entity =>
            {
                entity.HasKey(e=>e.PageId);

                entity.ToTable("MU_UserPages");

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Opb2014>(entity =>
            {
                entity.HasKey(e=>e.AccountId);

                entity.ToTable("opb2014");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Balance).HasColumnType("decimal(38, 4)");
            });

            modelBuilder.Entity<OpeningBalances>(entity =>
            {
                entity.HasKey(e => e.Vid)
                    .HasName("PK_OpeningBalance");

                entity.Property(e => e.Vid).HasColumnName("VID");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.OpeningBalance).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });



            modelBuilder.Entity<OpeningBalancesOld>(entity =>
            {
                entity.HasKey(e => e.Vid)
                    .HasName("PK_OpeningBalances");

                entity.ToTable("OpeningBalances_old");

                entity.Property(e => e.Vid).HasColumnName("VID");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.OpeningBalance).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OrderPayment>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.VoucherId });

                entity.ToTable("Order_Payment");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

                entity.Property(e => e.Esvid).HasColumnName("ESVID");
            });

            modelBuilder.Entity<PaymentCostSheet>(entity =>
            {
                entity.ToTable("Payment_CostSheet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Coaid).HasColumnName("COAID");

                entity.Property(e => e.Lcno)
                    .HasColumnName("LCNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentMode>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ModeOfPayment)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentPeriod>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => new { e.PaymentType1, e.PaymentMode });

                entity.Property(e => e.PaymentType1)
                    .HasColumnName("PaymentType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PnlAddCogsItem>(entity =>
            {
                entity.ToTable("PNL_ADD_COGS_ITEM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Text)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PnlAddLineItem>(entity =>
            {
                entity.ToTable("PNL_Add_LINE_ITEM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.CompId).HasColumnName("Comp_ID");

                entity.Property(e => e.LineItem)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Priority).HasColumnName("priority");
            });

            modelBuilder.Entity<PnlAssociateCogsItem>(entity =>
            {
                entity.ToTable("PNL_ASSOCIATE_COGS_ITEM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CogsLineId).HasColumnName("COGS_Line_ID");
            });

            modelBuilder.Entity<PnlAssociateLineItem>(entity =>
            {
                entity.ToTable("PNL_ASSOCIATE_LINE_ITEM");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CoaId).HasColumnName("COA_ID");

                entity.Property(e => e.LineId).HasColumnName("LineID");
            });

            modelBuilder.Entity<PurchaseVoucherInfo>(entity =>
            {
                entity.HasKey(e => e.Vid);

                entity.Property(e => e.Vid).HasColumnName("VID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.ConversionCost)
                    .HasColumnType("decimal(24, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.MaterialName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.QuantityUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rate).HasColumnType("decimal(24, 8)");

                entity.Property(e => e.RequisitionNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.PurchaseVoucherInfo)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseVoucherInfo_Voucher");
            });

            modelBuilder.Entity<RecurringEntries>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Rentals>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Insurance)
                    .HasColumnName("INSURANCE")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Interest).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LeaseId).HasColumnName("LeaseID");

                entity.Property(e => e.LeaseLoanCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Principal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Rentals1)
                    .HasColumnName("Rentals")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Startdate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.TotalFinancialChargesOutstanding).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalPrincipalOutstanding).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalRentalOutstanding).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Lease)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.LeaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rentals_LeaseLoanPayment");
            });

            modelBuilder.Entity<Revaluation>(entity =>
            {
                entity.HasKey(e=>e.RevaluationId);

                entity.Property(e => e.FixedAssetId)
                    .HasColumnName("FixedAssetID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RevaluationDate).HasColumnType("datetime");

                entity.Property(e => e.RevaluationId)
                    .HasColumnName("RevaluationID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ValuerAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ValuerExperiance)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValuerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValuerPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValuerQualification)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sheet>(entity =>
            {
                entity.HasKey(e=>e.PoNo);

                entity.Property(e => e.AccountHead).HasColumnName("Account Head");

                entity.Property(e => e.F8).HasMaxLength(255);

                entity.Property(e => e.GrvNo)
                    .HasColumnName("GRV NO")
                    .HasMaxLength(255);

                entity.Property(e => e.ItemName)
                    .HasColumnName("Item name")
                    .HasMaxLength(255);

                entity.Property(e => e.LedgerPageNo)
                    .HasColumnName("Ledger Page No")
                    .HasMaxLength(255);

                entity.Property(e => e.NewIdOfCoa).HasColumnName("New ID of COA");

                entity.Property(e => e.OldIdOfCoa).HasColumnName("OLD ID of COA");

                entity.Property(e => e.PoNo).HasColumnName("PO NO");

                entity.Property(e => e.VoucherDate)
                    .HasColumnName("Voucher Date ")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ShippingInvoiceExcelMigration>(entity =>
            {
                entity.Property(e => e.ExcelUploadDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MigrationDate).HasColumnType("datetime");

                entity.Property(e => e.MigrationIdList).IsUnicode(false);

                entity.Property(e => e.ModifiedDescription)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingBillNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Signatory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SignatoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StoresInformation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Initials)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StoreCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreIncharge)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.StoresInformation)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_StoresInformation_BasicCOA");
            });

            modelBuilder.Entity<SubVoucherTypeSetup>(entity =>
            {
                entity.ToTable("SubVoucherType_setup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasColumnName("initials")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SubVoucherType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubVoucherTypeId).HasColumnName("SubVoucherTypeID");

                entity.Property(e => e.VoucherTypeId).HasColumnName("VoucherTypeID");

                entity.HasOne(d => d.VoucherType)
                    .WithMany(p => p.SubVoucherTypeSetup)
                    .HasForeignKey(d => d.VoucherTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubVoucherType_setup_VoucherType_setup");
            });

            modelBuilder.Entity<SupplierAttributeExDty>(entity =>
            {
                entity.HasKey(e=>e.AttributeId);

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.ExciseDutyAccountId).HasColumnName("ExciseDutyAccountID");

                entity.Property(e => e.FiscalYear).HasDefaultValueSql("(2008)");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SupplierAttributeGst>(entity =>
            {
                entity.HasKey(e=>e.AttributeId);

                entity.ToTable("SupplierAttributeGST");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.Deleted).HasDefaultValueSql("(0)");

                entity.Property(e => e.FiscalYear).HasDefaultValueSql("(2008)");

                entity.Property(e => e.SalesTaxAccountId).HasColumnName("SalesTaxAccountID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SupplierBankInfo>(entity =>
            {
                entity.HasKey(e=>e.SupplierId);

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoutingNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SwiftNo)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SupplierDetail>(entity =>
            {
                entity.HasKey(e=>e.SupplierId);

                entity.Property(e => e.CellNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Division)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SupplierSetup>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ntnnumber)
                    .HasColumnName("NTNNumber")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SalesTaxRegNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierType)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemDomain>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaxAssociationSetup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.TaxTypeId).HasColumnName("TaxTypeID");
            });

            modelBuilder.Entity<TaxType>(entity =>
            {
                entity.Property(e => e.TaxTypeId)
                    .HasColumnName("TaxTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAssociation>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.ToTable("tbl_Association");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DeletionDate).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LibId).HasColumnName("LibID");
            });

            modelBuilder.Entity<TblBpvreport>(entity =>
            {
                entity.HasKey(e=>e.Net);

                entity.ToTable("Tbl_BPVReport");

                entity.Property(e => e.ChqDate).HasColumnType("datetime");

                entity.Property(e => e.ChqNum)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CompId)
                    .HasColumnName("CompID")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DateToBePaid).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Identification)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Item)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Net).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrepareDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCbmAdvancePayment>(entity =>
            {
                entity.ToTable("tbl_CBM_AdvancePayment");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Vid)
                    .HasColumnName("VID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Vindex)
                    .HasColumnName("VINDEX")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblCbmAdvancePaymentRfpRelate>(entity =>
            {
                entity.ToTable("tbl_CBM_AdvancePayment_RFP_Relate");

                entity.HasIndex(e => new { e.AdvancePaymentId, e.InvoiceId })
                    .HasName("IX_tbl_CBM_AdvancePayment_RFP_Relate_MIGRATION_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.AdvancePaymentId, e.InvoiceId, e.Rfpid })
                    .HasName("IX_tbl_CBM_AdvancePayment_RFP_Relate_MIGRATION")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvancePaymentId)
                    .HasColumnName("AdvancePaymentID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AmountDeducted).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.EntryTime).HasColumnType("datetime");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rfpid).HasColumnName("RFPID");

                entity.HasOne(d => d.AdvancePayment)
                    .WithMany(p => p.TblCbmAdvancePaymentRfpRelate)
                    .HasForeignKey(d => d.AdvancePaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_CBM_AdvancePayment_RFP_Relate_MIGRATION_tbl_CBM_AdvancePayment_MIGRATION");
            });

            modelBuilder.Entity<TblCurrencyDetail>(entity =>
            {
                entity.HasKey(e=>e.CurId);

                entity.ToTable("tbl_Currency_Detail");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.RateInPakRs).HasColumnType("money");
            });

            modelBuilder.Entity<TblCurrencySetup>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.ToTable("tbl_Currency_Setup");

                entity.Property(e => e.CountryName)
                    .HasColumnName("countryName")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CurrencyName)
                    .HasColumnName("currencyName")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Symbol)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblDepRate>(entity =>
            {
                entity.HasKey(e=>e.AssetCoaid);

                entity.ToTable("tblDepRate");
            });

            modelBuilder.Entity<TblImportSupplier>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.ToTable("tbl_import_supplier");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompId).HasColumnName("CompID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<TblInvoiceCurrency>(entity =>
            {
                entity.HasKey(e=>e.InvoiceId);

                entity.ToTable("tbl_Invoice_Currency");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            });

            modelBuilder.Entity<TblPaymentReport>(entity =>
            {
                entity.HasKey(e=>e.Amount);

                entity.ToTable("tbl_payment_Report");

                entity.Property(e => e.Amount).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.CoaTag)
                    .HasMaxLength(771)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Identification)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Item)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NrGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPayrollMaster>(entity =>
            {
                entity.HasKey(e => e.PayrollId);

                entity.ToTable("Tbl_Payroll_Master");

                entity.Property(e => e.PayrollId)
                    .HasColumnName("Payroll_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PayrollAbsent)
                    .HasColumnName("Payroll_Absent")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollAdvance)
                    .HasColumnName("Payroll_Advance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollAllowance)
                    .HasColumnName("Payroll_Allowance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollAttendanceAllownce)
                    .HasColumnName("Payroll_AttendanceAllownce")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollBank)
                    .HasColumnName("Payroll_Bank")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollBasic)
                    .HasColumnName("Payroll_Basic")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollBasicSalary)
                    .HasColumnName("Payroll_BasicSalary")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollBasicSalaryEarned)
                    .HasColumnName("Payroll_BasicSalary_Earned")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollCompany).HasColumnName("Payroll_Company");

                entity.Property(e => e.PayrollCompanyId).HasColumnName("Payroll_CompanyID");

                entity.Property(e => e.PayrollConductAllowance)
                    .HasColumnName("Payroll_ConductAllowance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollConveyance)
                    .HasColumnName("Payroll_Conveyance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollConveyanceEarned)
                    .HasColumnName("Payroll_Conveyance_Earned")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollDeduction)
                    .HasColumnName("Payroll_Deduction")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollDefault)
                    .HasColumnName("Payroll_Default")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollDept).HasColumnName("Payroll_Dept");

                entity.Property(e => e.PayrollDesignation).HasColumnName("Payroll_Designation");

                entity.Property(e => e.PayrollDivision).HasColumnName("Payroll_Division");

                entity.Property(e => e.PayrollEmp).HasColumnName("Payroll_Emp");

                entity.Property(e => e.PayrollEmpCategory).HasColumnName("Payroll_EmpCategory");

                entity.Property(e => e.PayrollEmpCd)
                    .IsRequired()
                    .HasColumnName("Payroll_EmpCD")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PayrollEmpTotalDays)
                    .HasColumnName("Payroll_EmpTotalDays")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollExtraOtAmt).HasColumnName("Payroll_ExtraOtAmt");

                entity.Property(e => e.PayrollExtraOtHrs).HasColumnName("Payroll_ExtraOtHrs");

                entity.Property(e => e.PayrollFrom)
                    .HasColumnName("Payroll_From")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PayrollGrossSalary)
                    .HasColumnName("Payroll_GrossSalary")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollHoliday)
                    .HasColumnName("Payroll_Holiday")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollHouseRent)
                    .HasColumnName("Payroll_HouseRent")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollHouseRentEarned)
                    .HasColumnName("Payroll_HouseRent_Earned")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollLoan)
                    .HasColumnName("Payroll_Loan")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollLwop)
                    .HasColumnName("Payroll_LWOP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollLwp)
                    .HasColumnName("Payroll_LWP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollMedical)
                    .HasColumnName("Payroll_Medical")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollMedicalEarned)
                    .HasColumnName("Payroll_Medical_Earned")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollModified).HasColumnName("Payroll_Modified");

                entity.Property(e => e.PayrollMonth).HasColumnName("Payroll_Month");

                entity.Property(e => e.PayrollNetSalary)
                    .HasColumnName("Payroll_NetSalary")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollOffDay)
                    .HasColumnName("Payroll_OffDay")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollOtAmt)
                    .HasColumnName("Payroll_OtAmt")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollOtHrs)
                    .HasColumnName("Payroll_OtHrs")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollOtherAllowances)
                    .HasColumnName("Payroll_OtherAllowances")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollPaid)
                    .HasColumnName("Payroll_Paid")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollPaidDate)
                    .HasColumnName("Payroll_PaidDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PayrollPayDays).HasColumnName("Payroll_PayDays");

                entity.Property(e => e.PayrollPfvalue)
                    .HasColumnName("payroll_PFValue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollPresent)
                    .HasColumnName("Payroll_Present")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollProductionBonus)
                    .HasColumnName("Payroll_ProductionBonus")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollRoundOff)
                    .HasColumnName("Payroll_RoundOff")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollSection).HasColumnName("Payroll_Section");

                entity.Property(e => e.PayrollStampDeduction)
                    .HasColumnName("Payroll_StampDeduction")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollStampDeductions)
                    .HasColumnName("Payroll_StampDeductions")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollStatus)
                    .HasColumnName("Payroll_Status")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.PayrollTax)
                    .HasColumnName("Payroll_Tax")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollTaxable)
                    .HasColumnName("Payroll_Taxable")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollTo)
                    .HasColumnName("Payroll_To")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PayrollTotalAllowances)
                    .HasColumnName("Payroll_TotalAllowances")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollTtldays)
                    .HasColumnName("Payroll_TTLDays")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollVersion)
                    .HasColumnName("Payroll_Version")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PayrollWelfareFund)
                    .HasColumnName("Payroll_WelfareFund")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollWorkedHours).HasColumnName("Payroll_WorkedHours");

                entity.Property(e => e.PayrollWorkedHoursAmount)
                    .HasColumnName("Payroll_workedHoursAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PayrollYear).HasColumnName("Payroll_Year");
            });

            modelBuilder.Entity<TblPurchaseReport>(entity =>
            {
                entity.HasKey(e=>e.Amount);

                entity.ToTable("tbl_purchase_Report");

                entity.Property(e => e.Amount).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.BroadGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Des)
                    .HasColumnName("des")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Identity)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NarrowGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubCategory)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRfpCurrency>(entity =>
            {
                entity.HasKey(e=>e.Rfpid);

                entity.ToTable("tbl_RFP_Currency");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.Rfpid).HasColumnName("RFPID");
            });

            modelBuilder.Entity<TblSupplierCurrency>(entity =>
            {
                entity.HasKey(e=>e.SupplierId);

                entity.ToTable("tbl_supplier_Currency");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            });

            modelBuilder.Entity<TblVoucherCurrency>(entity =>
            {
                entity.HasKey(e=>e.VoucherId);

                entity.ToTable("tbl_Voucher_Currency");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            });

            modelBuilder.Entity<TempDate>(entity =>
            {
                entity.HasKey(e=>e.DateFrom);

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.Property(e => e.Dfrom)
                    .HasColumnName("DFrom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dto)
                    .HasColumnName("DTo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TempErvinvoices>(entity =>
            {
                entity.HasKey(e => e.TempInvoiceId);

                entity.ToTable("TempERVInvoices");

                entity.Property(e => e.TempInvoiceId).HasColumnName("TempInvoiceID");

                entity.Property(e => e.InvBalance).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.InvCrate)
                    .HasColumnName("InvCRate")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.InvFcamount)
                    .HasColumnName("InvFCAmount")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.InvGrossAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.InvNetAmount).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.InvPayment).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.InvoiceNo).HasMaxLength(200);

                entity.Property(e => e.Mlcid).HasColumnName("MLCID");

                entity.Property(e => e.Mlcno)
                    .HasColumnName("MLCNo")
                    .HasMaxLength(200);

                entity.Property(e => e.Rate).HasColumnType("numeric(18, 4)");

                entity.Property(e => e.TempMasterInvoiceId).HasColumnName("TempMasterInvoiceID");
            });

            modelBuilder.Entity<TempErvinvoicesMaster>(entity =>
            {
                entity.HasKey(e=>e.TempMasterInvoiceId);

                entity.ToTable("TempERVInvoicesMaster");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.TempMasterInvoiceId)
                    .HasColumnName("TempMasterInvoiceID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TempMasterInvoiceNo).HasMaxLength(100);
            });

            modelBuilder.Entity<TermsOfPayment>(entity =>
            {
                entity.HasKey(e => e.TermId);

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrimTaxationSetup>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.FiscalYear).HasDefaultValueSql("(2007)");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TaxType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("decimal(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompId).HasColumnName("CompID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SystemDomainId).HasColumnName("SystemDomainID");

                entity.Property(e => e.SystemId)
                    .HasColumnName("SystemID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UtilityInformation>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ItemDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Unit)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UtitlityExpenditureVoucherInfo>(entity =>
            {
                entity.HasKey(e => e.Vid);

                entity.Property(e => e.Vid).HasColumnName("VID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.RequisitionNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Vindex).HasColumnName("VIndex");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Valuation>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.Property(e => e.AssetCoaid).HasColumnName("AssetCOAID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.Caccountid).HasColumnName("CAccountid");

                entity.Property(e => e.Daccountid).HasColumnName("DAccountid");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ReasonId).HasColumnName("ReasonID");

                entity.Property(e => e.RevisedValue).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ValuationDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValuatorId).HasColumnName("ValuatorID");

                entity.Property(e => e.ValuatorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Wdv)
                    .HasColumnName("WDV")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<ValuationClass>(entity =>
            {
                entity.HasKey(e=>e.ClassId);

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.ClassId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ValuationClass)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_ValuationClass_BasicCOA");
            });

            modelBuilder.Entity<Valuators>(entity =>
            {
                entity.HasKey(e=>e.ValuatorId);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.AssetCoaid).HasColumnName("AssetCOAID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FaxNo).HasMaxLength(50);

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.Property(e => e.ValuatorCompany).HasMaxLength(50);

                entity.Property(e => e.ValuatorId).HasColumnName("ValuatorID");
            });

            modelBuilder.Entity<ValutorTypes>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ValuatorId).HasColumnName("ValuatorID");
            });

            modelBuilder.Entity<Valutorperson>(entity =>
            {
                entity.HasKey(e=>e.ValuatorNameId);

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValuatorId).HasColumnName("ValuatorID");

                entity.Property(e => e.ValuatorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValuatorNameId).HasColumnName("ValuatorNameID");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e=>e.VendorId);

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasKey(e=>e.Amount);

                entity.ToTable("view1");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(38, 2)");
            });

            modelBuilder.Entity<View2>(entity =>
            {
                entity.HasKey(e=>e.Amount);

                entity.ToTable("view2");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(38, 2)");
            });

            modelBuilder.Entity<ViwAccounts>(entity =>
            {
                entity.HasKey(e=>e.L6Id);

                entity.ToTable("viw_Accounts");

                entity.Property(e => e.L1Desc)
                    .HasColumnName("L1_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L1Id)
                    .HasColumnName("L1_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.L2Desc)
                    .HasColumnName("L2_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L2Id)
                    .HasColumnName("L2_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.L3Desc)
                    .HasColumnName("L3_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L3Id)
                    .HasColumnName("L3_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.L4Desc)
                    .HasColumnName("L4_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L4Id)
                    .HasColumnName("L4_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.L5Desc)
                    .HasColumnName("L5_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L5Id)
                    .HasColumnName("L5_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.L6Desc)
                    .HasColumnName("L6_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L6Id)
                    .HasColumnName("L6_ID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ViwAgeingDetailReport>(entity =>
            {
                entity.HasKey(e=>e.InvoiceId);

                entity.ToTable("VIW_AgeingDetail_Report");

                entity.Property(e => e.ControlAccount)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Creditors)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NetAmount).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViwFixedAssetAddition>(entity =>
            {
                entity.HasKey(e=>e.AssetId);

                entity.ToTable("viwFixedAssetAddition");

                entity.Property(e => e.AccumulatedDepriciation).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.AllocationDate).HasColumnType("datetime");

                entity.Property(e => e.AssetCoaid).HasColumnName("AssetCOAID");

                entity.Property(e => e.AssetCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Bcoccurence).HasColumnName("BCOccurence");

                entity.Property(e => e.BillOfEntryDate).HasColumnType("datetime");

                entity.Property(e => e.BookValue).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenterId).HasColumnName("CostCenterID");

                entity.Property(e => e.CostOfAcquisition).HasColumnType("decimal(32, 2)");

                entity.Property(e => e.DateofAcquisition).HasColumnType("datetime");

                entity.Property(e => e.DepreciationType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.DirectlyAttributedCost).HasColumnType("decimal(28, 2)");

                entity.Property(e => e.DismantlingCost).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.DisposalAdditionalSalesTaxRate).HasColumnType("decimal(24, 0)");

                entity.Property(e => e.DisposalAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.DisposalBillNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerNic)
                    .HasColumnName("DisposalBuyerNIC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerStaxNum)
                    .HasColumnName("DisposalBuyerSTaxNum")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalBuyerType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalDate).HasColumnType("datetime");

                entity.Property(e => e.DisposalMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalRecieptMode)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalRefNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalSalesTaxRate).HasColumnType("decimal(24, 0)");

                entity.Property(e => e.FixedAssetClassId).HasColumnName("FixedAssetClassID");

                entity.Property(e => e.Identification)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImpairmentAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ImpairmentDate).HasColumnType("datetime");

                entity.Property(e => e.ImportAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.ImportCurrency)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ImportDuties).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.InitialDeliveryCost).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.InstallationCost).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.IntendedUse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Item)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.OriginalCost).HasColumnType("decimal(30, 2)");

                entity.Property(e => e.OverhaulPeriod).HasColumnType("decimal(24, 7)");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PorefNumber)
                    .HasColumnName("PORefNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrimarySpecs)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProfessionalFees).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rebates).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.ResidualValue).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.SecondarySpecs)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SitePreparationCost).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.SubActivityId).HasColumnName("SubActivityID");

                entity.Property(e => e.ThirdPartyAsset)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TradeDiscount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferVoucherId).HasColumnName("TransferVoucherID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.Property(e => e.WrittenDownValue).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.YearofManufacturing)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ViwInvoice>(entity =>
            {
                entity.HasKey(e=>e.InvoiceId);

                entity.ToTable("VIW_INVOICE");

                entity.Property(e => e.AmtInDoller).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CurrencyRate).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Edn)
                    .HasColumnName("EDN")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.EdnexciseDuty)
                    .HasColumnName("EDNExciseDuty")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.Edngross)
                    .HasColumnName("EDNGross")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.EdnsalesTax)
                    .HasColumnName("EDNSalesTax")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.ExciseDuty).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GrossAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.GrvexciseDuty)
                    .HasColumnName("GRVExciseDuty")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.Grvgross)
                    .HasColumnName("GRVGross")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.GrvsalesTax)
                    .HasColumnName("GRVSalesTax")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceSystemId)
                    .IsRequired()
                    .HasColumnName("InvoiceSystemID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nedn)
                    .HasColumnName("NEDN")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NednexciseDuty)
                    .HasColumnName("NEDNExciseDuty")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.Nedngross)
                    .HasColumnName("NEDNGross")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NednsalesTax)
                    .HasColumnName("NEDNSalesTax")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Ponum)
                    .IsRequired()
                    .HasColumnName("PONum")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrepareDate).HasColumnType("datetime");

                entity.Property(e => e.SalesTax).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ViwLedger>(entity =>
            {
                entity.HasKey(e=>e.Voucherid);

                entity.ToTable("VIW_LEDGER");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vdate)
                    .HasColumnName("VDATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Vindex).HasColumnName("vindex");

                entity.Property(e => e.Voucherid)
                    .HasColumnName("VOUCHERID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Vouchernumber)
                    .IsRequired()
                    .HasColumnName("VOUCHERNUMBER")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViwMigInfectedInvoices>(entity =>
            {
                entity.HasKey(e=>e.InvoiceId);

                entity.ToTable("VIW_MIG_INFECTED_INVOICEs");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ViwMigInfectedPayments>(entity =>
            {
                entity.HasKey(e=>e.VoucherId);

                entity.ToTable("VIW_MIG_INFECTED_PAYMENTS");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ViwMigInfectedRfps>(entity =>
            {
                entity.HasKey(e=>e.Rfpid);

                entity.ToTable("VIW_MIG_INFECTED_RFPs");

                entity.Property(e => e.Rfpid)
                    .HasColumnName("RFPID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ViwMigrationInfectedCreditors>(entity =>
            {
                entity.HasKey(e=>e.Supplierid);

                entity.ToTable("viw_MIGRATION_InfectedCreditors");

                entity.Property(e => e.Cou).HasColumnName("COU");

                entity.Property(e => e.L1Desc)
                    .HasColumnName("L1_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L1Id)
                    .HasColumnName("L1_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.L2Desc)
                    .HasColumnName("L2_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L2Id)
                    .HasColumnName("L2_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.L3Desc)
                    .HasColumnName("L3_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L3Id)
                    .HasColumnName("L3_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.L4Desc)
                    .HasColumnName("L4_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L4Id)
                    .HasColumnName("L4_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.L5Desc)
                    .HasColumnName("L5_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L5Id)
                    .HasColumnName("L5_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.L6Desc)
                    .HasColumnName("L6_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L6Id)
                    .HasColumnName("L6_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Supplierid)
                    .HasColumnName("SUPPLIERID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ViwRfp>(entity =>
            {
                entity.HasKey(e=>e.Rfpid);

                entity.ToTable("VIW_RFP");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Rfpdate)
                    .HasColumnName("RFPDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rfpid)
                    .HasColumnName("RFPID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Rfpnum)
                    .HasColumnName("RFPNum")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ViwVoucher>(entity =>
            {
                entity.HasKey(e=>e.VoucherId);

                entity.ToTable("viw_Voucher");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.AuthorizedBy).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CheckedBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Crate)
                    .HasColumnName("CRate")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.PreparedBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vdate)
                    .HasColumnName("VDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Vid).HasColumnName("VID");

                entity.Property(e => e.VoucherDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViwVoucherFiscalYear>(entity =>
            {
                entity.HasKey(e=>e.VoucherId);

                entity.ToTable("viw_Voucher_FiscalYear");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Pvamount)
                    .HasColumnName("PVAMOUNT")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Pvdate)
                    .HasColumnName("PVDATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Pvno)
                    .HasColumnName("PVNO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rfpid)
                    .HasColumnName("RFPID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vdate)
                    .HasColumnName("VDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasIndex(e => new { e.VoucherType, e.Vdate, e.CompanyId })
                    .HasName("IX_Voucher_NC");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AmtInDoller).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AuthorizeDate).HasColumnType("datetime");

                entity.Property(e => e.AuthorizedBy).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.CheckedBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Crate)
                    .HasColumnName("CRate")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeletionDate).HasColumnType("datetime");

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.IndividualVoucherId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentTerm)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrepareDate).HasColumnType("datetime");

                entity.Property(e => e.PreparedBy)
                    .HasColumnType("numeric(10, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.SubVoucherType).HasDefaultValueSql("((1))");

                entity.Property(e => e.SystemVoucher).HasDefaultValueSql("((0))");

                entity.Property(e => e.Vdate)
                    .HasColumnName("VDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VoucherDescription)
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.VoucherTypeNavigation)
                    .WithMany(p => p.Voucher)
                    .HasForeignKey(d => d.VoucherType)
                    .HasConstraintName("FK_Voucher_VoucherType_setup");
            });

            modelBuilder.Entity<VoucherCheck>(entity =>
            {
                entity.HasKey(e=>e.VoucherId);

                entity.Property(e => e.CheckDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VoucherConfigurationSetup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.Nature)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Parameter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SelectionMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VoucherGeneralInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                //.ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.VoucherId, e.AccountId })
                    .HasName("IX_VoucherGeneralInfo");
                    //.ForSqlServerIsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.BankAccId).HasColumnName("BankAccID");

                entity.Property(e => e.Billdate).HasColumnType("smalldatetime");

                entity.Property(e => e.Billno)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ConversionRate).HasColumnType("decimal(24, 6)");

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dcdate)
                    .HasColumnName("DCDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(24, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExciseDuty).HasColumnType("decimal(25, 0)");

                entity.Property(e => e.Grndate)
                    .HasColumnName("GRNDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gross)
                    .HasColumnType("decimal(24, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InTax)
                    .HasColumnType("decimal(24, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceEffect).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Lcid).HasColumnName("LCID");

                entity.Property(e => e.Lcnumber)
                    .HasColumnName("LCNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Net)
                    .HasColumnType("decimal(24, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Podate)
                    .HasColumnName("PODate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('None')");

                entity.Property(e => e.SupplierDonumber)
                    .HasColumnName("SupplierDONumber")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Vindex).HasDefaultValueSql("((0))");

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<VoucherGeneralInfoBk21>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.ToTable("VoucherGeneralInfo_bk_21");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.BankAccId).HasColumnName("BankAccID");

                entity.Property(e => e.Billdate).HasColumnType("smalldatetime");

                entity.Property(e => e.Billno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ConversionRate).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dcdate)
                    .HasColumnName("DCDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(24, 4)");

                entity.Property(e => e.ExciseDuty).HasColumnType("decimal(25, 0)");

                entity.Property(e => e.Grndate)
                    .HasColumnName("GRNDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gross).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InTax).HasColumnType("decimal(24, 5)");

                entity.Property(e => e.InvoiceEffect).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Lcid).HasColumnName("LCID");

                entity.Property(e => e.Lcnumber)
                    .HasColumnName("LCNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Net).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.Podate)
                    .HasColumnName("PODate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierDonumber)
                    .HasColumnName("SupplierDONumber")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<VoucherLog>(entity =>
            {
                entity.ToTable("Voucher_log");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CoomentsDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            });

            modelBuilder.Entity<VoucherParameters>(entity =>
            {
                entity.HasKey(e=>e.VoucherType);

                entity.Property(e => e.EntryType)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Treatment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.VoucherTypeNavigation)
                    .WithMany(p => p.VoucherParameters)
                    .HasForeignKey(d => d.VoucherType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoucherParameters_VoucherType_setup");
            });

            modelBuilder.Entity<VoucherReversalVoucherAssociation>(entity =>
            {
                entity.HasKey(e => new { e.VoucherId, e.ReversalVoucherId });

                entity.ToTable("Voucher_ReversalVoucher_Association");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

                entity.Property(e => e.ReversalVoucherId).HasColumnName("ReversalVoucherID");

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<VoucherSumforTb>(entity =>
            {
                entity.HasKey(e=>e.Voucherid);

                entity.ToTable("VoucherSumforTB");

                entity.Property(e => e.AmountSum).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Voucherid)
                    .HasColumnName("voucherid")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<VoucherTempXml>(entity =>
            {
                entity.HasKey(e=>e.TempXmlId);

                entity.ToTable("VoucherTemp_XML");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.TempXmlId)
                    .HasColumnName("Temp_XML_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherXml)
                    .HasColumnName("Voucher_XML")
                    .HasMaxLength(5000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VoucherTypeSetup>(entity =>
            {
                entity.ToTable("VoucherType_setup");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VoucherType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Voucheracb>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.ToTable("voucheracb");

                entity.Property(e => e.AmtInDoller).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AuthorizeDate).HasColumnType("datetime");

                entity.Property(e => e.AuthorizedBy).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.CheckedBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Crate)
                    .HasColumnName("CRate")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeletedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeletionDate).HasColumnType("datetime");

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PaymentTerm)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrepareDate).HasColumnType("datetime");

                entity.Property(e => e.PreparedBy).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Rdate)
                    .HasColumnName("RDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Vdate)
                    .HasColumnName("VDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.VoucherDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Voucherdetail>(entity =>
            {
                entity.HasKey(e=>e.Vid);

                entity.ToTable("voucherdetail");

                entity.HasIndex(e => e.VoucherId)
                    .HasName("voucherDetailIndex");
                    //.ForSqlServerIsClustered();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Amount).HasColumnType("decimal(24, 4)");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vid)
                    .HasColumnName("VID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.VoucherId)
                    .HasColumnName("VoucherID")
                    .HasColumnType("numeric(18, 0)");
            });

  

            modelBuilder.Entity<WorkCenters>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<WorkInProgressCb>(entity =>
            {
                entity.HasKey(e=>e.Id);

                entity.ToTable("WorkInProgress_CB");

                entity.Property(e => e.DateOfCb)
                    .HasColumnName("DateOfCB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();
            });

 
        }
 

    }
}
