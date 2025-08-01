using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
    public class BankChequeViewModel
    {

        [Display(Name ="Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Bank")]
        public int BankID { get; set; }
        [Display(Name = "Branch")]
        public int BranchID { get; set; }
        [Display(Name = "Chart Of Accounts")]
        public int AccountID { get; set; }
        [Display(Name = "Cheque Number")]
        public string ChequeNumber { get; set; }
        [Display(Name = "Cheque Number")]
        public int ChequeID { get; set; }
        
        public decimal ChequePercentage { get; set; }
        [Display(Name = "Income Tax & Vat percent")]
        public string ChequePercentageSTR { get; set; }
        public int AltAccounts { get; set; }

        [Display(Name = "Vat Percent")]
        public decimal VatPercent { get; set; }
        [Display(Name = "Income Tax Percent")]
        public decimal IncomeTaxPercent { get; set; }
        [Display(Name = "Voucher Category")]
        public string VoucherCategory { get; set; }

        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLBank { get; set; }
        public List<SelectListItem> DDLBranch { get; set; }
        public List<SelectListItem> DDLCheque { get; set; }

        public List<SelectListItem>DDLBankChartOfAccounts { get; set; }
        public List<SelectListItem> DDLBankALTChartOfAccounts { get; set; }
        public List<SelectListItem> DDLVoucherCategory { get; set; }
    }
}
