using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO.VoucherConfiguration
{
    public class BankPaymentVoucherViewModel
    {
        public int CompanyID { get; set; }
        public int BusinessID { get; set; }
        public int LocationID { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyID { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Description { get; set; }
        public int PaymentTypeID { get; set; }
        public string PaidTo { get; set; }
        public decimal LedgerBalance  { get; set; }
        public int DebitAccountID { get; set; }
        public int DebitCostCenterID { get; set; }
        public int DebitActivityID { get; set; }
        public string BankAccount { get; set; }
        public int CreditAccountID { get; set; }
        public int CreditCostCenterID { get; set; }
        public int CreaditActivityID { get; set; }
        public int DiscountAccID { get; set; }
        public int InstrumentTypeID { get; set; }
        public string InstrumentNo { get; set; }
        public string ChequeNarration { get; set; }
        public Date ChequeDate { get; set; }
        public int SignatoryID { get; set; }
        public decimal VATPercentage { get; set; }
        public decimal VATAmount { get; set; }
        public int VATAccountID { get; set; }
        public decimal ITaxPercentage { get; set; }
        public decimal ITaxAmount { get; set; }
        public int ITaxAccountID { get; set; }
        public int ExportInvoiceTypeID { get; set; }
        public List<SelectListItem> ExportInvoiceTypeList { get; set; }
        public List<SelectListItem> CompanyList { get; set; }
        public List<SelectListItem> BusinessList { get; set; }
        public List<SelectListItem> LocationList { get; set; }
        public List<SelectListItem> CurrencyList { get; set; }
        public List<SelectListItem> PaymentTypeList { get; set; }
        public List<SelectListItem> CostCenterList { get; set; }
        public List<SelectListItem> ActivityList { get; set; }
        public List<SelectListItem> DiscountAccList { get; set; }
        public List<SelectListItem> InstrumentTypeList { get; set; }
        public List<SelectListItem> SignatoryList { get; set; }
        public List<SelectListItem> VATAccountList { get; set; }
        public List<SelectListItem> ITaxAccountList { get; set; }

    }
}
