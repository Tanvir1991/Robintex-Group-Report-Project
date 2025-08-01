using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
    public class GetOrderPOListSPModel
    {
        public long POID { get; set; }
        public string PurchaseOrderNo { get; set; }
        public int SigningAuthorityID { get; set; }
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public int? ContactPersonID { get; set; }
        public string SpecialComments { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Status { get; set; }
        public string StatusDescription { get; set; }
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public int? ParentPOID { get; set; }
        public int? VersionNo { get; set; }
        public int? OriginalPOID { get; set; }
        public int? RevisionReasonID { get; set; }
        public int? PriceSelection { get; set; }
        public int? LocationSelection { get; set; }
        public int? DeliveryDateSelection { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public string MName { get; set; }
        public string UNForStatus { get; set; }
        public string DateForStatus { get; set; }
        public int Consolidate { get; set; }
        public int IsImported { get; set; }
        public int IsIndReq { get; set; }

        public string CreationDateSTR { get { return CreationDate.HasValue == true ? this.CreationDate.Value.ToString("dd-MMM-yyyy") : ""; } }
    }
}
