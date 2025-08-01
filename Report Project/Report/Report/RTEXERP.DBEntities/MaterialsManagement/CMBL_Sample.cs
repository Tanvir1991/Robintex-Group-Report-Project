using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class CMBL_Sample
    {
        public CMBL_Sample()
        {
            CMBL_SampleItem = new HashSet<CMBL_SampleItem>();
            //CMBL_SampleReceiving = new CMBL_SampleReceiving();
        }
        [Key]
        public long SampleID { get; set; }
        public long SampleNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ApproxDeliveryDate { get; set; }
        public int UserID { get; set; }
        public int? SupplierID { get; set; }
        public string SampleComments { get; set; }
        public int? CompanyID { get; set; }
        public int? ApprovedBy { get; set; }
        public string MainComments { get; set; }
        public decimal TotalValue { get; set; }
        public int? LocationSelStatus { get; set; }
        public int? DateSelStatus { get; set; }
        public int? PriceSelStatus { get; set; }
        public int SampleStatus { get; set; }
        public virtual ICollection<CMBL_SampleItem> CMBL_SampleItem { get; set; }
        //public virtual CMBL_SampleGateReceiving CMBL_SampleReceiving { get; set; }

    }
}
