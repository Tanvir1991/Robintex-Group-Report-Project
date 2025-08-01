using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
    public class DD_PO_PurchaseOrderInfoSPModel
    {
        public long ID { get; set; }
        public string PurchaseOrderNo { get; set; }
        public DateTime PODate { get; set; }
        public string LCNO { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public string BuyerName { get; set; }
        public int NumberOfGarments { get; set; }
        public double POAmount { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyShortName { get; set; }
        public string CurrencyName { get; set; }
        public int CompanyID { get; set; }
        public string Companyname { get; set; }
        public string CompanyAddress { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanySTN { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierMobileNo { get; set; }
        public string SupplierFax { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }

        public string PODateSTR { get { return PODate.ToString("dd-MMM-yyyy"); } }
    }
}
