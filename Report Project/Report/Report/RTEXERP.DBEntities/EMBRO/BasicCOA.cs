using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class BasicCoa
    {
        public BasicCoa()
        {
            ApmSupplierPaymentTerms = new HashSet<ApmSupplierPaymentTerms>();
            ApmTaxationSetup = new HashSet<ApmTaxationSetup>();
            BankRecGeneralInfo = new HashSet<BankRecGeneralInfo>();
            CbmActype = new HashSet<CbmActype>();
            CbmBaccountFacility = new HashSet<CbmBaccountFacility>();
            CbmBank = new HashSet<CbmBank>();
            CbmBankAccountSetupBaccount = new HashSet<CbmBankAccountSetup>();
            CbmBankAccountSetupType = new HashSet<CbmBankAccountSetup>();
            CbmFinFacility = new HashSet<CbmFinFacility>();
            CostCenterLocation = new HashSet<CostCenterLocation>();
            InventoryInformation = new HashSet<InventoryInformation>();
            StoresInformation = new HashSet<StoresInformation>();
            ValuationClass = new HashSet<ValuationClass>();
        }

        public decimal Id { get; set; }
        public string Description { get; set; }
        public string AccountCode { get; set; }
        public int? ParentId { get; set; }
        public int LevelId { get; set; }
        public byte Status { get; set; }//int //
        public DateTime Rdate { get; set; }
        public long? NaturalAccountId { get; set; }

        public virtual CompanyInfo CompanyInfo { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<ApmSupplierPaymentTerms> ApmSupplierPaymentTerms { get; set; }
        public virtual ICollection<ApmTaxationSetup> ApmTaxationSetup { get; set; }
        public virtual ICollection<BankRecGeneralInfo> BankRecGeneralInfo { get; set; }
        public virtual ICollection<CbmActype> CbmActype { get; set; }
        public virtual ICollection<CbmBaccountFacility> CbmBaccountFacility { get; set; }
        public virtual ICollection<CbmBank> CbmBank { get; set; }
        public virtual ICollection<CbmBankAccountSetup> CbmBankAccountSetupBaccount { get; set; }
        public virtual ICollection<CbmBankAccountSetup> CbmBankAccountSetupType { get; set; }
        public virtual ICollection<CbmFinFacility> CbmFinFacility { get; set; }
        public virtual ICollection<CostCenterLocation> CostCenterLocation { get; set; }
        public virtual ICollection<InventoryInformation> InventoryInformation { get; set; }
        public virtual ICollection<StoresInformation> StoresInformation { get; set; }
        public virtual ICollection<ValuationClass> ValuationClass { get; set; }
    }
}
