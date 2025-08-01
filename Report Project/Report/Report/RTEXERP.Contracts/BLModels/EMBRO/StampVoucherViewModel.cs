using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
   public class StampVoucherViewModel
    {
        public StampVoucherViewModel()
        {
            voucherDetail = new List<StampVoucherdetailViewModel>();
            VoucherGeneralInfo = new List<StampVoucherGeneralInfoViewModel>();
            VoucherCreditInformation = new VoucherCreditInformation();
        }
        public decimal Id { get; set; }
        public string VoucherNumber { get; set; }
        public int? VoucherType { get; set; }
        [Display(Name = "Date")]
        public DateTime? Vdate { get; set; }
        public string VdateStr { get { return Vdate?.ToString("dd-MMM-yyyy"); } }
        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
        [Display(Name= "Rate")]
        public decimal ExchangeRate { get; set; }
        [Display(Name = "Business")]
        public int BusinessId { get; set; }
        public decimal? PreparedBy { get; set; }
        public decimal? CheckedBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? IndividualVoucherId { get; set; }
        [Display(Name = "Description")]
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

        public int LocationId { get; set; }
        public IEnumerable<SelectListItem>  DDLCompany { get; set; }
        public IEnumerable<SelectListItem> DDLBusiness { get; set; }
        public IEnumerable<SelectListItem> DDLCurrencyList { get; set; }
        public IEnumerable<SelectListItem> DDLLocation { get; set; }
        public IEnumerable<SelectListItem> DDLCostCenter { get; set; }
        public IEnumerable<SelectListItem> DDLActivity { get; set; }
        public List<StampVoucherdetailViewModel> voucherDetail { get; set; }
        public List<StampVoucherGeneralInfoViewModel> VoucherGeneralInfo { get; set; }
        public VoucherCreditInformation VoucherCreditInformation { get; set; }
    }
}
