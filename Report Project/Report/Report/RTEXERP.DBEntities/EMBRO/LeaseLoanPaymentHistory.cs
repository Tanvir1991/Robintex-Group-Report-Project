using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class LeaseLoanPaymentHistory
    {
        public int Id { get; set; }
        public int LeaseLoanId { get; set; }
        public string LeaseLoanCode { get; set; }
        public string InstallmentPeriodType { get; set; }
        public int? NoOfinstallments { get; set; }
        public DateTime? FirstInstallmentDate { get; set; }
        public float? TotalLiability { get; set; }
        public float? LeaseRental { get; set; }
        public float? InterestRatepa { get; set; }
        public float? DepositAmnt { get; set; }
        public float? BargainPurchaseValue { get; set; }
        public string IsLeaseOwnershipTransferable { get; set; }
        public string Ltype { get; set; }
        public int? GracePeriod { get; set; }
        public int? LeasorLenderId { get; set; }
        public int? AssetId { get; set; }
        public int? AssetCoaid { get; set; }
        public bool? Isinsurance { get; set; }
        public int? Versionno { get; set; }
        public int? Companyid { get; set; }
        public bool? ContractType { get; set; }
        public string PaymentMode { get; set; }
        public int Status { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Description { get; set; }
        public DateTime? RevisionDate { get; set; }
    }
}
