using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO.VoucherModel
{
   public class VoucherReportsViewModel
    {
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        [Display(Name = "Voucher Type")]
        public int VoucherTypeID { get; set; }
        [Display(Name = "Voucher Number")]
        public int VoucherID { get; set; }
        [Display(Name ="Vat Percent")]
        public decimal VatPercent { get; set; }
        [Display(Name = "Income Tax Percent")]
        public decimal IncomeTaxPercent { get; set; }
        [Display(Name ="Voucher Category")]
        public string VoucherCategory { get; set; }
        public string ChequePercentageSTR { get; set; }
        public List<SelectListItem> CompanyList { get; set; }
        public List<SelectListItem> VoucherList { get; set; }
        public List<SelectListItem> YearList { get; set; }
        public List<SelectListItem> MonthList { get; set; }
        public List<SelectListItem> VoucherTypeList { get; set; }
        public List<SelectListItem> DDLVoucherCategory { get; set; }

    }
}
