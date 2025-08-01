using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class FixedAsset
    {
        public FixedAsset()
        {
            LeaseAssetsContractWise = new HashSet<LeaseAssetsContractWise>();
        }

        public int AssetId { get; set; }
        public string AssetCode { get; set; }
        public int AssetCoaid { get; set; }
        public int FixedAssetClassId { get; set; }
        public string Description { get; set; }
        public int? UsefulLifeUnits { get; set; }
        public int? UsefulLifeQtty { get; set; }
        public string PrimarySpecs { get; set; }
        public string SecondarySpecs { get; set; }
        public int? VendorId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal? ImportDuties { get; set; }
        public decimal? InstallationCost { get; set; }
        public decimal? SitePreparationCost { get; set; }
        public decimal? InitialDeliveryCost { get; set; }
        public decimal? ProfessionalFees { get; set; }
        public decimal? DismantlingCost { get; set; }
        public decimal? DirectlyAttributedCost { get; set; }
        public decimal? TradeDiscount { get; set; }
        public decimal? Rebates { get; set; }
        public decimal? OriginalCost { get; set; }
        public decimal? CostOfAcquisition { get; set; }
        public decimal? WrittenDownValue { get; set; }
        public decimal? BookValue { get; set; }
        public int? CostCenterId { get; set; }
        public int? WorkCenterId { get; set; }
        public DateTime DateofAcquisition { get; set; }
        public decimal? AccumulatedDepriciation { get; set; }
        public decimal? ResidualValue { get; set; }
        public string IntendedUse { get; set; }
        public int? PaymentMode { get; set; }
        public bool? ValuationNature { get; set; }
        public bool? ValuationBasis { get; set; }
        public bool? ValuationMovement { get; set; }
        public short? ValuationFrequency { get; set; }
        public DateTime? DisposalDate { get; set; }
        public decimal? DisposalAmount { get; set; }
        public string DisposalMode { get; set; }
        public string DisposalRecieptMode { get; set; }
        public string DisposalBuyerName { get; set; }
        public string DisposalBuyerAddress { get; set; }
        public string DisposalBuyerPhone { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int? LocationId { get; set; }
        public int? ActivityId { get; set; }
        public int? SubActivityId { get; set; }
        public int? CompanyId { get; set; }
        public int? CategoryId { get; set; }
        public int? TypeId { get; set; }
        public int? PaymentId { get; set; }
        public double? InputTaxes { get; set; }
        public DateTime? BillOfEntryDate { get; set; }
        public string ImportCurrency { get; set; }
        public decimal? ImportAmount { get; set; }
        public int? InputTaxAccount { get; set; }
        public int? SourceCostCenter { get; set; }
        public int? SourceActivity { get; set; }
        public string YearofManufacturing { get; set; }
        public string Comments { get; set; }
        public string InvoiceNumber { get; set; }
        public string PorefNumber { get; set; }
        public int? VoucherId { get; set; }
        public int? BusinessId { get; set; }
        public string BarCode { get; set; }
        public string DisposalBuyerNic { get; set; }
        public string DisposalRefNumber { get; set; }
        public string DisposalBuyerType { get; set; }
        public decimal? DisposalAdditionalSalesTaxRate { get; set; }
        public decimal? DisposalSalesTaxRate { get; set; }
        public string DisposalBuyerStaxNum { get; set; }
        public string DisposalBillNumber { get; set; }
        public int? DisposalBuyerIdent { get; set; }
        public string ThirdPartyAsset { get; set; }
        public decimal? OverhaulPeriod { get; set; }
        public string DepreciationType { get; set; }
        public DateTime? AllocationDate { get; set; }
        public long? DispVoucherid { get; set; }
        public DateTime? ImpairmentDate { get; set; }
        public decimal? ImpairmentAmount { get; set; }
        public int? TransferStatus { get; set; }
        public DateTime? TransferDate { get; set; }
        public int Bcoccurence { get; set; }
        public int? TransferVoucherId { get; set; }
        public DateTime Rdate { get; set; }
        public double? InputExciseDuty { get; set; }
        public int? InputExciseDutyAccount { get; set; }
        public int? RelatedAssetId { get; set; }
        public bool? IsAcquired { get; set; }
        public DateTime? AcquisitionTransferDate { get; set; }

        public virtual FixedAssetClass FixedAssetClass { get; set; }
        public virtual ICollection<LeaseAssetsContractWise> LeaseAssetsContractWise { get; set; }
    }
}
