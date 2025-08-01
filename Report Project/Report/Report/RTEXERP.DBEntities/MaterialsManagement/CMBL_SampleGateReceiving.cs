using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class CMBL_SampleGateReceiving
    {
        public CMBL_SampleGateReceiving()
        {
            CMBL_SampleItemGateReceiving = new HashSet<CMBL_SampleItemGateReceiving>();
        }
        [Key]
        public int SampleRecID { get; set; }
        public DateTime DocumentDate { get; set; }
        public long SupplierID { get; set; }
        //[ForeignKey("CMBL_Sample")]
        public long SampleID { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string Deleted { get; set; }
        public long? SampleRecNo { get; set; }
        public string DeliveryChallano { get; set; }
        public DateTime? DeliveryChallanDate { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNumber { get; set; }
        public ICollection<CMBL_SampleItemGateReceiving> CMBL_SampleItemGateReceiving { get; set; }

    }
}
