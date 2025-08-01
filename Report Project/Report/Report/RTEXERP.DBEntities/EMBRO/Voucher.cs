using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Voucher
    {
        public Voucher()
        {
            BankVoucherInfo = new HashSet<BankVoucherInfo>();
            CbmRelateEcfRfpChqVoucher = new HashSet<CbmRelateEcfRfpChqVoucher>();
            CbmVoucherBillToBillPayment = new HashSet<CbmVoucherBillToBillPayment>();
            EsvagentInfo = new HashSet<EsvagentInfo>();
            ExportSalesVoucherInfo = new HashSet<ExportSalesVoucherInfo>();
            JournalVoucherInfo = new HashSet<JournalVoucherInfo>();
            LcvoucherInfo = new HashSet<LcvoucherInfo>();
            LocalSalesCustomerInfo = new HashSet<LocalSalesCustomerInfo>();
            LocalSalesVoucherInfo = new HashSet<LocalSalesVoucherInfo>();
            PurchaseVoucherInfo = new HashSet<PurchaseVoucherInfo>();
            Voucherdetail = new HashSet<Voucherdetail>();
            VoucherGeneralInfo = new HashSet<VoucherGeneralInfo>();
            
        }

        public decimal Id { get; set; }
        public string VoucherNumber { get; set; }
        public int? VoucherType { get; set; }
        public DateTime? Vdate { get; set; }
        public int CompanyId { get; set; }
        public int BusinessId { get; set; }
        public decimal? PreparedBy { get; set; }
        public decimal? CheckedBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? IndividualVoucherId { get; set; }
        public string VoucherDescription { get; set; }
        public decimal? AuthorizedBy { get; set; }
        public DateTime? AuthorizeDate { get; set; }
        public DateTime? PrepareDate { get; set; }
        public int? SystemVoucher { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? ExpiredBy { get; set; }
        public string EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public int? NoOfDays { get; set; }
        public string PaymentTerm { get; set; }
        public int SubVoucherType { get; set; }
        public DateTime Rdate { get; set; }
        public int? StoreId { get; set; }
        public decimal? Crate { get; set; }
        public decimal? AmtInDoller { get; set; }

        public virtual VoucherTypeSetup VoucherTypeNavigation { get; set; }
        public virtual ApmInvoiceDetail ApmInvoiceDetail { get; set; }
        public virtual ICollection<BankVoucherInfo> BankVoucherInfo { get; set; }
        public virtual ICollection<CbmRelateEcfRfpChqVoucher> CbmRelateEcfRfpChqVoucher { get; set; }
        public virtual ICollection<CbmVoucherBillToBillPayment> CbmVoucherBillToBillPayment { get; set; }
        public virtual ICollection<EsvagentInfo> EsvagentInfo { get; set; }
        public virtual ICollection<ExportSalesVoucherInfo> ExportSalesVoucherInfo { get; set; }
        public virtual ICollection<JournalVoucherInfo> JournalVoucherInfo { get; set; }
        public virtual ICollection<LcvoucherInfo> LcvoucherInfo { get; set; }
        public virtual ICollection<LocalSalesCustomerInfo> LocalSalesCustomerInfo { get; set; }
        public virtual ICollection<LocalSalesVoucherInfo> LocalSalesVoucherInfo { get; set; }
        public virtual ICollection<PurchaseVoucherInfo> PurchaseVoucherInfo { get; set; }
        public virtual ICollection<Voucherdetail> Voucherdetail { get; set; }
        public virtual ICollection<VoucherGeneralInfo> VoucherGeneralInfo { get; set; }

    }
}
