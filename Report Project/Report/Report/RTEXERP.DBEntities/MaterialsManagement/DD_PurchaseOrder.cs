using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
   public class DD_PurchaseOrder
    {
        public DD_PurchaseOrder()
        {
            DD_POItemMaster = new List<DD_POItemMaster>();
        }
        public long ID { get; set; }
        public string PurchaseOrderNo { get; set; }
        public int SigningAuthorityID { get; set; }
        public int SupplierID { get; set; }
        public int? ContactPersonID { get; set; }
        public string SpecialComments { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Status { get; set; }
        public int? UserID { get; set; }
        public int? ParentPOID { get; set; }
        public int? VersionNo { get; set; }
        public int? OriginalPOID { get; set; }
        public int? RevisionReasonID { get; set; }
        public int? PriceSelection { get; set; }
        public int? LocationSelection { get; set; }
        public int? DeliveryDateSelection { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public int Consolidate { get; set; }
        public int? PaymentTermDays { get; set; }
        public string PaymentSubTerm { get; set; }
        public int? IsImported { get; set; }
        public int? NoOfDays { get; set; }
        public int? IsIndReq { get; set; }
        public long? CompanyID { get; set; }
        public long? BusinessID { get; set; }
        public int? LCM_ID { get; set; }
        public int? advance_percentage { get; set; }

        public List<DD_POItemMaster> DD_POItemMaster { get; set; }
    }
}
